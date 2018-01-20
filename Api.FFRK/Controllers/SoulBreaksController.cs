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
    public interface ISoulBreaksController
    {
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

        #endregion
    }
}
