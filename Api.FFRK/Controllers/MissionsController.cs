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
    public interface IMissionsController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class MissionsController : Controller, IMissionsController
    {
        #region Class Variables

        private readonly IMissionsLogic _missionsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<MissionsController> _logger;
        #endregion

        #region Constructors

        public MissionsController(IMissionsLogic missionsLogic, IMapper mapper, ILogger<MissionsController> logger)
        {
            _missionsLogic = missionsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IMissionsController Implementation

        #endregion
    }
}
