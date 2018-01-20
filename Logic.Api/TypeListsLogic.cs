using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using FFRKApi.Model.Api;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ITypeListsLogic
    {
        TypeListBundle GetAllTypeLists();

        IEnumerable<KeyValuePair<int, string>> GetAbilityTypeList();
        IEnumerable<KeyValuePair<int, string>> GetAutoTargetTypeList();
        IEnumerable<KeyValuePair<int, string>> GetDamageFormulaTypeList();
        IEnumerable<KeyValuePair<int, string>> GetElementTypeList();
        IEnumerable<KeyValuePair<int, string>> GetEquipmentTypeList();
        IEnumerable<KeyValuePair<int, string>> GetEventTypeList();
        IEnumerable<KeyValuePair<int, string>> GetMissionTypeList();
        IEnumerable<KeyValuePair<int, string>> GetOrbTypeList();
        IEnumerable<KeyValuePair<int, string>> GetRealmTypeList();
        IEnumerable<KeyValuePair<int, string>> GetRelicTypeList();
        IEnumerable<KeyValuePair<int, string>> GetSchoolTypeList();
        IEnumerable<KeyValuePair<int, string>> GetSoulBreakTierTypeList();
        IEnumerable<KeyValuePair<int, string>> GetTargetTypeList();

    }

    public class TypeListsLogic : ITypeListsLogic
    {

        #region Class Variables

        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<TypeListsLogic> _logger;
        #endregion

        #region Constructors

        public TypeListsLogic(IEnlirRepository enlirRepository, ILogger<TypeListsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ITypeListsLogic Implementation

        public TypeListBundle GetAllTypeLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllTypeLists)}");

            TypeListBundle bundle = new TypeListBundle()
                    {
                        AbilityType = _enlirRepository.GetMergeResultsContainer().AbilityTypeList,
                        AutoTargetType = _enlirRepository.GetMergeResultsContainer().AutoTargetTypeList,
                        DamageFormulaType = _enlirRepository.GetMergeResultsContainer().DamageFormulaTypeList,
                        ElementType = _enlirRepository.GetMergeResultsContainer().ElementList,
                        EquipmentType = _enlirRepository.GetMergeResultsContainer().EquipmentTypeList,
                        EventType = _enlirRepository.GetMergeResultsContainer().EventTypeList,
                        MissionType = _enlirRepository.GetMergeResultsContainer().MissionTypeList,
                        OrbType = _enlirRepository.GetMergeResultsContainer().OrbTypeList,
                        RealmType = _enlirRepository.GetMergeResultsContainer().RealmList,
                        RelicType = _enlirRepository.GetMergeResultsContainer().RelicIdList,
                        SchoolType = _enlirRepository.GetMergeResultsContainer().SchoolList,
                        SoulBreakTierType = _enlirRepository.GetMergeResultsContainer().SoulBreakTierList,
                        TargetType = _enlirRepository.GetMergeResultsContainer().TargetTypeList
                    };

            return bundle;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAbilityTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilityTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().AbilityTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAutoTargetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAutoTargetTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().AutoTargetTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetDamageFormulaTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDamageFormulaTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().DamageFormulaTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetElementTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetElementTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().ElementList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetEquipmentTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEquipmentTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().EquipmentTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetEventTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().EventTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMissionTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().MissionTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetOrbTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOrbTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().OrbTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRealmTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRealmTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().RealmList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRelicTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().RelicTypeList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSchoolTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSchoolTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().SchoolList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSoulBreakTierTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreakTierTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().SoulBreakTierList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetTargetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetTargetTypeList)}");

            return _enlirRepository.GetMergeResultsContainer().TargetTypeList;
        }

        #endregion
    }
}

