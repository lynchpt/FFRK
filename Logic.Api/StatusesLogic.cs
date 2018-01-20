using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IStatusesLogic
    {
    }

    public class StatusesLogic : IStatusesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<StatusesLogic> _logger;
        #endregion

        #region Constructors

        public StatusesLogic(IEnlirRepository enlirRepository, ILogger<StatusesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IStatusesLogic Implementation

        #endregion
    }
}
