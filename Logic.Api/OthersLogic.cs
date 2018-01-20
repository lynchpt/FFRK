using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IOthersLogic
    {
    }

    public class OthersLogic : IOthersLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<OthersLogic> _logger;
        #endregion

        #region Constructors

        public OthersLogic(IEnlirRepository enlirRepository, ILogger<OthersLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IOthersLogic Implementation

        #endregion
    }
}
