using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class MagiciteTransformer : RowTransformerBase<MagiciteRow, Magicite>
    {
        #region Class Variables

        private readonly IntConverter _intConverter;
        private readonly DoubleConverter _doubleConverter;
        private readonly StringToBooleanConverter _stringToBooleanConverter;
        private readonly TypeListConverter _abilityTypeConverter;
        private readonly TypeListConverter _autoTargetTypeConverter;
        private readonly TypeListConverter _damageFormulaTypeConverter;
        private readonly TypeListConverter _elementConverter;
        private readonly TypeListConverter _realmConverter;
        #endregion

        #region Constants

        private const int MagiciteLevelBands = 9;
        private readonly int[] MagiciteLevelBandBreakpoints = new[] {1, 10, 25, 50, 65, 80, 81, 90, 99};
        #endregion

        #region Constructors
        public MagiciteTransformer(ILogger<RowTransformerBase<MagiciteRow, Magicite>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _intConverter = new IntConverter();
            _doubleConverter = new DoubleConverter();
            _stringToBooleanConverter = new StringToBooleanConverter();
            _abilityTypeConverter = new TypeListConverter(new AbilityTypeList());
            _autoTargetTypeConverter = new TypeListConverter(new AutoTargetTypeList());
            _damageFormulaTypeConverter = new TypeListConverter(new DamageFormulaTypeList());
            _elementConverter = new TypeListConverter(new ElementList());
            _realmConverter = new TypeListConverter(new RealmList());

        }
        #endregion

        #region RowTransformerBase Overrides
        protected override Magicite ConvertRowToModel(int generatedId, MagiciteRow row)
        {
            Magicite model = new Magicite();

            //IModelDescriptor
            model.Id = generatedId;
            model.Description = row.Name;

            //core attributes
            model.MagiciteName = row.Name;
            model.Element = _elementConverter.ConvertFromNameToId(row.Element);
            model.Rarity = _intConverter.ConvertFromStringToInt(row.Rarity);
            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);
            model.ImagePath = row.ImagePath;
            model.IntroducingEventName = row.IntroducingEvent;
            model.IntroducingEventId = 0; //fill in during merge phase

            //stats
            model.HitPoints = _intConverter.ConvertFromStringToInt(row.HP);
            model.Attack = _intConverter.ConvertFromStringToInt(row.ATK);
            model.Defense = _intConverter.ConvertFromStringToInt(row.DEF);
            model.Magic = _intConverter.ConvertFromStringToInt(row.MAG);
            model.Resistance = _intConverter.ConvertFromStringToInt(row.RES);
            model.Mind = _intConverter.ConvertFromStringToInt(row.MND);
            model.Speed = _intConverter.ConvertFromStringToInt(row.SPD);

            //passives
            model.PassiveEffects = GetPassiveEffectsForMagicite(row);

            //ultra skill
            if (row.UltraSkill.Length > 1)
            {
                UltraSkill ultraSkill = new UltraSkill()
                                        {
                                            Name = row.UltraSkill,
                                            JapaneseName = row.JapaneseName,
                                            AbilityType = _abilityTypeConverter.ConvertFromNameToId(row.Type),
                                            AutoTargetType = _autoTargetTypeConverter.ConvertFromNameToId(row.AutoTarget),
                                            DamageFormulaType = _damageFormulaTypeConverter.ConvertFromNameToId(row.Formula),
                                            Multiplier = _doubleConverter.ConvertFromStringToDouble(row.Multiplier),
                                            Element = _elementConverter.ConvertFromNameToId(row.Element),
                                            CastTime = _doubleConverter.ConvertFromStringToDouble(row.Time),
                                            Effects = row.Effects,
                                            IsCounterable = _stringToBooleanConverter.ConvertFromStringToBool(row.Counter),
                                            Cooldown = _doubleConverter.ConvertFromStringToDouble(row.Cooldown),
                                            Duration = _doubleConverter.ConvertFromStringToDouble(row.Duration),
                                            EnlirId = row.ID
                                        };

                model.UltraSkill = ultraSkill;
            }


            //magicite skills
            model.MagiciteSkills = new List<MagiciteSkill>(); //fill in during merge phase            

            _logger.LogInformation("Converted MagiciteRow to Magicite: {Id} - {Description}", model.Id, model.Description);

            return model;
        }
        #endregion

        #region Private Methods

        private IEnumerable<PassiveEffectValueByLevelInfo> GetPassiveEffectsForMagicite(MagiciteRow row)
        {
            List<PassiveEffectValueByLevelInfo> passives = new List<PassiveEffectValueByLevelInfo>();

            //passive 1
            if (!String.IsNullOrWhiteSpace(row.Passive1Name))
            {
                for (int counter = 0; counter < MagiciteLevelBands; counter++)
                {
                    passives.Add(new PassiveEffectValueByLevelInfo()
                                 {
                                     Level = MagiciteLevelBandBreakpoints[counter],
                                     Name = row.Passive1Name,
                                     Value = _intConverter.ConvertFromStringToInt(GetPassiveStrengthByPassiveNumberAndLevel(1, MagiciteLevelBandBreakpoints[counter], row))
                    });
                }
            }

            //passive 2
            if (!String.IsNullOrWhiteSpace(row.Passive2Name))
            {
                for (int counter = 0; counter < MagiciteLevelBands; counter++)
                {
                    passives.Add(new PassiveEffectValueByLevelInfo()
                                 {
                                     Level = MagiciteLevelBandBreakpoints[counter],
                                     Name = row.Passive2Name,
                                     Value = _intConverter.ConvertFromStringToInt(GetPassiveStrengthByPassiveNumberAndLevel(2, MagiciteLevelBandBreakpoints[counter], row))
                                 });
                }
            }

            //passive 3
            if (!String.IsNullOrWhiteSpace(row.Passive3Name))
            {
                for (int counter = 0; counter < MagiciteLevelBands; counter++)
                {
                    passives.Add(new PassiveEffectValueByLevelInfo()
                                 {
                                     Level = MagiciteLevelBandBreakpoints[counter],
                                     Name = row.Passive3Name,
                                     Value = _intConverter.ConvertFromStringToInt(GetPassiveStrengthByPassiveNumberAndLevel(3, MagiciteLevelBandBreakpoints[counter], row))
                                 });
                }
            }
            return passives;
        }

        private string GetPassiveStrengthByPassiveNumberAndLevel(int passiveNumber, int magiciteLevelBandBreakpoint, MagiciteRow row)
        {
            string passiveStrength = String.Empty;

            switch (passiveNumber)
            {
                case 1:
                    switch (magiciteLevelBandBreakpoint)
                    {
                        case 1:
                            passiveStrength = row.Passive1StrengthLevel1;
                            break;
                        case 10:
                            passiveStrength = row.Passive1StrengthLevel10;
                            break;
                        case 25:
                            passiveStrength = row.Passive1StrengthLevel25;
                            break;
                        case 50:
                            passiveStrength = row.Passive1StrengthLevel50;
                            break;
                        case 65:
                            passiveStrength = row.Passive1StrengthLevel65;
                            break;
                        case 80:
                            passiveStrength = row.Passive1StrengthLevel80;
                            break;
                        case 81:
                            passiveStrength = row.Passive1StrengthLevel81;
                            break;
                        case 90:
                            passiveStrength = row.Passive1StrengthLevel90;
                            break;
                        case 99:
                            passiveStrength = row.Passive1StrengthLevel99;
                            break;
                        default:

                            break;
                    }
                    break;
                case 2:
                    switch (magiciteLevelBandBreakpoint)
                    {
                        case 1:
                            passiveStrength = row.Passive2StrengthLevel1;
                            break;
                        case 10:
                            passiveStrength = row.Passive2StrengthLevel10;
                            break;
                        case 25:
                            passiveStrength = row.Passive2StrengthLevel25;
                            break;
                        case 50:
                            passiveStrength = row.Passive2StrengthLevel50;
                            break;
                        case 65:
                            passiveStrength = row.Passive2StrengthLevel65;
                            break;
                        case 80:
                            passiveStrength = row.Passive2StrengthLevel80;
                            break;
                        case 81:
                            passiveStrength = row.Passive2StrengthLevel81;
                            break;
                        case 90:
                            passiveStrength = row.Passive2StrengthLevel90;
                            break;
                        case 99:
                            passiveStrength = row.Passive2StrengthLevel99;
                            break;
                        default:

                            break;
                    }
                    break;
                case 3:
                    switch (magiciteLevelBandBreakpoint)
                    {
                        case 1:
                            passiveStrength = row.Passive3StrengthLevel1;
                            break;
                        case 10:
                            passiveStrength = row.Passive3StrengthLevel10;
                            break;
                        case 25:
                            passiveStrength = row.Passive3StrengthLevel25;
                            break;
                        case 50:
                            passiveStrength = row.Passive3StrengthLevel50;
                            break;
                        case 65:
                            passiveStrength = row.Passive3StrengthLevel65;
                            break;
                        case 80:
                            passiveStrength = row.Passive3StrengthLevel80;
                            break;
                        case 81:
                            passiveStrength = row.Passive3StrengthLevel81;
                            break;
                        case 90:
                            passiveStrength = row.Passive3StrengthLevel90;
                            break;
                        case 99:
                            passiveStrength = row.Passive3StrengthLevel99;
                            break;
                        default:

                            break;
                    }
                    break;
                default:

                    break;
            }

            return passiveStrength;
        }
        #endregion
    }
}
