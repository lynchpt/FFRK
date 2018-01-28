using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ICharactersLogic
    {
        IEnumerable<Character> GetAllCharacters();
        IEnumerable<Character> GetCharactersById(int characterId);
        IEnumerable<Character> GetCharactersByRealm(int realmType);
        IEnumerable<Character> GetCharactersByName(string characterName);
        IEnumerable<Character> GetCharactersByEquipmentAccess(int equipmentType);
        IEnumerable<Character> GetCharactersBySchoolAccess(int schoolType, int schoolMinLevel);
        IEnumerable<Character> GetCharactersBySearch(Character searchPrototype);
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

        public IEnumerable<Character> GetAllCharacters()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllCharacters)}");

            return _enlirRepository.GetMergeResultsContainer().Characters;
        }

        public IEnumerable<Character> GetCharactersById(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersById)}");

            return _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.Id == characterId);
        }

        public IEnumerable<Character> GetCharactersByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.Realm == realmType);
        }

        public IEnumerable<Character> GetCharactersByName(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersByName)}");

            return _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.CharacterName.ToLower().Contains(characterName.ToLower()));
        }

        public IEnumerable<Character> GetCharactersByEquipmentAccess(int equipmentType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersByEquipmentAccess)}");

            return _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.EquipmentAccessInfos.Any(i => i.EquipmentType == equipmentType && i.CanAccess == true));
        }

        public IEnumerable<Character> GetCharactersBySchoolAccess(int schoolType, int schoolMinLevel)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersBySchoolAccess)}");

            return _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.SchoolAccessInfos.Any(i => i.School == schoolType && i.AccessLevel >= schoolMinLevel));

        }

        public IEnumerable<Character> GetCharactersBySearch(Character searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersBySearch)}");


            //ignore: all but the same attributes exposed in the standard get methods. Here we just allow more than one at a time to be used. Also igore Id.
            var query = _enlirRepository.GetMergeResultsContainer().Characters;

            if (searchPrototype.Realm != 0)
            {
                query = query.Where(c => c.Realm == searchPrototype.Realm);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.CharacterName))
            {
                query = query.Where(c => c.CharacterName.ToLower().Contains(searchPrototype.CharacterName.ToLower()));
            }
            if (searchPrototype.EquipmentAccessInfos.Any())
            {
                query = query.Where(c => c.EquipmentAccessInfos.Any(i => i.EquipmentType == searchPrototype.EquipmentAccessInfos.First().EquipmentType && i.CanAccess == true));
            }
            if (searchPrototype.SchoolAccessInfos.Any())
            {
                query = query.Where(c => c.SchoolAccessInfos.Any(i => i.School == searchPrototype.SchoolAccessInfos.First().School && i.AccessLevel >= searchPrototype.SchoolAccessInfos.First().AccessLevel));
            }

            return query;
        }

        #endregion
    }
}
