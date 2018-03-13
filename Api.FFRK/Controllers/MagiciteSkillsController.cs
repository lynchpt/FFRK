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
    public interface IMagiciteSkillsController
    {
        IActionResult GetAllMagiciteSkills();
        IActionResult GetMagiciteSkillsById(int magiciteSkillId);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class MagiciteSkillsController : Controller, IMagiciteSkillsController
    {
        #region Class Variables

        private readonly IMagiciteSkillsLogic _magiciteSkillsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<MagiciteSkillsController> _logger;
        #endregion

        #region Constructors

        public MagiciteSkillsController(IMagiciteSkillsLogic magiciteSkillsLogic, IMapper mapper, ILogger<MagiciteSkillsController> logger)
        {
            _magiciteSkillsLogic = magiciteSkillsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IMagiciteSkillsController Implementation

        /// <summary>
        /// Gets all MagiciteSkills and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of MagiciteSkills, it is faster to get each individual ability MagiciteSkills using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/MagiciteSkills (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;MagiciteSkill&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagiciteSkillsRoute_All)]
        [SwaggerOperation(nameof(GetAllMagiciteSkills))]
        [ProducesResponseType(typeof(IEnumerable<D.MagiciteSkill>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMagiciteSkills()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMagiciteSkills)}");

            IEnumerable<MagiciteSkill> model = _magiciteSkillsLogic.GetAllMagiciteSkills();

            IEnumerable<D.MagiciteSkill> result = _mapper.Map<IEnumerable<D.MagiciteSkill>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one MagiciteSkill by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the King Bomb (XII) MagiciteSkill Short Fuse.
        /// - You first call /api/v1.0/IdLists/MagiciteSkill to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "King Bomb" and "Short Fuse" in the IdList (the id is 19 in this case)
        /// - Finally you call this api: api/v1.0/MagiciteSkills/19
        /// <br /> 
        /// Example - http://ffrkapi.azurewebsites.net/api/v1.0/MagiciteSkills/19 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="magiciteSkillId">the integer id for the desired MagiciteSkill; it can be found in the MagiciteSkill IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;MagiciteSkill&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.MagiciteSkillsRoute_Id)]
        [SwaggerOperation(nameof(GetMagiciteSkillsById))]
        [ProducesResponseType(typeof(IEnumerable<D.MagiciteSkill>), (int)HttpStatusCode.OK)]
        public IActionResult GetMagiciteSkillsById(int magiciteSkillId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetMagiciteSkillsById)}");

            IEnumerable<MagiciteSkill> model = _magiciteSkillsLogic.GetAllMagiciteSkillsById(magiciteSkillId);

            IEnumerable<D.MagiciteSkill> result = _mapper.Map<IEnumerable<D.MagiciteSkill>>(model);

            return new ObjectResult(result);
        }

        //comment to force push to azure
        #endregion

    }
}
