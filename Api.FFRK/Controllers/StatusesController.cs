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

        /// <summary>
        /// Gets all Statuses and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Statuses, it is faster to get each individual Status instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Statuses (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Status&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets one Status by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Blink Status
        /// - You first call /api/v1.0/IdLists/Status to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "Stop" in the IdList (the id is 7 in this case)
        /// - Finally you call this api: api/v1.0/Statuses/7
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Statuses/7 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="statusId">the integer id for the desired Status; it can be found in the Status IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Status&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Statuses whose Coded Name contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Statuses with "Doom" in their Coded Name.
        /// - You can straight away call this api: api/v1.0/Statuses/CodedName/doom";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Statuses/CodedName/doom (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="codedName">the string that must be a part of a Status's Coded Name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Status&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Statuses whose Common Name contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Statuses with "Reraise" in their Common Name.
        /// - You can straight away call this api: api/v1.0/Statuses/CommonName/reraise";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Statuses/CommonName/reraise (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="commonName">the string that must be a part of a Status's Common Name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Status&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Statuses whose Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Statuses with "Returns" (i.e., a Radiant Shield) in their Effect.
        /// - You can straight away call this api: api/v1.0/Statuses/Effect/returns";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Statuses/Effect/returns (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a Status's Effect in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Status&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Statuses whose Notes contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Statuses with "Not used" in their Notes.
        /// - You can straight away call this api: api/v1.0/Statuses/Notes/not%20used";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Statuses/Notes/not%20used (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="notes">the string that must be a part of a Status's Notes in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Status&gt;</see>
        /// </response>
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

        //comment to force push to azure
        #endregion
    }
}
