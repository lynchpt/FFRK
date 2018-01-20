using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ISoulBreaksLogic
    {
    }

    public class SoulBreaksLogic : ISoulBreaksLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<SoulBreaksLogic> _logger;
        #endregion

        #region Constructors

        public SoulBreaksLogic(IEnlirRepository enlirRepository, ILogger<SoulBreaksLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ISoulBreaksLogic Implementation

        #endregion
    }
}
