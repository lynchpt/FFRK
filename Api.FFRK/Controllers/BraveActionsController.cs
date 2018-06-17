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
using M = FFRKApi.Model.EnlirTransform;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IBraveActionsController
    {
        IActionResult GetAllBraveActions();
        IActionResult GetBraveActionsById(int braveActionId);

        IActionResult GetBraveActionsByAbilityType(int abilityType);
        IActionResult GetBraveActionsByCharacter(int characterId);
        IActionResult GetBraveActionsBySchool(int schoolType);
        IActionResult GetBraveActionsByElement(int elementType);
        IActionResult GetBraveActionsBySearch(D.BraveAction searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class BraveActionsController : Controller, IBraveActionsController
    {
        #region Class Variables

        private readonly IBraveActionsLogic _braveActionsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<BraveActionsController> _logger;
        #endregion

        #region Constructors

        public BraveActionsController(IBraveActionsLogic braveActionsLogic, IMapper mapper, ILogger<BraveActionsController> logger)
        {
            _braveActionsLogic = braveActionsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        /// <summary>
        /// Gets all Soul Break BraveActions and their associated data.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of BraveActions, it is faster to get each individual BraveActions instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/BraveActions (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;BraveAction&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.BraveActionsRoute_All)]
        [SwaggerOperation(nameof(GetAllBraveActions))]
        [ProducesResponseType(typeof(IEnumerable<D.BraveAction>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllBraveActions()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllBraveActions)}");

            IEnumerable<M.BraveAction> model = _braveActionsLogic.GetAllBraveActions();

            IEnumerable<D.BraveAction> result = _mapper.Map<IEnumerable<D.BraveAction>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Soul Break BraveAction by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the BraveAction identified by "Riot Fire"
        /// - You first call /api/v1.0/IdLists/BraveAction to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Riot Fire" in the IdList
        /// - Finally you call this api: api/v1.0/BraveActions/{id}
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Commands/2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="braveActionId">the integer id for the desired BraveAction; it can be found in the BraveAction IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;BraveAction&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.BraveActionsRoute_Id)]
        [SwaggerOperation(nameof(GetBraveActionsById))]
        [ProducesResponseType(typeof(IEnumerable<D.BraveAction>), (int)HttpStatusCode.OK)]
        public IActionResult GetBraveActionsById(int braveActionId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetBraveActionsById)}");

            IEnumerable<M.BraveAction> model = _braveActionsLogic.GetBraveActionsById(braveActionId);

            IEnumerable<D.BraveAction> result = _mapper.Map<IEnumerable<D.BraveAction>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Soul Break BraveActions that have the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all BraveActions that have the AbilityType of "BLK"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "BLK" in the TypeList (the id is 2 in this case)
        /// - Finally you call this api: api/v1.0/BraveActions/AbilityType/2
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/BraveAction/AbilityType/2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;BraveAction&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.BraveActionsRoute_AbilityType)]
        [SwaggerOperation(nameof(GetBraveActionsByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.BraveAction>), (int)HttpStatusCode.OK)]
        public IActionResult GetBraveActionsByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetBraveActionsByAbilityType)}");

            IEnumerable<M.BraveAction> model = _braveActionsLogic.GetBraveActionsByAbilityType(abilityType);

            IEnumerable<D.BraveAction> result = _mapper.Map<IEnumerable<D.BraveAction>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Soul Break BraveActions that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all BraveActions that belong to Terra (that is, to BraveActions for the Soul Breaks associated with the Relics that belong to Bartz)
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Terra" in the IdList
        /// - Finally you call this api: api/v1.0/Commands/Character/{id}
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/BraveActions/Character/{id} (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;BraveAction&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.BraveActionsRoute_Character)]
        [SwaggerOperation(nameof(GetBraveActionsByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.BraveAction>), (int)HttpStatusCode.OK)]
        public IActionResult GetBraveActionsByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetBraveActionsByCharacter)}");

            IEnumerable<M.BraveAction> model = _braveActionsLogic.GetBraveActionsByCharacter(characterId);

            IEnumerable<D.BraveAction> result = _mapper.Map<IEnumerable<D.BraveAction>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Soul Break BraveActions that belong to the specified School 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all BraveAction that belong to the Black Magic School
        /// - You first call /api/v1.0/TypeLists/SchoolType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Black Magic" in the TypeList
        /// - Finally you call this api: api/v1.0/Commands/School/{id}
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/BraveActions/School/{id} (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="schoolType">the integer id for the desired School; it can be found in the SchoolType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;BraveAction&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.BraveActionsRoute_School)]
        [SwaggerOperation(nameof(GetBraveActionsBySchool))]
        [ProducesResponseType(typeof(IEnumerable<D.BraveAction>), (int)HttpStatusCode.OK)]
        public IActionResult GetBraveActionsBySchool(int schoolType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetBraveActionsBySchool)}");

            IEnumerable<M.BraveAction> model = _braveActionsLogic.GetBraveActionsBySchool(schoolType);

            IEnumerable<D.BraveAction> result = _mapper.Map<IEnumerable<D.BraveAction>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Soul Break BraveActions that have the specified element 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all BraveActions that do Fire damage
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/BraveAction/Element/5
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/BraveActions/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired Element; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;BraveAction&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.BraveActionsRoute_Element)]
        [SwaggerOperation(nameof(GetBraveActionsByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.BraveAction>), (int)HttpStatusCode.OK)]
        public IActionResult GetBraveActionsByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetBraveActionsByElement)}");

            IEnumerable<M.BraveAction> model = _braveActionsLogic.GetBraveActionsByElement(elementType);

            IEnumerable<D.BraveAction> result = _mapper.Map<IEnumerable<D.BraveAction>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Soul Break BraveActions that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full BraveAction object as a search template, only the following fields are used in the search (all others are ignored):
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
        /// Sample Use Case - You want to find out data about all BraveActions that have an ElementType of "Fire" and a SchoolType of Black Magic
        /// - You first call Type List Apis to get the ids for Element = Fire and SchoolType = Black Magic (4 and 3)
        /// - You create an Command object and fill in the above ids into the Element collection and School property
        /// - You attach the Command specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/Abilities/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/BraveActions/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Command object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;BraveAction&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.BraveActionsRoute_Search)]
        [SwaggerOperation(nameof(GetBraveActionsBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.BraveAction>), (int)HttpStatusCode.OK)]
        public IActionResult GetBraveActionsBySearch(D.BraveAction searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetBraveActionsBySearch)}");

            M.BraveAction braveAction = _mapper.Map<M.BraveAction>(searchPrototype);

            IEnumerable<M.BraveAction> model = _braveActionsLogic.GetBraveActionsBySearch(braveAction);

            IEnumerable<D.BraveAction> result = _mapper.Map<IEnumerable<D.BraveAction>>(model);

            return new ObjectResult(result);
        }
    }
}
