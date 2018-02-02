using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
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
        #endregion

        #region Constructors

        public OthersLogic(IEnlirRepository enlirRepository, ILogger<OthersLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IOthersLogic Implementation

        public IEnumerable<Other> GetAllOthers()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllOthers)}");

            return _enlirRepository.GetMergeResultsContainer().Others;
        }

        public IEnumerable<Other> GetOthersById(int otherId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersById)}");

            return _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.Id == otherId);
        }

        public IEnumerable<Other> GetOthersByName(string otherName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByName)}");

            IEnumerable<Other> results = new List<Other>();

            if (!String.IsNullOrWhiteSpace(otherName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.Name.ToLower().Contains(otherName.ToLower()));
            }

            return results;
        }

        public IEnumerable<Other> GetOthersBySourceName(string sourceName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersBySourceName)}");

            IEnumerable<Other> results = new List<Other>();

            if (!String.IsNullOrWhiteSpace(sourceName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.SourceName.ToLower().Contains(sourceName.ToLower()));
            }

            return results;
        }

        public IEnumerable<Other> GetOthersByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByAbilityType)}");

            return _enlirRepository.GetMergeResultsContainer().Others.Where(a => a.AbilityType == abilityType);
        }

        public IEnumerable<Other> GetOthersBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersBySchool)}");

            return _enlirRepository.GetMergeResultsContainer().Others.Where(a => a.School == schoolType);
        }

        public IEnumerable<Other> GetOthersByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByElement)}");

            return _enlirRepository.GetMergeResultsContainer().Others.Where(a => a.Elements.Contains(elementType));
        }

        public IEnumerable<Other> GetOthersByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOthersByEffect)}");

            IEnumerable<Other> results = new List<Other>();

            if (!String.IsNullOrWhiteSpace(effectText))
            {
                results = _enlirRepository.GetMergeResultsContainer().Others.Where(e => e.Effects.ToLower().Contains(effectText.ToLower()));
            }

            return results;
        }

        #endregion
    }
}
