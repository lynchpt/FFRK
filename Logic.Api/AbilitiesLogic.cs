using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IAbilitiesLogic
    {

    }

    public class AbilitiesLogic : IAbilitiesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<AbilitiesLogic> _logger;
        #endregion

        #region Constructors

        public AbilitiesLogic(IEnlirRepository enlirRepository, ILogger<AbilitiesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IAbilitiesLogic Implementation

        #endregion
    }
}
