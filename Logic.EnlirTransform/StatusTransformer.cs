using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class StatusTransformer : RowTransformerBase<StatusRow, Status>
    {
        #region Class Variables
        private readonly IntConverter _intConverter;
        private readonly DoubleConverter _doubleConverter;
        private readonly PercentConverter _percentConverter;

        #endregion

        #region Constants
        private readonly char[] PlusMinusCharArray = "±".ToCharArray();
        #endregion

        public StatusTransformer(ILogger<RowTransformerBase<StatusRow, Status>> logger) : base(logger)
        {
            _doubleConverter = new DoubleConverter();
            _intConverter = new IntConverter();
            _percentConverter = new PercentConverter();
           
        }

        protected override Status ConvertRowToModel(int generatedId, StatusRow row)
        {
            Status model = new Status();

            model.Id = generatedId;
            model.Description = row.CommonName;

            model.StatusId = _intConverter.ConvertFromStringToInt(row.ID);
            model.CommonName = row.CommonName;
            model.Effects = row.Effects;
            model.DefaultDuration = _intConverter.ConvertFromStringToInt(row.DefaultDuration);
            model.MindModifier = _percentConverter.ConvertFromStringToDouble(row.MindModifier.TrimStart(PlusMinusCharArray));
            model.ExclusiveStatuses = ConvertCommaSeparatedStringToList(row.ExclusiveStatus);
            model.CodedName = row.CodedName;
            model.Notes = row.Notes.Replace(DashCharacter, String.Empty);

            _logger.LogInformation("Converted StatusRow to Status: {Id} - {Description}", model.Id, model.Description);

            return model;
        }
    }
}
