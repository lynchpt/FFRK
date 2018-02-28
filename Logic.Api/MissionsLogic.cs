using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMissionsLogic
    {
        IEnumerable<Mission> GetAllMissions();
        IEnumerable<Mission> GetMissionsById(int missionId);
        IEnumerable<Mission> GetMissionsByMissionType(int missionType);
        IEnumerable<Mission> GetMissionsByEventId(int eventId); 
        IEnumerable<Mission> GetMissionsByDescription(string description);
        IEnumerable<Mission> GetMissionsByReward(string rewardName);
    }

    public class MissionsLogic : IMissionsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<MissionsLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public MissionsLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<MissionsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IMissionsLogic Implementation

        public IEnumerable<Mission> GetAllMissions()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMissions)}");

            string cacheKey = $"{nameof(GetAllMissions)}";
            IEnumerable<Mission> results = _cacheProvider.ObjectGet<IList<Mission>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsById(int missionId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsById)}");

            string cacheKey = $"{nameof(GetMissionsById)}:{missionId}";
            IEnumerable<Mission> results = _cacheProvider.ObjectGet<IList<Mission>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.Id == missionId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsByMissionType(int missionType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByMissionType)}");

            string cacheKey = $"{nameof(GetMissionsByMissionType)}:{missionType}";
            IEnumerable<Mission> results = _cacheProvider.ObjectGet<IList<Mission>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.MissionType == missionType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsByEventId(int eventId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByEventId)}");

            string cacheKey = $"{nameof(GetMissionsByEventId)}:{eventId}";
            IEnumerable<Mission> results = _cacheProvider.ObjectGet<IList<Mission>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.AssociatedEventId == eventId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsByDescription(string description)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByDescription)}");

            string cacheKey = $"{nameof(GetMissionsByDescription)}:{description}";
            IEnumerable<Mission> results = _cacheProvider.ObjectGet<IList<Mission>>(cacheKey);

            if (results == null)
            {
                results = new List<Mission>();

                if (!String.IsNullOrWhiteSpace(description))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.Description.ToLower().Contains(description.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsByReward(string rewardName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByReward)}");

            string cacheKey = $"{nameof(GetMissionsByReward)}:{rewardName}";
            IEnumerable<Mission> results = _cacheProvider.ObjectGet<IList<Mission>>(cacheKey);

            if (results == null)
            {
                results = new List<Mission>();

                if (!String.IsNullOrWhiteSpace(rewardName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.Rewards.Any(r => r.ItemName.ToLower().Contains(rewardName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }
        #endregion
    }
}
