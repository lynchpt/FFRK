using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using D = FFRKApi.Dto.Api;
using FFRKApi.Model.EnlirTransform;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IOthersController
    {
        IActionResult GetAllOthers();
        IActionResult GetOthersById(int otherId);
        IActionResult GetOthersByName(string otherName);
        IActionResult GetOthersBySourceName(string sourceName);
        IActionResult GetOthersByAbilityType(int abilityType);
        IActionResult GetOthersBySchool(int schoolType);
        IActionResult GetOthersByElement(int elementType);
        IActionResult GetOthersByEffect(string effectText);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class OthersController : Controller, IOthersController
    {
        #region Class Variables

        private readonly IOthersLogic _othersLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<OthersController> _logger;
        #endregion

        #region Constructors

        public OthersController(IOthersLogic othersLogic, IMapper mapper, ILogger<OthersController> logger)
        {
            _othersLogic = othersLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IOthersController Implementation

        [HttpGet]
        [Route(RouteConstants.OthersRoute_All)]
        [SwaggerOperation(nameof(GetAllOthers))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllOthers()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllOthers)}");

            IEnumerable<Other> model = _othersLogic.GetAllOthers();

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.OthersRoute_Id)]
        [SwaggerOperation(nameof(GetOthersById))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetOthersById(int otherId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOthersById)}");

            IEnumerable<Other> model = _othersLogic.GetOthersById(otherId);

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.OthersRoute_Name)]
        [SwaggerOperation(nameof(GetOthersByName))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetOthersByName(string otherName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOthersByName)}");

            IEnumerable<Other> model = _othersLogic.GetOthersByName(otherName);

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.OthersRoute_SourceName)]
        [SwaggerOperation(nameof(GetOthersBySourceName))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetOthersBySourceName(string sourceName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOthersBySourceName)}");

            IEnumerable<Other> model = _othersLogic.GetOthersBySourceName(sourceName);

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.OthersRoute_AbilityType)]
        [SwaggerOperation(nameof(GetOthersByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetOthersByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOthersByAbilityType)}");

            IEnumerable<Other> model = _othersLogic.GetOthersByAbilityType(abilityType);

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.OthersRoute_School)]
        [SwaggerOperation(nameof(GetOthersBySchool))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetOthersBySchool(int schoolType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOthersBySchool)}");

            IEnumerable<Other> model = _othersLogic.GetOthersBySchool(schoolType);

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.OthersRoute_Element)]
        [SwaggerOperation(nameof(GetOthersByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetOthersByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOthersByElement)}");

            IEnumerable<Other> model = _othersLogic.GetOthersByElement(elementType);

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.OthersRoute_Effect)]
        [SwaggerOperation(nameof(GetOthersByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Other>), (int)HttpStatusCode.OK)]
        public IActionResult GetOthersByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOthersByEffect)}");

            IEnumerable<Other> model = _othersLogic.GetOthersByEffect(effectText);

            IEnumerable<D.Other> result = _mapper.Map<IEnumerable<D.Other>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
