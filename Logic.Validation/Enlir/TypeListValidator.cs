using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Validation.Enlir
{
    /// <summary>
    /// Implementations will provide methods to ensure that the the actual values in the TypeLists
    /// from the Model.EnlirTransform or Model.EnlirMerge libraries exactly match the values found in the 
    /// imported data. If there is a difference, the TypeLists need to be corrected in code
    /// </summary>
    public interface ITypeListValidator
    {
        IEnumerable<TypeListDifferences> TryValidateTypeLists(ImportResultsContainer importResultsContainer);
    }

    public class TypeListValidator : ITypeListValidator
    {
        #region Class Variables
        private ILogger<TypeListValidator> _logger;
        #endregion

        #region Constructors

        public TypeListValidator(ILogger<TypeListValidator> logger)
        {
            _logger = logger;
        }
        #endregion

        #region ITypeListValidator Implementation
        public IEnumerable<TypeListDifferences> TryValidateTypeLists(ImportResultsContainer importResultsContainer)
        {
            IList<TypeListDifferences> validationResults = new List<TypeListDifferences>();

            validationResults.Add(ValidateAbilityTypes(importResultsContainer));
            validationResults.Add(ValidateAutoTargetTypes(importResultsContainer));
            validationResults.Add(ValidateDamageFormulaTypes(importResultsContainer));
            validationResults.Add(ValidateElements(importResultsContainer));
            validationResults.Add(ValidateEventTypes(importResultsContainer));
            validationResults.Add(ValidateMissionTypes(importResultsContainer));
            validationResults.Add(ValidateOrbTypes(importResultsContainer));
            validationResults.Add(ValidateRealms(importResultsContainer));
            validationResults.Add(ValidateRelicTypes(importResultsContainer));
            validationResults.Add(ValidateSchools(importResultsContainer));
            validationResults.Add(ValidateSoulBreakTiers(importResultsContainer));
            validationResults.Add(ValidateTargetTypes(importResultsContainer));

            return validationResults;
        }
        #endregion

        #region Private Methods
        private TypeListDifferences ValidateAbilityTypes(ImportResultsContainer irc)
        {
            var abilityAbilityTypes = irc.AbilityRows.Select(ar => ar.Type.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var commandAbilityTypes = irc.CommandRows.Select(ar => ar.Type.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteAbilityTypes = irc.MagiciteRows.Select(ar => ar.Type.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteSkillAbilityTypes = irc.MagiciteSkillRows.Where(ar => !String.IsNullOrWhiteSpace(ar.Type)).Select(ar => ar.Type.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var otherAbilityTypes = irc.OtherRows.Select(ar => ar.Type.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var soulBreakAbilityTypes = irc.SoulBreakRows.Select(ar => ar.Type.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //AbilityTypes - source
            var unifiedAbilityTypesList = abilityAbilityTypes.Union(commandAbilityTypes).Union(magiciteAbilityTypes).
                Union(magiciteSkillAbilityTypes).Union(otherAbilityTypes).Union(soulBreakAbilityTypes).OrderBy(e => e);

            //AbilityTypes - id list
            var abilityTypesIdList = new AbilityTypeList();
            var abilityTypesIdListAbilityTypeNames = abilityTypesIdList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences abilityTypesDifferences = new TypeListDifferences()
            {
                IdListName = nameof(AbilityTypeList),
                ValuesMissingFromIdList = unifiedAbilityTypesList.Except(abilityTypesIdListAbilityTypeNames).ToList(),
                ValuesSuperfluousInIdList = abilityTypesIdListAbilityTypeNames.Except(unifiedAbilityTypesList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedAbilityTypesList)
            };

            return abilityTypesDifferences;
        }

        private TypeListDifferences ValidateAutoTargetTypes(ImportResultsContainer irc)
        {
            var abilityAutoTargetTypes = irc.AbilityRows.Select(ar => ar.AutoTarget.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var commandAutoTargetTypes = irc.CommandRows.Select(ar => ar.AutoTarget.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteAutoTargetTypes = irc.MagiciteRows.Select(ar => ar.AutoTarget.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteSkillAutoTargetTypes = irc.MagiciteSkillRows.Where(ar => !String.IsNullOrWhiteSpace(ar.Type)).Select(ar => ar.AutoTarget.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var otherAutoTargetTypes = irc.OtherRows.Select(ar => ar.AutoTarget.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var soulBreakAutoTargetTypes = irc.SoulBreakRows.Select(ar => ar.AutoTarget.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //AutoTargetTypes - source
            var unifiedAutoTargetTypesList = abilityAutoTargetTypes.Union(commandAutoTargetTypes).Union(magiciteAutoTargetTypes).
                Union(magiciteSkillAutoTargetTypes).Union(otherAutoTargetTypes).Union(soulBreakAutoTargetTypes).OrderBy(e => e);

            //AutoTargetTypes - id list
            var autoTargetTypesIdList = new AutoTargetTypeList();
            var autoTargetTypesIdListAutoTargetTypeNames = autoTargetTypesIdList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences autoTargetTypesDifferences = new TypeListDifferences()
            {
                IdListName = nameof(AutoTargetTypeList),
                ValuesMissingFromIdList = unifiedAutoTargetTypesList.Except(autoTargetTypesIdListAutoTargetTypeNames).ToList(),
                ValuesSuperfluousInIdList = autoTargetTypesIdListAutoTargetTypeNames.Except(unifiedAutoTargetTypesList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedAutoTargetTypesList)
            };

            return autoTargetTypesDifferences;
        }

        private TypeListDifferences ValidateDamageFormulaTypes(ImportResultsContainer irc)
        {
            var abilityDamageFormulaTypes = irc.AbilityRows.Select(ar => ar.Formula.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var commandDamageFormulaTypes = irc.CommandRows.Select(ar => ar.Formula.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteDamageFormulaTypes = irc.MagiciteRows.Select(ar => ar.Formula.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteSkillDamageFormulaTypes = irc.MagiciteSkillRows.Where(ar => !String.IsNullOrWhiteSpace(ar.Type)).Select(ar => ar.Formula.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var otherDamageFormulaTypes = irc.OtherRows.Select(ar => ar.Formula.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var soulBreakDamageFormulaTypes = irc.SoulBreakRows.Select(ar => ar.Formula.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //DamageFormulaTypes - source
            var unifiedDamageFormulaTypesList = abilityDamageFormulaTypes.Union(commandDamageFormulaTypes).Union(magiciteDamageFormulaTypes).
                Union(magiciteSkillDamageFormulaTypes).Union(otherDamageFormulaTypes).Union(soulBreakDamageFormulaTypes).OrderBy(e => e);

            //DamageFormulaTypes - id list
            var damageFormulaTypesIdList = new DamageFormulaTypeList();
            var damageFormulaTypesIdListDamageFormulaTypeNames = damageFormulaTypesIdList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences damageFormulaTypesDifferences = new TypeListDifferences()
            {
                IdListName = nameof(DamageFormulaTypeList),
                ValuesMissingFromIdList = unifiedDamageFormulaTypesList.Except(damageFormulaTypesIdListDamageFormulaTypeNames).ToList(),
                ValuesSuperfluousInIdList = damageFormulaTypesIdListDamageFormulaTypeNames.Except(unifiedDamageFormulaTypesList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedDamageFormulaTypesList)
            };

            return damageFormulaTypesDifferences;
        }

        private TypeListDifferences ValidateElements(ImportResultsContainer irc)
        {
            var abilityElements = irc.AbilityRows.Select(ar => ar.Element.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var commandElements = irc.CommandRows.Select(ar => ar.Element.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteElements = irc.MagiciteRows.Select(ar => ar.Element.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteSkillElements = irc.MagiciteSkillRows.Where(ar => !String.IsNullOrWhiteSpace(ar.Type)).Select(ar => ar.Element.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var otherElements = irc.OtherRows.Select(ar => ar.Element.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var soulBreakElements = irc.SoulBreakRows.Select(ar => ar.Element.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //elements - source
            var unifiedElementsList = abilityElements.Union(commandElements).Union(magiciteElements).
                Union(magiciteSkillElements).Union(otherElements).Union(soulBreakElements).OrderBy(e => e);

            //elements - id list
            var elementIdList = new ElementList();
            var elementIdListElementNames = elementIdList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences elementDifferences = new TypeListDifferences()
            {
                IdListName = nameof(ElementList),
                ValuesMissingFromIdList = unifiedElementsList.Except(elementIdListElementNames).ToList(),
                ValuesSuperfluousInIdList = elementIdListElementNames.Except(unifiedElementsList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedElementsList)
            };

            return elementDifferences;
        }

        private TypeListDifferences ValidateEventTypes(ImportResultsContainer irc)
        {
            var eventEventTypes = irc.EventRows.Select(ar => ar.Type.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //events - source
            var unifiedEventTypeList = eventEventTypes.OrderBy(e => e);

            //events - id list
            var eventTypeList = new EventTypeList();
            var eventTypeListEventNames = eventTypeList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences eventTypeDifferences = new TypeListDifferences()
            {
                IdListName = nameof(EventTypeList),
                ValuesMissingFromIdList = unifiedEventTypeList.Except(eventTypeListEventNames).ToList(),
                ValuesSuperfluousInIdList = eventTypeListEventNames.Except(unifiedEventTypeList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedEventTypeList)
            };

            return eventTypeDifferences;
        }

        private TypeListDifferences ValidateMissionTypes(ImportResultsContainer irc)
        {
            var missionMissionTypes = irc.MissionRows.Select(m => m.Type.Trim()).Distinct().OrderBy(e => e).ToList();

            //MissionTypes - source
            var unifiedMissionTypeList = missionMissionTypes.OrderBy(e => e);

            //MissionTypes - id list
            var missionTypeList = new MissionTypeList();
            var missionTypeListMissionNames = missionTypeList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences missionTypeDifferences = new TypeListDifferences()
            {
                IdListName = nameof(MissionTypeList),
                ValuesMissingFromIdList = unifiedMissionTypeList.Except(missionTypeListMissionNames).ToList(),
                ValuesSuperfluousInIdList = missionTypeListMissionNames.Except(unifiedMissionTypeList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedMissionTypeList)
            };

            return missionTypeDifferences;
        }

        private TypeListDifferences ValidateOrbTypes(ImportResultsContainer irc)
        {
            var abilityOrb1Types = irc.AbilityRows.Select(a => a.Orb1RequiredType.Trim()).Distinct().OrderBy(e => e).ToList();
            var abilityOrb2Types = irc.AbilityRows.Select(a => a.Orb2RequiredType.Trim()).Distinct().OrderBy(e => e).ToList();
            var abilityOrb3Types = irc.AbilityRows.Select(a => a.Orb3RequiredType.Trim()).Distinct().OrderBy(e => e).ToList();
            var abilityOrb4Types = irc.AbilityRows.Select(a => a.Orb4RequiredType.Trim()).Distinct().OrderBy(e => e).ToList();

            //OrbTypes - source
            var unifiedOrbTypeList = abilityOrb1Types.Union(abilityOrb2Types).Union(abilityOrb3Types).Union(abilityOrb4Types).OrderBy(e => e);

            //OrbTypes - id list
            var orbTypeList = new OrbTypeList();
            var orbTypeListOrbNames = orbTypeList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences orbTypeDifferences = new TypeListDifferences()
            {
                IdListName = nameof(OrbTypeList),
                ValuesMissingFromIdList = unifiedOrbTypeList.Except(orbTypeListOrbNames).ToList(),
                ValuesSuperfluousInIdList = orbTypeListOrbNames.Except(unifiedOrbTypeList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedOrbTypeList)
            };

            return orbTypeDifferences;
        }

        private TypeListDifferences ValidateRealms(ImportResultsContainer irc)
        {
            var characterRealms = irc.CharacterRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //var dungeonRealms = irc.DungeonRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
            //    SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var eventRealms = irc.EventRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var legendMateriaRealms = irc.LegendMateriaRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var legendSphereRealms = irc.LegendSphereRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var magiciteRealms = irc.MagiciteRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var recordMateriaRealms = irc.RecordMateriaRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var recordSphereRealms = irc.RecordSphereRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var relicRealms = irc.RelicRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var soulBreakRealms = irc.SoulBreakRows.Select(ar => ar.Realm.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //Realms - source
            var unifiedRealmsList = characterRealms.Union(eventRealms).
                Union(legendMateriaRealms).Union(legendSphereRealms).Union(magiciteRealms).
                Union(recordMateriaRealms).Union(recordSphereRealms).Union(relicRealms).Union(soulBreakRealms).OrderBy(e => e);

            //Realms - id list
            var realmList = new RealmList();
            var realmListRealmNames = realmList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences realmDifferences = new TypeListDifferences()
            {
                IdListName = nameof(RealmList),
                ValuesMissingFromIdList = unifiedRealmsList.Except(realmListRealmNames).ToList(),
                ValuesSuperfluousInIdList = realmListRealmNames.Except(unifiedRealmsList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedRealmsList)
            };

            return realmDifferences;
        }

        private TypeListDifferences ValidateRelicTypes(ImportResultsContainer irc)
        {
            var relicRelicTypes = irc.RelicRows.Select(m => m.Type.Trim()).Distinct().OrderBy(e => e).ToList();

            //RelicTypes - source
            var unifiedRelicTypeList = relicRelicTypes.OrderBy(e => e);

            //RelicTypes - id list
            var relicTypeList = new RelicTypeList();
            var relicTypeListNames = relicTypeList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences relicTypeDifferences = new TypeListDifferences()
            {
                IdListName = nameof(RelicTypeList),
                ValuesMissingFromIdList = unifiedRelicTypeList.Except(relicTypeListNames).ToList(),
                ValuesSuperfluousInIdList = relicTypeListNames.Except(unifiedRelicTypeList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedRelicTypeList)
            };

            return relicTypeDifferences;
        }

        private TypeListDifferences ValidateSchools(ImportResultsContainer irc)
        {
            var abilitySchoolTypes = irc.AbilityRows.Select(ar => ar.School.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var commandSchoolTypes = irc.CommandRows.Select(ar => ar.School.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var otherSchoolTypes = irc.OtherRows.Select(ar => ar.School.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //SchoolTypes - source
            var unifiedSchoolTypesList = abilitySchoolTypes.Union(commandSchoolTypes).Union(otherSchoolTypes).OrderBy(e => e);

            //SchoolTypes - id list
            var schoolTypesIdList = new SchoolList();
            var schoolTypesIdListSchoolNames = schoolTypesIdList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences schoolTypesDifferences = new TypeListDifferences()
            {
                IdListName = nameof(SchoolList),
                ValuesMissingFromIdList = unifiedSchoolTypesList.Except(schoolTypesIdListSchoolNames).ToList(),
                ValuesSuperfluousInIdList = schoolTypesIdListSchoolNames.Except(unifiedSchoolTypesList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedSchoolTypesList)
            };

            return schoolTypesDifferences;
        }

        private TypeListDifferences ValidateSoulBreakTiers(ImportResultsContainer irc)
        {
            var soulBreakSoulBreakTiers = irc.SoulBreakRows.Select(m => m.Tier.Trim()).Distinct().OrderBy(e => e).ToList();

            //SoulBreakTiers - source
            var unifiedSoulBreakTierList = soulBreakSoulBreakTiers.OrderBy(e => e);

            //SoulBreakTiers - id list
            var soulBreakTierList = new SoulBreakTierList();
            var soulBreakTierListNames = soulBreakTierList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences soulBreakTierDifferences = new TypeListDifferences()
            {
                IdListName = nameof(SoulBreakTierList),
                ValuesMissingFromIdList = unifiedSoulBreakTierList.Except(soulBreakTierListNames).ToList(),
                ValuesSuperfluousInIdList = soulBreakTierListNames.Except(unifiedSoulBreakTierList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedSoulBreakTierList)
            };

            return soulBreakTierDifferences;
        }

        private TypeListDifferences ValidateTargetTypes(ImportResultsContainer irc)
        {
            var abilityTargetTypes = irc.AbilityRows.Select(ar => ar.Target.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var commandTargetTypes = irc.CommandRows.Select(ar => ar.Target.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var otherTargetTypes = irc.OtherRows.Select(ar => ar.Target.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            var soulBreakTargetTypes = irc.SoulBreakRows.Select(ar => ar.Target.Split(",".ToCharArray())).
                SelectMany(el => el).Select(s => s.Trim()).Distinct().OrderBy(e => e).ToList();

            //TargetTypes - source
            var unifiedTargetTypesList = abilityTargetTypes.Union(commandTargetTypes).Union(otherTargetTypes).Union(soulBreakTargetTypes).OrderBy(e => e);

            //TargetTypes - id list
            var targetTypesIdList = new TargetTypeList();
            var targetTypesIdListTargetTypeNames = targetTypesIdList.TypeList.Where(il => il.Key != 0).Select(kvp => kvp.Value).ToList();

            TypeListDifferences targetTypesDifferences = new TypeListDifferences()
            {
                IdListName = nameof(TargetTypeList),
                ValuesMissingFromIdList = unifiedTargetTypesList.Except(targetTypesIdListTargetTypeNames).ToList(),
                ValuesSuperfluousInIdList = targetTypesIdListTargetTypeNames.Except(unifiedTargetTypesList).ToList(),
                SuggestedIdListContents = GenerateSuggestedIdListContents(unifiedTargetTypesList)
            };

            return targetTypesDifferences;
        }

        private IList<KeyValuePair<int, string>> GenerateSuggestedIdListContents(IEnumerable<string> sourceData)
        {
            IList<KeyValuePair<int, string>> defaultList = new List<KeyValuePair<int, string>>() { new KeyValuePair<int, string>(0, "Unknown") };
            IList<KeyValuePair<int, string>> suggestedIdListContents = new List<KeyValuePair<int, string>>();

            if (sourceData != null && sourceData.Any())
            {
                suggestedIdListContents = defaultList.Concat(sourceData.Select((a, index) => new KeyValuePair<int, string>(index + 1, a))).ToList();
            }

            return suggestedIdListContents;
        }
        #endregion
    }

    public class TypeListDifferences
    {
        public string IdListName { get; set; }
        public bool IsIdListDifferentFromSource => ValuesMissingFromIdList.Any() || ValuesSuperfluousInIdList.Any();
        public IList<string> ValuesMissingFromIdList { get; set; }
        public IList<string> ValuesSuperfluousInIdList { get; set; }
        public IList<KeyValuePair<int, string>> SuggestedIdListContents { get; set; }
    }
}
