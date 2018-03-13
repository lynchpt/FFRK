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
    public interface IRecordMateriasController
    {
        IActionResult GetAllRecordMaterias();
        IActionResult GetRecordMateriasById(int recordMateriaId);
        IActionResult GetRecordMateriasByName(string recordMateriaName);
        IActionResult GetAllRecordMateriasByRealm(int realmType);
        IActionResult GetRecordMateriasByCharacter(int characterId);
        IActionResult GetRecordMateriasByEffect(string effectText);
        IActionResult GetRecordMateriasByUnlockCriteria(string unlockText);
        IActionResult GetRecordMateriasBySearch(D.RecordMateria searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RecordMateriasController : Controller, IRecordMateriasController
    {
        #region Class Variables

        private readonly IRecordMateriasLogic _recordMateriasLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordMateriasController> _logger;
        #endregion

        #region Constructors

        public RecordMateriasController(IRecordMateriasLogic recordMateriasLogic, IMapper mapper, ILogger<RecordMateriasController> logger)
        {
            _recordMateriasLogic = recordMateriasLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRecordMateriasController Implementation

        /// <summary>
        /// Gets all RecordMaterias and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of RecordMateria, it is faster to get each individual RecordMateria instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_All)]
        [SwaggerOperation(nameof(GetAllRecordMaterias))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllRecordMaterias()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllRecordMaterias)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetAllRecordMaterias();

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one RecordMateria by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the RecordMateria called "Scholar's Boon" and owned by Tyro
        /// - You first call /api/v1.0/IdLists/RecordMateria to get the proper IdList
        /// - Then you look up the integer Key associated with the Values of "Scholar's Boon" and "Tyro" in the IdList (the id is 4 in this case)
        /// - Finally you call this api: api/v1.0/RecordMaterias/4
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias/4 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="legendMateriaId">the integer id for the desired RecordMateria; it can be found in the RecordMateria IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Id)]
        [SwaggerOperation(nameof(GetRecordMateriasById))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasById(int recordMateriaId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasById)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasById(recordMateriaId);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordMaterias whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Dungeons with "blade" in their name.
        /// - You can straight away call this api: api/v1.0/RecordMaterias/Name/blade";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias/Name/blade (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="recordMateriaName">the string that must be a part of a RecordMateria's name in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Name)]
        [SwaggerOperation(nameof(GetRecordMateriasByName))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByName(string recordMateriaName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByName)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByName(recordMateriaName);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordMaterias that belong to the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all RecordMaterias in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/RecordMaterias/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_RealmType)]
        [SwaggerOperation(nameof(GetAllRecordMateriasByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllRecordMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllRecordMateriasByRealm)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetAllRecordMateriasByRealm(realmType);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordMaterias that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all RecordMaterias that belong to Bartz.
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/RecordMaterias/Character/73
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Character)]
        [SwaggerOperation(nameof(GetRecordMateriasByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByCharacter)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByCharacter(characterId);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordMaterias whose Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all RecordMaterias with "dualcast" as their effect.
        /// - You can straight away call this api: api/v1.0/RecordMaterias/Effect/dualcast";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias/Effect/dualcast (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a RecordMateria's Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Effect)]
        [SwaggerOperation(nameof(GetRecordMateriasByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByEffect)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByEffect(effectText);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordMaterias whose Unlock Criteria column contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all RecordMaterias with "level 99" in their Unlock Criteria.
        /// - You can straight away call this api: api/v1.0/RecordMaterias/Unlock/level%2099";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias/Unlock/level%2099 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="unlockText">the string that must be a part of a RecordMateria's Unlock Criteria text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Unlock)]
        [SwaggerOperation(nameof(GetRecordMateriasByUnlockCriteria))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByUnlockCriteria(string unlockText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByUnlockCriteria)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByUnlockCriteria(unlockText);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordMaterias that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full RecordMateria object as a search template, only the following fields are used in the search (all others are ignored):
        /// - Realm
        /// - RecordMateriaName (comparison is Contains, not exact match)
        /// - CharacterId 
        /// - Effect (comparison is Contains, not exact match)
        /// - UnlockCriteria (comparison is Contains, not exact match)
        /// 
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any RecordMateria in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all RecordMaterias that have an RealmType of "VI" and a UnlockCriteria of "level 99"
        /// - You first call Type List Apis to get the id for RealmType = VI (the id is 6))
        /// - You create an RecordMateria object and fill in the above 6 into the Realm property and "level 99" into the UnlockCriteria property
        /// - You attach the RecordMateria specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/RecordMaterias/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordMaterias/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the RecordMateria object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordMateria&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.RecordMateriasRoute_Search)]
        [SwaggerOperation(nameof(GetRecordMateriasBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasBySearch([FromBody]D.RecordMateria searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasBySearch)}");

            RecordMateria recordMateria = _mapper.Map<RecordMateria>(searchPrototype);

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasBySearch(recordMateria);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        //comment to force push to azure
        #endregion
    }
}
