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
    public interface ILegendMateriasController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class LegendMateriasController : Controller, ILegendMateriasController
    {
        #region Class Variables

        private readonly ILegendMateriasLogic _legendMateriasLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<LegendMateriasController> _logger;
        #endregion

        #region Constructors

        public LegendMateriasController(ILegendMateriasLogic legendMateriasLogic, IMapper mapper, ILogger<LegendMateriasController> logger)
        {
            _legendMateriasLogic = legendMateriasLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ILegendMateriasController Implementation

        #endregion
    }
}
