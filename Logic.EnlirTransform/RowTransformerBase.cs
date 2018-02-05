using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FFRKApi.Logic.EnlirTransform
{
    public abstract class RowTransformerBase<TRow, TModel> : IRowTransformer<TRow, TModel> where TRow : class
                                                       where TModel : class, new()
    {
        #region Class Variables

        protected readonly ILogger<RowTransformerBase<TRow, TModel>> _logger;

        #endregion

        #region Constants

        protected const string CountCharacter = "x";
        protected const string CommaCharacter = ",";
        protected const string StarCharacter = "★";
        protected const string DashCharacter = "-";
        protected const string RewardAndToken = " and ";
        protected const string Comma = ",";
        protected const string CommaWithSpace = ", ";
        protected const string Space = " ";
        #endregion

        #region Constructors

        public RowTransformerBase(ILogger<RowTransformerBase<TRow, TModel>> logger)
        {
            _logger = logger;
        }
        #endregion



        #region IRowTransformer Implementation
        public virtual IEnumerable<TModel> Transform(IEnumerable<TRow> importedRows)
        {
            _logger.LogInformation("Transform invoked and attempting to transform imported Rows for {ImportRowType}", typeof(TRow).Name);

            IList<TModel> models = new List<TModel>();
       
            int generatedId = 1; 

            foreach (TRow row in importedRows)
            {
                TModel model = ConvertRowToModel(generatedId, row);

                generatedId++;

                models.Add(model);
            }

            return models;
        }

        #endregion

        #region Protected Abstract Methods

        protected abstract TModel ConvertRowToModel(int generatedId, TRow row);

        #endregion

        #region Protected Conversion Methods

        protected IList<string> ConvertCommaSeparatedStringToList(string input)
        {
            IList<string> results = new List<string>();

            if (!String.IsNullOrWhiteSpace(input))
            {
                results = input.Split(new string[] { CommaCharacter }, StringSplitOptions.None).Select(s => s.Trim()).ToList();
            }

            return results;
        }

        protected ItemWithItemCount ExtractItemWithItemCount(string input)
        {
            ItemWithItemCount result = new ItemWithItemCount();

            int xPosition = input.LastIndexOf(CountCharacter);

            if (xPosition == -1) //there is no count
            {
                result.ItemName = input.Trim();
                result.ItemCount = 0;
            }
            else //the count number will be the string after the "x", turned into a number. the item name is the part before the x
            {
                string preCountSection = input.Remove(xPosition);

                string postCountSection = input.Substring(xPosition + 1);
                int itemCount = Convert.ToInt32(postCountSection);

                result.ItemName = preCountSection.Trim();
                result.ItemCount = itemCount;
            }

            return result;
        }

        protected ItemWithStarLevel ExtractItemWithStarLevel(string input)
        {
            ItemWithStarLevel result = new ItemWithStarLevel();

            int starPosition = input.IndexOf(StarCharacter);

            if (starPosition == -1) //there is no star
            {
                result.ItemName = input.Trim();
                result.ItemStarLevel = 0;
            }
            else
            {
                //the star level will be the character right before the star, turned into a number
                if (starPosition > 0)
                {
                    result.ItemStarLevel = Convert.ToInt32(input[starPosition - 1].ToString());

                    //now we need to get the item name which needs the star, level and any surrounding parentheses stripped out
                    if (input[starPosition - 2].ToString() == "(")
                    {
                        result.ItemName = input.Remove(starPosition - 2).Trim();
                    }
                    else
                    {
                        result.ItemName = input.Remove(starPosition - 1).Trim();
                    }

                }
                else //star is first char, so star level is 0
                {
                    result.ItemName = input.Trim();
                    result.ItemStarLevel = 0;
                }
            }

            return result;
        }

        protected IEnumerable<ItemWithCountAndStarLevel> ExtractItemWithCountAndStarLevel(string input)
        {
            List<ItemWithCountAndStarLevel> iwcaslList = new List<ItemWithCountAndStarLevel>();


            try
            {
                //see if we need to jump out to the more complex multi item, single count reward parsing
                if(input.Contains(RewardAndToken))
                {
                    int andIndex = input.IndexOf(RewardAndToken);
                    string lastPhrase = input.Substring(andIndex + 5);
                    string[] lastPhraseParts = lastPhrase.Split(Space.ToCharArray());
                    string firstWordOfLastPhrase = lastPhraseParts[0];
                    string rewardPartOfLastPhrase = lastPhrase.Replace(firstWordOfLastPhrase, String.Empty).Trim();

                    string inputAndReplaced = input.Replace(RewardAndToken, CommaWithSpace);

                    string inputRewardRemoved = inputAndReplaced.Replace(rewardPartOfLastPhrase, String.Empty).Trim();

                    string[] rewardTypes = inputRewardRemoved.Split(Comma.ToCharArray());

                    string[] rewardTypesAndCounts = rewardTypes.Select(r => $"{r} {rewardPartOfLastPhrase}").ToArray();
                    string convertedInput = String.Join(CommaWithSpace, rewardTypesAndCounts);

                    input = convertedInput;
                }

                //turn reward string into a list, if needed
                    IList<string> rewardStrings = ConvertCommaSeparatedStringToList(input);

                //for each reward, turn it into an item name and a count
                IList<ItemWithItemCount> rewardItemsWithItemCounts = new List<ItemWithItemCount>();

                foreach (var rewardString in rewardStrings)
                {
                    ItemWithItemCount itemWithItemCount = ExtractItemWithItemCount(rewardString);
                    rewardItemsWithItemCounts.Add(itemWithItemCount);
                }

                //now for each reward item, extract the star level if applicable
                foreach (ItemWithItemCount iwc in rewardItemsWithItemCounts)
                {
                    ItemWithCountAndStarLevel iwcasl = new ItemWithCountAndStarLevel();

                    ItemWithStarLevel iwsl = ExtractItemWithStarLevel(iwc.ItemName);

                    iwcasl.ItemName = iwsl.ItemName;
                    iwcasl.ItemCount = iwc.ItemCount > 0 ? iwc.ItemCount : !String.IsNullOrWhiteSpace(iwsl.ItemName) ? 1 : 0;
                    iwcasl.ItemStarLevel = iwsl.ItemStarLevel;

                    iwcaslList.Add(iwcasl);
                }
            }
            catch (Exception ex)
            {

                _logger.LogWarning("ItemWithCountAndStarLevel String {iwcaslString} could not be parsed; {Message}", input, ex.Message);
            }

            return iwcaslList;
        }


        #endregion


    }
}
