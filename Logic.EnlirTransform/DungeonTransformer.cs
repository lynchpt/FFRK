using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class DungeonTransformer : RowTransformerBase<DungeonRow, Dungeon>
    {
        #region Class Variables
        private readonly IntConverter _intConverter;
        private readonly TypeListConverter _realmConverter;
        #endregion

        #region Constants

        private readonly char[] GilCharArray = "G".ToCharArray();
        #endregion

        #region Constructors
        public DungeonTransformer(ILogger<RowTransformerBase<DungeonRow, Dungeon>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _intConverter = new IntConverter();
            _realmConverter = new TypeListConverter(new RealmList());
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override Dungeon ConvertRowToModel(int generatedId, DungeonRow row)
        {
            Dungeon model = new Dungeon();

            //IModelDescriptor
            model.Id = generatedId;
            model.Description = row.DungeonName;

            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);
            model.DungeonName = row.DungeonName;
            model.IntroducingDungeonUpdateId = 0; //fill in during merge stage

            //classic
            model.StaminaClassic = _intConverter.ConvertFromStringToInt(row.StaminaClassic);
            model.DifficultyClassic = _intConverter.ConvertFromStringToInt(row.DifficultyClassic);
            model.CompletionGilClassic = _intConverter.ConvertFromStringToInt(row.CompletionClassic.TrimEnd(GilCharArray));
            model.FirstTimeRewardsClassic = ExtractItemWithCountAndStarLevel(row.FirstTimeClassic);
            model.MasteryRewardsClassic = ExtractItemWithCountAndStarLevel(row.MasteryClassic);

            //elite
            model.StaminaElite = _intConverter.ConvertFromStringToInt(row.StaminaElite);
            model.DifficultyElite = _intConverter.ConvertFromStringToInt(row.DifficultyElite);
            model.CompletionGilElite = _intConverter.ConvertFromStringToInt(row.CompletionElite.TrimEnd(GilCharArray));
            model.FirstTimeRewardsElite = ExtractItemWithCountAndStarLevel(row.FirstTimeElite);
            model.MasteryRewardsElite = ExtractItemWithCountAndStarLevel(row.MasteryElite);

            _logger.LogInformation("Converted DungeonRow to Dungeon: {Id} - {Description}", model.Id, model.Description);

            return model;
        }
        #endregion

        #region Private Methods

      
        #endregion
    }
}
