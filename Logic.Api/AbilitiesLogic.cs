using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IAbilitiesLogic
    {
        IEnumerable<Ability> GetAllAbilities();
        IEnumerable<Ability> GetAbilitiesById(int abilityId);
        IEnumerable<Ability> GetAbilitiesByAbilityType(int abilityType);
        IEnumerable<Ability> GetAbilitiesByRarity(int rarity);
        IEnumerable<Ability> GetAbilitiesBySchool(int schoolType);
        IEnumerable<Ability> GetAbilitiesByElement(int elementType);
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
   
        public IEnumerable<Ability> GetAllAbilities()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllAbilities)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities;
        }

        public IEnumerable<Ability> GetAbilitiesById(int abilityId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesById)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.Id == abilityId);
        }

        public IEnumerable<Ability> GetAbilitiesByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByAbilityType)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.AbilityType == abilityType);
        }

        public IEnumerable<Ability> GetAbilitiesByRarity(int rarity)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByRarity)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.Rarity == rarity);
        }

        public IEnumerable<Ability> GetAbilitiesBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesBySchool)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.School == schoolType);
        }

        public IEnumerable<Ability> GetAbilitiesByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByElement)}");

            return _enlirRepository.GetMergeResultsContainer().Abilities.Where(a => a.Elements.Contains(elementType));
        }
        #endregion
    }
}
