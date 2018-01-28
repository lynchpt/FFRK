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
