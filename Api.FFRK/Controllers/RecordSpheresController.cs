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
    public interface IRecordSpheresController
    {
        IActionResult GetAllRecordSpheres();
        IActionResult GetRecordSpheresById(int recordSphereId);
        IActionResult GetRecordSpheresByRealm(int realmType);
        IActionResult GetRecordSpheresByCharacter(int characterId);
        IActionResult GetRecordSpheresByBenefit(string benefit);
        IActionResult GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2);
        IActionResult GetRecordSpheresBySearch(D.RecordSphere searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RecordSpheresController : Controller, IRecordSpheresController
    {
        #region Class Variables

        private readonly IRecordSpheresLogic _recordSpheresLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordSpheresController> _logger;
        #endregion

        #region Constructors

        public RecordSpheresController(IRecordSpheresLogic recordSpheresLogic, IMapper mapper, ILogger<RecordSpheresController> logger)
        {
            _recordSpheresLogic = recordSpheresLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRecordSpheresController Implementation

        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_All)]
        [SwaggerOperation(nameof(GetAllRecordSpheres))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllRecordSpheres()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllRecordSpheres)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetAllRecordSpheres();

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_Id)]
        [SwaggerOperation(nameof(GetRecordSpheresById))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresById(int recordSphereId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresById)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresById(recordSphereId);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_RealmType)]
        [SwaggerOperation(nameof(GetRecordSpheresByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresByRealm)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresByRealm(realmType);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_Character)]
        [SwaggerOperation(nameof(GetRecordSpheresByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresByCharacter)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresByCharacter(characterId);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_Benefit)]
        [SwaggerOperation(nameof(GetRecordSpheresByBenefit))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresByBenefit(string benefit)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresByBenefit)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresByBenefit(benefit);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordSpheresRoute_RequiredMotes)]
        [SwaggerOperation(nameof(GetLRecordSpheresByRequiredMotes))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLRecordSpheresByRequiredMotes)}");

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetLRecordSpheresByRequiredMotes(moteType1, moteType2);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        [HttpPost]
        [Route(RouteConstants.RecordSpheresRoute_Search)]
        [SwaggerOperation(nameof(GetRecordSpheresBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordSphere>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSpheresBySearch([FromBody]D.RecordSphere searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSpheresBySearch)}");

            RecordSphere recordSphere = _mapper.Map<RecordSphere>(searchPrototype);

            IEnumerable<RecordSphere> model = _recordSpheresLogic.GetRecordSpheresBySearch(recordSphere);

            IEnumerable<D.RecordSphere> result = _mapper.Map<IEnumerable<D.RecordSphere>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
