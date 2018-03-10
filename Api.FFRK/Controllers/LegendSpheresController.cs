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
    public interface ILegendSpheresController
    {
        IActionResult GetAllLegendSpheres();
        IActionResult GetLegendSpheresById(int legendSphereId);
        IActionResult GetLegendSpheresByRealm(int realmType);
        IActionResult GetLegendSpheresByCharacter(int characterId);
        IActionResult GetLegendSpheresByBenefit(string benefit);
        IActionResult GetLegendSpheresByRequiredMotes(string moteType1, string moteType2);
        IActionResult GetLegendSpheresBySearch(D.LegendSphere searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class LegendSpheresController : Controller, ILegendSpheresController
    {
        #region Class Variables

        private readonly ILegendSpheresLogic _legendSpheresLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<LegendSpheresController> _logger;
        #endregion

        #region Constructors

        public LegendSpheresController(ILegendSpheresLogic legendSpheresLogic, IMapper mapper, ILogger<LegendSpheresController> logger)
        {
            _legendSpheresLogic = legendSpheresLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ILegendSpheresController Implementation

        /// <summary>
        /// Gets all LegendSpheres and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of LegendSphere, it is faster to get each individual ability instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendSpheres (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendSpheresRoute_All)]
        [SwaggerOperation(nameof(GetAllLegendSpheres))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllLegendSpheres()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllLegendSpheres)}");

            IEnumerable<LegendSphere> model = _legendSpheresLogic.GetAllLegendSpheres();

            IEnumerable<D.LegendSphere> result = _mapper.Map<IEnumerable<D.LegendSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one LegendSphere by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the LegendSphere where Bartz gets DEF +20
        /// - You first call /api/v1.0/IdLists/LegendSphere to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "Bartz" and "DEF +20" in the IdList (the id is 235 in this case)
        /// - Finally you call this api: api/v1.0/LegendSpheres/235
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendSpheres/235 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="legendSphereId">the integer id for the desired LegendSphere; it can be found in the LegendSphere IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendSpheresRoute_Id)]
        [SwaggerOperation(nameof(GetLegendSpheresById))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendSpheresById(int legendSphereId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendSpheresById)}");

            IEnumerable<LegendSphere> model = _legendSpheresLogic.GetLegendSpheresById(legendSphereId);

            IEnumerable<D.LegendSphere> result = _mapper.Map<IEnumerable<D.LegendSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendSpheres that belong to Characters in the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendSpheres that belong to Characters in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/LegendSpheres/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendSpheres/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendSpheresRoute_RealmType)]
        [SwaggerOperation(nameof(GetLegendSpheresByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendSpheresByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendSpheresByRealm)}");

            IEnumerable<LegendSphere> model = _legendSpheresLogic.GetLegendSpheresByRealm(realmType);

            IEnumerable<D.LegendSphere> result = _mapper.Map<IEnumerable<D.LegendSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendSpheres that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendSpheres that belong to Bartz.
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/LegendSpheres/Character/73
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendSpheres/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendSpheresRoute_Character)]
        [SwaggerOperation(nameof(GetLegendSpheresByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendSpheresByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendSpheresByCharacter)}");

            IEnumerable<LegendSphere> model = _legendSpheresLogic.GetLegendSpheresByCharacter(characterId);

            IEnumerable<D.LegendSphere> result = _mapper.Map<IEnumerable<D.LegendSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendSpheres whose Benefit contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendSpheres with "Silence Imm" as their benefit.
        /// - You can straight away call this api: api/v1.0/LegendMaterias/LegendSpheres/dualcast";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendSpheres/Benefit/silence%20imm (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="benefit">the string that must be a part of a LegendSpheres's Benefit text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendSpheresRoute_Benefit)]
        [SwaggerOperation(nameof(GetLegendSpheresByBenefit))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendSpheresByBenefit(string benefit)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendSpheresByBenefit)}");

            IEnumerable<LegendSphere> model = _legendSpheresLogic.GetLegendSpheresByBenefit(benefit);

            IEnumerable<D.LegendSphere> result = _mapper.Map<IEnumerable<D.LegendSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendSpheres that require Motes of the specified type
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendSpheres that require Bravery and Dexterity motes.
        /// Unlike most of the api calls that take string parameters, this query is an exact match by text - NOT a contains match. 
        /// Case is still ignored. 
        /// The order in which you specify the more types does not matter.
        /// - You can straight away call this api: api/v1.0/LegendSpheres/RequiredMotes/bravery/dexterity";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendSpheres/RequiredMotes/bravery/dexterity (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="moteType1">the (complete) string value of the first type of mote the LegendSphere uses</param>
        /// <param name="moteType2">the (complete) string value of the second type of mote the LegendSphere uses</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendSphere&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendSpheresRoute_RequiredMotes)]
        [SwaggerOperation(nameof(GetLegendSpheresByRequiredMotes))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendSpheresByRequiredMotes(string moteType1, string moteType2)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendSpheresByRequiredMotes)}");

            IEnumerable<LegendSphere> model = _legendSpheresLogic.GetLegendSpheresByRequiredMotes(moteType1, moteType2);

            IEnumerable<D.LegendSphere> result = _mapper.Map<IEnumerable<D.LegendSphere>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendSpheres that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full LegendSphere object as a search template, only the following fields are used in the search (all others are ignored):
        /// - Realm
        /// - CharacterId 
        /// - More criteria may be added to this search in the future
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any LegendSphere in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all LegendSpheres that have an RealmType of "VI"
        /// - You first call Type List Apis to get the id for RealmType = VI (the id is 6))
        /// - You create an LegendSphere object and fill in the above 6 into the Realm property
        /// - You attach the LegendSphere specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/LegendSpheres/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendSpheres/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the LegendSphere object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendSphere&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.LegendSpheresRoute_Search)]
        [SwaggerOperation(nameof(GetLegendSpheresBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendSpheresBySearch([FromBody]D.LegendSphere searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendSpheresBySearch)}");

            LegendSphere legendSphere = _mapper.Map<LegendSphere>(searchPrototype);

            IEnumerable<LegendSphere> model = _legendSpheresLogic.GetLegendSpheresBySearch(legendSphere);

            IEnumerable<D.LegendSphere> result = _mapper.Map<IEnumerable<D.LegendSphere>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
