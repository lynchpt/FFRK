using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IIdListsController
    {
        IActionResult GetAbilityTypeList();
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class IdListsController : Controller, IIdListsController
    {
        #region Class Variables

        private readonly IIdListsLogic _idListsLogic;
        private readonly ILogger<IdListsController> _logger;
        #endregion

        #region Constructors

        public IdListsController(IIdListsLogic idListsLogic, ILogger<IdListsController> logger)
        {
            _idListsLogic = idListsLogic;
            _logger = logger;
        }
        #endregion

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_AbilityType)]
        [SwaggerOperation(nameof(GetAbilityTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilityTypeList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilityTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetAbilityTypeList();

            return new ObjectResult(result);
        }
    }
}
