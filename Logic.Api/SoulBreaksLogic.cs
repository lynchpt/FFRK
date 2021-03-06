﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ISoulBreaksLogic
    {
        IEnumerable<SoulBreak> GetAllSoulBreaks();
        IEnumerable<SoulBreak> GetSoulBreaksById(int soulBreakId);
        IEnumerable<SoulBreak> GetSoulBreaksByAbilityType(int abilityType);
        IEnumerable<SoulBreak> GetSoulBreaksByName(string soulBreakName);
        IEnumerable<SoulBreak> GetSoulBreaksByRealm(int realmType);
        IEnumerable<SoulBreak> GetSoulBreaksByCharacter(int characterId);
        IEnumerable<SoulBreak> GetSoulBreaksByMultiplier(int multiplier);
        IEnumerable<SoulBreak> GetSoulBreaksByElement(int elementType);
        IEnumerable<SoulBreak> GetSoulBreaksByEffect(string effectText);
        IEnumerable<SoulBreak> GetSoulBreaksByTier(int soulBreakTier);
        IEnumerable<SoulBreak> GetSoulBreaksByMasteryBonus(string masteryBonusText);
        IEnumerable<SoulBreak> GetSoulBreaksByStatus(int statusId);
        IEnumerable<SoulBreak> GetSoulBreaksBySearch(SoulBreak searchPrototype);
    }

    public class SoulBreaksLogic : ISoulBreaksLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<SoulBreaksLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public SoulBreaksLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<SoulBreaksLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region ISoulBreaksLogic Implementation

        public IEnumerable<SoulBreak> GetAllSoulBreaks()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllSoulBreaks)}");

            string cacheKey = $"{nameof(GetAllSoulBreaks)}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksById(int soulBreakId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksById)}");

            string cacheKey = $"{nameof(GetSoulBreaksById)}:{soulBreakId}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(s => s.Id == soulBreakId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByAbilityType)}");

            string cacheKey = $"{nameof(GetSoulBreaksByAbilityType)}:{abilityType}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(s => s.AbilityType == abilityType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByName(string soulBreakName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByName)}");

            string cacheKey = $"{nameof(GetSoulBreaksByName)}:{soulBreakName}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = new List<SoulBreak>();

                if (!String.IsNullOrWhiteSpace(soulBreakName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(e => e.SoulBreakName.ToLower().Contains(soulBreakName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByRealm)}");

            string cacheKey = $"{nameof(GetSoulBreaksByRealm)}:{realmType}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(s => s.Realm == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByCharacter)}");

            string cacheKey = $"{nameof(GetSoulBreaksByCharacter)}:{characterId}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(s => s.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByMultiplier(int multiplier)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByMultiplier)}");

            return _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(s => s.Multiplier >= multiplier);
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByElement)}");

            string cacheKey = $"{nameof(GetSoulBreaksByElement)}:{elementType}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where
                    (a => a.Elements.Contains(elementType) ||
                      a.Commands.Any(c => c.Elements.Contains(elementType)) ||
                      a.OtherEffects.Any(e => e.Elements.Contains(elementType)));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByEffect)}");

            string cacheKey = $"{nameof(GetSoulBreaksByEffect)}:{effectText}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = new List<SoulBreak>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(e => e.Effects.ToLower().Contains(effectText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByTier(int soulBreakTier)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByTier)}");

            string cacheKey = $"{nameof(GetSoulBreaksByTier)}:{soulBreakTier}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(a => a.SoulBreakTier == soulBreakTier);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByMasteryBonus(string masteryBonusText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByMasteryBonus)}");

            string cacheKey = $"{nameof(GetSoulBreaksByMasteryBonus)}:{masteryBonusText}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = new List<SoulBreak>();

                if (!String.IsNullOrWhiteSpace(masteryBonusText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(e => e.MasteryBonus.ToLower().Contains(masteryBonusText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksByStatus(int statusId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksByStatus)}");

            string cacheKey = $"{nameof(GetSoulBreaksByStatus)}:{statusId}";
            IEnumerable<SoulBreak> results = _cacheProvider.ObjectGet<IList<SoulBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SoulBreaks.Where(a => a.Statuses.Any(s => s.Id == statusId));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SoulBreak> GetSoulBreaksBySearch(SoulBreak searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSoulBreaksBySearch)}");


            //ignore: Description, Effects, EnlirId, Id, ImagePath, IntroducingEventId, IntroducingEventName, IsChecked, IsCounterable, SoulBreakPointsGainedJapan
            var query = _enlirRepository.GetMergeResultsContainer().SoulBreaks;

            if (searchPrototype.AbilityType != 0)
            {
                query = query.Where(a => a.AbilityType == searchPrototype.AbilityType);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.SoulBreakName))
            {
                query = query.Where(a => a.SoulBreakName.ToLower().Contains(searchPrototype.SoulBreakName.ToLower()));
            }
            if (searchPrototype.Realm != 0)
            {
                query = query.Where(a => a.Realm == searchPrototype.Realm);
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(a => a.CharacterId == searchPrototype.CharacterId);
            }
            if (searchPrototype.Multiplier != 0)
            {
                query = query.Where(a => a.Multiplier >= searchPrototype.Multiplier);
            }           
            if (searchPrototype.Elements != null && searchPrototype.Elements.Any())
            {
                query = query.Where(a => a.Elements.Contains(searchPrototype.Elements.First()) ||
                                         a.Commands.Any(c => c.Elements.Contains(searchPrototype.Elements.First())) ||
                                         a.OtherEffects.Any(e => e.Elements.Contains(searchPrototype.Elements.First())));
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.Effects))
            {
                query = query.Where(a => a.Effects.ToLower().Contains(searchPrototype.Effects.ToLower()));
            }
            if (searchPrototype.SoulBreakTier != 0)
            {
                query = query.Where(a => a.SoulBreakTier == searchPrototype.SoulBreakTier);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.MasteryBonus))
            {
                query = query.Where(a => a.MasteryBonus.ToLower().Contains(searchPrototype.MasteryBonus.ToLower()));
            }
            if (searchPrototype.Statuses != null && searchPrototype.Statuses.Any())
            {
                query = query.Where(a => a.Statuses.Any(s => s.Id == searchPrototype.Statuses.First().Id));
            }
            if (searchPrototype.AutoTargetType != 0)
            {
                query = query.Where(a => a.AutoTargetType == searchPrototype.AutoTargetType);
            }
            if (searchPrototype.CastTime != 0)
            {
                query = query.Where(a => a.CastTime <= searchPrototype.CastTime);
            }
            if (searchPrototype.DamageFormulaType != 0)
            {
                query = query.Where(a => a.DamageFormulaType == searchPrototype.DamageFormulaType);
            }           
            if (searchPrototype.TargetType != 0)
            {
                query = query.Where(a => a.TargetType == searchPrototype.TargetType);
            }


            return query;
        }
        #endregion
    }
}
