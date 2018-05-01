using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api.CharacterRating;
using FFRKApi.Model.Api.CharacterRating;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api.CharacterRating;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface ICharacterRatingController
    {

        IActionResult GetAltemaCharacterInfos();

        IActionResult GetRatingPools();

        IActionResult GetCharacterRatingContextInfos();

        IActionResult GetCharacterRatingContextInfosByCharacterId(int characterId);

        IActionResult GetCharacterRatingContextInfosByCharacterName(string characterName);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class CharacterRatingController : Controller, ICharacterRatingController
    {
        #region Class Variables

        private readonly ICharacterRatingLogic _characterRatingLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<CharacterRatingController> _logger;
        #endregion

        #region Constructors

        public CharacterRatingController(ICharacterRatingLogic abilitiesLogic, IMapper mapper, ILogger<CharacterRatingController> logger)
        {
            _characterRatingLogic = abilitiesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ICharacterRatingController Implementation

        /// <summary>
        /// Gets full list of Altema Character Ratings
        /// </summary>
        /// <remarks>
        /// This includes the Japanese names and role info, as well as versions translated into English. Character name translations 
        /// are done so as to match up with the character names used by Enlir and thus in the rest of the FFRK Api.
        /// In addition to translating the Japanese role info to English, the English string has been broken into its component parts
        /// and assigned to the Roles list property.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/AltemaRatings (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;AltemaCharacterInfo&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharacterRatingRoute_AltemaRatings)]
        [SwaggerOperation(nameof(GetAltemaCharacterInfos))]
        [ProducesResponseType(typeof(IEnumerable<D.AltemaCharacterInfo>), (int)HttpStatusCode.OK)]
        public IActionResult GetAltemaCharacterInfos()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAltemaCharacterInfos)}");

            IEnumerable<AltemaCharacterInfo> model = _characterRatingLogic.GetAltemaCharacterInfos();

            IEnumerable<D.AltemaCharacterInfo> result = _mapper.Map<IEnumerable<D.AltemaCharacterInfo>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets full list of RatingPools
        /// </summary>
        /// <remarks>
        /// A RatingPool object is meant to represent some grouping of characters who share some attribute in common, where that 
        /// attribute is relevant to the decision to Legend Diving. Each RatingPool contains a list of nthe characters who belong in it,
        /// order by descending Altema Rating.
        /// 
        /// For example, if you wanted to Dive someone Proficient (5* or above) in the Black Magic School, you would call this method, 
        /// find the RatingPool named School: Black Magic and look in the CharactersInRatingPool property to see the highest rated character 
        /// for whom you had good relics
        /// 
        /// Other RatingPools (besides the school based ones like above) are Mote (e.g. Spirit / Wisdom), Role (e.g. Healing, Fire ATK),
        /// and LM2 (e.g. Trance, 35% Chance to Dualcast Spellblade)
        /// 
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/RatingPools (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;RatingPool&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharacterRatingRoute_RatingPools)]
        [SwaggerOperation(nameof(GetRatingPools))]
        [ProducesResponseType(typeof(IEnumerable<D.RatingPool>), (int)HttpStatusCode.OK)]
        public IActionResult GetRatingPools()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetRatingPools)}");

            IEnumerable<RatingPool> model = _characterRatingLogic.GetRatingPools();

            IEnumerable<D.RatingPool> result = _mapper.Map<IEnumerable<D.RatingPool>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets full list of FFRK Api CharacterRatings
        /// </summary>
        /// <remarks>
        /// This method is optimized for helping Legend Diving decisions. The list of CharacterRatingContextInfo objects is 
        /// like a pivoted take on RatingPools. Instead of looking at RatingPools and then inspecting what Characters are inside of them,
        /// this method is for looking at charcacters and seeing what RatingPools they participate in. 
        /// 
        /// But this data goeas beyond just showing RatingPools for a character; it also show other data useful when making diving decisions 
        /// such as proficient schools, Legend Materia, Legend Materia Relics, nad of course the Altema Rating and Roles.
        /// 
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/CharacterRating (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;CharacterRatingContextInfo&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharacterRatingRoute_All)]
        [SwaggerOperation(nameof(GetCharacterRatingContextInfos))]
        [ProducesResponseType(typeof(IEnumerable<D.CharacterRatingContextInfo>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharacterRatingContextInfos()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharacterRatingContextInfos)}");

            IEnumerable<CharacterRatingContextInfo> model = _characterRatingLogic.GetCharacterRatingContextInfos();

            IEnumerable<D.CharacterRatingContextInfo> result = _mapper.Map<IEnumerable<D.CharacterRatingContextInfo>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets a list (of one) of FFRK Api CharacterRatings for the requested FFRK Api character id. If you request an id that does not
        /// match a character, you get back a CharacterRating object with empty properties.
        /// </summary>
        /// <remarks>
        /// This method is optimized for helping Legend Diving decisions for a specific character. 
        /// 
        /// This data shows RatingPools for a character; it also show other data useful when making diving decisions 
        /// such as proficient schools, Legend Materia, Legend Materia Relics, nad of course the Altema Rating and Roles.
        /// 
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/CharacterRating/1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;CharacterRatingContextInfo&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharacterRatingRoute_Id)]
        [SwaggerOperation(nameof(GetCharacterRatingContextInfosByCharacterId))]
        [ProducesResponseType(typeof(IEnumerable<D.CharacterRatingContextInfo>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharacterRatingContextInfosByCharacterId(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharacterRatingContextInfosByCharacterId)}");

            IEnumerable<CharacterRatingContextInfo> model = _characterRatingLogic.GetCharacterRatingContextInfosByCharacterId(characterId);

            IEnumerable<D.CharacterRatingContextInfo> result = _mapper.Map<IEnumerable<D.CharacterRatingContextInfo>>(model);

            return new JsonResult(result, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Gets a list of FFRK Api CharacterRatings for characters whose name contains the requested character name string. 
        /// If you request an name that does not match any character, you get back a CharacterRating object with empty properties.
        /// </summary>
        /// <remarks>
        /// This method is optimized for helping Legend Diving decisions for a specific character that you match by name. 
        /// 
        /// This data shows RatingPools for a character; it also show other data useful when making diving decisions 
        /// such as proficient schools, Legend Materia, Legend Materia Relics, nad of course the Altema Rating and Roles.
        /// 
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/CharacterRating/cid (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;CharacterRatingContextInfo&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.CharacterRatingRoute_Name)]
        [SwaggerOperation(nameof(GetCharacterRatingContextInfosByCharacterName))]
        [ProducesResponseType(typeof(IEnumerable<D.CharacterRatingContextInfo>), (int)HttpStatusCode.OK)]
        public IActionResult GetCharacterRatingContextInfosByCharacterName(string characterName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetCharacterRatingContextInfosByCharacterName)}");

            IEnumerable<CharacterRatingContextInfo> model = _characterRatingLogic.GetCharacterRatingContextInfosByCharacterName(characterName);

            IEnumerable<D.CharacterRatingContextInfo> result = _mapper.Map<IEnumerable<D.CharacterRatingContextInfo>>(model);

            return new JsonResult(result, new JsonSerializerSettings(){Formatting = Formatting.Indented});
        } 

        #endregion
    }
}
