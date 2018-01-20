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
    public interface IStatusesController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class StatusesController : Controller, IStatusesController
    {
        #region Class Variables

        private readonly IStatusesLogic _statusesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<StatusesController> _logger;
        #endregion

        #region Constructors

        public StatusesController(IStatusesLogic statusesLogic, IMapper mapper, ILogger<StatusesController> logger)
        {
            _statusesLogic = statusesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region I_Controller Implementation

        #endregion
    }
}
