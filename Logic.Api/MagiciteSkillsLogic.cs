using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMagiciteSkillsLogic
    {
    }

    public class MagiciteSkillsLogic : IMagiciteSkillsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<MagiciteSkillsLogic> _logger;
        #endregion

        #region Constructors

        public MagiciteSkillsLogic(IEnlirRepository enlirRepository, ILogger<MagiciteSkillsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IMagiciteSkillsLogic Implementation

        #endregion
    }
}
