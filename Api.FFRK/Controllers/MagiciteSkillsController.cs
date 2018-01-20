using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IMagiciteSkillsController
    {
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

        #endregion
    }
}
