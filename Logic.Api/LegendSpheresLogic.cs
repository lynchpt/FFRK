using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ILegendSpheresLogic
    {
    }

    public class LegendSpheresLogic : ILegendSpheresLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<LegendSpheresLogic> _logger;
        #endregion

        #region Constructors

        public LegendSpheresLogic(IEnlirRepository enlirRepository, ILogger<LegendSpheresLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ILegendSpheresLogic Implementation

        #endregion
    }
}
