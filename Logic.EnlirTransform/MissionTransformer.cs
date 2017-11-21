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

            model.Rewards = ExtractItemWithCountAndStarLevel(row.Reward);

            return model;
        } 
        #endregion
    }
}
