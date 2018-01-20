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
    public interface ILegendSpheresController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class LegendSpheresController : Controller, ILegendSpheresController
    {
        #region Class Variables

        private readonly ILegendSpheresLogic _legendSpheresLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<LegendSpheresController> _logger;
        #endregion

        #region Constructors

        public LegendSpheresController(ILegendSpheresLogic legendSpheresLogic, IMapper mapper, ILogger<LegendSpheresController> logger)
        {
            _legendSpheresLogic = legendSpheresLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ILegendSpheresController Implementation

        #endregion
    }
}
