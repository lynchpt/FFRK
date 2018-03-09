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
using M = FFRKApi.Model.EnlirTransform;

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

        /// <summary>
        /// Gets all Burst Soul Break Commands and their associated data.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Commands, it is faster to get each individual Command instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Command&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CommandsRoute_All)]
        [SwaggerOperation(nameof(GetAllCommands))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllCommands()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllCommands)}");

            IEnumerable<M.Command> model = _commandsLogic.GetAllCommands();

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Burst Soul Break Command by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Command identified by "Keeper's Tome - Book of Retribution"
        /// - You first call /api/v1.0/IdLists/Command to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Keeper's Tome - Book of Retribution" in the IdList (the id is 2 in this case)
        /// - Finally you call this api: api/v1.0/Commands/2
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands/2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="commandId">the integer id for the desired Command; it can be found in the Command IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Command&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CommandsRoute_Id)]
        [SwaggerOperation(nameof(GetCommandsById))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsById(int commandId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsById)}");

            IEnumerable<M.Command> model = _commandsLogic.GetCommandsById(commandId);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Burst Soul Break Commands that have the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Commands that have the AbilityType of "BLK"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "BLK" in the TypeList (the id is 2 in this case)
        /// - Finally you call this api: api/v1.0/Commands/AbilityType/2
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands/AbilityType/2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Command&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CommandsRoute_AbilityType)]
        [SwaggerOperation(nameof(GetCommandsByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsByAbilityType)}");

            IEnumerable<M.Command> model = _commandsLogic.GetCommandsByAbilityType(abilityType);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Burst Soul Break Commands that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Commands that belong to Bartz (that is, to Commands for the Burst Soul Breaks associated with the Relics that belong to Bartz)
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/Commands/Character/73
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Command&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CommandsRoute_Character)]
        [SwaggerOperation(nameof(GetCommandsByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsByCharacter)}");

            IEnumerable<M.Command> model = _commandsLogic.GetCommandsByCharacter(characterId);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Burst Soul Break Commands that belong to the specified School 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Commands that belong to the Summoning School
        /// - You first call /api/v1.0/TypeLists/SchoolType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Summoning" in the TypeList (the id is 19 in this case)
        /// - Finally you call this api: api/v1.0/Commands/School/19
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands/School/19 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="schoolType">the integer id for the desired School; it can be found in the SchoolType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Command&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CommandsRoute_School)]
        [SwaggerOperation(nameof(GetCommandsBySchool))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsBySchool(int schoolType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsBySchool)}");

            IEnumerable<M.Command> model = _commandsLogic.GetCommandBySchool(schoolType);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Burst Soul Break Commands that have the specified element 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Commands that do Fire damage
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Commands/School/19
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired Element; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Command&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CommandsRoute_Element)]
        [SwaggerOperation(nameof(GeCommandsByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GeCommandsByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GeCommandsByElement)}");

            IEnumerable<M.Command> model = _commandsLogic.GetCommandByElement(elementType);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Burst Soul Break Commands that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full Command object as a search template, only the following fields are used in the search (all others are ignored):
        /// - CharacterId
        /// - AbilityType
        /// - School 
        /// - Elements (only the first in the list is considered)
        /// - CommandName (comparison is Contains, not exact match)
        /// - AutoTargetType 
        /// - CastTime (value specified or less)
        /// - DamageFormulaType
        /// - Multiplier (value specified or greater)
        /// - SoulBreakPointsGained (value specified or greater)
        /// - TargetType
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any Command in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Commands that have an ElementType of "Fire" and a SchoolType of Black Magic
        /// - You first call Type List Apis to get the ids for Element = Fire and SchoolType = Black Magic (4 and 3)
        /// - You create an Command object and fill in the above ids into the Element collection and School property
        /// - You attach the Command specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/Abilities/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Command object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Command&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.CommandsRoute_Search)]
        [SwaggerOperation(nameof(GetCommandsBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.Command>), (int)HttpStatusCode.OK)]
        public IActionResult GetCommandsBySearch([FromBody]D.Command searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCommandsBySearch)}");

            M.Command command = _mapper.Map<M.Command>(searchPrototype);

            IEnumerable<M.Command> model = _commandsLogic.GetCommandsBySearch(command);

            IEnumerable<D.Command> result = _mapper.Map<IEnumerable<D.Command>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
