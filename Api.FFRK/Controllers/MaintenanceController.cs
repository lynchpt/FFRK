using System.Net;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using FFRKApi.Model.EnlirMerge;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IMaintenanceController
    {
        IActionResult RefreshMergeResultsContainer();
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class MaintenanceController : Controller, IMaintenanceController
    {
        #region Class Variables

        private readonly IMaintenanceLogic _maintenanceLogic;
        private readonly ILogger<MaintenanceController> _logger;
        #endregion


        #region Constructors

        public MaintenanceController(IMaintenanceLogic maintenanceLogic, ILogger<MaintenanceController> logger)
        {
            _maintenanceLogic = maintenanceLogic;
            _logger = logger;
        }
        #endregion


        #region IMaintenanceController Implementation
        [HttpGet]
        [Route(RouteConstants.MaintenanceRoute_DataStatus)]
        [SwaggerOperation(nameof(RefreshMergeResultsContainer))]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult RefreshMergeResultsContainer()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(RefreshMergeResultsContainer)}");
            _maintenanceLogic.RefreshMergeResultsContainer();

            return new OkResult();
        }

        //comment to force push to azure
        #endregion
    }
}