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
    public interface ILegendMateriasController
    {
        IActionResult GetAllLegendMaterias();
        IActionResult GetLegendMateriasById(int legendMateriaId);
        IActionResult GetLegendMateriasByName(string legendMateriaName);
        IActionResult GetLegendMateriasByRealm(int realmType);
        IActionResult GetLegendMateriasByCharacter(int characterId);
        IActionResult GetLegendMateriasByEffect(string effectText);
        IActionResult GetLegendMateriasByMasteryBonus(string masteryBonusText);
        IActionResult GetLegendMateriasByRelic(int relicId);
        IActionResult GetLegendMateriasBySearch(D.LegendMateria searchPrototype);

    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class LegendMateriasController : Controller, ILegendMateriasController
    {
        #region Class Variables

        private readonly ILegendMateriasLogic _legendMateriasLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<LegendMateriasController> _logger;
        #endregion

        #region Constructors

        public LegendMateriasController(ILegendMateriasLogic legendMateriasLogic, IMapper mapper, ILogger<LegendMateriasController> logger)
        {
            _legendMateriasLogic = legendMateriasLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ILegendMateriasController Implementation

        /// <summary>
        /// Gets all LegendMaterias and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of LegendMaterias, it is faster to get each individual ability instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_All)]
        [SwaggerOperation(nameof(GetAllLegendMaterias))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllLegendMaterias()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllLegendMaterias)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetAllLegendMaterias();

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one LegendMateria by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the LegendMateria called "Windborn Warrior" (owned by Luneth)
        /// - You first call /api/v1.0/IdLists/LegendMateria to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Windborn Warrior" in the IdList (the id is 43 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/4
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/43 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="legendMateriaId">the integer id for the desired LegendMateria; it can be found in the LegendMateria IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_Id)]
        [SwaggerOperation(nameof(GetLegendMateriasById))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasById(int legendMateriaId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasById)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasById(legendMateriaId);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendMaterias whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Dungeons with "Warrior" in their name.
        /// - You can straight away call this api: api/v1.0/Dungeons/Name/lunar";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/Name/warrior (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="legendMateriaName">the string that must be a part of a LegendMateria's name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_Name)]
        [SwaggerOperation(nameof(GetLegendMateriasByName))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasByName(string legendMateriaName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasByName)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasByName(legendMateriaName);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendMaterias that belong to the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendMaterias in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/LegendMaterias/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_RealmType)]
        [SwaggerOperation(nameof(GetLegendMateriasByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasByRealm)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasByRealm(realmType);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendMaterias that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendMaterias that belong to Bartz.
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/LegendMaterias/Character/73
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_Character)]
        [SwaggerOperation(nameof(GetLegendMateriasByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasByCharacter)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasByCharacter(characterId);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendMaterias whose Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendMaterias with "dualcast" as their effect.
        /// - You can straight away call this api: api/v1.0/LegendMaterias/Effect/dualcast";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/Effect/dualcast (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a LegendMateria's Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_Effect)]
        [SwaggerOperation(nameof(GetLegendMateriasByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasByEffect)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasByEffect(effectText);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendMaterias whose MasteryBonus text contains the provided string (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LegendMaterias with "MND" as the stat improved upon mastery.
        /// - You can straight away call this api: api/v1.0/LegendMaterias/Effect/dualcast";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/MasteryBonus/mnd (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a LegendMateria's MasteryBonus text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_MasteryBonus)]
        [SwaggerOperation(nameof(GetLegendMateriasByMasteryBonus))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasByMasteryBonus(string masteryBonusText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasByMasteryBonus)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasByMasteryBonus(masteryBonusText);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets the LegendMateria that associated to the specified Relic
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the LegendMateria associated to Tyro's Relic "Keeper's Cap"
        /// - You first call /api/v1.0/IdLists/Relic to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Keeper's Cap" in the IdList (the id is 1200 in this case)
        /// - Finally you call this api: api/v1.0/LegendMaterias/Relic/1200
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/Relic/1200 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="relicId">the integer id for the desired Relic; it can be found in the Relic IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_Relic)]
        [SwaggerOperation(nameof(GetLegendMateriasByRelic))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasByRelic(int relicId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasByRelic)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasByRelic(relicId);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LegendMaterias that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full LegendMateria object as a search template, only the following fields are used in the search (all others are ignored):
        /// - Realm
        /// - LegendMateriaName (comparison is Contains, not exact match)
        /// - CharacterId 
        /// - Effect (comparison is Contains, not exact match)
        /// - MasteryBonus (comparison is Contains, not exact match)
        /// - RelicId 
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any LegendMateria in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all LegendMaterias that have an RealmType of "VI" and a MasteryBonus of "ATK"
        /// - You first call Type List Apis to get the id for RealmType = VI (the id is 6))
        /// - You create an LegendMateria object and fill in the above 6 into the Realm property and "atk" into the MasteryBonus property
        /// - You attach the LegendMateria specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/LegendMaterias/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the LegendMateria object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LegendMateria&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.LegendMateriasRoute_Search)]
        [SwaggerOperation(nameof(GetLegendMateriasBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriasBySearch([FromBody]D.LegendMateria searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriasBySearch)}");

            LegendMateria legendMateria = _mapper.Map<LegendMateria>(searchPrototype);

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetLegendMateriasBySearch(legendMateria);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
