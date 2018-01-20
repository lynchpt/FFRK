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
    public interface ICharactersController
    {
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class CharactersController : Controller, ICharactersController
    {
        #region Class Variables

        private readonly ICharactersLogic _charactersLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<CharactersController> _logger;
        #endregion

        #region Constructors

        public CharactersController(ICharactersLogic charactersLogic, IMapper mapper, ILogger<CharactersController> logger)
        {
            _charactersLogic = charactersLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ICharactersController Implementation

        #endregion
    }
}
