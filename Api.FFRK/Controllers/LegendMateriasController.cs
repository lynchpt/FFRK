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
        IActionResult GetAllLegendMateriasByRealm(int realmType);
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

        [HttpGet]
        [Route(RouteConstants.LegendMateriasRoute_RealmType)]
        [SwaggerOperation(nameof(GetAllLegendMateriasByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.LegendMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllLegendMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllLegendMateriasByRealm)}");

            IEnumerable<LegendMateria> model = _legendMateriasLogic.GetAllLegendMateriasByRealm(realmType);

            IEnumerable<D.LegendMateria> result = _mapper.Map<IEnumerable<D.LegendMateria>>(model);

            return new ObjectResult(result);
        }

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
