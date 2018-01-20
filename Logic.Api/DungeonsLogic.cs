using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IDungeonsLogic
    {
    }

    public class DungeonsLogic : IDungeonsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<DungeonsLogic> _logger;
        #endregion

        #region Constructors

        public DungeonsLogic(IEnlirRepository enlirRepository, ILogger<DungeonsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IDungeonsLogic Implementation

        #endregion
    }
}
