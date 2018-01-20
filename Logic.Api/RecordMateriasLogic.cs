using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IRecordMateriasLogic
    {
    }

    public class RecordMateriasLogic : IRecordMateriasLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RecordMateriasLogic> _logger;
        #endregion

        #region Constructors

        public RecordMateriasLogic(IEnlirRepository enlirRepository, ILogger<RecordMateriasLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IRecordMateriasLogic Implementation

        #endregion
    }
}
