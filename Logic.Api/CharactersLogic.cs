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
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public CharactersLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<CharactersLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region ICharactersLogic Implementation

        public IEnumerable<Character> GetAllCharacters()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllCharacters)}");

            string cacheKey = nameof(GetAllCharacters);
            IEnumerable<Character> results = _cacheProvider.ObjectGet<IList<Character>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Characters;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Character> GetCharactersById(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersById)}");

            string cacheKey = $"{nameof(GetCharactersById)}:{characterId}";
            IEnumerable<Character> results = _cacheProvider.ObjectGet<IList<Character>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.Id == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Character> GetCharactersByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersByRealm)}");

            string cacheKey = $"{nameof(GetCharactersByRealm)}:{realmType}";
            IEnumerable<Character> results = _cacheProvider.ObjectGet<IList<Character>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.Realm == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Character> GetCharactersByName(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersByName)}");

            string cacheKey = $"{nameof(GetCharactersByName)}:{characterName}";
            IEnumerable<Character> results = _cacheProvider.ObjectGet<IList<Character>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.CharacterName.ToLower().Contains(characterName.ToLower()));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Character> GetCharactersByEquipmentAccess(int equipmentType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersByEquipmentAccess)}");

            string cacheKey = $"{nameof(GetCharactersByEquipmentAccess)}:{equipmentType}";
            IEnumerable<Character> results = _cacheProvider.ObjectGet<IList<Character>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.EquipmentAccessInfos.Any(i => i.EquipmentType == equipmentType && i.CanAccess == true));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<Character> GetCharactersBySchoolAccess(int schoolType, int schoolMinLevel)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharactersBySchoolAccess)}");

            string cacheKey = $"{nameof(GetCharactersBySchoolAccess)}:{schoolType}:{schoolMinLevel}";
            IEnumerable<Character> results = _cacheProvider.ObjectGet<IList<Character>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.SchoolAccessInfos.Any(i => i.School == schoolType && i.AccessLevel >= schoolMinLevel));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
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
