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
    public class MagiciteSkillTransformer : RowTransformerBase<MagiciteSkillRow, MagiciteSkill>
    {
        #region Class Variables
        private readonly DoubleConverter _doubleConverter;
        private readonly StringToBooleanConverter _stringToBooleanConverter;
        private readonly PercentConverter _percentConverter;
        private readonly TypeListConverter _abilityTypeConverter;
        private readonly TypeListConverter _autoTargetTypeConverter;
        private readonly TypeListConverter _damageFormulaTypeConverter;
        private readonly TypeListConverter _elementConverter;

        #endregion

        #region Constructors
        public MagiciteSkillTransformer(ILogger<RowTransformerBase<MagiciteSkillRow, MagiciteSkill>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _doubleConverter = new DoubleConverter();
            _stringToBooleanConverter = new StringToBooleanConverter();
            _percentConverter = new PercentConverter();
            _abilityTypeConverter = new TypeListConverter(new AbilityTypeList());
            _autoTargetTypeConverter = new TypeListConverter(new AutoTargetTypeList());
            _damageFormulaTypeConverter = new TypeListConverter(new DamageFormulaTypeList());
            _elementConverter = new TypeListConverter(new ElementList());

        }
        #endregion

        #region RowTransformerBase Overrides
        protected override MagiciteSkill ConvertRowToModel(int generatedId, MagiciteSkillRow row)
        {
            MagiciteSkill model = new MagiciteSkill();

            model.Id = generatedId;
            model.Description = $"{row.Magicite} - {row.Name}";

            model.MagiciteName = row.Magicite;
            model.MagiciteId = 0; //fill in during merge phase
            model.SkillName = row.Name;
            model.JapaneseName = row.JapaneseName;
            model.ImagePath = row.ImagePath;
            model.AbilityType = _abilityTypeConverter.ConvertFromNameToId(row.Type);
            model.AutoTargetType = _autoTargetTypeConverter.ConvertFromNameToId(row.AutoTarget);
            model.DamageFormulaType = _damageFormulaTypeConverter.ConvertFromNameToId(row.Formula);
            model.Multiplier = _doubleConverter.ConvertFromStringToDouble(row.Multiplier);
            model.Element = _elementConverter.ConvertFromNameToId(row.Element);
            model.CastTime = _doubleConverter.ConvertFromStringToDouble(row.Time);
            model.Effects = row.Effects;
            model.IsCounterable = _stringToBooleanConverter.ConvertFromStringToBool(row.Counter);
            model.IsInGlobal = _stringToBooleanConverter.ConvertFromStringToBool(row.IsInGlobal);
            model.IsChecked = _stringToBooleanConverter.ConvertFromStringToBool(row.Checked);

            model.ChanceForSkillUseWith0LevelCapBreaks = _doubleConverter.ConvertFromStringToDouble(row.ChanceToUseTier0);
            model.ChanceForSkillUseWith1LevelCapBreaks = _doubleConverter.ConvertFromStringToDouble(row.ChanceToUseTier1);
            model.ChanceForSkillUseWith2LevelCapBreaks = _doubleConverter.ConvertFromStringToDouble(row.ChanceToUseTier2);
            model.ChanceForSkillUseWith3LevelCapBreaks = _doubleConverter.ConvertFromStringToDouble(row.ChanceToUseTier3);

            _logger.LogDebug("Converted MagiciteSkillRow to MagiciteSkill: {Id} - {Description}", model.Id, model.Description);

            return model;
        } 
        #endregion
    }
}
