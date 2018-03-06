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
using D = FFRKApi.Dto.Api;

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
        IActionResult GetStatSetTypeList();
        IActionResult GetStatTypeList();
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

        /// <summary>
        /// Gets all TypeList instances in one call
        /// </summary>
        /// <remarks>
        /// Concept - TypeLists are an artifact of trying to normalize much of the underlying Enlir data (which is all typed out strings) 
        /// into a set of ids that make for easier programmatic use. A concrete example will make this clearer:
        /// <br /> 
        /// In the underlying Enlir data, when he refers to the realm to which something (like a character or relic) belongs, he 
        /// uses a descriptive string like I, II, III,..., IX,..., IV:TAY etc. These are human readable and descriptive, but not 
        /// easy to use programatically, so this api converts them into a sythesized id like 1, 2, 3, ..., 9, ..., 21.
        /// <br /> 
        /// Thus, when you want to ask the api a question about all XYZ in realm X-2, you would need to find out the realm id 
        /// first, because that is the key the api understands. In this example, you would get the Realm TypeList, 
        /// find out which integer id is associated with realm string description "X-2", and use that id with the api.
        /// <br /> 
        /// RealmTypeList is just one example; there are TypeList for other things like EquipmentType, ElementType etc.
        /// <br /> 
        /// Use Case - If you only need to access a small number of TypeLists, it is faster to get each individual instance, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally 
        /// so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>TypeListBundle</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_All)]
        [SwaggerOperation(nameof(GetAllTypeLists))]
        [ProducesResponseType(typeof(D.TypeListBundle), (int)HttpStatusCode.OK)]
        public IActionResult GetAllTypeLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllTypeLists)}");

            TypeListBundle model = _typeListsLogic.GetAllTypeLists();

            FFRKApi.Dto.Api.TypeListBundle result = _mapper.Map<FFRKApi.Dto.Api.TypeListBundle>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Get the TypeList for AbilityType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Type" when in the context of an ability. 
        /// Some example values are BLK, NAT, NIN, PHY, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Abilities", column "Type" (and other places)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Abilities api and find all abilities that are of the NIN type. 
        /// The results of this method would give you the id for NIN that you need use in that Abilities Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/AbilityType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for AutoTargetType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Auto Target" when in the context of an ability. 
        /// Some example values are All allies, Highest HP% enemy, Self, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Abilities", column "Auto Target" (and other places)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Abilities Search api and include as a criteria that qualifying abilities must auto target the Highest HP% enemy. 
        /// The results of this method would give you the id for Highest HP% enemy that you need use in that Abilities Search Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/AutoTargetType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for DamageFormulaType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Formula" when in the context of an ability. 
        /// Some example values are Hybrid, Magical, Physical, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Abilities", column "Formula" (and other places)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Abilities Search api and include as a criteria that qualifying abilities must use the Magical damage formula. 
        /// The results of this method would give you the id for Magical that you need use in that Abilities Search Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/DamageFormulaType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for ElementType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Element" when in the context of an ability, soul break command etc,. 
        /// Some example values are Dark, Earth, Fire, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Abilities", column "Element" (and other places)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Abilities api and find all abilities that have the Fire element. 
        /// The results of this method would give you the id for Fire that you need use in that Abilities Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/ElementType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for EquipmentType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir related to Equipment that a Character can use. 
        /// Some example values are Dagger, Sword, Shield, etc.
        /// Although these are multiple columns in Enlir, this api pivots that equipment access data so Characters can expose lists of the equipment they can use.
        /// <br /> 
        /// Enlir Mapping - sheet: "Characters", column "Dagger", "Sword", "Shield" etc.
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Characters api and find all characters who can use a Staff. 
        /// The results of this method would give you the id for Staff that you need use in that Characters Api call.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/EquipmentType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for EventType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the column in Enlir called "Type" when in the context of an Event. 
        /// Some example values are Dungeons Update, Challenge Event, Torment Dungeon, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Events", column "Type"
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Events api and find all events of type "Challenge Event". 
        /// The results of this method would give you the id for Challenge Event that you need use in that Events Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/EventType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for MissionType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the column in Enlir called "Type" when in the context of a Mission. 
        /// Some example values are Wayfarer, Normal, Special, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Missions", column "Type"
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Missions api and find all missions of type "Wayfarer". 
        /// The results of this method would give you the id for Wayfarer that you need use in that Missions Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/MissionType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for OrbType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Orb X Required" when in the context of an Ability. 
        /// Some example values are Greater Black, Major Power, Ice Crystal, etc.
        /// Although these are multiple columns in Enlir, this api pivots the orb requirments so Abilities can expose lists of the orbs they need for honing.
        /// <br /> 
        /// Enlir Mapping - sheet: "Abilities", column "Orb 1 Required", "Orb 2 Required", etc.
        /// <br /> 
        /// Sample Use Case - You would call this method so you could translate the OrbType ids returned by calls to the Abilities api into human readable descriptions like "Major Power"
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/OrbType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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


        /// <summary>
        /// Get the TypeList for RealmType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Realm" when in the context of an Character, Relic, or other object that is associated with a Realm. 
        /// Some example values are I, II, III, IX, IV:TAY etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Characters", column "Realm" (and other places)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Characters api and find all Characters belonging to the "III" Realm. 
        /// The results of this method would give you the id for III that you need use in that Characters Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/RealmType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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


        /// <summary>
        /// Get the TypeList for RelicType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Type" when in the context of a Relic
        /// Some example values are Dagger, Sword, Shield, etc. (Yes, these values end up being the same as EquipmentType values).
        /// <br /> 
        /// Enlir Mapping - sheet: "Relics", column "Type"
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Relics api and find all Relics that were Shields. 
        /// The results of this method would give you the id for Shield that you need use in that Relics Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/RelicType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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


        /// <summary>
        /// Get the TypeList for SchoolType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "School" when in the context of an Ability, Soul Break Command, etc.
        /// Some example values are Celerity, Heavy, Sharpshooter, etc. 
        /// <br /> 
        /// Enlir Mapping - sheet: "Commands", column "School"
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Commands api and find all Soul Break Commands that belonged to the Sharpshooter School. 
        /// The results of this method would give you the id for Sharpshooter that you need use in that Commands Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/SchoolType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for StatSetType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir regarding stats when in the context of a Relic.
        /// Some example values are Base, Standard, Max, etc. 
        /// Although these are multiple columns in Enlir, this api pivots the stats so Relics can expose lists stats by the StatSte they belong to.
        /// <br /> 
        /// Enlir Mapping - sheet: "ATK", "Batk" "Bdef", "Matk", "Mdef", etc.
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Relics api and find all relics that had Max values for some stat of higher than X value. 
        /// The results of this method would give you the id for Max stat set that you need use in that Relics Api call.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/StatSetType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_StatSetType)]
        [SwaggerOperation(nameof(GetStatSetTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatSetTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatSetTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetStatSetTypeList();

            return new ObjectResult(result);
        }


        /// <summary>
        /// Get the TypeList for StatType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir regarding stats when in the context of a Relic.
        /// Some example values are ATK, DEF, MAG, etc. 
        /// Although these are multiple columns in Enlir, this api pivots the stats so Relics can expose lists stats by the Stat Type they belong to.
        /// <br /> 
        /// Enlir Mapping - sheet: "ATK", "Batk" "Bdef", "Matk", "Mdef", etc.
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Relics api and find all relics that had values for the MAG stat higher than X value. 
        /// The results of this method would give you the id for MAG stat that you need use in that Relics Api call.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/StatType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.TypeListsRoute_StatType)]
        [SwaggerOperation(nameof(GetStatTypeList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetStatTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetStatTypeList)}");

            IEnumerable<KeyValuePair<int, string>> result = _typeListsLogic.GetStatTypeList();

            return new ObjectResult(result);
        }

        /// <summary>
        /// Get the TypeList for SoulBreakTierType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Tier" when in the context of a Soul Break
        /// Some example values are SSB, USB, CSB, Glint, etc. 
        /// <br /> 
        /// Enlir Mapping - sheet: "Soul Breaks", column "Tier"
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the SoulBreaks api and find all Soul Breaks that belonged to the USB tier. 
        /// The results of this method would give you the id for USB that you need use in that SoulBreaks Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/SoulBreakTierType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the TypeList for TargetType
        /// </summary>
        /// <remarks>
        /// The values in this TypeList are drawn from those found in the columns in Enlir called "Target" when in the context of an ability. 
        /// Some example values are All allies, Single Enemy, Self, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Abilities", column "Target" (and other places)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Abilities Search api and include as a criteria that qualifying abilities must target a single enemy. 
        /// The results of this method would give you the id for Single Enemy that you need use in that Abilities Search Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/TypeLists/TargetType (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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
