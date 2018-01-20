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
    public interface IRelicsController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RelicsController : Controller, IRelicsController
    {
        #region Class Variables

        private readonly IRelicsLogic _relicsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RelicsController> _logger;
        #endregion

        #region Constructors

        public RelicsController(IRelicsLogic relicsLogic, IMapper mapper, ILogger<RelicsController> logger)
        {
            _relicsLogic = relicsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRelicsController Implementation

        #endregion
    }
}
