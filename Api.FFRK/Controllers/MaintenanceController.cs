using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using FFRKApi.Model.EnlirMerge;
using Microsoft.AspNetCore.Mvc;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IMaintenanceController
    {
        IActionResult LoadLatestMergeResultsContainer();
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
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
        [HttpGet]
        [Route(RouteConstants.MaintenanceRoute_DataStatus)]
        public IActionResult LoadLatestMergeResultsContainer()
        {
            MergeResultsContainer mergeResultsContainer = _maintenanceLogic.GetLatestMergeResultsContainer();

            _mergeResultsContainer = mergeResultsContainer;

            return new OkResult();
        } 
        #endregion
    }
}