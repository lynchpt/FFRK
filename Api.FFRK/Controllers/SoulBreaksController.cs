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
    public interface ISoulBreaksController
    {
        IActionResult GetAllSoulBreaks();
        IActionResult GetSoulBreaksById(int soulBreakId);
        IActionResult GetSoulBreaksByAbilityType(int abilityType);
        IActionResult GetSoulBreaksByName(string soulBreakName);
        IActionResult GetSoulBreaksByRealm(int realmType);
        IActionResult GetSoulBreaksByCharacter(int characterId);
        IActionResult GetSoulBreaksByMultiplier(int multiplier);
        IActionResult GetSoulBreaksByElement(int elementType);
        IActionResult GetSoulBreaksByEffect(string effectText);
        IActionResult GetSoulBreaksByTier(int soulBreakTier);
        IActionResult GetSoulBreaksByMasteryBonus(string masteryBonusText);
        IActionResult GetSoulBreaksByStatus(int statusId);
        IActionResult GetSoulBreaksBySearch(D.SoulBreak searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class SoulBreaksController : Controller, ISoulBreaksController
    {
        #region Class Variables

        private readonly ISoulBreaksLogic _soulBreaksLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<SoulBreaksController> _logger;
        #endregion

        #region Constructors

        public SoulBreaksController(ISoulBreaksLogic soulBreaksLogic, IMapper mapper, ILogger<SoulBreaksController> logger)
        {
            _soulBreaksLogic = soulBreaksLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ISoulBreaksController Implementation

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_All)]
        [SwaggerOperation(nameof(GetAllSoulBreaks))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllSoulBreaks()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllSoulBreaks)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetAllSoulBreaks();

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Id)]
        [SwaggerOperation(nameof(GetSoulBreaksById))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksById(int soulBreakId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksById)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksById(soulBreakId);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_AbilityType)]
        [SwaggerOperation(nameof(GetSoulBreaksByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByAbilityType)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByAbilityType(abilityType);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Name)]
        [SwaggerOperation(nameof(GetSoulBreaksByName))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByName(string soulBreakName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByName)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByName(soulBreakName);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_RealmType)]
        [SwaggerOperation(nameof(GetSoulBreaksByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByRealm)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByRealm(realmType);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Character)]
        [SwaggerOperation(nameof(GetSoulBreaksByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByCharacter)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByCharacter(characterId);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Multiplier)]
        [SwaggerOperation(nameof(GetSoulBreaksByMultiplier))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByMultiplier(int multiplier)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByMultiplier)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByMultiplier(multiplier);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Element)]
        [SwaggerOperation(nameof(GetSoulBreaksByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByElement)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByElement(elementType);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Effect)]
        [SwaggerOperation(nameof(GetSoulBreaksByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByEffect)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByEffect(effectText);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Tier)]
        [SwaggerOperation(nameof(GetSoulBreaksByTier))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByTier(int soulBreakTier)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByTier)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByTier(soulBreakTier);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_MasteryBonus)]
        [SwaggerOperation(nameof(GetSoulBreaksByMasteryBonus))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByMasteryBonus(string masteryBonusText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByMasteryBonus)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByMasteryBonus(masteryBonusText);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Status)]
        [SwaggerOperation(nameof(GetSoulBreaksByStatus))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByStatus(int statusId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByStatus)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByStatus(statusId);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        [HttpPost]
        [Route(RouteConstants.SoulBreaksRoute_Search)]
        [SwaggerOperation(nameof(GetSoulBreaksBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksBySearch([FromBody]D.SoulBreak searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksBySearch)}");

            SoulBreak soulBreak = _mapper.Map<SoulBreak>(searchPrototype);

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksBySearch(soulBreak);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
