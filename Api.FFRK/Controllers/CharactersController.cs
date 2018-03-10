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
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface ICharactersController
    {
        IActionResult GetAllCharacters();
        IActionResult GetCharactersById(int characterId);
        IActionResult GetCharactersByRealm(int realmType);
        IActionResult GetCharactersByName(string characterName);
        IActionResult GetCharactersByEquipmentAccess(int equipmentType);
        IActionResult GetCharactersBySchoolAccess(int schoolType, int schoolMinLevel);
        IActionResult GetCharactersBySearch(D.Character searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class CharactersController : Controller, ICharactersController
    {
        #region Class Variables

        private readonly ICharactersLogic _charactersLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<CharactersController> _logger;
        #endregion

        #region Constructors

        public CharactersController(ICharactersLogic charactersLogic, IMapper mapper, ILogger<CharactersController> logger)
        {
            _charactersLogic = charactersLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ICharactersController Implementation

        /// <summary>
        /// Gets all Characters and their associated data, including Relics, Record Spheres, Legend Spheres, etc.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Characters, it is faster to get each individual Character instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Characters (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Character&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharactersRoute_All)]
        [SwaggerOperation(nameof(GetAllCharacters))]
        [ProducesResponseType(typeof(IEnumerable<D.Character>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllCharacters()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllCharacters)}");

            IEnumerable<Character> model = _charactersLogic.GetAllCharacters();

            IEnumerable<D.Character> result = _mapper.Map<IEnumerable<D.Character>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Character by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Character named "Ramza"
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Ramza" in the IdList (the id is 192 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/4
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Characters/192 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Character&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharactersRoute_Id)]
        [SwaggerOperation(nameof(GetCharactersById))]
        [ProducesResponseType(typeof(IEnumerable<D.Character>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharactersById(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharactersById)}");

            IEnumerable<Character> model = _charactersLogic.GetCharactersById(characterId);

            IEnumerable<D.Character> result = _mapper.Map<IEnumerable<D.Character>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Characters that belong to the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Characters in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Characters/RealmType/6
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Characters/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Character&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharactersRoute_RealmType)]
        [SwaggerOperation(nameof(GetCharactersByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.Character>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharactersByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharactersByRealm)}");

            IEnumerable<Character> model = _charactersLogic.GetCharactersByRealm(realmType);

            IEnumerable<D.Character> result = _mapper.Map<IEnumerable<D.Character>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Characters whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Characters with "Cid" in their name.
        /// - You can straight away call this api: api/v1.0/Characters/Name/cid";
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Characters/Name/cid (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterName">the string that must be a part of a Character's name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Character&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharactersRoute_Name)]
        [SwaggerOperation(nameof(GetCharactersByName))]
        [ProducesResponseType(typeof(IEnumerable<D.Character>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharactersByName(string characterName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharactersByName)}");

            IEnumerable<Character> model = _charactersLogic.GetCharactersByName(characterName);

            IEnumerable<D.Character> result = _mapper.Map<IEnumerable<D.Character>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Characters that can use a specified type of Equipment
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Characters who can equip Rods
        /// - You first call /api/v1.0/TypeLists/EquipmentType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Rod" in the IdList (the id is 8 in this case)
        /// - Finally you call this api: api/v1.0/Characters/Equipment/8
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Characters/Equipment/8 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="equipmentType">the integer id for the desired EquipmentType; it can be found in the EquipmentType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Character&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharactersRoute_Equipment)]
        [SwaggerOperation(nameof(GetCharactersByEquipmentAccess))]
        [ProducesResponseType(typeof(IEnumerable<D.Character>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharactersByEquipmentAccess(int equipmentType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharactersByEquipmentAccess)}");

            IEnumerable<Character> model = _charactersLogic.GetCharactersByEquipmentAccess(equipmentType);

            IEnumerable<D.Character> result = _mapper.Map<IEnumerable<D.Character>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Characters that can use Abilities that belong to the specified School and that are of at least the specified minimum level (or higher)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Characters who can use Combat Abilities of at least Level 4 (or higher)
        /// - You first call /api/v1.0/TypeLists/SchoolType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Combat" in the IdList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/Characters/School/5/4
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Characters/School/5/4 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="schoolType">the integer id for the desired SchoolType; it can be found in the SchoolType TypeList</param>
        /// <param name="schoolMinLevel">the integer that specifies the minimum access level to an Ability School that a Character needs to be returned from this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Character&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharactersRoute_School)]
        [SwaggerOperation(nameof(GetCharactersBySchoolAccess))]
        [ProducesResponseType(typeof(IEnumerable<D.Character>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharactersBySchoolAccess(int schoolType, int schoolMinLevel)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharactersBySchoolAccess)}");

            IEnumerable<Character> model = _charactersLogic.GetCharactersBySchoolAccess(schoolType, schoolMinLevel);

            IEnumerable<D.Character> result = _mapper.Map<IEnumerable<D.Character>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Characters that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full Character object as a search template, only the following fields are used in the search (all others are ignored):
        /// - Realm 
        /// - CharacterName (comparison is Contains, not exact match)
        /// - EquipmentAccessInfos (only the first in the list is considered)
        /// - SchoolAccessInfos (only the first in the list is considered)
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any Character in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Characters that have an RealmType of "V" and a SchoolType of Black Magic with a minimum access level of 5
        /// - You first call TypeList Apis to get the ids for RealmType = "V" and SchoolType = Black Magic (5 and 3)
        /// - You create an Character object and fill in the above ids (and the minimum level of 5) into the Realm property and the SchoolAccessInfos collection property
        /// - You attach the Character specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/Characters/Search [POST];
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/Characters/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Character object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Characters&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.CharactersRoute_Search)]
        [SwaggerOperation(nameof(GetCharactersBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.Character>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharactersBySearch([FromBody]D.Character searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharactersBySearch)}");

            //D.Character characterDto = JsonConvert.DeserializeObject<D.Character>(searchPrototype);

            Character character = _mapper.Map<Character>(searchPrototype);

            IEnumerable<Character> model = _charactersLogic.GetCharactersBySearch(character);

            IEnumerable<D.Character> result = _mapper.Map<IEnumerable<D.Character>>(model);

            return new ObjectResult(result);
        }
        #endregion
    }
}
