using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class MissionTransformer : RowTransformerBase<MissionRow, Mission>
    {
        #region Class Variables
        private readonly TypeListConverter _missionTypeConverter;
        #endregion

        #region Constructors
        public MissionTransformer(ILogger<RowTransformerBase<MissionRow, Mission>> logger): base(logger)
        {
            _missionTypeConverter = new TypeListConverter(new MissionTypeList());
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override Mission ConvertRowToModel(int generatedId, MissionRow row)
        {
            Mission model = new Mission();

            model.Id = generatedId;
            model.Description = row.Description;

            model.MissionType = _missionTypeConverter.ConvertFromNameToId(row.Type);
            model.AssociatedEvent = row.Event;
            model.AssociatedEventId = 0; //Fill in during Merge Phase

            model.Rewards = ExtractItemWithCountAndStarLevel(row.Reward);

            _logger.LogDebug("Converted MissionRow to Mission: {Id} - {Description}", model.Id, model.Description);

            return model;
        } 
        #endregion
    }
}
