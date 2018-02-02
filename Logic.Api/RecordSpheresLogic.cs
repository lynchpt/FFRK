using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IRecordSpheresLogic
    {
        IEnumerable<RecordSphere> GetAllRecordSpheres();
        IEnumerable<RecordSphere> GetRecordSpheresById(int recordSphereId);
        IEnumerable<RecordSphere> GetRecordSpheresByRealm(int realmType);
        IEnumerable<RecordSphere> GetRecordSpheresByCharacter(int characterId);
        IEnumerable<RecordSphere> GetRecordSpheresByBenefit(string benefit);
        IEnumerable<RecordSphere> GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2);
        IEnumerable<RecordSphere> GetRecordSpheresBySearch(RecordSphere searchPrototype);
    }

    public class RecordSpheresLogic : IRecordSpheresLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RecordSpheresLogic> _logger;
        #endregion

        #region Constructors

        public RecordSpheresLogic(IEnlirRepository enlirRepository, ILogger<RecordSpheresLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IRecordSpheresLogic Implementation

        public IEnumerable<RecordSphere> GetAllRecordSpheres()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllRecordSpheres)}");

            return _enlirRepository.GetMergeResultsContainer().RecordSpheres;
        }

        public IEnumerable<RecordSphere> GetRecordSpheresById(int recordSphereId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresById)}");

            return _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(e => e.Id == recordSphereId);
        }

        public IEnumerable<RecordSphere> GetRecordSpheresByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(e => e.Realm == realmType);
        }

        public IEnumerable<RecordSphere> GetRecordSpheresByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresByCharacter)}");

            return _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(e => e.CharacterId == characterId);
        }

        public IEnumerable<RecordSphere> GetRecordSpheresByBenefit(string benefit)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresByBenefit)}");

            IEnumerable<RecordSphere> results = new List<RecordSphere>();

            if (!String.IsNullOrWhiteSpace(benefit))
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(
                    l => l.RecordSphereLevels.Any(i => i.Benefit.ToLower().Contains(benefit.ToLower())));
            }
            return results;
        }

        public IEnumerable<RecordSphere> GetLRecordSpheresByRequiredMotes(string moteType1, string moteType2)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLRecordSpheresByRequiredMotes)}");

            IEnumerable<RecordSphere> results = new List<RecordSphere>();

            if (!String.IsNullOrWhiteSpace(moteType1) && !String.IsNullOrWhiteSpace(moteType2))
            {
                results = _enlirRepository.GetMergeResultsContainer().RecordSpheres.Where(
                    l => l.RecordSphereLevels.Any(i => i.RequiredMotes.Any(m => m.ItemName.ToLower() == moteType1.ToLower()) &&
                                                      l.RecordSphereLevels.Any(j => j.RequiredMotes.Any(m => m.ItemName.ToLower() == moteType2.ToLower())
                                                      )));
            }
            return results;
        }

        public IEnumerable<RecordSphere> GetRecordSpheresBySearch(RecordSphere searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRecordSpheresBySearch)}");


            //ignore: all but Realm and Character
            var query = _enlirRepository.GetMergeResultsContainer().RecordSpheres;

            if (searchPrototype.Realm != 0)
            {
                query = query.Where(l => l.Realm == searchPrototype.Realm);
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(l => l.CharacterId == searchPrototype.CharacterId);
            }
            if (searchPrototype.RecordSphereLevels != null && searchPrototype.RecordSphereLevels.Any() && !String.IsNullOrWhiteSpace(searchPrototype.RecordSphereLevels.First().Benefit))
            {
                query = query.Where(
                    l => l.RecordSphereLevels.Any(i => i.Benefit.ToLower().Contains(searchPrototype.RecordSphereLevels.First().Benefit.ToLower())));
            }

            return query;
        }

        #endregion
    }
}
