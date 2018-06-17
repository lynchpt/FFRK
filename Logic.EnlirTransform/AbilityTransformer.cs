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
    public class AbilityTransformer : RowTransformerBase<AbilityRow, Ability>
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
        private readonly TypeListConverter _orbTypeConverter;
        private readonly TypeListConverter _schoolConverter;

        #endregion

        #region Constructors
        public AbilityTransformer(ILogger<RowTransformerBase<AbilityRow, Ability>> logger) : base(logger)
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
            _orbTypeConverter = new TypeListConverter(new OrbTypeList());
            _schoolConverter = new TypeListConverter(new SchoolList());
        }
        #endregion

        #region RowTransformerBase Overrides
        protected override Ability ConvertRowToModel(int generatedId, AbilityRow row)
        {
            Ability model = new Ability();

            model.Id = generatedId;
            model.Description = row.AbilityName;

            model.AbilityName = row.AbilityName;
            model.ImagePath = row.ImagePath;

            model.School = _schoolConverter.ConvertFromNameToId(row.School ?? "Unknown");

            model.Rarity = _intConverter.ConvertFromStringToInt(row.Rarity);
            model.MinUses = _intConverter.ConvertFromStringToInt(row.Uses);
            model.MaxUses = _intConverter.ConvertFromStringToInt(row.Max);

            model.AbilityType = _abilityTypeConverter.ConvertFromNameToId(row.Type);
            model.TargetType = _targetTypeConverter.ConvertFromNameToId(row.Target);
            model.AutoTargetType = _autoTargetTypeConverter.ConvertFromNameToId(row.AutoTarget);
            model.DamageFormulaType = _damageFormulaTypeConverter.ConvertFromNameToId(row.Formula);
            model.Multiplier = _doubleConverter.ConvertFromStringToDouble(row.Multiplier);
            model.Elements = _elementConverter.ConvertFromCommaSeparatedListToIds(row.Element);
            model.CastTime = _doubleConverter.ConvertFromStringToDouble(row.Time);
            model.Effects = row.Effects;
            model.IsCounterable = _stringToBooleanConverter.ConvertFromStringToBool(row.Counter);
            model.IsChecked = _stringToBooleanConverter.ConvertFromStringToBool(row.Checked);
            model.SoulBreakPointsGained = _intConverter.ConvertFromStringToInt(row.SB);

            model.IntroducingEventName = row.IntroducingEvent;
            model.IntroducingEventId = 0; //filled in during merge phase
            model.JapaneseName = row.JapaneseName;
            model.EnlirId = row.ID;

            model.OrbRequirements = GetOrbRequirements(row);

            _logger.LogDebug("Converted AbilityRow to Ability: {Id} - {Description}", model.Id, model.Description);

            return model;
        }


        #endregion

        #region Private Methods
        private IEnumerable<OrbRequirementsByRankInfo> GetOrbRequirements(AbilityRow row)
        {
            IList<OrbRequirementsByRankInfo> orbRequirementsByRankInfos = new List<OrbRequirementsByRankInfo>();

            //orb 1
            if (!String.IsNullOrWhiteSpace(row.Orb1RequiredType))
            {
                string orb1Name = row.Orb1RequiredType;
                int orb1Id = _orbTypeConverter.ConvertFromNameToId(row.Orb1RequiredType);

                OrbRequirementsByRankInfo orbRequirementsRank1 = new OrbRequirementsByRankInfo()
                                                            {
                                                                HoneRank = 1,
                                                                OrbCount = _intConverter.ConvertFromStringToInt(row.Orb1RequiredRank1),
                                                                OrbName = orb1Name,
                                                                OrbId = orb1Id
                                                            };
                orbRequirementsByRankInfos.Add(orbRequirementsRank1);

                OrbRequirementsByRankInfo orbRequirementsRank2 = new OrbRequirementsByRankInfo()
                                                            {
                                                                HoneRank = 2,
                                                                OrbCount = _intConverter.ConvertFromStringToInt(row.Orb1RequiredRank2),
                                                                OrbName = orb1Name,
                                                                OrbId = orb1Id
                                                            };
                orbRequirementsByRankInfos.Add(orbRequirementsRank2);

                OrbRequirementsByRankInfo orbRequirementsRank3 = new OrbRequirementsByRankInfo()
                                                            {
                                                                HoneRank = 3,
                                                                OrbCount = _intConverter.ConvertFromStringToInt(row.Orb1RequiredRank3),
                                                                OrbName = orb1Name,
                                                                OrbId = orb1Id
                                                            };
                orbRequirementsByRankInfos.Add(orbRequirementsRank3);

                OrbRequirementsByRankInfo orbRequirementsRank4 = new OrbRequirementsByRankInfo()
                                                            {
                                                                HoneRank = 4,
                                                                OrbCount = _intConverter.ConvertFromStringToInt(row.Orb1RequiredRank4),
                                                                OrbName = orb1Name,
                                                                OrbId = orb1Id
                                                            };
                orbRequirementsByRankInfos.Add(orbRequirementsRank4);

                OrbRequirementsByRankInfo orbRequirementsRank5 = new OrbRequirementsByRankInfo()
                                                            {
                                                                HoneRank = 5,
                                                                OrbCount = _intConverter.ConvertFromStringToInt(row.Orb1RequiredRank5),
                                                                OrbName = orb1Name,
                                                                OrbId = orb1Id
                                                            };
                orbRequirementsByRankInfos.Add(orbRequirementsRank5);                
            }

            //orb 2
            if (!String.IsNullOrWhiteSpace(row.Orb2RequiredType))
            {
                string orb2Name = row.Orb2RequiredType;
                int orb2Id = _orbTypeConverter.ConvertFromNameToId(row.Orb2RequiredType);

                OrbRequirementsByRankInfo orbRequirementsRank1 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 1,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb2RequiredRank1),
                    OrbName = orb2Name,
                    OrbId = orb2Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank1);

                OrbRequirementsByRankInfo orbRequirementsRank2 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 2,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb2RequiredRank2),
                    OrbName = orb2Name,
                    OrbId = orb2Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank2);

                OrbRequirementsByRankInfo orbRequirementsRank3 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 3,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb2RequiredRank3),
                    OrbName = orb2Name,
                    OrbId = orb2Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank3);

                OrbRequirementsByRankInfo orbRequirementsRank4 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 4,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb2RequiredRank4),
                    OrbName = orb2Name,
                    OrbId = orb2Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank4);

                OrbRequirementsByRankInfo orbRequirementsRank5 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 5,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb2RequiredRank5),
                    OrbName = orb2Name,
                    OrbId = orb2Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank5);
            }

            //orb 3
            if (!String.IsNullOrWhiteSpace(row.Orb3RequiredType))
            {
                string orb3Name = row.Orb3RequiredType;
                int orb3Id = _orbTypeConverter.ConvertFromNameToId(row.Orb3RequiredType);

                OrbRequirementsByRankInfo orbRequirementsRank1 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 1,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb3RequiredRank1),
                    OrbName = orb3Name,
                    OrbId = orb3Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank1);

                OrbRequirementsByRankInfo orbRequirementsRank2 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 2,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb3RequiredRank2),
                    OrbName = orb3Name,
                    OrbId = orb3Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank2);

                OrbRequirementsByRankInfo orbRequirementsRank3 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 3,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb3RequiredRank3),
                    OrbName = orb3Name,
                    OrbId = orb3Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank3);

                OrbRequirementsByRankInfo orbRequirementsRank4 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 4,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb3RequiredRank4),
                    OrbName = orb3Name,
                    OrbId = orb3Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank4);

                OrbRequirementsByRankInfo orbRequirementsRank5 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 5,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb3RequiredRank5),
                    OrbName = orb3Name,
                    OrbId = orb3Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank5);
            }

            //orb 4
            if (!String.IsNullOrWhiteSpace(row.Orb4RequiredType))
            {
                string orb4Name = row.Orb4RequiredType;
                int orb4Id = _orbTypeConverter.ConvertFromNameToId(row.Orb4RequiredType);

                OrbRequirementsByRankInfo orbRequirementsRank1 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 1,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb4RequiredRank1),
                    OrbName = orb4Name,
                    OrbId = orb4Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank1);

                OrbRequirementsByRankInfo orbRequirementsRank2 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 2,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb4RequiredRank2),
                    OrbName = orb4Name,
                    OrbId = orb4Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank2);

                OrbRequirementsByRankInfo orbRequirementsRank3 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 3,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb4RequiredRank3),
                    OrbName = orb4Name,
                    OrbId = orb4Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank3);

                OrbRequirementsByRankInfo orbRequirementsRank4 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 4,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb4RequiredRank4),
                    OrbName = orb4Name,
                    OrbId = orb4Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank4);

                OrbRequirementsByRankInfo orbRequirementsRank5 = new OrbRequirementsByRankInfo()
                {
                    HoneRank = 5,
                    OrbCount = _intConverter.ConvertFromStringToInt(row.Orb4RequiredRank5),
                    OrbName = orb4Name,
                    OrbId = orb4Id
                };
                orbRequirementsByRankInfos.Add(orbRequirementsRank5);
            }

            //before returning to caller, filter out any rows that have a 0 required orb count

            IList<OrbRequirementsByRankInfo> orbRequirementsByRankInfosFiltered = orbRequirementsByRankInfos.Where(o => o.OrbCount != 0).ToList();

            return orbRequirementsByRankInfosFiltered;
        }
        #endregion
    }
}
