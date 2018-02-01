using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMagicitesLogic
    {
        //Magicite
        IEnumerable<Magicite> GetAllMagicites();
        IEnumerable<Magicite> GetMagicitesById(int magiciteId);
        IEnumerable<Magicite> GetMagicitesByName(string magiciteName);
        IEnumerable<Magicite> GetMagicitesByRealm(int realmType);
        IEnumerable<Magicite> GetMagicitesByRarity(int rarity);
        IEnumerable<Magicite> GetMagicitesByElement(int elementType);
        IEnumerable<Magicite> GetMagicitesByPassiveEffect(string passiveEffect);

        //UltraSkill
        IEnumerable<Magicite> GetMagicitesByUltraSkillName(string ultraSkillName);
        IEnumerable<Magicite> GetMagicitesByUltraSkillAbilityType(int abilityType);
        IEnumerable<Magicite> GetMagicitesByUltraSkillElement(int elementType);
        IEnumerable<Magicite> GetMagicitesByUltraSkillEffect(string effectText);

        //MagiciteSkill
        IEnumerable<Magicite> GetMagicitesByMagiciteSkillId(int magiciteSkillId);
        IEnumerable<Magicite> GetMagicitesByMagiciteSkillName(string magiciteSkillName);
        IEnumerable<Magicite> GetMagicitesByMagiciteSkillAbilityType(int abilityType);
        IEnumerable<Magicite> GetMagicitesByMagiciteSkillElement(int elementType);
        IEnumerable<Magicite> GetMagicitesByMagiciteSkillEffect(string effectText);
    }

    public class MagicitesLogic : IMagicitesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<MagicitesLogic> _logger;
        #endregion

        #region Constructors

        public MagicitesLogic(IEnlirRepository enlirRepository, ILogger<MagicitesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IMagicitesLogic Implementation

        //Magicite
        public IEnumerable<Magicite> GetAllMagicites()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMagicites)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites;
        }

        public IEnumerable<Magicite> GetMagicitesById(int magiciteId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesById)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Id == magiciteId);
        }

        public IEnumerable<Magicite> GetMagicitesByName(string magiciteName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByName)}");

            IEnumerable<Magicite> results = new List<Magicite>();

            if (!String.IsNullOrWhiteSpace(magiciteName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteName.ToLower().Contains(magiciteName.ToLower()));
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Realm == realmType);
        }

        public IEnumerable<Magicite> GetMagicitesByRarity(int rarity)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByRarity)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Rarity == rarity);
        }

        public IEnumerable<Magicite> GetMagicitesByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByElement)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Element == elementType);
        }

        public IEnumerable<Magicite> GetMagicitesByPassiveEffect(string passiveEffect)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByPassiveEffect)}");

            IEnumerable<Magicite> results = new List<Magicite>();

            if (!String.IsNullOrWhiteSpace(passiveEffect))
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.PassiveEffects.Any(p => p.Name.ToLower().Contains(passiveEffect.ToLower())));
            }

            return results;
        }

        //UltraSkill
        public IEnumerable<Magicite> GetMagicitesByUltraSkillName(string ultraSkillName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillName)}");

            IEnumerable<Magicite> results = new List<Magicite>();

            if (!String.IsNullOrWhiteSpace(ultraSkillName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.Name.ToLower().Contains(ultraSkillName.ToLower()));
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByUltraSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillAbilityType)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.AbilityType == abilityType);
        }

        public IEnumerable<Magicite> GetMagicitesByUltraSkillElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillElement)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.Element == elementType);
        }

        public IEnumerable<Magicite> GetMagicitesByUltraSkillEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillEffect)}");

            IEnumerable<Magicite> results = new List<Magicite>();

            if (!String.IsNullOrWhiteSpace(effectText))
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.Effects.ToLower().Contains(effectText.ToLower()));
            }

            return results;
        }

        //MagiciteSkill
        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillId(int magiciteSkillId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillId)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.Id == magiciteSkillId));
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillName(string magiciteSkillName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillName)}");

            IEnumerable<Magicite> results = new List<Magicite>();

            if (!String.IsNullOrWhiteSpace(magiciteSkillName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.SkillName.ToLower().Contains(magiciteSkillName.ToLower())));
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillAbilityType)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.AbilityType == abilityType));
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillElement)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.Element == elementType));
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillEffect)}");

            return _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.Effects.ToLower().Contains(effectText.ToLower())));
        }

        #endregion
    }
}
