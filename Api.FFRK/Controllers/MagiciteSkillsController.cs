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

        [HttpGet]
        [Route(RouteConstants.MagicitesRoute_All)]
        [SwaggerOperation(nameof(GetAllMagiciteSkills))]
        [ProducesResponseType(typeof(IEnumerable<D.MagiciteSkill>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllMagiciteSkills()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllMagiciteSkills)}");

            IEnumerable<MagiciteSkill> model = _magiciteSkillsLogic.GetAllMagiciteSkills();

            IEnumerable<D.MagiciteSkill> result = _mapper.Map<IEnumerable<D.MagiciteSkill>>(model);

            return new ObjectResult(result);
        }

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

        #endregion

    }
}
