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
    public class BraveActionTransformer : RowTransformerBase<BraveActionRow, BraveAction>
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

        #region Constructors
        public BraveActionTransformer(ILogger<RowTransformerBase<BraveActionRow, BraveAction>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _intConverter = new IntConverter();
            _doubleConverter = new DoubleConverter();
            _stringToBooleanConverter = new StringToBooleanConverter();
            _abilityTypeConverter = new TypeListConverter(new AbilityTypeList());
            _targetTypeConverter = new TypeListConverter(new TargetTypeList());
            _autoTargetTypeConverter = new TypeListConverter(new AutoTargetTypeList());
            _damageFormulaTypeConverter = new TypeListConverter(new DamageFormulaTypeList());
            _elementConverter = new TypeListConverter(new ElementList());
            _schoolConverter = new TypeListConverter(new SchoolList());
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override BraveAction ConvertRowToModel(int generatedId, BraveActionRow row)
        {
            BraveAction model = new BraveAction();

            model.Id = generatedId;
            model.Description = $"{row.Source} - {row.BraveName} - {row.BraveLevel}";

            model.BraveActionName = row.BraveName;
            model.BraveLevel = _intConverter.ConvertFromStringToInt(row.BraveLevel);
            model.JapaneseName = row.JapaneseName;

            model.CharacterName = row.Character;
            model.CharacterId = 0; //fill in during merge phase

            model.SourceSoulBreakName = row.Source;
            model.SourceSoulBreakId = 0; //fill in during merge phase

            model.ImagePath = row.ImagePath;

            model.AbilityType = _abilityTypeConverter.ConvertFromNameToId(row.Type);
            model.TargetType = _targetTypeConverter.ConvertFromNameToId(row.Target);
            model.AutoTargetType = _autoTargetTypeConverter.ConvertFromNameToId(row.AutoTarget);
            model.DamageFormulaType = _damageFormulaTypeConverter.ConvertFromNameToId(row.Formula);
            model.Multiplier = _doubleConverter.ConvertFromStringToDouble(row.Multiplier);
            model.Elements = _elementConverter.ConvertFromCommaSeparatedListToIds(row.Element);
            model.CastTime = _doubleConverter.ConvertFromStringToDouble(row.Time);
            model.Effects = row.Effects;
            model.IsCounterable = _stringToBooleanConverter.ConvertFromStringToBool(row.Counter);
            model.EnlirId = row.ID;
            model.IsInGlobal = _stringToBooleanConverter.ConvertFromStringToBool(row.IsInGlobal);
            model.IsChecked = _stringToBooleanConverter.ConvertFromStringToBool(row.Checked);
            model.SoulBreakPointsGained = _intConverter.ConvertFromStringToInt(row.SB);
            model.School = _schoolConverter.ConvertFromNameToId(row.School);
            model.BraveCondition = row.BraveCondition;

            _logger.LogDebug("Converted BraveActionRow to BraveAction: {Id} - {Description}", model.Id, model.Description);

            return model;
        } 
        #endregion
    }
}
