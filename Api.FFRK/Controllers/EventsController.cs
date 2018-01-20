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
    public interface IEventsController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class EventsController : Controller, IEventsController
    {
        #region Class Variables

        private readonly IEventsLogic _eventsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<EventsController> _logger;
        #endregion

        #region Constructors

        public EventsController(IEventsLogic eventsLogic, IMapper mapper, ILogger<EventsController> logger)
        {
            _eventsLogic = eventsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IEventsController Implementation

        #endregion
    }
}
