using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IDungeonsLogic
    {
        IEnumerable<Dungeon> GetAllDungeons();
        IEnumerable<Dungeon> GetDungeonsById(int dungeonId);
        IEnumerable<Dungeon> GetDungeonsByRealm(int realmType);
        IEnumerable<Dungeon> GetDungeonsByName(string dungeonName);
        IEnumerable<Dungeon> GetDungeonsByRewards(string itemName, int starlevel);
        IEnumerable<Dungeon> GetDungeonsBySearch(Dungeon searchPrototype);
    }

    public class DungeonsLogic : IDungeonsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<DungeonsLogic> _logger;
        #endregion

        #region Constructors

        public DungeonsLogic(IEnlirRepository enlirRepository, ILogger<DungeonsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IDungeonsLogic Implementation
        public IEnumerable<Dungeon> GetAllDungeons()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllDungeons)}");

            return _enlirRepository.GetMergeResultsContainer().Dungeons;
        }

        public IEnumerable<Dungeon> GetDungeonsById(int dungeonId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDungeonsById)}");

            return _enlirRepository.GetMergeResultsContainer().Dungeons.Where(d => d.Id == dungeonId);
        }

        public IEnumerable<Dungeon> GetDungeonsByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDungeonsByRealm)}");

            return _enlirRepository.GetMergeResultsContainer().Dungeons.Where(d => d.Realm == realmType);
        }

        public IEnumerable<Dungeon> GetDungeonsByName(string dungeonName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDungeonsByName)}");

            IEnumerable<Dungeon> results = new List<Dungeon>();

            if (!String.IsNullOrWhiteSpace(dungeonName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Dungeons.Where(d => d.DungeonName.ToLower().Contains(dungeonName.ToLower()));
            }

            return results;
        }

        public IEnumerable<Dungeon> GetDungeonsByRewards(string itemName, int starlevel)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDungeonsByRewards)}");

            IEnumerable<Dungeon> results = new List<Dungeon>();

            if (!String.IsNullOrWhiteSpace(itemName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Dungeons.Where(d =>
                                d.MasteryRewardsClassic.Any(r => r.ItemName.ToLower().Contains(itemName.ToLower()) && r.ItemStarLevel >= starlevel) ||
                                d.MasteryRewardsElite.Any(r => r.ItemName.ToLower().Contains(itemName.ToLower()) && r.ItemStarLevel >= starlevel) ||
                                d.FirstTimeRewardsClassic.Any(r => r.ItemName.ToLower().Contains(itemName.ToLower()) && r.ItemStarLevel >= starlevel) ||
                                d.FirstTimeRewardsElite.Any(r => r.ItemName.ToLower().Contains(itemName.ToLower()) && r.ItemStarLevel >= starlevel)
                );
            }

            return results;
        }

        public IEnumerable<Dungeon> GetDungeonsBySearch(Dungeon searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetDungeonsBySearch)}");


            //ignore: Id, Description, IntroducingEvent, IntroducingEventId
            //stamina and difficulty comparisons are <= ; gil comparisons are >=
            var query = _enlirRepository.GetMergeResultsContainer().Dungeons;

            if (!string.IsNullOrWhiteSpace(searchPrototype.DungeonName))
            {
                query = query.Where(d => d.DungeonName.ToLower().Contains(searchPrototype.DungeonName.ToLower()));
            }
            if (searchPrototype.Realm != 0)
            {
                query = query.Where(d => d.Realm == searchPrototype.Realm);
            }
            if (searchPrototype.StaminaClassic != 0)
            {
                query = query.Where(d => d.StaminaClassic <= searchPrototype.StaminaClassic);
            }
            if (searchPrototype.StaminaElite != 0)
            {
                query = query.Where(d => d.StaminaElite <= searchPrototype.StaminaElite);
            }
            if (searchPrototype.DifficultyClassic != 0)
            {
                query = query.Where(d => d.DifficultyClassic <= searchPrototype.DifficultyClassic);
            }
            if (searchPrototype.DifficultyElite != 0)
            {
                query = query.Where(d => d.DifficultyElite <= searchPrototype.DifficultyElite);
            }
            if (searchPrototype.CompletionGilClassic != 0)
            {
                query = query.Where(d => d.CompletionGilClassic >= searchPrototype.CompletionGilClassic);
            }
            if (searchPrototype.CompletionGilElite != 0)
            {
                query = query.Where(d => d.CompletionGilElite >= searchPrototype.CompletionGilElite);
            }
            if (searchPrototype.FirstTimeRewardsClassic.Any())
            {
                if (!String.IsNullOrWhiteSpace(searchPrototype.FirstTimeRewardsClassic.First().ItemName))
                {
                    query = query.Where(d => d.FirstTimeRewardsClassic.Any(
                                            r => r.ItemName.ToLower().Contains(searchPrototype.FirstTimeRewardsClassic.First().ItemName.ToLower()) &&
                                                 r.ItemCount >= searchPrototype.FirstTimeRewardsClassic.First().ItemCount &&
                                                 r.ItemStarLevel >= searchPrototype.FirstTimeRewardsClassic.First().ItemStarLevel));
                }

            }
            if (searchPrototype.FirstTimeRewardsElite.Any())
            {
                if (!String.IsNullOrWhiteSpace(searchPrototype.FirstTimeRewardsElite.First().ItemName))
                {
                    query = query.Where(d => d.FirstTimeRewardsElite.Any(
                                            r => r.ItemName.ToLower().Contains(searchPrototype.FirstTimeRewardsElite.First().ItemName.ToLower()) &&
                                                 r.ItemCount >= searchPrototype.FirstTimeRewardsElite.First().ItemCount &&
                                                 r.ItemStarLevel >= searchPrototype.FirstTimeRewardsElite.First().ItemStarLevel));
                }

            }
            if (searchPrototype.MasteryRewardsClassic.Any())
            {
                if (!String.IsNullOrWhiteSpace(searchPrototype.MasteryRewardsClassic.First().ItemName))
                {
                    query = query.Where(d => d.MasteryRewardsClassic.Any(
                                            r => r.ItemName.ToLower().Contains(searchPrototype.MasteryRewardsClassic.First().ItemName.ToLower()) &&
                                                 r.ItemCount >= searchPrototype.MasteryRewardsClassic.First().ItemCount &&
                                                 r.ItemStarLevel >= searchPrototype.MasteryRewardsClassic.First().ItemStarLevel));
                }

            }
            if (searchPrototype.MasteryRewardsElite.Any())
            {
                if (!String.IsNullOrWhiteSpace(searchPrototype.MasteryRewardsElite.First().ItemName))
                {
                    query = query.Where(d => d.MasteryRewardsElite.Any(
                                            r => r.ItemName.ToLower().Contains(searchPrototype.MasteryRewardsElite.First().ItemName.ToLower()) &&
                                                 r.ItemCount >= searchPrototype.MasteryRewardsElite.First().ItemCount &&
                                                 r.ItemStarLevel >= searchPrototype.MasteryRewardsElite.First().ItemStarLevel));
                }

            }

            return query;
        }

        #endregion

    }
}
