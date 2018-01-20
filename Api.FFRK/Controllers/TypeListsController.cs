using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using FFRKApi.Model.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface ITypeListsController
    {
        IActionResult GetAllTypeLists();

        IActionResult GetAbilityTypeList();
        IActionResult GetAutoTargetTypeList();
        IActionResult GetDamageFormulaTypeList();
        IActionResult GetElementTypeList();
        IActionResult GetEquipmentTypeList();
        IActionResult GetEventTypeList();
        IActionResult GetMissionTypeList();
        IActionResult GetOrbTypeList();
        IActionResult GetRealmTypeList();
        IActionResult GetRelicTypeList();
        IActionResult GetSchoolTypeList();
        IActionResult GetSoulBreakTierTypeList();
        IActionResult GetTargetTypeList();

    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class TypeListsController : Controller, ITypeListsController
    {
        #region Class Variables

        private readonly ITypeListsLogic _typeListsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<TypeListsController> _logger;
        #endregion

        #region Constructors

        public TypeListsController(ITypeListsLogic typeListsLogic, IMapper mapper, ILogger<TypeListsController> logger)
        {
            _typeListsLogic = typeListsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ITypeListsController Implementation
        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_All)]
        [SwaggerOperation(nameof(GetAllTypeLists))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllTypeLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllTypeLists)}");

            TypeListBundle model = _typeListsLogic.GetAllTypeLists();

            FFRKApi.Dto.Api.TypeListBundle result = _mapper.Map<FFRKApi.Dto.Api.TypeListBundle>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_AbilityType)]
        [SwaggerOperation(nameof(GetAbilityTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilityTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilityTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetAbilityTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_AutoTargetType)]
        [SwaggerOperation(nameof(GetAutoTargetTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetAutoTargetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAutoTargetTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetAutoTargetTypeList();

            return new ObjectResult(result);
        }


        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_DamageFormulaType)]
        [SwaggerOperation(nameof(GetDamageFormulaTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetDamageFormulaTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDamageFormulaTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetDamageFormulaTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_ElementType)]
        [SwaggerOperation(nameof(GetElementTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetElementTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetElementTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetElementTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_EquipmentType)]
        [SwaggerOperation(nameof(GetEquipmentTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetEquipmentTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEquipmentTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetEquipmentTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_EventType)]
        [SwaggerOperation(nameof(GetEventTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetEventTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetEventTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_MissionType)]
        [SwaggerOperation(nameof(GetMissionTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetMissionTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_OrbType)]
        [SwaggerOperation(nameof(GetOrbTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetOrbTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetOrbTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetOrbTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_RealmType)]
        [SwaggerOperation(nameof(GetRealmTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetRealmTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRealmTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetRealmTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_RelicType)]
        [SwaggerOperation(nameof(GetRelicTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetRelicTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_SchoolType)]
        [SwaggerOperation(nameof(GetSchoolTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetSchoolTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSchoolTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetSchoolTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_SoulBreakTierType)]
        [SwaggerOperation(nameof(GetSoulBreakTierTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreakTierTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreakTierTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetSoulBreakTierTypeList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_TargetType)]
        [SwaggerOperation(nameof(GetTargetTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetTargetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetTargetTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetTargetTypeList();

            return new ObjectResult(result);
        }

        #endregion
    }
}
