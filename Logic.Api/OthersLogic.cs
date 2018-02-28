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
    public interface IOthersLogic
    {
        IEnumerable<Other> GetAllOthers();
        IEnumerable<Other> GetOthersById(int otherId);
        IEnumerable<Other> GetOthersByName(string otherName);
        IEnumerable<Other> GetOthersBySourceName(string sourceName);
        IEnumerable<Other> GetOthersByAbilityType(int abilityType);
        IEnumerable<Other> GetOthersBySchool(int schoolType);
        IEnumerable<Other> GetOthersByElement(int elementType);
        IEnumerable<Other> GetOthersByEffect(string effectText);
    }

    public class OthersLogic : IOthersLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<OthersLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public OthersLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<OthersLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IOthersLogic Implementation

        public IEnumerable<Other> GetAllOthers()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllOthers)}");

            string cacheKey = $"{nameof(GetAllOthers)}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Others;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Other> GetOthersById(int otherId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersById)}");

            string cacheKey = $"{nameof(GetOthersById)}:{otherId}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.Id == otherId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Other> GetOthersByName(string otherName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByName)}");

            string cacheKey = $"{nameof(GetOthersByName)}:{otherName}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = new List<Other>();

                if (!String.IsNullOrWhiteSpace(otherName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.Name.ToLower().Contains(otherName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Other> GetOthersBySourceName(string sourceName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersBySourceName)}");

            string cacheKey = $"{nameof(GetOthersBySourceName)}:{sourceName}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = new List<Other>();

                if (!String.IsNullOrWhiteSpace(sourceName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.SourceName.ToLower().Contains(sourceName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Other> GetOthersByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByAbilityType)}");

            string cacheKey = $"{nameof(GetOthersByAbilityType)}:{abilityType}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Others.Where(a => a.AbilityType == abilityType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Other> GetOthersBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersBySchool)}");

            string cacheKey = $"{nameof(GetOthersBySchool)}:{schoolType}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Others.Where(a => a.School == schoolType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Other> GetOthersByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByElement)}");

            string cacheKey = $"{nameof(GetOthersByElement)}:{elementType}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Others.Where(a => a.Elements.Contains(elementType));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Other> GetOthersByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByEffect)}");

            string cacheKey = $"{nameof(GetOthersByEffect)}:{effectText}";
            IEnumerable<Other> results = _cacheProvider.ObjectGet<IList<Other>>(cacheKey);

            if (results == null)
            {
                results = new List<Other>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.Effects.ToLower().Contains(effectText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        #endregion
    }
}
