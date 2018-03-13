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

        /// <summary>
        /// Gets all Other instances and their associated data.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Others, it is faster to get each individual Other instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets one Other instance by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Other instance for "Stock Raid"
        /// - You first call /api/v1.0/IdLists/Other to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Stock Raid" in the IdList (the id is 46 in this case)
        /// - Finally you call this api: api/v1.0/Others/46
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others/46 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="otherId">the integer id for the desired Other insatnce; it can be found in the Other IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Other instances whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Other instances with "Barrage" in their name.
        /// - You can straight away call this api: api/v1.0/Others/Name/barrage";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others/Name/barrage (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="otherName">the string that must be a part of a Dungeon's name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Other instances whose Source column contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Other instances with "Machinist" in their Source field.
        /// - You can straight away call this api: api/v1.0/Others/SourceName/machinist";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others/SourceName/machinist (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="sourceName">the string that must be a part of a Other's Source in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Other instances that have the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Other instances that have the AbilityType of "BLK"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "BLK" in the TypeList (the id is 2 in this case)
        /// - Finally you call this api: api/v1.0/Others/AbilityType/2
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others/AbilityType/2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Other instances that belong to the specified School 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Other instances that belong to the Summoning School
        /// - You first call /api/v1.0/TypeLists/SchoolType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Summoning" in the TypeList (the id is 19 in this case)
        /// - Finally you call this api: api/v1.0/Others/School/19
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others/School/19 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="schoolType">the integer id for the desired School; it can be found in the SchoolType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Other instances that have the specified element 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Other instances that do Fire damage
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Others/School/19
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired Element; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        /// <summary>
        /// Gets all Other instances whose Effect column contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Other instances with "Blink" in their Effect field.
        /// - You can straight away call this api: api/v1.0/Others/Effect/blink";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Others/Effect/blink (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a Other's Effect in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Other&gt;</see>
        /// </response>
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

        //comment to force push to azure
        #endregion
    }
}
