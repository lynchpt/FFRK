using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirMerge;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMaintenanceLogic
    {
        void RefreshMergeResultsContainer();
    }

    public class MaintenanceLogic : IMaintenanceLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<MaintenanceLogic> _logger;
        #endregion


        #region Constructors

        public MaintenanceLogic(IEnlirRepository enlirRepository, ILogger<MaintenanceLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;

        }
        #endregion


        #region IMaintenanceController Implementation
        public void RefreshMergeResultsContainer()
        {            
            _enlirRepository.LoadMergeResultsContainer();
            _logger.LogInformation($"Logic Method invoked: {nameof(RefreshMergeResultsContainer)}");
        }
        #endregion
    }
}
