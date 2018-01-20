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
    public interface IMagicitesController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class MagicitesController : Controller, IMagicitesController
    {
        #region Class Variables

        private readonly IMagicitesLogic _magicitesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<MagicitesController> _logger;
        #endregion

        #region Constructors

        public MagicitesController(IMagicitesLogic magicitesLogic, IMapper mapper, ILogger<MagicitesController> logger)
        {
            _magicitesLogic = magicitesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IMagicitesController Implementation

        #endregion
    }
}
