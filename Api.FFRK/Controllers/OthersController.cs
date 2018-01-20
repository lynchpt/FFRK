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
    public interface IOthersController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class OthersController : Controller, IOthersController
    {
        #region Class Variables

        private readonly IOthersLogic _othersLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<OthersController> _logger;
        #endregion

        #region Constructors

        public OthersController(IOthersLogic othersLogic, IMapper mapper, ILogger<OthersController> logger)
        {
            _othersLogic = othersLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IOthersController Implementation

        #endregion
    }
}
