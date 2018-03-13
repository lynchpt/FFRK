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
    public interface IRelicsController
    {
        IActionResult GetAllRelics();
        IActionResult GetRelicsById(int relicId);
        IActionResult GetRelicsByIdMulti(IEnumerable<int> relicIds); //POST
        IActionResult GetRelicsByName(string relicName);
        IActionResult GetRelicsByRealm(int realmType);
        IActionResult GetRelicsByCharacter(int characterId);
        IActionResult GetRelicsBySoulBreak(int soulBreakId);
        IActionResult GetRelicsByLegendMateria(int legendMateriaId);
        IActionResult GetRelicsByRelicType(int relicType);
        IActionResult GetRelicsByEffect(string effectText);
        IActionResult GetRelicsByRarity(int rarity);
        IActionResult GetRelicsByStat(int statSetType, int statType, int statValue);
        IActionResult GetRelicsBySearch(D.Relic searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RelicsController : Controller, IRelicsController
    {
        #region Class Variables

        private readonly IRelicsLogic _relicsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RelicsController> _logger;
        #endregion

        #region Constructors

        public RelicsController(IRelicsLogic relicsLogic, IMapper mapper, ILogger<RelicsController> logger)
        {
            _relicsLogic = relicsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRelicsController Implementation

        /// <summary>
        /// Gets all Relics and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Relics, it is faster to get each individual Relic instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_All)]
        [SwaggerOperation(nameof(GetAllRelics))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllRelics()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllRelics)}");

            IEnumerable<Relic> model = _relicsLogic.GetAllRelics();

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Relic by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Ichigeki Relic from Realm VI 
        /// - You first call /api/v1.0/IdLists/Relic to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "Ichigeki" and "VI" in the IdList (the id is 32 in this case)
        /// - Finally you call this api: api/v1.0/Relics/32
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/32 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="relicId">the integer id for the desired Relic; it can be found in the Relic IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_Id)]
        [SwaggerOperation(nameof(GetRelicsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsById(int relicId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsById)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsById(relicId);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }


        /// <summary>
        /// Gets a multiple of Relics, corresponding to a specified list of unique Relic ids
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the several Relics in the same call 
        /// - You first call /api/v1.0/IdLists/Relic to get the proper IdList
        /// - Then you look up the integer Key associated with the Values that relate to the Relics of interest. 
        /// Alternatively, from a different api call you may have already retrieved a list of Relic ids.
        /// - Finally you call this api: api/v1.0/Relics/ {POST Body - array of integers}
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/ [POST] (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="relicId">the integer id for the desired Relic; it can be found in the Relic IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.RelicsRoute_IdMulti)]
        [SwaggerOperation(nameof(GetRelicsByIdMulti))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByIdMulti([FromBody]IEnumerable<int> relicIds)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByIdMulti)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByIdMulti(relicIds);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }


        /// <summary>
        /// Gets all Relics whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Relics with "Dragon" in their name.
        /// - You can straight away call this api: api/v1.0/Relics/Name/dragon";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/Name/dragon (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="relicName">the string that must be a part of a Relic's name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_Name)]
        [SwaggerOperation(nameof(GetRelicsByName))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByName(string relicName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByName)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByName(relicName);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Relics that belong to Characters in the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Relics that belong to Characters in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Relics/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_RealmType)]
        [SwaggerOperation(nameof(GetRelicsByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByRealm)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByRealm(realmType);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Relics that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Relics that belong to Bartz.
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/Relics/Character/73
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_Character)]
        [SwaggerOperation(nameof(GetRelicsByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByCharacter)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByCharacter(characterId);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets the Relic instance associated with the specified Soul Break
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Relic that is associated with the "Sentinel's Grimoire" Soul Break
        /// - You first call /api/v1.0/IdLists/SoulBreak to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Sentinel's Grimoire" in the IdList (the id is 3 in this case)
        /// - Finally you call this api: api/v1.0/Relics/SoulBreak/3
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/SoulBreak/3 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="soulBreakId">the integer id for the desired Soul Break that a Relic are associated with; it can be found in the SoulBreak IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_SoulBreak)]
        [SwaggerOperation(nameof(GetRelicsBySoulBreak))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsBySoulBreak(int soulBreakId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsBySoulBreak)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsBySoulBreak(soulBreakId);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets the Relic instance associated with the specified LegendMateria
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Relic that is associated with the "Gifted Bard" LegendMateria
        /// - You first call /api/v1.0/IdLists/LegendMateria to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Gifted Bard" in the IdList (the id is 108 in this case)
        /// - Finally you call this api: api/v1.0/Relics/LegendMateria/108
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/LegendMateria/108 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="legendMateriaId">the integer id for the desired LegendMateria that a Relic is associated with; it can be found in the LegendMateria IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_LegendMateria)]
        [SwaggerOperation(nameof(GetRelicsByLegendMateria))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByLegendMateria(int legendMateriaId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByLegendMateria)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByLegendMateria(legendMateriaId);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Relics that are of the specified RelicType (Sword, Shield, etc.)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Relics that are Rods
        /// - You first call /api/v1.0/TypeLists/RelicType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Rod" in the IdList (the id is 8 in this case)
        /// - Finally you call this api: api/v1.0/Relics/RelicType/8
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/RelicType/8 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="relicType">the integer id for the desired RelicType; it can be found in the RelicType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_RelicType)]
        [SwaggerOperation(nameof(GetRelicsByRelicType))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByRelicType(int relicType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByRelicType)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByRelicType(relicType);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Relics whose Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Relics with "Wind" as their effect.
        /// - You can straight away call this api: api/v1.0/Relics/Effect/wind";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/Effect/wind (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a Relic's Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_Effect)]
        [SwaggerOperation(nameof(GetRelicsByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByEffect)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByEffect(effectText);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Relics that have the specified Rarity
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Relics that have an Rarity of 5 (as in 5*)
        /// - You can straight away call this api: api/v1.0/Relics/Rarity/5";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/Rarity/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="rarity">the integer rarity that all returned Relics need to share</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_Rarity)]
        [SwaggerOperation(nameof(GetRelicsByRarity))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByRarity(int rarity)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByRarity)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByRarity(rarity);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Relics that that equal or exceed the specified StatValue for the specified StatType, which belongs to the specified StatSetType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Relics that equal or exceed a StatValue of 180 for a StatType of ATK, for a StatSetType of Max (= fully ++ combined)
        /// - You first call /api/v1.0/TypeLists/StatType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "ATK" in the TypeList (the id is 2 in this case)
        /// - You then call /api/v1.0/TypeLists/StatSetType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "MAX" in the TypeList (the id is 3 in this case)
        /// - Finally you call this api: api/v1.0/Relics/Stat/3/2/180
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/Rarity/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="statSetType">e.g. Max, Base</param>
        /// <param name="statType">e.g. ATK, DEF</param>
        /// <param name="statValue">the integer value whoch you want the specified relic stat to equal or exceed</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.RelicsRoute_Stat)]
        [SwaggerOperation(nameof(GetRelicsByStat))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsByStat(int statSetType, int statType, int statValue)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsByStat)}");

            IEnumerable<Relic> model = _relicsLogic.GetRelicsByStat(statSetType, statType, statValue);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Relics that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full Relic object as a search template, only the following fields are used in the search (all others are ignored):
        /// - RelicName (comparison is Contains, not exact match)
        /// - Realm
        /// - CharacterId
        /// - SoulBreakId
        /// - LegendMateriaId
        /// - RelicType
        /// - Effect (comparison is Contains, not exact match)
        /// - Rarity
        /// - Accuracy (value specified or greater)
        /// - Attack (value specified or greater)
        /// - Defense (value specified or greater)
        /// - Evasion (value specified or greater)
        /// - Magic (value specified or greater)
        /// - Mind (value specified or greater)
        /// - Resistance (value specified or greater)
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any Relic in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Relics that have an RealmType of "VI" and a RelicType of "Sword"
        /// - You first call TypeList Apis to get the id for RealmType = VI (the id is 6)) and the id for RelicType = Sword (the id is 2)
        /// - You create an Relic object and fill in the above 6 into the Realm property, and 2 into the RelicType property
        /// - You attach the Relic specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/Relics/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Relics/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Relic object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Relic&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.RelicsRoute_Search)]
        [SwaggerOperation(nameof(GetRelicsBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.Relic>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicsBySearch([FromBody]D.Relic searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicsBySearch)}");

            Relic relic = _mapper.Map<Relic>(searchPrototype);

            IEnumerable<Relic> model = _relicsLogic.GetRelicsBySearch(relic);

            IEnumerable<D.Relic> result = _mapper.Map<IEnumerable<D.Relic>>(model);

            return new ObjectResult(result);
        }

        //comment to force push to azure
        #endregion
    }
}
