using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ICharactersLogic
    {
    }

    public class CharactersLogic : ICharactersLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<CharactersLogic> _logger;
        #endregion

        #region Constructors

        public CharactersLogic(IEnlirRepository enlirRepository, ILogger<CharactersLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ICharactersLogic Implementation

        #endregion
    }
}
