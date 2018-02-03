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

        #endregion
    }
}
