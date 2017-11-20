using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class MissionTransformer : RowTransformerBase<MissionRow, Mission>
    {
        #region Class Variables

        #endregion

        #region Constructors
        public MissionTransformer(ILogger<RowTransformerBase<MissionRow, Mission>> logger): base(logger)
        {
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override Mission ConvertRowToModel(int generatedId, MissionRow row)
        {
            Mission model = new Mission();

            model.Id = generatedId;
            model.Description = row.Description;

            model.MissionType = row.Type;
            model.AssociatedEvent = row.Event;

            //rewards
            var iwcaslList = new List<ItemWithCountAndStarLevel>();

            //turn reward string into a list, if needed
            IList<string> rewardStrings = ConvertCommaSeparatedStringToList(row.Reward);

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
                iwcasl.ItemCount = iwc.ItemCount;
                iwcasl.ItemStarLevel = iwsl.ItemStarLevel;

                iwcaslList.Add(iwcasl);
            }

            model.Rewards = iwcaslList;

            return model;
        } 
        #endregion
    }
}
