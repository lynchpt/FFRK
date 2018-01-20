using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ILegendMateriasLogic
    {
    }

    public class LegendMateriasLogic : ILegendMateriasLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<LegendMateriasLogic> _logger;
        #endregion

        #region Constructors

        public LegendMateriasLogic(IEnlirRepository enlirRepository, ILogger<LegendMateriasLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ILegendMateriasLogic Implementation

        #endregion
    }
}
