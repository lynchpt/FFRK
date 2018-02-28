using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IExperiencesLogic
    {
        IEnumerable<Experience> GetAllExperiences();
    }

    public class ExperiencesLogic : IExperiencesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<ExperiencesLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public ExperiencesLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<ExperiencesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IExperiencesLogic Implementation
        public IEnumerable<Experience> GetAllExperiences()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllExperiences)}");

            string cacheKey = $"{nameof(GetAllExperiences)}";
            IEnumerable<Experience> results = _cacheProvider.ObjectGet<IList<Experience>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Experiences;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }
        #endregion


    }
}
