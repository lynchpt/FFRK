using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMissionsLogic
    {
    }

    public class MissionsLogic : IMissionsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<MissionsLogic> _logger;
        #endregion

        #region Constructors

        public MissionsLogic(IEnlirRepository enlirRepository, ILogger<MissionsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IMissionsLogic Implementation

        #endregion
    }
}
