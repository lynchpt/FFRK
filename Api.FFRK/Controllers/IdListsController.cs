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
    public interface IIdListsController
    {
        IActionResult GetAllIdLists();

        IActionResult GetAbilityIdList();    
        IActionResult GetCharacterIdList();
        IActionResult GetCommandIdList();

        IActionResult GetBraveActionIdList();
        //IActionResult GetDungeonIdList();
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

        /// <summary>
        /// Gets all IdList instances in one call
        /// </summary>
        /// <remarks>
        /// Concept - IdLists are an artifact of trying to normalize much of the underlying Enlir data (which is all typed out strings) 
        /// into a set of ids that make for easier programmatic use. A concrete example will make this clearer:
        /// <br /> 
        /// In the underlying Enlir data, when he refers to a Character, he always uses thier name such as "Rosa", "Cloud", "Cid (XIV)" etc. 
        /// These are human readable and descriptive, but not easy to use programatically, so this api converts them into a sythesized id like 1, 2, 3,... 200, etc..
        /// <br /> 
        /// Thus, when you want to ask the api a question about all XYZ for Cid (XIV), you would need to find out the character id for Cid (XIV)
        /// first, because that is the key the api understands. In this example, you would get the Character IdList, 
        /// find out which integer id is associated with character string name "Cid (XIV)", and use that id with the api.
        /// <br /> 
        /// The Character IdList is just one example; there are IdLists for other things like Relics, SoulBreaks etc.
        /// <br /> 
        /// Use Case - If you only need to access a small number of IdLists, it is faster to get each individual instance, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally 
        /// so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IdListBundle</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.IdListsRoute_All)]
        [SwaggerOperation(nameof(GetAllIdLists))]
        [ProducesResponseType(typeof(D.IdListBundle), (int)HttpStatusCode.OK)]
        public IActionResult GetAllIdLists()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllIdLists)}");

            IdListBundle model = _idListsLogic.GetAllIdLists();

            FFRKApi.Dto.Api.IdListBundle result = _mapper.Map<FFRKApi.Dto.Api.IdListBundle>(model);

            return new ObjectResult(result);
        }


        /// <summary>
        /// Get the IdList for Ability
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Abilities" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are Firaja, Esuna, Power Breakdown, Engulfing Quadstrike, etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Abilities", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Abilities api and find info for the Firaja ability. 
        /// The results of this method would give you the id for Firaja that you need use in that Abilities Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Ability (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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


        /// <summary>
        /// Get the IdList for Character
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Characters" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Rosa", "Cloud", "Cid (XIV)" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Characters", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Characters api and find info for Cid (XIV). 
        /// The results of this method would give you the id for Cid (XIV) that you need use in that Characters Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Character (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for Command
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Commands" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Book of Despair", "Riddle of the Flame", "Water Barrage" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Commands", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Commands api and find info for Water Barrage. 
        /// The results of this method would give you the id for Water Barrage that you need use in that Commands Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Command (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for BraveAction
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Brave" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Rising High", "Riot Fire" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Brave", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the BraveActions api and find info for Riot Fire. 
        /// The results of this method would give you the id fo rRiot Fire that you need use in that BraveActions Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/BraveAction (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.IdListsRoute_BraveAction)]
        [SwaggerOperation(nameof(GetBraveActionIdList))]
        [ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        public IActionResult GetBraveActionIdList()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetBraveActionIdList)}");

            IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetBraveActionIdList();

            return new ObjectResult(result);
        }

        /// <summary>
        /// Get the IdList for Dungeon
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Dungeons" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Chaos Shrine", "Mount Hobs", "Big Bridge" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Dungeons", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Dungeons api and find info for Big Bridge. 
        /// The results of this method would give you the id for Big Bridge that you need to use in that Dungeons Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Dungeon (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
        //[HttpGet]
        //[Route(RouteConstants.IdListsRoute_Dungeon)]
        //[SwaggerOperation(nameof(GetDungeonIdList))]
        //[ProducesResponseType(typeof(IEnumerable<KeyValuePair<int, string>>), (int)HttpStatusCode.OK)]
        //public IActionResult GetDungeonIdList()
        //{
        //    _logger.LogInformation($"Controller Method invoked: {nameof(GetDungeonIdList)}");

        //    IEnumerable<KeyValuePair<int, string>> result = _idListsLogic.GetDungeonIdList();

        //    return new ObjectResult(result);
        //}

        /// <summary>
        /// Get the IdList for Event
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Events" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Of Lies and Love", "Type-0: Into the Fray", "Masters of the Planet" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Events", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Events api and find info for Masters of the Planet. 
        /// The results of this method would give you the id for Masters of the Planet that you need to use in that Events Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Event (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for Experience
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Experience" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// This IdList is an exception to the norm as there is just one row representing the entire Experience object.
        /// <br /> 
        /// Enlir Mapping - sheet: "Experience", no column (which then gets a harcoded integer id of 1 associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - No real case; this method is just included for consistency
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Experience (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for LegendMateria
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Legend Materia" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Secret of the Archives", "Master of Weapons", "Twinstrike Champion" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Legend Materia", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the LegendMaterias api and find info for Master of Weapons. 
        /// The results of this method would give you the id for Master of Weapons that you need to use in that LegendMaterias Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/LegendMateria (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for LegendSphere
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Legend Spheres" sheet, using a generated integer as the Key and the string values in the "Character" and "Sphere" columns as the Value. 
        /// Some example values are "Refia - DEF +10", "Kain - RES +20", "Bartz - Wind Res. (minor)" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Legend Spheres", columns "Character" and "Sphere" [the first one] (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the LegendSpheres api and find info for Refia's sphere denoted by the synthesized name Refia - DEF +10. 
        /// The results of this method would give you the id for Refia - DEF +10 that you need to use in that LegendMaterias Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/LegendSphere (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for Magicite
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Magicite" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Wendigo", "Enlil", "Kraken" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Magicite", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Magicites api and find info for Kraken. 
        /// The results of this method would give you the id for Kraken that you need to use in that Events Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Magicite (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for MagiciteSkill
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Magicite Skills" sheet, using a generated integer as the Key and the string values in the "Magicite" and "Name" columns as the Value. 
        /// Some example values are "Maliris (IX) - Raining Swords", "Wendigo (XII) - Blizzara", "Midgardsormr (VI) - Tail" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Magicite Skills", columns "Magicite" and "Name" (which then get a synthesized integer id associated with them in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the MagiciteSkills api and find info for Wendigo (XII) - Blizzara. 
        /// The results of this method would give you the id for Wendigo (XII) - Blizzara that you need to use in that MagiciteSkills Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/MagiciteSkill (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for Mission
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Missions" sheet, using a generated integer as the Key and the string value in the "Description" column as the Value. 
        /// Some example values are "Use a Rare Relic Draw", "Bring a character to Level 99", "Bring a Dark Magicite to Level 99" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Missions", column "Description" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Missions api and find info for Bring a character to Level 99. 
        /// The results of this method would give you the id for Bring a character to Level 99 that you need to use in that Missions Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Mission (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for Other
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Other" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "TCELES B HSUP", "Fire Barrage", "Shattering Finish" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Other", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Others api and find info for Shattering Finish. 
        /// The results of this method would give you the id for Shattering Finish that you need to use in that Others Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Other (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for RecordMateria
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Record Materia" sheet, using a generated integer as the Key and the string values in the "Character" and "Name" columns as the Value. 
        /// Some example values are "Luneth - Might of Wind", "Bartz - World Traveler", "Aerith - Prayer of the Cetra" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Record Materia", columns "Character" and "Name" (which then get a synthesized integer id associated with them in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the RecordMaterias api and find info for Bartz - World Traveler. 
        /// The results of this method would give you the id for Bartz - World Traveler that you need to use in that RecordMaterias Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/RecordMateria (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for RecordSphere
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Record Spheres" sheet, using a generated integer as the Key and the string values in the "Character" and "Sphere" columns as the Value. 
        /// Some example values are "Onion Knight - Warrior", "Bartz - Paladin", "Cloud - Demonsblood" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Record Spheres", columns "Character" and "Sphere" (which then get a synthesized integer id associated with them in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the RecordSpheres api and find info for Onion Knight - Warrior. 
        /// The results of this method would give you the id for Onion Knight - Warrior that you need to use in that RecordSpheres Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/RecordSphere (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for Relic
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Relics" sheet, using a generated integer as the Key and the string values in the "Name" and "Realm" columns as the Value. 
        /// Some example values are "Chicken Knife - V", "Ichigeki - VI", "Ragnarok - VII" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Relics", columns "Name" and "Realm" (which then get a synthesized integer id associated with them in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Relics api and find info for Chicken Knife - V. 
        /// The results of this method would give you the id for Chicken Knife - V that you need to use in that Relics Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Relic (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for SoulBreak
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Soul Breaks" sheet, using a generated integer as the Key and the string value in the "Name" column as the Value. 
        /// Some example values are "Sentinel's Grimoire", "Vessel of Fate", "Chosen Traveler" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Soul Breaks", column "Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the SoulBreaks api and find info for Sentinel's Grimoire. 
        /// The results of this method would give you the id for Sentinel's Grimoire that you need to use in that SoulBreaks Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/SoulBreak (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        /// <summary>
        /// Get the IdList for Status
        /// </summary>
        /// <remarks>
        /// Each value in this IdList is created from a row in the Enlir "Status" sheet, using a generated integer as the Key and the string value in the "Common Name" column as the Value. 
        /// Some example values are "Haste", "Instant KO", "Last Stand" etc.
        /// <br /> 
        /// Enlir Mapping - sheet: "Status", column "Common Name" (which then gets a synthesized integer id associated with it in this IdList)
        /// <br /> 
        /// Sample Use Case - You would call this method if you wanted to call the Statuses api and find info for Last Stand. 
        /// The results of this method would give you the id for Last Stand that you need to use in that Statuses Api call
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/IdLists/Status (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;KeyValuePair&lt;int,string&gt;&gt;</see>
        /// </response>
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

        //comment to force push to azure
        #endregion


    }
}
