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
    public interface IAbilitiesController
    {
        IActionResult GetAllAbilities();
        IActionResult GetAbilitiesById(int abilityId);
        IActionResult GetAbilitiesByAbilityType(int abilityType);
        IActionResult GetAbilitiesByRarity(int rarity);
        IActionResult GetAbilitiesBySchool(int schoolType);
        IActionResult GetAbilitiesByElement(int elementType);
        IActionResult GetAbilitiesBySearch(D.Ability searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class AbilitiesController : Controller, IAbilitiesController
    {
        #region Class Variables

        private readonly IAbilitiesLogic _abilitiesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<AbilitiesController> _logger;
        #endregion

        #region Constructors

        public AbilitiesController(IAbilitiesLogic abilitiesLogic, IMapper mapper, ILogger<AbilitiesController> logger)
        {
            _abilitiesLogic = abilitiesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IAbilitiesController Implementation

        /// <summary>
        /// Gets all Abilities and their properties, including required orbs
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Abilities, it is faster to get each individual ability instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Abilities (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Ability&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_All)]
        [SwaggerOperation(nameof(GetAllAbilities))]
        [ProducesResponseType(typeof(IEnumerable<D.Ability>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllAbilities()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllAbilities)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAllAbilities();

            IEnumerable<D.Ability> result = _mapper.Map< IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Ability by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Ability called "Firaja"
        /// - You first call /api/v1.0/IdLists/Ability to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Firaja" in the IdList (the id is 4 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/4
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Abilities/4 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityId">the integer id for the desired Ability; it can be found in the Ability IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Ability&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_Id)]
        [SwaggerOperation(nameof(GetAbilitiesById))]
        [ProducesResponseType(typeof(IEnumerable<D.Ability>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesById(int abilityId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilitiesById)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesById(abilityId);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Abilities that have the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Abilities that have an AbilityType of "NIN"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "NIN" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/AbilityType/5";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Abilities/AbilityType/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Ability&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_AbilityType)]
        [SwaggerOperation(nameof(GetAbilitiesByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Ability>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilitiesByAbilityType)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesByAbilityType(abilityType);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Abilities that have the specified Rarity
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Abilities that have an Rarity of 5 (as in 5*)
        /// - You can straight away call this api: api/v1.0/Abilities/Rarity/5";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Abilities/Rarity/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="rarity">the integer rarity that all returned Abilities need to share</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Ability&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_Rarity)]
        [SwaggerOperation(nameof(GetAbilitiesByRarity))]
        [ProducesResponseType(typeof(IEnumerable<D.Ability>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesByRarity(int rarity)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilitiesByRarity)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesByRarity(rarity);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Abilities that have the specified SchoolType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Abilities that have a SchoolType of "Dancer"
        /// - You first call /api/v1.0/TypeLists/SchoolType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Dancer" in the TypeList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/School/6";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Abilities/School/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="schoolType">the integer id for the desired SchoolType; it can be found in the SchoolType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Ability&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_School)]
        [SwaggerOperation(nameof(GetAbilitiesBySchool))]
        [ProducesResponseType(typeof(IEnumerable<D.Ability>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesBySchool(int schoolType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilitiesBySchool)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesBySchool(schoolType);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Abilities that have the specified ElementType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Abilities that have an ElementType of "Fire"
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/Element/5;
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Abilities/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired ElementType; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Ability&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_Element)]
        [SwaggerOperation(nameof(GetAbilitiesByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Ability>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilitiesByElement)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesByElement(elementType);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Abilities that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full Ability object as a search template, only the following fields are used in the search (all others are ignored):
        /// - AbilityName (comparison is Contains, not exact match)
        /// - AbilityType
        /// - AutoTargetType 
        /// - CastTime (value specified or less)
        /// - DamageFormulaType
        /// - Elements (only the first in the list is considered)
        /// - Multiplier (value specified or greater)
        /// - OrbRequirements (only the first in the list is considered)
        /// - Rarity
        /// - School 
        /// - SoulBreakPointsGained (value specified or greater)
        /// - TargetType
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any Ability in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Abilities that have an ElementType of "Fire" and a SchoolType of Black Magic
        /// - You first call Type List Apis to get the ids for Element = Fire and SchoolType = Black Magic (4 and 3)
        /// - You create an Ability object and fill in the above ids into the Element collection and School property
        /// - You attach the Ability specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/Abilities/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Abilities/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Ability object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;D.Ability&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.AbilitiesRoute_Search)]
        [SwaggerOperation(nameof(GetAbilitiesBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.Ability>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesBySearch([FromBody]D.Ability searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAbilitiesBySearch)}");

            Ability ability = _mapper.Map<Ability>(searchPrototype);

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesBySearch(ability);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
