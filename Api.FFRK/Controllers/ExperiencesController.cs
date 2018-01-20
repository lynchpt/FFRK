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
    public interface IExperiencesController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class ExperiencesController : Controller, IExperiencesController
    {
        #region Class Variables

        private readonly IExperiencesLogic _experiencesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<ExperiencesController> _logger;
        #endregion

        #region Constructors

        public ExperiencesController(IExperiencesLogic experiencesLogic, IMapper mapper, ILogger<ExperiencesController> logger)
        {
            _experiencesLogic = experiencesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IExperiencesController Implementation

        #endregion
    }
}
