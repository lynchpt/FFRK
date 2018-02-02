﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMagiciteSkillsLogic
    {
        IEnumerable<MagiciteSkill> GetAllMagiciteSkills();
        IEnumerable<MagiciteSkill> GetAllMagiciteSkillsById(int magiciteSkillId);
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

        public IEnumerable<MagiciteSkill> GetAllMagiciteSkills()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMagiciteSkills)}");

            return _enlirRepository.GetMergeResultsContainer().MagiciteSkills;
        }

        public IEnumerable<MagiciteSkill> GetAllMagiciteSkillsById(int magiciteSkillId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMagiciteSkillsById)}");

            return _enlirRepository.GetMergeResultsContainer().MagiciteSkills.Where(s => s.Id == magiciteSkillId);
        }
    }
}
