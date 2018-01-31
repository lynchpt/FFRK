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
