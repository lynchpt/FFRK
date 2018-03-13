using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;


namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IDungeonsController
    {
        IActionResult GetAllDungeons();
        IActionResult GetDungeonsById(int dungeonId);
        IActionResult GetDungeonsByRealm(int realmType);
        IActionResult GeDungeonsByName(string dungeonName);
        IActionResult GetDungeonsByRewards(string itemName, int starlevel);
        IActionResult GetDungeonsBySearch(D.Dungeon searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class DungeonsController : Controller, IDungeonsController
    {
        #region Class Variables

        private readonly IDungeonsLogic _dungeonsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<DungeonsController> _logger;
        #endregion

        #region Constructors

        public DungeonsController(IDungeonsLogic dungeonsLogic, IMapper mapper, ILogger<DungeonsController> logger)
        {
            _dungeonsLogic = dungeonsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IDungeonsController Implementation

        /// <summary>
        /// Gets all Dungeons and their associated data.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Dungeons, it is faster to get each individual Dungeons instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Dungeons (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Dungeon&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.DungeonsRoute_All)]
        [SwaggerOperation(nameof(GetAllDungeons))]
        [ProducesResponseType(typeof(IEnumerable<D.Dungeon>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllDungeons()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllDungeons)}");

            IEnumerable<Dungeon> model = _dungeonsLogic.GetAllDungeons();

            IEnumerable<D.Dungeon> result = _mapper.Map<IEnumerable<D.Dungeon>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Dungeon by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Dungeon named "Mist Cave"
        /// - You first call /api/v1.0/IdLists/Dungeon to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Mist Cave" in the IdList (the id is 61 in this case)
        /// - Finally you call this api: api/v1.0/Dungeons/61
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Dungeons/61 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="dungeonId">the integer id for the desired Dungeon; it can be found in the Dungeon IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Dungeon&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.DungeonsRoute_Id)]
        [SwaggerOperation(nameof(GetDungeonsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Dungeon>), (int)HttpStatusCode.OK)]
        public IActionResult GetDungeonsById(int dungeonId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetDungeonsById)}");

            IEnumerable<Dungeon> model = _dungeonsLogic.GetDungeonsById(dungeonId);

            IEnumerable<D.Dungeon> result = _mapper.Map<IEnumerable<D.Dungeon>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Dungeons that belong to the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Dungeons in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Dungeons/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Dungeons/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Dungeon&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.DungeonsRoute_RealmType)]
        [SwaggerOperation(nameof(GetDungeonsByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.Dungeon>), (int)HttpStatusCode.OK)]
        public IActionResult GetDungeonsByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetDungeonsByRealm)}");

            IEnumerable<Dungeon> model = _dungeonsLogic.GetDungeonsByRealm(realmType);

            IEnumerable<D.Dungeon> result = _mapper.Map<IEnumerable<D.Dungeon>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Dungeons whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Dungeons with "Lunar" in their name.
        /// - You can straight away call this api: api/v1.0/Dungeons/Name/lunar";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Dungeons/Name/lunar (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="dungeonName">the string that must be a part of a Dungeon's name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Dungeon&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.DungeonsRoute_Name)]
        [SwaggerOperation(nameof(GeDungeonsByName))]
        [ProducesResponseType(typeof(IEnumerable<D.Dungeon>), (int)HttpStatusCode.OK)]
        public IActionResult GeDungeonsByName(string dungeonName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetDungeonsByRealm)}");

            IEnumerable<Dungeon> model = _dungeonsLogic.GetDungeonsByName(dungeonName);

            IEnumerable<D.Dungeon> result = _mapper.Map<IEnumerable<D.Dungeon>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Dungeons whose rewards include the specified item, at the specified star level (if star level is relevant for a particular item). 
        /// The item name is used as a Contains query, and does not need to be an exact match to the actual reward item. The star level should be set to 0 for
        /// items that do not have a star level
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Dungeons that rewards 4* Bravery Motes.
        /// - You can straight away call this api: api/v1.0/Dungeons/Rewards/bravery/4";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Rewards/{itemName}/{starLevel} (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="itemName">the string that must be a part of one of the Dungeon's reward items in order for the Dungeon to be returned by this api call.</param>
        /// <param name="starlevel">the integer star level of the item; use 0 if the item has no star level (like Mythril, for example).</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Dungeon&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.DungeonsRoute_Rewards)]
        [SwaggerOperation(nameof(GetDungeonsByRewards))]
        [ProducesResponseType(typeof(IEnumerable<D.Dungeon>), (int)HttpStatusCode.OK)]
        public IActionResult GetDungeonsByRewards(string itemName, int starlevel)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetDungeonsByRewards)}");

            IEnumerable<Dungeon> model = _dungeonsLogic.GetDungeonsByRewards(itemName, starlevel);

            IEnumerable<D.Dungeon> result = _mapper.Map<IEnumerable<D.Dungeon>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Dungeons that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full Dungeon object as a search template, only the following fields are used in the search (all others are ignored):
        /// - DungeonName (comparison is Contains, not exact match)
        /// - Realm
        /// - StaminaClassic (value specified or less)
        /// - StaminaElite (value specified or less)
        /// - DifficultyClassic (value specified or less)
        /// - DifficultyElite (value specified or less)
        /// - CompletionGilClassic (value specified or greater)
        /// - CompletionGilElite (value specified or greater)
        /// - FirstTimeRewardsClassic (only the first in the list is considered)
        /// - FirstTimeRewardsElite (only the first in the list is considered)
        /// - MasteryRewardsClassic (only the first in the list is considered)
        /// - MasteryRewardsElite (only the first in the list is considered)
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any Dungeon in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Dungeons in Realm VI whose Elite Difficulty is lesas than 120
        /// - You first call Type List Apis to get the ids for RealmType = VI (the id is 6 in this case)
        /// - You create an Dungeon object and fill in 6 into the Realm property
        /// - You fill in 120 into the DifficultyElite property
        /// - You attach the Dungeon specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/Dungeons/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Dungeons/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Dungeon object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Dungeon&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.DungeonsRoute_Search)]
        [SwaggerOperation(nameof(GetDungeonsBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.Dungeon>), (int)HttpStatusCode.OK)]
        public IActionResult GetDungeonsBySearch([FromBody]D.Dungeon searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetDungeonsBySearch)}");

            Dungeon dungeon = _mapper.Map<Dungeon>(searchPrototype);

            IEnumerable<Dungeon> model = _dungeonsLogic.GetDungeonsBySearch(dungeon);

            IEnumerable<D.Dungeon> result = _mapper.Map<IEnumerable<D.Dungeon>>(model);

            return new ObjectResult(result);
        }

        //comment to force push to azure
        #endregion

    }
}
