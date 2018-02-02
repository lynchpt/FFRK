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
using FFRKApi.Model.EnlirTransform;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IStatusesController
    {
        IActionResult GetAllStatuses();
        IActionResult GetStatusesById(int statusId);
        IActionResult GetStatusesByCodedName(string codedName);
        IActionResult GetStatusesByCommonName(string commonName);
        IActionResult GetStatusesByEffect(string effectText);
        IActionResult GetStatusesByNotes(string notes);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class StatusesController : Controller, IStatusesController
    {
        #region Class Variables

        private readonly IStatusesLogic _statusesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<StatusesController> _logger;
        #endregion

        #region Constructors

        public StatusesController(IStatusesLogic statusesLogic, IMapper mapper, ILogger<StatusesController> logger)
        {
            _statusesLogic = statusesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IStatusesController Implementation

        [HttpGet]
        [Route(RouteConstants.StatusesRoute_All)]
        [SwaggerOperation(nameof(GetAllStatuses))]
        [ProducesResponseType(typeof(IEnumerable<D.Status>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllStatuses()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllStatuses)}");

            IEnumerable<Status> model = _statusesLogic.GetAllStatuses();

            IEnumerable<D.Status> result = _mapper.Map<IEnumerable<D.Status>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.StatusesRoute_Id)]
        [SwaggerOperation(nameof(GetStatusesById))]
        [ProducesResponseType(typeof(IEnumerable<D.Status>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatusesById(int statusId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetStatusesById)}");

            IEnumerable<Status> model = _statusesLogic.GetStatusesById(statusId);

            IEnumerable<D.Status> result = _mapper.Map<IEnumerable<D.Status>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.StatusesRoute_CodedName)]
        [SwaggerOperation(nameof(GetStatusesByCodedName))]
        [ProducesResponseType(typeof(IEnumerable<D.Status>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatusesByCodedName(string codedName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetStatusesByCodedName)}");

            IEnumerable<Status> model = _statusesLogic.GetStatusesByCodedName(codedName);

            IEnumerable<D.Status> result = _mapper.Map<IEnumerable<D.Status>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.StatusesRoute_CommonName)]
        [SwaggerOperation(nameof(GetStatusesByCommonName))]
        [ProducesResponseType(typeof(IEnumerable<D.Status>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatusesByCommonName(string commonName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetStatusesByCommonName)}");

            IEnumerable<Status> model = _statusesLogic.GetStatusesByCommonName(commonName);

            IEnumerable<D.Status> result = _mapper.Map<IEnumerable<D.Status>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.StatusesRoute_Effect)]
        [SwaggerOperation(nameof(GetStatusesByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Status>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatusesByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetStatusesByEffect)}");

            IEnumerable<Status> model = _statusesLogic.GetStatusesByEffect(effectText);

            IEnumerable<D.Status> result = _mapper.Map<IEnumerable<D.Status>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.StatusesRoute_Notes)]
        [SwaggerOperation(nameof(GetStatusesByNotes))]
        [ProducesResponseType(typeof(IEnumerable<D.Status>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatusesByNotes(string notes)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetStatusesByNotes)}");

            IEnumerable<Status> model = _statusesLogic.GetStatusesByNotes(notes);

            IEnumerable<D.Status> result = _mapper.Map<IEnumerable<D.Status>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
