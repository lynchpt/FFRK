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
    public interface ICommandsController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class CommandsController : Controller, ICommandsController
    {
        #region Class Variables

        private readonly ICommandsLogic _commandsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<CommandsController> _logger;
        #endregion

        #region Constructors

        public CommandsController(ICommandsLogic commandsLogic, IMapper mapper, ILogger<CommandsController> logger)
        {
            _commandsLogic = commandsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ICommandsController Implementation

        #endregion
    }
}
