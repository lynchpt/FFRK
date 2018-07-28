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
    public class OtherTransformer : RowTransformerBase<OtherRow, Other>
    {
        #region Class Variables
        private readonly IntConverter _intConverter;
        private readonly DoubleConverter _doubleConverter;
        private readonly StringToBooleanConverter _stringToBooleanConverter;

        private readonly TypeListConverter _abilityTypeConverter;
        private readonly TypeListConverter _targetTypeConverter;
        private readonly TypeListConverter _autoTargetTypeConverter;
        private readonly TypeListConverter _damageFormulaTypeConverter;
        private readonly TypeListConverter _elementConverter;
        private readonly TypeListConverter _schoolConverter;
        #endregion

        public OtherTransformer(ILogger<RowTransformerBase<OtherRow, Other>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _doubleConverter = new DoubleConverter();
            _intConverter = new IntConverter();
            _stringToBooleanConverter = new StringToBooleanConverter();
            _abilityTypeConverter = new TypeListConverter(new AbilityTypeList());
            _targetTypeConverter = new TypeListConverter(new TargetTypeList());
            _autoTargetTypeConverter = new TypeListConverter(new AutoTargetTypeList());
            _damageFormulaTypeConverter = new TypeListConverter(new DamageFormulaTypeList());
            _elementConverter = new TypeListConverter(new ElementList());
            _schoolConverter = new TypeListConverter(new SchoolList());
        }

        protected override Other ConvertRowToModel(int generatedId, OtherRow row)
        {
            Other model = new Other();

            model.Id = generatedId;
            model.Description = row.OtherName;

            model.CharacterName = row.Character;
            model.SourceName = row.Source;
            model.SourceType = null; //fill in during merge phase
            model.SourceId = 0; //fill in during merge phase
            model.ImagePath = row.ImagePath;
            model.Name = row.OtherName;

            model.AbilityType = _abilityTypeConverter.ConvertFromNameToId(row.Type);
            model.TargetType = _targetTypeConverter.ConvertFromNameToId(row.Target);
            model.DamageFormulaType = _damageFormulaTypeConverter.ConvertFromNameToId(row.Formula);
            model.Multiplier = _doubleConverter.ConvertFromStringToDouble(row.Multiplier);
            model.Elements = _elementConverter.ConvertFromCommaSeparatedListToIds(row.Element);
            model.CastTime = _doubleConverter.ConvertFromStringToDouble(row.Time);
            model.Effects = row.Effects;
            model.IsCounterable = _stringToBooleanConverter.ConvertFromStringToBool(row.Counter);
            model.AutoTargetType = _autoTargetTypeConverter.ConvertFromNameToId(row.AutoTarget);
            model.SoulBreakPointsGained = _intConverter.ConvertFromStringToInt(row.SB);
            model.School = _schoolConverter.ConvertFromNameToId(row.School);
            model.IsInGlobal = _stringToBooleanConverter.ConvertFromStringToBool(row.IsInGlobal);
            model.IsChecked = _stringToBooleanConverter.ConvertFromStringToBool(row.Checked);

            _logger.LogDebug("Converted OtherRow to Other: {Id} - {Description}", model.Id, model.Description);

            return model;
        }
    }
}
