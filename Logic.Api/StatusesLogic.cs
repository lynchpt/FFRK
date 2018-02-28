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
    public interface IStatusesLogic
    {
        IEnumerable<Status> GetAllStatuses();
        IEnumerable<Status> GetStatusesById(int statusId);
        IEnumerable<Status> GetStatusesByCodedName(string codedName);
        IEnumerable<Status> GetStatusesByCommonName(string commonName);
        IEnumerable<Status> GetStatusesByEffect(string effectText);
        IEnumerable<Status> GetStatusesByNotes(string notes);
    }

    public class StatusesLogic : IStatusesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<StatusesLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public StatusesLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<StatusesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IStatusesLogic Implementation

        public IEnumerable<Status> GetAllStatuses()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllStatuses)}");

            string cacheKey = $"{nameof(GetAllStatuses)}";
            IEnumerable<Status> results = _cacheProvider.ObjectGet<IList<Status>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Statuses;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Status> GetStatusesById(int statusId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesById)}");

            string cacheKey = $"{nameof(GetStatusesById)}:{statusId}";
            IEnumerable<Status> results = _cacheProvider.ObjectGet<IList<Status>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(e => e.Id == statusId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Status> GetStatusesByCodedName(string codedName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByCodedName)}");

            string cacheKey = $"{nameof(GetStatusesByCodedName)}:{codedName}";
            IEnumerable<Status> results = _cacheProvider.ObjectGet<IList<Status>>(cacheKey);

            if (results == null)
            {
                results = new List<Status>();

                if (!String.IsNullOrWhiteSpace(codedName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                        s => s.CodedName.ToLower().Contains(codedName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Status> GetStatusesByCommonName(string commonName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByCommonName)}");

            string cacheKey = $"{nameof(GetStatusesByCommonName)}:{commonName}";
            IEnumerable<Status> results = _cacheProvider.ObjectGet<IList<Status>>(cacheKey);

            if (results == null)
            {
                results = new List<Status>();

                if (!String.IsNullOrWhiteSpace(commonName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                        s => s.CommonName.ToLower().Contains(commonName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Status> GetStatusesByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByEffect)}");

            string cacheKey = $"{nameof(GetStatusesByEffect)}:{effectText}";
            IEnumerable<Status> results = _cacheProvider.ObjectGet<IList<Status>>(cacheKey);

            if (results == null)
            {
                results = new List<Status>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                        s => s.Effects.ToLower().Contains(effectText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Status> GetStatusesByNotes(string notes)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByNotes)}");

            string cacheKey = $"{nameof(GetStatusesByNotes)}:{notes}";
            IEnumerable<Status> results = _cacheProvider.ObjectGet<IList<Status>>(cacheKey);

            if (results == null)
            {
                results = new List<Status>();

                if (!String.IsNullOrWhiteSpace(notes))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                        s => s.Notes.ToLower().Contains(notes.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }
        #endregion
    }
}
