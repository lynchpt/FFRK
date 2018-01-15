using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFRKApi.Data.Storage;
using FFRKApi.Logic.Api;
using FFRKApi.Model.EnlirMerge;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Api.FFRK.Controllers
{
    [Produces("application/json")]
    [Route("api/Maintenance")]
    public class MaintenanceController : Controller, IMaintenanceController
    {
        #region Class Variables

        private readonly IMaintenanceLogic _maintenanceLogic;
        private MergeResultsContainer _mergeResultsContainer;
        #endregion


        #region Constructors

        public MaintenanceController(IMaintenanceLogic maintenanceLogic, MergeResultsContainer mergeResultsContainer)
        {
            _maintenanceLogic = maintenanceLogic;
            _mergeResultsContainer = mergeResultsContainer;
        }
        #endregion


        #region IMaintenanceController Implementation

        [Route("DataStatus")]
        public IActionResult LoadLatestMergeResultsContainer()
        {
            MergeResultsContainer mergeResultsContainer = _maintenanceLogic.GetLatestMergeResultsContainer();

            _mergeResultsContainer = mergeResultsContainer;

            return new OkResult();
        } 
        #endregion
    }
}