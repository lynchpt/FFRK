using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ILegendSpheresLogic
    {
        IEnumerable<LegendSphere> GetAllLegendSpheres();
        IEnumerable<LegendSphere> GetLegendSpheresById(int legendSphereId);
        IEnumerable<LegendSphere> GetLegendSpheresByRealm(int realmType);
        IEnumerable<LegendSphere> GetLegendSpheresByCharacter(int characterId);
        IEnumerable<LegendSphere> GetLegendSpheresByBenefit(string benefit);
        IEnumerable<LegendSphere> GetLegendSpheresByRequiredMotes(string moteType1, string moteType2);
        IEnumerable<LegendSphere> GetLegendSpheresBySearch(LegendSphere searchPrototype);
    }

    public class LegendSpheresLogic : ILegendSpheresLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<LegendSpheresLogic> _logger;
        #endregion

        #region Constructors

        public LegendSpheresLogic(IEnlirRepository enlirRepository, ILogger<LegendSpheresLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ILegendSpheresLogic Implementation
        public IEnumerable<LegendSphere> GetAllLegendSpheres()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllLegendSpheres)}");

            return _enlirRepository.GetMergeResultsContainer().LegendSpheres;
        }

        public IEnumerable<LegendSphere> GetLegendSpheresById(int legendSphereId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheresById)}");

            return _enlirRepository.GetMergeResultsContainer().LegendSpheres.Where(e => e.Id == legendSphereId);
        }

        public IEnumerable<LegendSphere> GetLegendSpheresByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheresByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().LegendSpheres.Where(e => e.Realm == realmType);
        }

        public IEnumerable<LegendSphere> GetLegendSpheresByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheresByCharacter)}");

            return _enlirRepository.GetMergeResultsContainer().LegendSpheres.Where(e => e.CharacterId == characterId);
        }

        public IEnumerable<LegendSphere> GetLegendSpheresByBenefit(string benefit)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheresByBenefit)}");

            IEnumerable<LegendSphere> results = new List<LegendSphere>();

            if (!String.IsNullOrWhiteSpace(benefit))
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendSpheres.Where(
                    l => l.LegendSphereInfos.Any(i => i.Benefit.ToLower().Contains(benefit.ToLower())));
            }
            return results;
        }

        public IEnumerable<LegendSphere> GetLegendSpheresByRequiredMotes(string moteType1, string moteType2)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheresByRequiredMotes)}");

            IEnumerable<LegendSphere> results = new List<LegendSphere>();

            if (!String.IsNullOrWhiteSpace(moteType1) && !String.IsNullOrWhiteSpace(moteType2))
            {
                results = _enlirRepository.GetMergeResultsContainer().LegendSpheres.Where(
                    l => l.LegendSphereInfos.Any(i => i.RequiredMotes.Any(m => m.ItemName.ToLower() == moteType1.ToLower()) &&
                    l.LegendSphereInfos.Any(j => j.RequiredMotes.Any(m => m.ItemName.ToLower() == moteType2.ToLower())
                    )));
            }
            return results;
        }

        public IEnumerable<LegendSphere> GetLegendSpheresBySearch(LegendSphere searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLegendSpheresBySearch)}");


            //ignore: all but Realm and Character
            var query = _enlirRepository.GetMergeResultsContainer().LegendSpheres;

            if (searchPrototype.Realm != 0)
            {
                query = query.Where(l => l.Realm == searchPrototype.Realm);
            }           
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(l => l.CharacterId == searchPrototype.CharacterId);
            }
            return query;
        }

        #endregion
    }
}
