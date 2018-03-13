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
    public interface ISoulBreaksController
    {
        IActionResult GetAllSoulBreaks();
        IActionResult GetSoulBreaksById(int soulBreakId);
        IActionResult GetSoulBreaksByAbilityType(int abilityType);
        IActionResult GetSoulBreaksByName(string soulBreakName);
        IActionResult GetSoulBreaksByRealm(int realmType);
        IActionResult GetSoulBreaksByCharacter(int characterId);
        IActionResult GetSoulBreaksByMultiplier(int multiplier);
        IActionResult GetSoulBreaksByElement(int elementType);
        IActionResult GetSoulBreaksByEffect(string effectText);
        IActionResult GetSoulBreaksByTier(int soulBreakTier);
        IActionResult GetSoulBreaksByMasteryBonus(string masteryBonusText);
        IActionResult GetSoulBreaksByStatus(int statusId);
        IActionResult GetSoulBreaksBySearch(D.SoulBreak searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class SoulBreaksController : Controller, ISoulBreaksController
    {
        #region Class Variables

        private readonly ISoulBreaksLogic _soulBreaksLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<SoulBreaksController> _logger;
        #endregion

        #region Constructors

        public SoulBreaksController(ISoulBreaksLogic soulBreaksLogic, IMapper mapper, ILogger<SoulBreaksController> logger)
        {
            _soulBreaksLogic = soulBreaksLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ISoulBreaksController Implementation

        /// <summary>
        /// Gets all SoulBreaks and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of SoulBreaks, it is faster to get each individual SoulBreak instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_All)]
        [SwaggerOperation(nameof(GetAllSoulBreaks))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllSoulBreaks()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllSoulBreaks)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetAllSoulBreaks();

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one SoulBreak by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Paladin Force SoulBreak
        /// - You first call /api/v1.0/IdLists/SoulBreak to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "SoulBreak" in the IdList (the id is 238 in this case)
        /// - Finally you call this api: api/v1.0/SoulBreaks/238
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/238 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="soulBreakId">the integer id for the desired SoulBreak; it can be found in the SoulBreak IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Id)]
        [SwaggerOperation(nameof(GetSoulBreaksById))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksById(int soulBreakId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksById)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksById(soulBreakId);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that have the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks that have an AbilityType of "PHY"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "PHY" in the TypeList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/SoulBreaks/AbilityType/6";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/AbilityType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_AbilityType)]
        [SwaggerOperation(nameof(GetSoulBreaksByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByAbilityType)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByAbilityType(abilityType);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks with "Dragon" in their name.
        /// - You can straight away call this api: api/v1.0/SoulBreaks/Name/dragon";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Name/dragon (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="soulBreakName">the string that must be a part of a SoulBreak's name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Name)]
        [SwaggerOperation(nameof(GetSoulBreaksByName))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByName(string soulBreakName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByName)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByName(soulBreakName);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that belong to Characters in the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks that belong to Characters in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/SoulBreaks/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_RealmType)]
        [SwaggerOperation(nameof(GetSoulBreaksByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByRealm)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByRealm(realmType);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks that belong to Bartz.
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/SoulBreaks/Character/73
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Character)]
        [SwaggerOperation(nameof(GetSoulBreaksByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByCharacter)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByCharacter(characterId);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that have a Multiplier greater than or equal to the specified Multiplier value
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks that have a multiplier greater than or equal to 6.
        /// - You can straight away call this api: api/v1.0/SoulBreaks/Multiplier/6";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Multiplier/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="multiplier">the integer multiplier value</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Multiplier)]
        [SwaggerOperation(nameof(GetSoulBreaksByMultiplier))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByMultiplier(int multiplier)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByMultiplier)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByMultiplier(multiplier);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that have the specified ElementType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks that have an ElementType of "Fire"
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/SoulBreaks/Element/5;
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired ElementType; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Element)]
        [SwaggerOperation(nameof(GetSoulBreaksByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByElement)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByElement(elementType);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks whose Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks with "Haste" in their Effect text.
        /// - You can straight away call this api: api/v1.0/SoulBreaks/Effect/haste";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Effect/haste (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a SoulBreak's Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Effect)]
        [SwaggerOperation(nameof(GetSoulBreaksByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByEffect)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByEffect(effectText);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that are of the specified SoulBreak Tier
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks are in the Chain Soul Break Tier
        /// - You first call /api/v1.0/TypeLists/SoulBreakTierType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "CSB" in the IdList (the id is 9 in this case)
        /// - Finally you call this api: api/v1.0/SoulBreaks/Tier/9
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Tier/9 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired soulBreakTier; it can be found in the soulBreakTier TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Tier)]
        [SwaggerOperation(nameof(GetSoulBreaksByTier))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByTier(int soulBreakTier)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByTier)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByTier(soulBreakTier);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks whose MasteryBonus text contains the provided string (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks with "MND" as the stat improved upon mastery.
        /// - You can straight away call this api: api/v1.0/SoulBreaks/MasteryBonus/mnd";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/MasteryBonus/mnd (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="masteryBonusText">the string that must be a part of a SoulBreak's MasteryBonus text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_MasteryBonus)]
        [SwaggerOperation(nameof(GetSoulBreaksByMasteryBonus))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByMasteryBonus(string masteryBonusText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByMasteryBonus)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByMasteryBonus(masteryBonusText);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that apply or provide a specified Status
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all SoulBreaks that apply / provide the Astra Status.
        /// - You first call /api/v1.0/IdLists/Status to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Astra" in the IdList (the id is 86 in this case)
        /// - Finally you call this api: api/v1.0/SoulBreaks/Status/86
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Status/86 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="statusId">the integer id for the desired Status; it can be found in the Status IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SoulBreaksRoute_Status)]
        [SwaggerOperation(nameof(GetSoulBreaksByStatus))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksByStatus(int statusId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksByStatus)}");

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksByStatus(statusId);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all SoulBreaks that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full SoulBreak object as a search template, only the following fields are used in the search (all others are ignored):
        /// 
        /// - AbilityType
        /// - SoulBreakName (comparison is Contains, not exact match)
        /// - Realm
        /// - CharacterId
        /// - Multiplier (value specified or greater)
        /// - Elements (only the first in the list is considered)
        /// - Effect (comparison is Contains, not exact match)
        /// - SoulBreakTier
        /// - MasteryBonus (comparison is Contains, not exact match)
        /// - Statuses (only the first in the list is considered)
        /// - AutoTargetType
        /// - CastTime (value specified or lower)
        /// - DamageFormulaType
        /// - TargetType
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any SoulBreak in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Relics that have an RealmType of "VI" and a RelicType of "Sword"
        /// - You first call TypeList Apis to get the id for RealmType = VI (the id is 6)) and the id for RelicType = Sword (the id is 2)
        /// - You create an SoulBreak object and fill in the above 6 into the Realm property, and 2 into the RelicType property
        /// - You attach the SoulBreak specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/SoulBreaks [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/SoulBreaks/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Relic object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SoulBreak&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.SoulBreaksRoute_Search)]
        [SwaggerOperation(nameof(GetSoulBreaksBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.SoulBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetSoulBreaksBySearch([FromBody]D.SoulBreak searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSoulBreaksBySearch)}");

            SoulBreak soulBreak = _mapper.Map<SoulBreak>(searchPrototype);

            IEnumerable<SoulBreak> model = _soulBreaksLogic.GetSoulBreaksBySearch(soulBreak);

            IEnumerable<D.SoulBreak> result = _mapper.Map<IEnumerable<D.SoulBreak>>(model);

            return new ObjectResult(result);
        }

        //comment to force push to azure
        #endregion
    }
}
