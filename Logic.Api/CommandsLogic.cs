using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ICommandsLogic
    {
    }

    public class CommandsLogic : ICommandsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<CommandsLogic> _logger;
        #endregion

        #region Constructors

        public CommandsLogic(IEnlirRepository enlirRepository, ILogger<CommandsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ICommandsLogic Implementation

        #endregion
    }
}
