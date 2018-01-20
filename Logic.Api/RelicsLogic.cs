using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IRelicsLogic
    {
    }

    public class RelicsLogic : IRelicsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RelicsLogic> _logger;
        #endregion

        #region Constructors

        public RelicsLogic(IEnlirRepository enlirRepository, ILogger<RelicsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IRelicsLogic Implementation

        #endregion
    }
}
