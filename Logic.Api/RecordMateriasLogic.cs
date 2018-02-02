using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IRecordMateriasLogic
    {
        IEnumerable<RecordMateria> GetAllRecordMaterias();
        IEnumerable<RecordMateria> GetRecordMateriasById(int recordMateriaId);
        IEnumerable<RecordMateria> GetRecordMateriasByName(string recordMateriaName);
        IEnumerable<RecordMateria> GetAllRecordMateriasByRealm(int realmType);
        IEnumerable<RecordMateria> GetRecordMateriasByCharacter(int characterId);
        IEnumerable<RecordMateria> GetRecordMateriasByEffect(string effectText);
        IEnumerable<RecordMateria> GetRecordMateriasByUnlockCriteria(string unlockText);
        IEnumerable<RecordMateria> GetRecordMateriasBySearch(RecordMateria searchPrototype);
    }

    public class RecordMateriasLogic : IRecordMateriasLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RecordMateriasLogic> _logger;
        #endregion

        #region Constructors

        public RecordMateriasLogic(IEnlirRepository enlirRepository, ILogger<RecordMateriasLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IRecordMateriasLogic Implementation

        public IEnumerable<RecordMateria> GetAllRecordMaterias()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllRecordMaterias)}");

            return _enlirRepository.GetMergeResultsContainer().RecordMaterias;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasById(int recordMateriaId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasById)}");

            return _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(r => r.Id == recordMateriaId);
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByName(string recordMateriaName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByName)}");

            IEnumerable<RecordMateria> results = new List<RecordMateria>();

            if (!String.IsNullOrWhiteSpace(recordMateriaName))
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(e => e.RecordMateriaName.ToLower().Contains(recordMateriaName.ToLower()));
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetAllRecordMateriasByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllRecordMateriasByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(r => r.Realm == realmType);
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByCharacter)}");

            return _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(r => r.CharacterId == characterId);
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByEffect)}");

            IEnumerable<RecordMateria> results = new List<RecordMateria>();

            if (!String.IsNullOrWhiteSpace(effectText))
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(e => e.Effect.ToLower().Contains(effectText.ToLower()));
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasByUnlockCriteria(string unlockText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasByUnlockCriteria)}");

            IEnumerable<RecordMateria> results = new List<RecordMateria>();

            if (!String.IsNullOrWhiteSpace(unlockText))
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordMaterias.Where(e => e.UnlockCriteria.ToLower().Contains(unlockText.ToLower()));
            }

            return results;
        }

        public IEnumerable<RecordMateria> GetRecordMateriasBySearch(RecordMateria searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordMateriasBySearch)}");


            //ignore: Id, Description, LegendMateriaId, JapaneseName, CharacterName, ImagePath, RelicName, IsChecked
            var query = _enlirRepository.GetMergeResultsContainer().RecordMaterias;

            if (searchPrototype.Realm != 0)
            {
                query = query.Where(l => l.Realm == searchPrototype.Realm);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.RecordMateriaName))
            {
                query = query.Where(l => l.RecordMateriaName.ToLower().Contains(searchPrototype.RecordMateriaName.ToLower()));
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(l => l.CharacterId == searchPrototype.CharacterId);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.Effect))
            {
                query = query.Where(l => l.Effect.ToLower().Contains(searchPrototype.Effect.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.UnlockCriteria))
            {
                query = query.Where(l => l.UnlockCriteria.ToLower().Contains(searchPrototype.UnlockCriteria.ToLower()));
            }

            return query;
        }
        #endregion
    }
}
