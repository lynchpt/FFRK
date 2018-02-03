using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IRelicsLogic
    {
        IEnumerable<Relic> GetAllRelics();
        IEnumerable<Relic> GetRelicsById(int relicId);
        IEnumerable<Relic> GetRelicsByIdMulti(IEnumerable<int> relicIds); //POST
        IEnumerable<Relic> GetRelicsByName(string relicName);
        IEnumerable<Relic> GetRelicsByRealm(int realmType);
        IEnumerable<Relic> GetRelicsByCharacter(int characterId);
        IEnumerable<Relic> GetRelicsBySoulBreak(int soulBreakId);
        IEnumerable<Relic> GetRelicsByLegendMateria(int legendMateriaId);
        IEnumerable<Relic> GetRelicsByRelicType(int relicType);
        IEnumerable<Relic> GetRelicsByEffect(string effectText);
        IEnumerable<Relic> GetRelicsByRarity(int rarity);
        IEnumerable<Relic> GetRelicsByStat(int statSetType, int statType, int statValue);
        IEnumerable<Relic> GetRelicsBySearch(Relic searchPrototype);
    }

    public class RelicsLogic : IRelicsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<RelicsLogic> _logger;
        #endregion

        #region Constructors

        public RelicsLogic(IEnlirRepository enlirRepository, ILogger<RelicsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IRelicsLogic Implementation

        public IEnumerable<Relic> GetAllRelics()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllRelics)}");

            return _enlirRepository.GetMergeResultsContainer().Relics;
        }

        public IEnumerable<Relic> GetRelicsById(int relicId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsById)}");

            return _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Id == relicId);
        }

        public IEnumerable<Relic> GetRelicsByIdMulti(IEnumerable<int> relicIds)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsById)}");

            IEnumerable<Relic> results = new List<Relic>();

            if (relicIds != null && relicIds.Any())
            {
                results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => relicIds.Contains(r.Id));
            }

            return results;
        }

        public IEnumerable<Relic> GetRelicsByName(string relicName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsByName)}");

            IEnumerable<Relic> results = new List<Relic>();

            if (!String.IsNullOrWhiteSpace(relicName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Relics.Where(e => e.RelicName.ToLower().Contains(relicName.ToLower()));
            }

            return results;
        }

        public IEnumerable<Relic> GetRelicsByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Realm == realmType);
        }

        public IEnumerable<Relic> GetRelicsByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsByCharacter)}");

            return _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.CharacterId == characterId);
        }

        public IEnumerable<Relic> GetRelicsBySoulBreak(int soulBreakId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsBySoulBreak)}");

            return _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.SoulBreakId == soulBreakId);
        }

        public IEnumerable<Relic> GetRelicsByLegendMateria(int legendMateriaId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsByLegendMateria)}");

            return _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.LegendMateriaId == legendMateriaId);
        }

        public IEnumerable<Relic> GetRelicsByRelicType(int relicType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsByRelicType)}");

            return _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.RelicType == relicType);
        }

        public IEnumerable<Relic> GetRelicsByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsByEffect)}");

            IEnumerable<Relic> results = new List<Relic>();

            if (!String.IsNullOrWhiteSpace(effectText))
            {
                results = _enlirRepository.GetMergeResultsContainer().Relics.Where(e => e.Effect.ToLower().Contains(effectText.ToLower()));
            }

            return results;
        }

        public IEnumerable<Relic> GetRelicsByRarity(int rarity)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsByRarity)}");

            return _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Rarity == rarity);
        }

        public IEnumerable<Relic> GetRelicsByStat(int statSetType, int statType, int statValue)
        {
            ITypeList statSetTypeList = new StatSetTypeList();
            IEnumerable<Relic> results = new List<Relic>();

            switch (statSetType)
            {
                case 1: //Base
                    switch (statType)
                    {
                        case 1: //ACC
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.BaseAccuracy >= statValue).OrderByDescending(r => r.BaseAccuracy);
                            break;
                        case 2: //ATK
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.BaseAttack >= statValue).OrderByDescending(r => r.BaseAttack);
                            break;
                        case 3: //DEF
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.BaseDefense >= statValue).OrderByDescending(r => r.BaseDefense);
                            break;
                        case 4: //EVA
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.BaseEvasion >= statValue).OrderByDescending(r => r.BaseEvasion);
                            break;
                        case 5: //MAG
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.BaseMagic >= statValue).OrderByDescending(r => r.BaseMagic);
                            break;
                        case 6: //MND
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.BaseMind >= statValue).OrderByDescending(r => r.BaseMind);
                            break;
                        case 7: //RES
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.BaseResistance >= statValue).OrderByDescending(r => r.BaseResistance);
                            break;
                        default:

                            break;
                    }
                        
                    break;
                case 2: //Standard
                    switch (statType)
                    {
                        case 1: //ACC
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Accuracy >= statValue).OrderByDescending(r => r.Accuracy);
                            break;
                        case 2: //ATK
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Attack >= statValue).OrderByDescending(r => r.Attack);
                            break;
                        case 3: //DEF
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Defense >= statValue).OrderByDescending(r => r.Defense);
                            break;
                        case 4: //EVA
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Evasion >= statValue).OrderByDescending(r => r.Evasion);
                            break;
                        case 5: //MAG
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Magic >= statValue).OrderByDescending(r => r.Magic);
                            break;
                        case 6: //MND
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Mind >= statValue).OrderByDescending(r => r.Mind);
                            break;
                        case 7: //RES
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.Resistance >= statValue).OrderByDescending(r => r.Resistance);
                            break;
                        default:

                            break;
                    }
                    break;
                case 3: //max
                    switch (statType)
                    {
                        case 1: //ACC
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.MaxAccuracy >= statValue).OrderByDescending(r => r.MaxAccuracy);
                            break;
                        case 2: //ATK
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.MaxAttack >= statValue).OrderByDescending(r => r.MaxAttack);
                            break;
                        case 3: //DEF
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.MaxDefense >= statValue).OrderByDescending(r => r.MaxDefense);
                            break;
                        case 4: //EVA
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.MaxEvasion >= statValue).OrderByDescending(r => r.MaxEvasion);
                            break;
                        case 5: //MAG
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.MaxMagic >= statValue).OrderByDescending(r => r.MaxMagic);
                            break;
                        case 6: //MND
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.MaxMind >= statValue).OrderByDescending(r => r.MaxMind);
                            break;
                        case 7: //RES
                            results = _enlirRepository.GetMergeResultsContainer().Relics.Where(r => r.MaxResistance >= statValue).OrderByDescending(r => r.MaxResistance);
                            break;
                        default:

                            break;
                    }
                    break;
                default:

                    break;
            }

            return results;
        }

        public IEnumerable<Relic> GetRelicsBySearch(Relic searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRelicsBySearch)}");


            //ignore:
            var query = _enlirRepository.GetMergeResultsContainer().Relics;

            if (!string.IsNullOrWhiteSpace(searchPrototype.RelicName))
            {
                query = query.Where(a => a.RelicName.ToLower().Contains(searchPrototype.RelicName.ToLower()));
            }
            if (searchPrototype.Realm != 0)
            {
                query = query.Where(a => a.Realm == searchPrototype.Realm);
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(a => a.CharacterId == searchPrototype.CharacterId);
            }
            if (searchPrototype.SoulBreakId != 0)
            {
                query = query.Where(a => a.SoulBreakId == searchPrototype.SoulBreakId);
            }
            if (searchPrototype.LegendMateriaId != 0)
            {
                query = query.Where(a => a.LegendMateriaId == searchPrototype.LegendMateriaId);
            }
            if (searchPrototype.RelicType != 0)
            {
                query = query.Where(a => a.RelicType == searchPrototype.RelicType);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.Effect))
            {
                query = query.Where(a => a.Effect.ToLower().Contains(searchPrototype.Effect.ToLower()));
            }
            if (searchPrototype.Rarity != 0)
            {
                query = query.Where(a => a.Rarity == searchPrototype.Rarity);
            }

            if (searchPrototype.Accuracy != 0)
            {
                query = query.Where(a => a.Accuracy == searchPrototype.Accuracy);
            }
            if (searchPrototype.Attack != 0)
            {
                query = query.Where(a => a.Attack == searchPrototype.Attack);
            }
            if (searchPrototype.Defense != 0)
            {
                query = query.Where(a => a.Defense == searchPrototype.Defense);
            }
            if (searchPrototype.Evasion != 0)
            {
                query = query.Where(a => a.Evasion == searchPrototype.Evasion);
            }
            if (searchPrototype.Magic != 0)
            {
                query = query.Where(a => a.Magic == searchPrototype.Magic);
            }
            if (searchPrototype.Mind != 0)
            {
                query = query.Where(a => a.Mind == searchPrototype.Mind);
            }
            if (searchPrototype.Resistance != 0)
            {
                query = query.Where(a => a.Resistance == searchPrototype.Resistance);
            }
           
            return query;
        }

        #endregion
    }
}
