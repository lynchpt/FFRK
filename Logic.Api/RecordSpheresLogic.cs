using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IRecordSpheresLogic
    {
    }

    public class RecordSpheresLogic : IRecordSpheresLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RecordSpheresLogic> _logger;
        #endregion

        #region Constructors

        public RecordSpheresLogic(IEnlirRepository enlirRepository, ILogger<RecordSpheresLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IRecordSpheresLogic Implementation

        #endregion
    }
}
