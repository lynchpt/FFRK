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
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public MagicitesLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<MagicitesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region IMagicitesLogic Implementation

        //Magicite
        public IEnumerable<Magicite> GetAllMagicites()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMagicites)}");

            string cacheKey = $"{nameof(GetAllMagicites)}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesById(int magiciteId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesById)}");

            string cacheKey = $"{nameof(GetMagicitesById)}:{magiciteId}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Id == magiciteId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByName(string magiciteName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByName)}");

            string cacheKey = $"{nameof(GetMagicitesByName)}:{magiciteName}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = new List<Magicite>();

                if (!String.IsNullOrWhiteSpace(magiciteName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteName.ToLower().Contains(magiciteName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByRealm)}");

            string cacheKey = $"{nameof(GetMagicitesByRealm)}:{realmType}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Realm == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByRarity(int rarity)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByRarity)}");

            string cacheKey = $"{nameof(GetMagicitesByRarity)}:{rarity}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Rarity == rarity);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByElement)}");

            string cacheKey = $"{nameof(GetMagicitesByElement)}:{elementType}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.Element == elementType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByPassiveEffect(string passiveEffect)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByPassiveEffect)}");

            string cacheKey = $"{nameof(GetMagicitesByPassiveEffect)}:{passiveEffect}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = new List<Magicite>();

                if (!String.IsNullOrWhiteSpace(passiveEffect))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.PassiveEffects.Any(p => p.Name.ToLower().Contains(passiveEffect.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        //UltraSkill
        public IEnumerable<Magicite> GetMagicitesByUltraSkillName(string ultraSkillName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillName)}");

            string cacheKey = $"{nameof(GetMagicitesByUltraSkillName)}:{ultraSkillName}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = new List<Magicite>();
                if (!String.IsNullOrWhiteSpace(ultraSkillName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.Name.ToLower().Contains(ultraSkillName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByUltraSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillAbilityType)}");

            string cacheKey = $"{nameof(GetMagicitesByUltraSkillAbilityType)}:{abilityType}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.AbilityType == abilityType);
                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByUltraSkillElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillElement)}");

            string cacheKey = $"{nameof(GetMagicitesByUltraSkillElement)}:{elementType}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.Element == elementType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByUltraSkillEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByUltraSkillEffect)}");

            string cacheKey = $"{nameof(GetMagicitesByUltraSkillEffect)}:{effectText}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = new List<Magicite>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.UltraSkill != null && e.UltraSkill.Effects.ToLower().Contains(effectText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        //MagiciteSkill
        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillId(int magiciteSkillId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillId)}");

            string cacheKey = $"{nameof(GetMagicitesByMagiciteSkillId)}:{magiciteSkillId}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.Id == magiciteSkillId));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillName(string magiciteSkillName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillName)}");

            string cacheKey = $"{nameof(GetMagicitesByMagiciteSkillName)}:{magiciteSkillName}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = new List<Magicite>();

                if (!String.IsNullOrWhiteSpace(magiciteSkillName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.SkillName.ToLower().Contains(magiciteSkillName.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillAbilityType)}");

            string cacheKey = $"{nameof(GetMagicitesByMagiciteSkillAbilityType)}:{abilityType}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.AbilityType == abilityType));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillElement)}");

            string cacheKey = $"{nameof(GetMagicitesByMagiciteSkillElement)}:{elementType}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.Element == elementType));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Magicite> GetMagicitesByMagiciteSkillEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMagicitesByMagiciteSkillEffect)}");

            string cacheKey = $"{nameof(GetMagicitesByMagiciteSkillEffect)}:{effectText}";
            IEnumerable<Magicite> results = _cacheProvider.ObjectGet<IList<Magicite>>(cacheKey);

            if (results == null)
            {
                results = new List<Magicite>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().Magicites.Where(e => e.MagiciteSkills.Any(s => s.Effects.ToLower().Contains(effectText.ToLower())));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        #endregion
    }
}
