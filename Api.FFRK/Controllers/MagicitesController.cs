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
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;
using FFRKApi.Model.EnlirTransform;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IMagicitesController
    {
        //Magicite
        IActionResult GetAllMagicites();
        IActionResult GetMagicitesById(int magiciteId);
        IActionResult GetMagicitesByName(string magiciteName);
        IActionResult GetMagicitesByRealm(int realmType);
        IActionResult GetMagicitesByRarity(int rarity);
        IActionResult GetMagicitesByElement(int elementType);
        IActionResult GetMagicitesByPassiveEffect(string passiveEffect);

        //UltraSkill
        IActionResult GetMagicitesByUltraSkillName(string ultraSkillName);
        IActionResult GetMagicitesByUltraSkillAbilityType(int abilityType);
        IActionResult GetMagicitesByUltraSkillElement(int elementType);
        IActionResult GetMagicitesByUltraSkillEffect(string effectText);

        //MagiciteSkill
        IActionResult GetMagicitesByMagiciteSkillId(int magiciteSkillId);
        IActionResult GetMagicitesByMagiciteSkillName(string magiciteSkillName);
        IActionResult GetMagicitesByMagiciteSkillAbilityType(int abilityType);
        IActionResult GetMagicitesByMagiciteSkillElement(int elementType);
        IActionResult GetMagicitesByMagiciteSkillEffect(string effectText);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class MagicitesController : Controller, IMagicitesController
    {
        #region Class Variables

        private readonly IMagicitesLogic _magicitesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<MagicitesController> _logger;
        #endregion

        #region Constructors

        public MagicitesController(IMagicitesLogic magicitesLogic, IMapper mapper, ILogger<MagicitesController> logger)
        {
            _magicitesLogic = magicitesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IMagicitesController Implementation

        //Magicite
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_All)]
        [SwaggerOperation(nameof(GetAllMagicites))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMagicites()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMagicites)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetAllMagicites();

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Id)]
        [SwaggerOperation(nameof(GetMagicitesById))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesById(int magiciteId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesById)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesById(magiciteId);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Name)]
        [SwaggerOperation(nameof(GetMagicitesByName))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByName(string magiciteName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByName)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByName(magiciteName);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_RealmType)]
        [SwaggerOperation(nameof(GetMagicitesByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByRealm)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByRealm(realmType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Rarity)]
        [SwaggerOperation(nameof(GetMagicitesByRarity))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByRarity(int rarity)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByRarity)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByRarity(rarity);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Element)]
        [SwaggerOperation(nameof(GetMagicitesByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByElement)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByElement(elementType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Effect)]
        [SwaggerOperation(nameof(GetMagicitesByPassiveEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByPassiveEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByPassiveEffect)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByPassiveEffect(effectText);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        //UltraSkill

        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_Name)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillName))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillName(string ultraSkillName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillName)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillName(ultraSkillName);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_AbilityType)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillAbilityType)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillAbilityType(abilityType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_Element)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillElement)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillElement(elementType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_Effect)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillEffect)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillEffect(effectText);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        //MagiciteSkill

        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Id)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillId))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillId(int magiciteSkillId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillId)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillId(magiciteSkillId);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Name)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillName))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillName(string magiciteSkillName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillName)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillName(magiciteSkillName);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_AbilityType)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillAbilityType)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillAbilityType(abilityType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Element)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillElement)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillElement(elementType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Effect)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillEffect)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillEffect(effectText);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
