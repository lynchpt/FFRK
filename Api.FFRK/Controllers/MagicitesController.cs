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
using FFRKApi.Model.EnlirTransform;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IMagicitesController
    {
        //Magicite
        IActionResult GetAllMagicites();
        IActionResult GetMagicitesById(int magiciteId);
        IActionResult GetMagicitesByName(string magiciteName);
        IActionResult GetMagicitesByRealm(int realmType);
        IActionResult GetMagicitesByRarity(int rarity);
        IActionResult GetMagicitesByElement(int elementType);
        IActionResult GetMagicitesByPassiveEffect(string passiveEffect);

        //UltraSkill
        IActionResult GetMagicitesByUltraSkillName(string ultraSkillName);
        IActionResult GetMagicitesByUltraSkillAbilityType(int abilityType);
        IActionResult GetMagicitesByUltraSkillElement(int elementType);
        IActionResult GetMagicitesByUltraSkillEffect(string effectText);

        //MagiciteSkill
        IActionResult GetMagicitesByMagiciteSkillId(int magiciteSkillId);
        IActionResult GetMagicitesByMagiciteSkillName(string magiciteSkillName);
        IActionResult GetMagicitesByMagiciteSkillAbilityType(int abilityType);
        IActionResult GetMagicitesByMagiciteSkillElement(int elementType);
        IActionResult GetMagicitesByMagiciteSkillEffect(string effectText);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class MagicitesController : Controller, IMagicitesController
    {
        #region Class Variables

        private readonly IMagicitesLogic _magicitesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<MagicitesController> _logger;
        #endregion

        #region Constructors

        public MagicitesController(IMagicitesLogic magicitesLogic, IMapper mapper, ILogger<MagicitesController> logger)
        {
            _magicitesLogic = magicitesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IMagicitesController Implementation

        // Magicite

        /// <summary>
        /// Gets all Magicites and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Magicites, it is faster to get each individual ability Magicites using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/LegendMaterias (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_All)]
        [SwaggerOperation(nameof(GetAllMagicites))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMagicites()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMagicites)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetAllMagicites();

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Magicite by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Wendigo Magicite.
        /// - You first call /api/v1.0/IdLists/Magicite to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "Wendigo" in the IdList (the id is 16 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/16
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/16 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="magiciteId">the integer id for the desired Magicite; it can be found in the Magicite IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Id)]
        [SwaggerOperation(nameof(GetMagicitesById))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesById(int magiciteId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesById)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesById(magiciteId);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites with "Bomb" in their name.
        /// - You can straight away call this api: api/v1.0/Magicites/Name/bomb";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/Name/bomb (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="magiciteName">the string that must be a part of a Magicites's name in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Name)]
        [SwaggerOperation(nameof(GetMagicitesByName))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByName(string magiciteName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByName)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByName(magiciteName);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites that belong to the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites that come from the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_RealmType)]
        [SwaggerOperation(nameof(GetMagicitesByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByRealm)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByRealm(realmType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites that are of the specified rarity / star level
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites that have a rarity of 4*.
        /// - You can straight away call this api: api/v1.0/Events/WardrobeRecord/cid";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/Rarity/4 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="rarity">the integer rarity level (equates to star level) of the Magicites to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Rarity)]
        [SwaggerOperation(nameof(GetMagicitesByRarity))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByRarity(int rarity)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByRarity)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByRarity(rarity);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites that have the specified ElementType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites that have an ElementType of "Fire"
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/Element/5;
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired ElementType; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Element)]
        [SwaggerOperation(nameof(GetMagicitesByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByElement)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByElement(elementType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites whose Passive Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites whose Passive effect contains the text "Dampen".
        /// - You can straight away call this api: api/v1.0/Magicites/Effect/dampen";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/Effect/dampen (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a Magicites's Passive Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_Effect)]
        [SwaggerOperation(nameof(GetMagicitesByPassiveEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByPassiveEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByPassiveEffect)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByPassiveEffect(effectText);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        //UltraSkill

        /// <summary>
        /// Gets all Magicites whose Ultra Skill's name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites whose Ultra Skills have "ice" in their name.
        /// - You can straight away call this api: api/v1.0/Magicites/UltraSkill/Name/ice";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/UltraSkill/Name/ice (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="ultraSkillName">the string that must be a part of a Magicites Ultra Skill's name in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_Name)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillName))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillName(string ultraSkillName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillName)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillName(ultraSkillName);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites whose Ultra Skill has the the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites whose Ultra Skill has an AbilityType of "NAT"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "NAT" in the TypeList (the id is 4 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/UltraSkill/AbilityType/5";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/UltraSkill/AbilityType/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_AbilityType)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillAbilityType)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillAbilityType(abilityType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites whose Ultra Skill has the specified ElementType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites whose Ultra Skill has an ElementType of "Fire"
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/UltraSkill/Element/5;
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/UltraSkill/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired ElementType; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_Element)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillElement)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillElement(elementType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites whose Ultra Skill Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites whose Ultra Skill effect contains the text "Imperil".
        /// - You can straight away call this api: api/v1.0/Magicites/UltraSkill/Effect/imperil";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/UltraSkill/Effect/imperil (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a Magicites's Ultra Skill's Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesUltraSkillRoute_Effect)]
        [SwaggerOperation(nameof(GetMagicitesByUltraSkillEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByUltraSkillEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByUltraSkillEffect)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByUltraSkillEffect(effectText);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        //MagiciteSkill

        /// <summary>
        /// Gets all Magicite who have a Magicite Skill that has the specified unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about any Magicites that has the Magicite Skill of Liquid Flame's version of "Fire.
        /// - You first call /api/v1.0/IdLists/MagiciteSkill to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "Liquid Flame" and "Fire" in the IdList (the id is 15 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/MagiciteSkill/15
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/MagiciteSkill/15 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="magiciteSkillId">the integer id for the desired MagiciteSkill; it can be found in the MagiciteSkill IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Id)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillId))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillId(int magiciteSkillId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillId)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillId(magiciteSkillId);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites having a Magicite Skill whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites having a Magicite Skill with "Lunge" in their name.
        /// - You can straight away call this api: api/v1.0/Magicites/MagiciteSkill/Name/lunge";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/MagiciteSkill/Name/lunge (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="magiciteSkillName">the string that must be a part of a Magicites's Magicite Skill name in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Name)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillName))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillName(string magiciteSkillName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillName)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillName(magiciteSkillName);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites having a Magicite Skill that has the the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites whose Magicite Skill has an AbilityType of "BLK"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "BLK" in the TypeList (the id is 2 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/MagiciteSkill/AbilityType/2";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/MagiciteSkill/AbilityType/2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_AbilityType)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillAbilityType)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillAbilityType(abilityType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites having a Magicite Skill that has the specified ElementType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites having a Magicite Skill that has an ElementType of "Fire"
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Magicites/MagiciteSkill/Element/5;
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/MagiciteSkill/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired ElementType; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Element)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillElement))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillElement)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillElement(elementType);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Magicites having a Magicite Skill whose Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Magicites having  Magicite Skills whose Effect contains the text "Slow".
        /// - You can straight away call this api: api/v1.0/Magicites/MagiciteSkill/Effect/slow";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Magicites/MagiciteSkill/Effect/slow (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a Magicites's Magicite Skill's Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Magicite&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagicitesMagiciteSkillRoute_Effect)]
        [SwaggerOperation(nameof(GetMagicitesByMagiciteSkillEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.Magicite>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagicitesByMagiciteSkillEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagicitesByMagiciteSkillEffect)}");

            IEnumerable<Magicite> model = _magicitesLogic.GetMagicitesByMagiciteSkillEffect(effectText);

            IEnumerable<D.Magicite> result = _mapper.Map<IEnumerable<D.Magicite>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
