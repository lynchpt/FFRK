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
    public interface IRecordMateriasController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class RecordMateriasController : Controller, IRecordMateriasController
    {
        #region Class Variables

        private readonly IRecordMateriasLogic _recordMateriasLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<RecordMateriasController> _logger;
        #endregion

        #region Constructors

        public RecordMateriasController(IRecordMateriasLogic recordMateriasLogic, IMapper mapper, ILogger<RecordMateriasController> logger)
        {
            _recordMateriasLogic = recordMateriasLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IRecordMateriasController Implementation

        #endregion
    }
}
