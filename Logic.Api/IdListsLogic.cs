using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Model.Api;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{

    public interface IIdListsLogic
    {
        IdListBundle GetAllIdLists();

        IEnumerable<KeyValuePair<int, string>> GetAbilityIdList();
        IEnumerable<KeyValuePair<int, string>> GetCharacterIdList();
        IEnumerable<KeyValuePair<int, string>> GetCommandIdList();
        IEnumerable<KeyValuePair<int, string>> GetDungeonIdList();
        IEnumerable<KeyValuePair<int, string>> GetEventIdList();
        IEnumerable<KeyValuePair<int, string>> GetExperienceIdList();
        IEnumerable<KeyValuePair<int, string>> GetLegendMateriaIdList();
        IEnumerable<KeyValuePair<int, string>> GetLegendSpheredList();
        IEnumerable<KeyValuePair<int, string>> GetMagiciteIdList();
        IEnumerable<KeyValuePair<int, string>> GetMagiciteSkillIdList();
        IEnumerable<KeyValuePair<int, string>> GetMissionIdList();
        IEnumerable<KeyValuePair<int, string>> GetOtherIdList();
        IEnumerable<KeyValuePair<int, string>> GetRecordMateriaIdList();
        IEnumerable<KeyValuePair<int, string>> GetRecordSphereIdList();
        IEnumerable<KeyValuePair<int, string>> GetRelicIdList();
        IEnumerable<KeyValuePair<int, string>> GetSoulBreakIdList();
        IEnumerable<KeyValuePair<int, string>> GetStatusIdList();
    }

    public class IdListsLogic : IIdListsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<IdListsLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public IdListsLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<IdListsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IIdListsLogic Implementation
        public IdListBundle GetAllIdLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllIdLists)}");

            string cacheKey = $"{nameof(GetAllIdLists)}";
            IdListBundle results = _cacheProvider.ObjectGet<IdListBundle> (cacheKey);

            if (results == null)
            {
                results = new IdListBundle()
                          {
                              Ability = _enlirRepository.GetMergeResultsContainer().AbilityIdList,
                              Character = _enlirRepository.GetMergeResultsContainer().CharacterIdList,
                              Command = _enlirRepository.GetMergeResultsContainer().CommandIdList,
                              Dungeon = _enlirRepository.GetMergeResultsContainer().DungeonIdList,
                              Event = _enlirRepository.GetMergeResultsContainer().EventIdList,
                              Experience = _enlirRepository.GetMergeResultsContainer().ExperienceIdList,
                              LegendMateria = _enlirRepository.GetMergeResultsContainer().LegendMateriaIdList,
                              LegendSphere = _enlirRepository.GetMergeResultsContainer().LegendSphereIdList,
                              Magicite = _enlirRepository.GetMergeResultsContainer().MagiciteIdList,
                              MagiciteSkill = _enlirRepository.GetMergeResultsContainer().MagiciteSkillIdList,
                              Mission = _enlirRepository.GetMergeResultsContainer().MissionList,
                              Other = _enlirRepository.GetMergeResultsContainer().OtherIdList,
                              RecordMateria = _enlirRepository.GetMergeResultsContainer().RecordMateriaIdList,
                              RecordSphere = _enlirRepository.GetMergeResultsContainer().RecordSphereIdList,
                              Relic = _enlirRepository.GetMergeResultsContainer().RelicIdList,
                              SoulBreak = _enlirRepository.GetMergeResultsContainer().SoulBreakIdList,
                              Status = _enlirRepository.GetMergeResultsContainer().StatusIdList
                          };

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;           
        }

        public IEnumerable<KeyValuePair<int, string>> GetAbilityIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilityIdList)}");

            string cacheKey = $"{nameof(GetAbilityIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().AbilityIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetCharacterIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharacterIdList)}");

            string cacheKey = $"{nameof(GetCharacterIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().CharacterIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetCommandIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCommandIdList)}");

            string cacheKey = $"{nameof(GetCommandIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().CommandIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetDungeonIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDungeonIdList)}");

            string cacheKey = $"{nameof(GetDungeonIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().DungeonIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetEventIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventIdList)}");

            string cacheKey = $"{nameof(GetEventIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().EventIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetExperienceIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetExperienceIdList)}");

            string cacheKey = $"{nameof(GetExperienceIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().ExperienceIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetLegendMateriaIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriaIdList)}");

            string cacheKey = $"{nameof(GetLegendMateriaIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendMateriaIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetLegendSpheredList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheredList)}");

            string cacheKey = $"{nameof(GetLegendSpheredList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendSphereIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMagiciteIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagiciteIdList)}");

            string cacheKey = $"{nameof(GetMagiciteIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().MagiciteIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMagiciteSkillIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagiciteSkillIdList)}");

            string cacheKey = $"{nameof(GetMagiciteSkillIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().MagiciteSkillIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMissionIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionIdList)}");

            string cacheKey = $"{nameof(GetMissionIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().MissionList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetOtherIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOtherIdList)}");

            string cacheKey = $"{nameof(GetOtherIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().OtherIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRecordMateriaIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriaIdList)}");

            string cacheKey = $"{nameof(GetRecordMateriaIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMateriaIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRecordSphereIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSphereIdList)}");

            string cacheKey = $"{nameof(GetRecordSphereIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordSphereIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRelicIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicIdList)}");

            string cacheKey = $"{nameof(GetRelicIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().RelicIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSoulBreakIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreakIdList)}");

            string cacheKey = $"{nameof(GetSoulBreakIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreakIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<KeyValuePair<int, string>> GetStatusIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusIdList)}");

            string cacheKey = $"{nameof(GetStatusIdList)}";
            IList<KeyValuePair<int, string>> results = _cacheProvider.ObjectGet<IList<KeyValuePair<int, string>>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().StatusIdList;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        #endregion
    }
}
