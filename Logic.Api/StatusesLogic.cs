using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
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
        #endregion

        #region Constructors

        public StatusesLogic(IEnlirRepository enlirRepository, ILogger<StatusesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IStatusesLogic Implementation

        public IEnumerable<Status> GetAllStatuses()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllStatuses)}");

            return _enlirRepository.GetMergeResultsContainer().Statuses;
        }

        public IEnumerable<Status> GetStatusesById(int statusId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesById)}");

            return _enlirRepository.GetMergeResultsContainer().Statuses.Where(e => e.Id == statusId);
        }

        public IEnumerable<Status> GetStatusesByCodedName(string codedName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByCodedName)}");

            IEnumerable<Status> results = new List<Status>();

            if (!String.IsNullOrWhiteSpace(codedName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                    s => s.CodedName.ToLower().Contains(codedName.ToLower()));
            }
            return results;
        }

        public IEnumerable<Status> GetStatusesByCommonName(string commonName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByCommonName)}");

            IEnumerable<Status> results = new List<Status>();

            if (!String.IsNullOrWhiteSpace(commonName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                    s => s.CommonName.ToLower().Contains(commonName.ToLower()));
            }
            return results;
        }

        public IEnumerable<Status> GetStatusesByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByEffect)}");

            IEnumerable<Status> results = new List<Status>();

            if (!String.IsNullOrWhiteSpace(effectText))
            {
                results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                    s => s.Effects.ToLower().Contains(effectText.ToLower()));
            }
            return results;
        }

        public IEnumerable<Status> GetStatusesByNotes(string notes)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatusesByNotes)}");

            IEnumerable<Status> results = new List<Status>();

            if (!String.IsNullOrWhiteSpace(notes))
            {
                results = _enlirRepository.GetMergeResultsContainer().Statuses.Where(
                    s => s.Notes.ToLower().Contains(notes.ToLower()));
            }
            return results;
        }
        #endregion
    }
}
