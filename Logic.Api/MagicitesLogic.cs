using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMagicitesLogic
    {
    }

    public class MagicitesLogic : IMagicitesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<MagicitesLogic> _logger;
        #endregion

        #region Constructors

        public MagicitesLogic(IEnlirRepository enlirRepository, ILogger<MagicitesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IMagicitesLogic Implementation

        #endregion
    }
}
