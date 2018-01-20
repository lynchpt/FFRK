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
    public interface IDungeonsController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class DungeonsController : Controller, IDungeonsController
    {
        #region Class Variables

        private readonly IDungeonsLogic _dungeonsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<DungeonsController> _logger;
        #endregion

        #region Constructors

        public DungeonsController(IDungeonsLogic dungeonsLogic, IMapper mapper, ILogger<DungeonsController> logger)
        {
            _dungeonsLogic = dungeonsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IDungeonsController Implementation

        #endregion
    }
}
