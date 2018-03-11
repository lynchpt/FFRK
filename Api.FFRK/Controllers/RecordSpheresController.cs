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
    public interface IRecordSpheresController
    {
        IActionResult GetAllRecordSpheres();
        IActionResult GetRecordSpheresById(int recordSphereId);
        IActionResult GetRecordSpheresByRealm(int realmType);
        IActionResult GetRecordSpheresByCharacter(int characterId);
        IActionResult GetRecordSpheresByBenefit(string benefit);
        IActionResult GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2);
        IActionResult GetRecordSpheresBySearch(D.RecordSphere searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RecordSpheresController : Controller, IRecordSpheresController
    {
        #region Class Variables

        private readonly IRecordSpheresLogic _recordSpheresLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordSpheresController> _logger;
        #endregion

        #region Constructors

        public RecordSpheresController(IRecordSpheresLogic recordSpheresLogic, IMapper mapper, ILogger<RecordSpheresController> logger)
        {
            _recordSpheresLogic = recordSpheresLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRecordSpheresController Implementation

        /// <summary>
        /// Gets all RecordSpheres and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of RecordSpheres, it is faster to get each individual RecordSphere instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordSpheres (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_All)]
        [SwaggerOperation(nameof(GetAllRecordSpheres))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllRecordSpheres()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllRecordSpheres)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetAllRecordSpheres();

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one RecordSphere by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about Bartz's Paladin RecordSphere
        /// - You first call /api/v1.0/IdLists/RecordSphere to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "Bartz" and "Paladin" in the IdList (the id is 369 in this case)
        /// - Finally you call this api: api/v1.0/RecordSpheres/369
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordSpheres/369 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="recordSphereId">the integer id for the desired RecordSphere; it can be found in the RecordSphere IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_Id)]
        [SwaggerOperation(nameof(GetRecordSpheresById))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresById(int recordSphereId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresById)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresById(recordSphereId);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordSpheres that belong to Characters in the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendSpheres that belong to Characters in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/RecordSpheres/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordSpheres/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_RealmType)]
        [SwaggerOperation(nameof(GetRecordSpheresByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresByRealm)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresByRealm(realmType);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordSpheres that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all RecordSpheres that belong to Bartz.
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/RecordSpheres/Character/73
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordSpheres/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_Character)]
        [SwaggerOperation(nameof(GetRecordSpheresByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresByCharacter)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresByCharacter(characterId);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordSpheres whose Benefit contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all RecordSpheres with "Spellblade" in their Benefit text.
        /// - You can straight away call this api: api/v1.0/RecordSpheres/Benefit/spellblade";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordSpheres/Benefit/spellblade (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="benefit">the string that must be a part of a RecordSphere's Benefit text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_Benefit)]
        [SwaggerOperation(nameof(GetRecordSpheresByBenefit))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresByBenefit(string benefit)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresByBenefit)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresByBenefit(benefit);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordSpheres that require Motes of the specified type
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all RecordSpheres that require Bravery and Dexterity motes.
        /// Unlike most of the api calls that take string parameters, this query is an exact match by text - NOT a contains match. 
        /// Case is still ignored. 
        /// The order in which you specify the more types does not matter.
        /// - You can straight away call this api: api/v1.0/RecordSpheres/RequiredMotes/bravery/dexterity";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordSpheres/RequiredMotes/bravery/dexterity (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="moteType1">the (complete) string value of the first type of mote the RecordSpheres uses</param>
        /// <param name="moteType2">the (complete) string value of the second type of mote the RecordSphere uses</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_RequiredMotes)]
        [SwaggerOperation(nameof(GetLRecordSpheresByRequiredMotes))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLRecordSpheresByRequiredMotes)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetLRecordSpheresByRequiredMotes(moteType1, moteType2);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all RecordSpheres that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full RecordSphere object as a search template, only the following fields are used in the search (all others are ignored):
        /// - Realm
        /// - CharacterId 
        /// - More criteria may be added to this search in the future
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any RecordSphere in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all RecordSpheres that have an RealmType of "VI" and a Benefit including "ATK"
        /// - You first call Type List Apis to get the id for RealmType = VI (the id is 6))
        /// - You create an RecordSphere object and fill in the above 6 into the Realm property, and "atk" into the Benefit propert
        /// - You attach the RecordSphere specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/RecordSpheres/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RecordSpheres/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the RecordSphere object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RecordSphere&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.RecordSpheresRoute_Search)]
        [SwaggerOperation(nameof(GetRecordSpheresBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresBySearch([FromBody]D.RecordSphere searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresBySearch)}");

            RecordSphere recordSphere = _mapper.Map<RecordSphere>(searchPrototype);

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresBySearch(recordSphere);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
