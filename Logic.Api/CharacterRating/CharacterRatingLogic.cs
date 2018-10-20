using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Model.Api.CharacterRating;
using FFRKApi.Model.EnlirTransform;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api.CharacterRating
{
    public interface ICharacterRatingLogic
    {
        IEnumerable<AltemaCharacterInfo> GetAltemaCharacterInfos();

        IEnumerable<RatingPool> GetRatingPools();

        IEnumerable<CharacterRatingContextInfo> GetCharacterRatingContextInfos();

        IEnumerable<CharacterRatingContextInfo> GetCharacterRatingContextInfosByCharacterId(int characterId);

        IEnumerable<CharacterRatingContextInfo> GetCharacterRatingContextInfosByCharacterName(string characterName);
    }

    public class CharacterRatingLogic : ICharacterRatingLogic
    {
        #region Class variables
        private readonly IAltemaCharacterRatingRepository _altemaCharacterRatingRepository;
        private readonly IAltemaCharacterNodeParser _altemaCharacterNodeParser;
        private readonly IAltemaCharacterNodeInterpreter _altemaCharacterNodeInterpreter;
        private readonly IEnlirRepository _enlirRepository;

        private readonly ILogger<CharacterRatingLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors
        public CharacterRatingLogic(IEnlirRepository enlirRepository, IAltemaCharacterRatingRepository altemaCharacterRatingRepository,
            IAltemaCharacterNodeParser altemaCharacterNodeParser, IAltemaCharacterNodeInterpreter altemaCharacterNodeInterpreter,
            ICacheProvider cacheProvider, ILogger<CharacterRatingLogic> logger)
        {
            _enlirRepository = enlirRepository;

            _altemaCharacterRatingRepository = altemaCharacterRatingRepository;
            _altemaCharacterNodeParser = altemaCharacterNodeParser;
            _altemaCharacterNodeInterpreter = altemaCharacterNodeInterpreter;
            _cacheProvider = cacheProvider;
            _logger = logger;

        } 
        #endregion

        #region ICharacterRatingLogic Implementation

        public IEnumerable<AltemaCharacterInfo> GetAltemaCharacterInfos()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAltemaCharacterInfos)}");

            string cacheKey = nameof(GetAltemaCharacterInfos);
            IEnumerable<AltemaCharacterInfo> results = _cacheProvider.ObjectGet<IList<AltemaCharacterInfo>>(cacheKey);

            if (results == null)
            {
                IList<AltemaCharacterInfo> altemaCharacterInfos = new List<AltemaCharacterInfo>();

                //Stream
                //Stream altemaCharacterRatingStream = _altemaCharacterRatingRepository.GetAltemaCharacterRatingStream();
                ////don't fail if we can't contact the altema page
                //if (altemaCharacterRatingStream == null) { return altemaCharacterInfos; }

                //HtmlDocument htmlDoc = GetLoadedHtmlDocument(altemaCharacterRatingStream);

                //String
                string altemaCharacterRatingString = _altemaCharacterRatingRepository.GetAltemaCharacterRatingString();

                //don't fail if we can't contact the altema page
                if (altemaCharacterRatingString == null) { return altemaCharacterInfos; }

                HtmlDocument htmlDoc = GetLoadedHtmlDocument(altemaCharacterRatingString);

                IEnumerable<HtmlNode> characterNodes = GetCharacterNodes(htmlDoc);

                int altemaOrder = 1;
                foreach (HtmlNode node in characterNodes)
                {
                    AltemaCharacterNodeComponents characterNodeComponents = _altemaCharacterNodeParser.ParseCharacterNode(node);
                    AltemaCharacterInfo characterInfo = _altemaCharacterNodeInterpreter.ConvertCharacterNodeToCharacterInfo(characterNodeComponents);

                    if (characterInfo != null)
                    {
                        characterInfo.AltemaOrder = altemaOrder++;
                        altemaCharacterInfos.Add(characterInfo);
                    }
                }

                results = altemaCharacterInfos;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<RatingPool> GetRatingPools()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetRatingPools)}");

            string cacheKey = nameof(GetRatingPools);
            IEnumerable<RatingPool> results = _cacheProvider.ObjectGet<IList<RatingPool>>(cacheKey);

            if (results == null)
            {
                //step 1 - get Altema info
                IEnumerable<AltemaCharacterInfo> altemaCharacterInfos = GetAltemaCharacterInfos();

                //step 2 - get summary Base CharacterRatingContextInfo (without roles or rating info filled in)
                IList<CharacterRatingContextInfo> characterRatingContextInfos = GetBaseCharacterRatingContextInfo().ToList();

                //step 3 - merge Altema data (rating and roles) into CharacterRatingContextInfo by char name
                MergeAltemaDataIntoBaseCharacterRatingContextInfo(altemaCharacterInfos, characterRatingContextInfos);

                //step 4 - remove characterRatingContextInfos that have no altema info (are unrated)
                characterRatingContextInfos = characterRatingContextInfos.Where(c => c.AltemaCharacterRating > 0).ToList();

                //rating pools will be each role, each proficient school type, each Mote combination, each LM2 type (exact word match)
                //first have to come up with the pools, then figure out who belongs in each one (characters will belong to several)

                // step 5a - role
                IEnumerable<RatingPool> roleRatingPools = GetRoleRatingPools(characterRatingContextInfos);

                // step 5b - proficient schools
                IEnumerable<RatingPool> schoolRatingPools = GetSchoolRatingPools(characterRatingContextInfos);

                // step 5c - mote combinations
                IEnumerable<RatingPool> moteRatingPools = GetMoteCombinationRatingPools(characterRatingContextInfos);

                // step 5d - LM 2 pools
                IEnumerable<RatingPool> lm2RatingPools = GetLegendMateria2RatingPools(characterRatingContextInfos);

                //step 5e - merge rating pools
                IList<RatingPool> allRatingPools = roleRatingPools.Concat(schoolRatingPools).Concat(moteRatingPools).Concat(lm2RatingPools).ToList();

                // step 6 - sort the characters by rating in each pool to mmake ranking easier
                foreach (RatingPool pool in allRatingPools)
                {
                    pool.CharactersInRatingPool =
                        pool.CharactersInRatingPool.OrderBy(c => c.AltemaOrder).ToList();
                }

                //step 7 - calculate characters rank in the various pools in which they participate
                AssignRatingPoolRankInfosToCharacters(allRatingPools);


                results = allRatingPools;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<CharacterRatingContextInfo> GetCharacterRatingContextInfos()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharacterRatingContextInfos)}");

            string cacheKey = nameof(GetCharacterRatingContextInfos);
            IEnumerable<CharacterRatingContextInfo> results = _cacheProvider.ObjectGet<IList<CharacterRatingContextInfo>>(cacheKey);

            if (results == null)
            {
                //the rating pools method does most of the work
                IEnumerable<RatingPool> ratingPools = GetRatingPools();

                //extract CharacterRatingContextInfo objects from rating pools (sort by overall altema rating)
                IList<CharacterRatingContextInfo> characterRatingContextInfos = ratingPools.SelectMany(p => p.CharactersInRatingPool).
                    Distinct().OrderBy(c => c.AltemaOrder).ToList();

                results = characterRatingContextInfos;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<CharacterRatingContextInfo> GetCharacterRatingContextInfosByCharacterId(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharacterRatingContextInfosByCharacterId)}");

            string cacheKey = $"{nameof(GetCharacterRatingContextInfosByCharacterId)}:{characterId}";
            IEnumerable<CharacterRatingContextInfo> results = _cacheProvider.ObjectGet<IList<CharacterRatingContextInfo>>(cacheKey);

            if (results == null)
            {
                IEnumerable<CharacterRatingContextInfo> characterRatingContextInfos = GetCharacterRatingContextInfos();

                results = characterRatingContextInfos.Where(c => c.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<CharacterRatingContextInfo> GetCharacterRatingContextInfosByCharacterName(string characterName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCharacterRatingContextInfosByCharacterName)}");


            string cacheKey = $"{nameof(GetCharacterRatingContextInfosByCharacterName)}:{characterName}";
            IEnumerable<CharacterRatingContextInfo> results = _cacheProvider.ObjectGet<IList<CharacterRatingContextInfo>>(cacheKey);

            if (results == null)
            {
                IEnumerable<CharacterRatingContextInfo> characterRatingContextInfos = GetCharacterRatingContextInfos();

                results = characterRatingContextInfos.Where(c => c.CharacterName.ToLower().Contains(characterName.ToLower()));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        #endregion

        #region Private Methods

        private HtmlDocument GetLoadedHtmlDocument(Stream altemaCharacterRatingStream)
        {
            HtmlDocument htmlDoc = new HtmlDocument
                                   {
                                       OptionFixNestedTags = true,
                                       OptionAutoCloseOnEnd = true
                                   };

            htmlDoc.Load(altemaCharacterRatingStream, Encoding.UTF8);

            altemaCharacterRatingStream.Dispose();

            return htmlDoc;
        }

        private HtmlDocument GetLoadedHtmlDocument(string altemaCharacterRatingString)
        {
            HtmlDocument htmlDoc = new HtmlDocument
                                   {
                                       OptionFixNestedTags = true,
                                       OptionAutoCloseOnEnd = true
                                   };

            htmlDoc.LoadHtml(altemaCharacterRatingString);

            return htmlDoc;
        }

        private IEnumerable<HtmlNode> GetCharacterNodes(HtmlDocument htmlDoc)
        {
            HtmlNode documentNode = htmlDoc.DocumentNode;

            IList<HtmlNode> characterNodes = documentNode.SelectNodes("//tbody[@id='data_area']/tr").ToList();

            return characterNodes;
        }

        private IEnumerable<CharacterRatingContextInfo> GetBaseCharacterRatingContextInfo()
        {
            // get summary Enlir character and Legend Dive Info

            //exclude Biggs, Wedge because they do not yet have full character data
            //var charactersGood = _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.Id != 3 && c.Id != 4);
            //exclude Eight, Cater because they do not yet have full character data
            var charactersGood = _enlirRepository.GetMergeResultsContainer().Characters.Where(c => c.Id != 222 && c.Id != 223);

            IEnumerable<CharacterRatingContextInfo> characterRatingContextInfos = charactersGood.Select(c => new CharacterRatingContextInfo()
            {
                CharacterId = c.Id,
                CharacterName = c.CharacterName,
                LegendDiveMote1Type = c.LegendSpheres.Any() ? c.LegendSpheres.First().LegendSphereInfos.First().RequiredMotes.Skip(0).Take(1).First().ItemName : null,
                LegendDiveMote2Type = c.LegendSpheres.Any() ? c.LegendSpheres.First().LegendSphereInfos.First().RequiredMotes.Skip(1).Take(1).First().ItemName : null,
                LegendMateria1 = c.LegendSpheres.Any() ? new LegendMateriaSummaryInfo()
                {
                    Effect = c.LegendMaterias.Skip(0).Take(1).First().Effect,
                    LegendMateriaId = c.LegendMaterias.Skip(0).Take(1).First().Id,
                    LegendMateriaName = c.LegendMaterias.Skip(0).Take(1).First().LegendMateriaName,
                    RelicId = 0
                } : null,
                LegendMateria2 = c.LegendSpheres.Any() ? new LegendMateriaSummaryInfo()
                {
                    Effect = c.LegendMaterias.Skip(1).Take(1).First().Effect,
                    LegendMateriaId = c.LegendMaterias.Skip(1).Take(1).First().Id,
                    LegendMateriaName = c.LegendMaterias.Skip(1).Take(1).First().LegendMateriaName,
                    RelicId = 0
                } : null,
                LegendMateriaFromRelics = c.LegendMaterias.Any() ? c.LegendMaterias.Where(lm => lm.RelicId != 0).Select(lm => new LegendMateriaSummaryInfo()
                {
                    Effect = lm.Effect,
                    LegendMateriaId = lm.Id,
                    LegendMateriaName = lm.LegendMateriaName,
                    RelicId = lm.RelicId
                }).ToList() : null,
                ProficientSchools = c.SchoolAccessInfos.Where(sai => sai.AccessLevel >= 5).Select(sai => sai.SchoolName).ToList(),
                RatingPoolRankInfos = new List<RatingPoolRankInfo>()
            });

            //IEnumerable<CharacterRatingContextInfo> characterRatingContextInfos = _enlirRepository.GetMergeResultsContainer().Characters.Select(c => new CharacterRatingContextInfo()
            //{
            //    CharacterId = c.Id,
            //    CharacterName = c.CharacterName,
            //    LegendDiveMote1Type = c.LegendSpheres.Any() ? c.LegendSpheres.First().LegendSphereInfos.First().RequiredMotes.Skip(0).Take(1).First().ItemName : null,
            //    LegendDiveMote2Type = c.LegendSpheres.Any() ? c.LegendSpheres.First().LegendSphereInfos.First().RequiredMotes.Skip(1).Take(1).First().ItemName : null,
            //    LegendMateria1 = c.LegendSpheres.Any() ? new LegendMateriaSummaryInfo()
            //    {
            //        Effect = c.LegendMaterias.Skip(0).Take(1).FirstOrDefault()?.Effect,
            //        LegendMateriaId = c.LegendMaterias.Skip(0).Take(1).FirstOrDefault()?.Id ?? 0,
            //        LegendMateriaName = c.LegendMaterias.Skip(0).Take(1).FirstOrDefault()?.LegendMateriaName,
            //        RelicId = 0
            //    } : null,
            //    LegendMateria2 = c.LegendSpheres.Any() ? new LegendMateriaSummaryInfo()
            //    {
            //        Effect = c.LegendMaterias.Skip(1).Take(1).FirstOrDefault()?.Effect,
            //        LegendMateriaId = c.LegendMaterias.Skip(1).Take(1).FirstOrDefault()?.Id ?? 0,
            //        LegendMateriaName = c.LegendMaterias.Skip(1).Take(1).FirstOrDefault()?.LegendMateriaName,
            //        RelicId = 0
            //    } : null,
            //    LegendMateriaFromRelics = c.LegendMaterias.Any() ? c.LegendMaterias.Where(lm => lm.RelicId != 0).Select(lm => new LegendMateriaSummaryInfo()
            //    {
            //        Effect = lm.Effect,
            //        LegendMateriaId = lm.Id,
            //        LegendMateriaName = lm.LegendMateriaName,
            //        RelicId = lm.RelicId
            //    }).ToList() : null,
            //    ProficientSchools = c.SchoolAccessInfos.Where(sai => sai.AccessLevel >= 5).Select(sai => sai.SchoolName).ToList(),
            //    RatingPoolRankInfos = new List<RatingPoolRankInfo>()
            //});

            return characterRatingContextInfos;
        }

        private void MergeAltemaDataIntoBaseCharacterRatingContextInfo(
            IEnumerable<AltemaCharacterInfo> altemaCharacterInfos,
            IEnumerable<CharacterRatingContextInfo> characterRatingContextInfos)
        {
            Dictionary<string, AltemaCharacterInfo> altemaMap = altemaCharacterInfos.ToDictionary(x => x.Name, x => x);

            foreach (var character in characterRatingContextInfos)
            {
                if (altemaMap.ContainsKey(character.CharacterName))
                {
                    character.AltemaCharacterRating = (altemaMap[character.CharacterName]).Rating;
                    character.AltemaOrder = (altemaMap[character.CharacterName]).AltemaOrder;
                    character.Roles = (altemaMap[character.CharacterName]).Roles;
                }
            }
        }

        private IEnumerable<RatingPool> GetRoleRatingPools(IList<CharacterRatingContextInfo> characterRatingContextInfos)
        {
            string roleTag = "Role: ";

            IEnumerable<RatingPool> roleRatingPools = characterRatingContextInfos.SelectMany(c => c.Roles)
                .Distinct().Select(p => new RatingPool() { RatingPoolName = roleTag + p }).ToList();

            //who is in each role based pool
            foreach (var pool in roleRatingPools)
            {
                pool.CharactersInRatingPool = characterRatingContextInfos
                    .Where(c => c.Roles.Contains(pool.RatingPoolName.Substring(roleTag.Length))).Select(c => c).ToList();
            }

            return roleRatingPools;
        }

        private IEnumerable<RatingPool> GetSchoolRatingPools(IList<CharacterRatingContextInfo> characterRatingContextInfos)
        {
            string schoolTag = "School: ";

            IList<RatingPool> schoolRatingPools = characterRatingContextInfos.SelectMany(c => c.ProficientSchools)
                .Distinct().Select(p => new RatingPool() { RatingPoolName = schoolTag + p }).ToList();

            //who is in each school based pool
            foreach (var pool in schoolRatingPools)
            {
                pool.CharactersInRatingPool = characterRatingContextInfos
                    .Where(c => c.ProficientSchools.Contains(pool.RatingPoolName.Substring(schoolTag.Length))).Select(c => c).ToList();
            }

            return schoolRatingPools;
        }

        private IEnumerable<RatingPool> GetMoteCombinationRatingPools(IList<CharacterRatingContextInfo> characterRatingContextInfos)
        {
            string moteTag = "Mote: ";
            string noneTag = "None";

            IList<RatingPool> moteRatingPools = characterRatingContextInfos.Select(c => $"{c.LegendDiveMote1Type ?? noneTag} / {c.LegendDiveMote2Type ?? noneTag}")
                .Distinct().Select(p => new RatingPool() { RatingPoolName = moteTag + p }).ToList();

            //who is in each mote combination based pool
            foreach (var pool in moteRatingPools)
            {
                pool.CharactersInRatingPool = characterRatingContextInfos
                    .Where(c => $"{moteTag}{c.LegendDiveMote1Type ?? noneTag} / {c.LegendDiveMote2Type ?? noneTag}" == pool.RatingPoolName).Select(c => c).ToList();
            }

            return moteRatingPools;
        }

        private IEnumerable<RatingPool> GetLegendMateria2RatingPools(IList<CharacterRatingContextInfo> characterRatingContextInfos)
        {
            string lm2Tag = "LM2: ";

            IList<RatingPool> lm2RatingPools = characterRatingContextInfos.Where(c => c.LegendMateria2 != null).Select(c => c.LegendMateria2.Effect)
                .Distinct().Select(p => new RatingPool() { RatingPoolName = p }).ToList();

            //who is in each mote combination based pool
            foreach (var pool in lm2RatingPools)
            {
                pool.CharactersInRatingPool = characterRatingContextInfos
                    .Where(c => c.LegendMateria2?.Effect == pool.RatingPoolName).Select(c => c).ToList();
            }

            //touch up select pools to unify names

            //trance
            RatingPool trancePool = new RatingPool() { RatingPoolName = "Trance", CharactersInRatingPool = new List<CharacterRatingContextInfo>() };
            IList<RatingPool> tranceRatingPoolsToRemove = new List<RatingPool>();

            foreach (var pool in lm2RatingPools)
            {
                if (pool.RatingPoolName.Contains("Trance"))
                {
                    foreach (var character in pool.CharactersInRatingPool)
                    {
                        trancePool.CharactersInRatingPool.Add(character);
                    }
                    tranceRatingPoolsToRemove.Add(pool);
                }
            }
            lm2RatingPools = lm2RatingPools.Except(tranceRatingPoolsToRemove).ToList();
            lm2RatingPools.Add(trancePool);

            //RatingPool adedPool = lm2RatingPools.FirstOrDefault(p => p.RatingPoolName == "Trance");

            //QuickCast 3
            RatingPool quickCastPool = new RatingPool() { RatingPoolName = "Quick Cast 3", CharactersInRatingPool = new List<CharacterRatingContextInfo>() };
            IList<RatingPool> quickCastRatingPoolsToRemove = new List<RatingPool>();

            foreach (var pool in lm2RatingPools)
            {
                if (pool.RatingPoolName.Contains("Quick Cast 3") && pool.CharactersInRatingPool.Count == 1)
                {
                    foreach (var character in pool.CharactersInRatingPool)
                    {
                        quickCastPool.CharactersInRatingPool.Add(character);
                    }
                    quickCastRatingPoolsToRemove.Add(pool);
                }
            }
            lm2RatingPools = lm2RatingPools.Except(quickCastRatingPoolsToRemove).ToList();
            lm2RatingPools.Add(quickCastPool);

            //Attack Buildup
            RatingPool atkBuildupPool = new RatingPool() { RatingPoolName = "Attack Buildup", CharactersInRatingPool = new List<CharacterRatingContextInfo>() };
            IList<RatingPool> atkBuildupRatingPoolsToRemove = new List<RatingPool>();

            foreach (var pool in lm2RatingPools)
            {
                if (pool.RatingPoolName.Contains("ATK +") && pool.RatingPoolName.Contains("each hit dealt") && pool.CharactersInRatingPool.Count == 1)
                {
                    foreach (var character in pool.CharactersInRatingPool)
                    {
                        atkBuildupPool.CharactersInRatingPool.Add(character);
                    }
                    atkBuildupRatingPoolsToRemove.Add(pool);
                }
            }
            lm2RatingPools = lm2RatingPools.Except(atkBuildupRatingPoolsToRemove).ToList();
            lm2RatingPools.Add(atkBuildupPool);

            //Minor Imperil
            RatingPool imperilPool = new RatingPool() { RatingPoolName = "Minor Imperil", CharactersInRatingPool = new List<CharacterRatingContextInfo>() };
            IList<RatingPool> imperilRatingPoolsToRemove = new List<RatingPool>();

            foreach (var pool in lm2RatingPools)
            {
                if (pool.RatingPoolName.Contains("chance to cause Minor Imperil") && pool.CharactersInRatingPool.Count == 1)
                {
                    foreach (var character in pool.CharactersInRatingPool)
                    {
                        imperilPool.CharactersInRatingPool.Add(character);
                    }
                    imperilRatingPoolsToRemove.Add(pool);
                }
            }
            lm2RatingPools = lm2RatingPools.Except(imperilRatingPoolsToRemove).ToList();
            lm2RatingPools.Add(imperilPool);

            //remove single member pools
            IList<RatingPool> singleMemberRatingPools = lm2RatingPools.Where(p => p.CharactersInRatingPool.Count == 1).ToList();
            lm2RatingPools = lm2RatingPools.Except(singleMemberRatingPools).ToList();

            //add in the lm 2 tag
            foreach (var pool in lm2RatingPools)
            {
                pool.RatingPoolName = $"{lm2Tag}{pool.RatingPoolName}";
            }

            return lm2RatingPools;
        }

        private void AssignRatingPoolRankInfosToCharacters(IEnumerable<RatingPool> ratingPools)
        {
            foreach (var pool in ratingPools)
            {
                int rank = 0;
                int lastRating = 0;
                int charactersSharingLastRating = 0;

                foreach (var character in pool.CharactersInRatingPool) //we know these are sorted
                {
                    if (character.AltemaCharacterRating == lastRating)
                    {
                        charactersSharingLastRating++;
                    }
                    else
                    {
                        rank = rank + charactersSharingLastRating + 1;
                        charactersSharingLastRating = 0;
                    }


                    RatingPoolRankInfo rankInfo = new RatingPoolRankInfo()
                    {
                        RatingPoolName = pool.RatingPoolName,
                        CharacterRankInRatingPool = rank,
                        RatingPoolMemberCount = pool.RatingPoolMemberCount
                    };
                    lastRating = character.AltemaCharacterRating;
                    character.RatingPoolRankInfos.Add(rankInfo);
                }

            }
        } 
        #endregion
    }
}
