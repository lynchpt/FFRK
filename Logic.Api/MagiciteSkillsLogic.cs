using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
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
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public MagiciteSkillsLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<MagiciteSkillsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IMagiciteSkillsLogic Implementation
        public IEnumerable<MagiciteSkill> GetAllMagiciteSkills()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMagiciteSkills)}");

            string cacheKey = $"{nameof(GetAllMagiciteSkills)}";
            IEnumerable<MagiciteSkill> results = _cacheProvider.ObjectGet<IList<MagiciteSkill>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().MagiciteSkills;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<MagiciteSkill> GetAllMagiciteSkillsById(int magiciteSkillId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMagiciteSkillsById)}");

            string cacheKey = $"{nameof(GetAllMagiciteSkillsById)}:{magiciteSkillId}";
            IEnumerable<MagiciteSkill> results = _cacheProvider.ObjectGet<IList<MagiciteSkill>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().MagiciteSkills.Where(s => s.Id == magiciteSkillId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }
        #endregion


    }
}
