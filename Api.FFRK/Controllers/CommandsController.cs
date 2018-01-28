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
    public interface ICommandsController
    {
        IActionResult GetAllCommands();
        IActionResult GetCommandsById(int commandId);

        IActionResult GetCommandsByAbilityType(int abilityType);
        IActionResult GetCommandsByCharacter(int characterId);
        IActionResult GetCommandsBySchool(int schoolType);
        IActionResult GeCommandsByElement(int elementType);
        IActionResult GetCommandsBySearch(D.Command searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class CommandsController : Controller, ICommandsController
    {
        #region Class Variables

        private readonly ICommandsLogic _commandsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<CommandsController> _logger;
        #endregion

        #region Constructors

        public CommandsController(ICommandsLogic commandsLogic, IMapper mapper, ILogger<CommandsController> logger)
        {
            _commandsLogic = commandsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ICommandsController Implementation

        [HttpGet]
        [Route(RouteConstants.CommandsRoute_All)]
        [SwaggerOperation(nameof(GetAllCommands))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllCommands()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllCommands)}");

            IEnumerable<Command> model = _commandsLogic.GetAllCommands();

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.CommandsRoute_Id)]
        [SwaggerOperation(nameof(GetCommandsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsById(int commandId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsById)}");

            IEnumerable<Command> model = _commandsLogic.GetCommandsById(commandId);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.CommandsRoute_AbilityType)]
        [SwaggerOperation(nameof(GetCommandsByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsByAbilityType)}");

            IEnumerable<Command> model = _commandsLogic.GetCommandsByAbilityType(abilityType);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.CommandsRoute_Character)]
        [SwaggerOperation(nameof(GetCommandsByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsByCharacter)}");

            IEnumerable<Command> model = _commandsLogic.GetCommandsByCharacter(characterId);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.CommandsRoute_School)]
        [SwaggerOperation(nameof(GetCommandsBySchool))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsBySchool(int schoolType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsBySchool)}");

            IEnumerable<Command> model = _commandsLogic.GetCommandBySchool(schoolType);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.CommandsRoute_Element)]
        [SwaggerOperation(nameof(GeCommandsByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GeCommandsByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GeCommandsByElement)}");

            IEnumerable<Command> model = _commandsLogic.GetCommandByElement(elementType);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        [HttpPost]
        [Route(RouteConstants.CommandsRoute_Search)]
        [SwaggerOperation(nameof(GetCommandsBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsBySearch([FromBody]D.Command searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsBySearch)}");

            Command command = _mapper.Map<Command>(searchPrototype);

            IEnumerable<Command> model = _commandsLogic.GetCommandsBySearch(command);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
