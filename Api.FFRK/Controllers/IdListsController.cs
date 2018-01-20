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
    public interface IIdListsController
    {
        IActionResult GetAllIdLists();

        IActionResult GetAbilityIdList();    
        IActionResult GetCharacterIdList();
        IActionResult GetCommandIdList();
        IActionResult GetDungeonIdList();
        IActionResult GetEventIdList();
        IActionResult GetExperienceIdList();
        IActionResult GetLegendMateriaIdList();
        IActionResult GetLegendSpheredList();
        IActionResult GetMagiciteIdList();
        IActionResult GetMagiciteSkillIdList();
        IActionResult GetMissionIdList();
        IActionResult GetOtherIdList();
        IActionResult GetRecordMateriaIdList();
        IActionResult GetRecordSphereIdList();
        IActionResult GetRelicIdList();
        IActionResult GetSoulBreakIdList();
        IActionResult GetStatusIdList();
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class IdListsController : Controller, IIdListsController
    {
        #region Class Variables

        private readonly IIdListsLogic _idListsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<IdListsController> _logger;
        #endregion

        #region Constructors

        public IdListsController(IIdListsLogic idListsLogic, IMapper mapper, ILogger<IdListsController> logger)
        {
            _idListsLogic = idListsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IIdListsController Implementation

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_All)]
        [SwaggerOperation(nameof(GetAllIdLists))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllIdLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllIdLists)}");

            IdListBundle model = _idListsLogic.GetAllIdLists();

            FFRKApi.Dto.Api.IdListBundle result = _mapper.Map<FFRKApi.Dto.Api.IdListBundle>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Ability)]
        [SwaggerOperation(nameof(GetAbilityIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilityIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilityIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetAbilityIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Character)]
        [SwaggerOperation(nameof(GetCharacterIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharacterIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharacterIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetCharacterIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Command)]
        [SwaggerOperation(nameof(GetCommandIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetCommandIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Dungeon)]
        [SwaggerOperation(nameof(GetDungeonIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetDungeonIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetDungeonIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetDungeonIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Event)]
        [SwaggerOperation(nameof(GetEventIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetEventIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetEventIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetEventIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Experience)]
        [SwaggerOperation(nameof(GetExperienceIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetExperienceIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetExperienceIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetExperienceIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_LegendMateria)]
        [SwaggerOperation(nameof(GetLegendMateriaIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendMateriaIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendMateriaIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetLegendMateriaIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_LegendSphere)]
        [SwaggerOperation(nameof(GetLegendSpheredList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetLegendSpheredList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLegendSpheredList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetLegendSpheredList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Magicite)]
        [SwaggerOperation(nameof(GetMagiciteIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagiciteIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagiciteIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetMagiciteIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_MagiciteSkill)]
        [SwaggerOperation(nameof(GetMagiciteSkillIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagiciteSkillIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagiciteSkillIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetMagiciteSkillIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Mission)]
        [SwaggerOperation(nameof(GetMissionIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetMissionIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMissionIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetMissionIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Other)]
        [SwaggerOperation(nameof(GetOtherIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetOtherIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetOtherIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetOtherIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_RecordMateria)]
        [SwaggerOperation(nameof(GetRecordMateriaIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordMateriaIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordMateriaIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetRecordMateriaIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_RecordSphere)]
        [SwaggerOperation(nameof(GetRecordSphereIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecordSphereIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRecordSphereIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetRecordSphereIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Relic)]
        [SwaggerOperation(nameof(GetRelicIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetRelicIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRelicIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetRelicIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_SoulBreak)]
        [SwaggerOperation(nameof(GetSoulBreakIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreakIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreakIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetSoulBreakIdList();

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.IdListsRoute_Status)]
        [SwaggerOperation(nameof(GetStatusIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatusIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetStatusIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetStatusIdList();

            return new ObjectResult(result);
        }

        #endregion


    }
}
