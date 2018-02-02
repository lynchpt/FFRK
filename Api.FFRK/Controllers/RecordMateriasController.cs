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
    public interface IRecordMateriasController
    {
        IActionResult GetAllRecordMaterias();
        IActionResult GetRecordMateriasById(int recordMateriaId);
        IActionResult GetRecordMateriasByName(string recordMateriaName);
        IActionResult GetAllRecordMateriasByRealm(int realmType);
        IActionResult GetRecordMateriasByCharacter(int characterId);
        IActionResult GetRecordMateriasByEffect(string effectText);
        IActionResult GetRecordMateriasByUnlockCriteria(string unlockText);
        IActionResult GetRecordMateriasBySearch(D.RecordMateria searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RecordMateriasController : Controller, IRecordMateriasController
    {
        #region Class Variables

        private readonly IRecordMateriasLogic _recordMateriasLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordMateriasController> _logger;
        #endregion

        #region Constructors

        public RecordMateriasController(IRecordMateriasLogic recordMateriasLogic, IMapper mapper, ILogger<RecordMateriasController> logger)
        {
            _recordMateriasLogic = recordMateriasLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRecordMateriasController Implementation

        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_All)]
        [SwaggerOperation(nameof(GetAllRecordMaterias))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllRecordMaterias()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllRecordMaterias)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetAllRecordMaterias();

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Id)]
        [SwaggerOperation(nameof(GetRecordMateriasById))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasById(int recordMateriaId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasById)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasById(recordMateriaId);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Name)]
        [SwaggerOperation(nameof(GetRecordMateriasByName))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByName(string recordMateriaName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByName)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByName(recordMateriaName);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_RealmType)]
        [SwaggerOperation(nameof(GetAllRecordMateriasByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllRecordMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllRecordMateriasByRealm)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetAllRecordMateriasByRealm(realmType);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Character)]
        [SwaggerOperation(nameof(GetRecordMateriasByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByCharacter)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByCharacter(characterId);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Effect)]
        [SwaggerOperation(nameof(GetRecordMateriasByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByEffect)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByEffect(effectText);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.RecordMateriasRoute_Unlock)]
        [SwaggerOperation(nameof(GetRecordMateriasByUnlockCriteria))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasByUnlockCriteria(string unlockText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasByUnlockCriteria)}");

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasByUnlockCriteria(unlockText);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }

        [HttpPost]
        [Route(RouteConstants.RecordMateriasRoute_Search)]
        [SwaggerOperation(nameof(GetRecordMateriasBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.RecordMateria>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriasBySearch([FromBody]D.RecordMateria searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriasBySearch)}");

            RecordMateria recordMateria = _mapper.Map<RecordMateria>(searchPrototype);

            IEnumerable<RecordMateria> model = _recordMateriasLogic.GetRecordMateriasBySearch(recordMateria);

            IEnumerable<D.RecordMateria> result = _mapper.Map<IEnumerable<D.RecordMateria>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
