using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
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
        IEnumerable<KeyValuePair<int, string>> GetStatSetTypeList();
        IEnumerable<KeyValuePair<int, string>> GetStatTypeList();
        IEnumerable<KeyValuePair<int, string>> GetSoulBreakTierTypeList();
        IEnumerable<KeyValuePair<int, string>> GetTargetTypeList();

    }

    public class TypeListsLogic : ITypeListsLogic
    {

        #region Class Variables

        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<TypeListsLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public TypeListsLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<TypeListsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region ITypeListsLogic Implementation

        public TypeListBundle GetAllTypeLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllTypeLists)}");

            string cacheKey = $"{nameof(GetAllTypeLists)}";
            TypeListBundle results = _cacheProvider.ObjectGet<TypeListBundle>(cacheKey);

            if (results == null)
            {
                results = new TypeListBundle()
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

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAbilityTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilityTypeList)}");

            string cacheKey = $"{nameof(GetAbilityTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().AbilityTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAutoTargetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAutoTargetTypeList)}");

            string cacheKey = $"{nameof(GetAutoTargetTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().AutoTargetTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetDamageFormulaTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDamageFormulaTypeList)}");

            string cacheKey = $"{nameof(GetDamageFormulaTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().DamageFormulaTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetElementTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetElementTypeList)}");

            string cacheKey = $"{nameof(GetElementTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().ElementList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetEquipmentTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEquipmentTypeList)}");

            string cacheKey = $"{nameof(GetEquipmentTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().EquipmentTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetEventTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventTypeList)}");

            string cacheKey = $"{nameof(GetEventTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().EventTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMissionTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionTypeList)}");

            string cacheKey = $"{nameof(GetMissionTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().MissionTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetOrbTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOrbTypeList)}");

            string cacheKey = $"{nameof(GetOrbTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().OrbTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRealmTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRealmTypeList)}");

            string cacheKey = $"{nameof(GetRealmTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RealmList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRelicTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicTypeList)}");

            string cacheKey = $"{nameof(GetRelicTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RelicTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSchoolTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSchoolTypeList)}");

            string cacheKey = $"{nameof(GetSchoolTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SchoolList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetStatSetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatSetTypeList)}");

            string cacheKey = $"{nameof(GetStatSetTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().StatSetTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetStatTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatTypeList)}");

            string cacheKey = $"{nameof(GetStatTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().StatTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSoulBreakTierTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreakTierTypeList)}");

            string cacheKey = $"{nameof(GetSoulBreakTierTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreakTierList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetTargetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetTargetTypeList)}");

            string cacheKey = $"{nameof(GetTargetTypeList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().TargetTypeList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        #endregion
    }
}

