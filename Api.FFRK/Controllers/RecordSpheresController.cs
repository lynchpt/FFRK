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
    public interface IRecordSpheresController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RecordSpheresController : Controller, IRecordSpheresController
    {
        #region Class Variables

        private readonly IRecordSpheresLogic _recordSpheresLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordSpheresController> _logger;
        #endregion

        #region Constructors

        public RecordSpheresController(IRecordSpheresLogic recordSpheresLogic, IMapper mapper, ILogger<RecordSpheresController> logger)
        {
            _recordSpheresLogic = recordSpheresLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRecordSpheresController Implementation

        #endregion
    }
}
