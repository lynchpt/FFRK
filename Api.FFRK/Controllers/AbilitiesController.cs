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
    public interface IAbilitiesController
    {
        
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class AbilitiesController : Controller, IAbilitiesController
    {
        #region Class Variables

        private readonly IAbilitiesLogic _abilitiesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<AbilitiesController> _logger;
        #endregion

        #region Constructors

        public AbilitiesController(IAbilitiesLogic abilitiesLogic, IMapper mapper, ILogger<AbilitiesController> logger)
        {
            _abilitiesLogic = abilitiesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IAbilitiesController Implementation

        #endregion
    }
}
