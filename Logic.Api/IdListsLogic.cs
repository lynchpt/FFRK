using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using FFRKApi.Model.Api;
using FFRKApi.Model.EnlirMerge;
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
        #endregion

        #region Constructors

        public IdListsLogic(IEnlirRepository enlirRepository, ILogger<IdListsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IIdListsLogic Implementation
        public IdListBundle GetAllIdLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllIdLists)}");

            IdListBundle bundle = new IdListBundle()
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

            return bundle;
        }

        public IEnumerable<KeyValuePair<int, string>> GetAbilityIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilityIdList)}");

            return _enlirRepository.GetMergeResultsContainer().AbilityIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetCharacterIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharacterIdList)}");

            return _enlirRepository.GetMergeResultsContainer().CharacterIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetCommandIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCommandIdList)}");

            return _enlirRepository.GetMergeResultsContainer().CommandIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetDungeonIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDungeonIdList)}");

            return _enlirRepository.GetMergeResultsContainer().DungeonIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetEventIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventIdList)}");

            return _enlirRepository.GetMergeResultsContainer().EventIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetExperienceIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetExperienceIdList)}");

            return _enlirRepository.GetMergeResultsContainer().ExperienceIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetLegendMateriaIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendMateriaIdList)}");

            return _enlirRepository.GetMergeResultsContainer().LegendMateriaIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetLegendSpheredList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheredList)}");

            return _enlirRepository.GetMergeResultsContainer().LegendSphereIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMagiciteIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagiciteIdList)}");

            return _enlirRepository.GetMergeResultsContainer().MagiciteIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMagiciteSkillIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagiciteSkillIdList)}");

            return _enlirRepository.GetMergeResultsContainer().MagiciteSkillIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetMissionIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionIdList)}");

            return _enlirRepository.GetMergeResultsContainer().MissionList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetOtherIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOtherIdList)}");

            return _enlirRepository.GetMergeResultsContainer().OtherIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRecordMateriaIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriaIdList)}");

            return _enlirRepository.GetMergeResultsContainer().RecordMateriaIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRecordSphereIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSphereIdList)}");

            return _enlirRepository.GetMergeResultsContainer().RecordSphereIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetRelicIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicIdList)}");

            return _enlirRepository.GetMergeResultsContainer().RelicIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetSoulBreakIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreakIdList)}");

            return _enlirRepository.GetMergeResultsContainer().SoulBreakIdList;
        }

        public IEnumerable<KeyValuePair<int, string>> GetStatusIdList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusIdList)}");

            return _enlirRepository.GetMergeResultsContainer().StatusIdList;
        }

        #endregion
    }
}
