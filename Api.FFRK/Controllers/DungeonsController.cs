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

        [HttpPost]
        [Route(RouteConstants.CharactersRoute_Search)]
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

        #endregion

    }
}
