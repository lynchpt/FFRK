using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Data.Api;
using FFRKApi.Data.Storage;
using FFRKApi.Logic.Api.CharacterRating;
using FFRKApi.Model.Api.CharacterRating;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Logic.Api
{
    [TestClass]
    public class CharacterRatingTests
    {
        #region Class Variables

        private static IMergeStorageProvider _mergeStorageProvider;
        private static IEnlirRepository _enlirRepository;
        private static ILogger<FileMergeStorageProvider> _fileMergeStorageProviderLogger;
        private static ILogger<CacheProvider> _cacheProviderLogger;
        private static ILogger<CharacterRatingLogic> _altemaCharacterRatingLogicLogger;
        private static ICacheProvider _cacheProvider;
        private static IAltemaCharacterRatingRepository _altemaCharacterRatingRepository;

        private IAltemaCharacterNodeParser _altemaCharacterNodeParser;
        private IAltemaCharacterJapaneseTextMapper _altemaCharacterJapaneseTextMapper;
        private IAltemaCharacterNodeInterpreter _altemaCharacterNodeInterpreter;
        private ICharacterRatingLogic _characterRatingLogic;

        #endregion

        [ClassInitialize]
        public static void InitializeTestClass(TestContext testContext)
        {
            FileMergeStorageOptions fileMergeStorageOptions = new FileMergeStorageOptions() { MergeResultsStoragePath = "D:\\Temp\\FFRKApi\\MergeResults-{Date}.json" };
            IOptions<FileMergeStorageOptions> fileMergeStorageOptionsWrapper = new OptionsWrapper<FileMergeStorageOptions>(fileMergeStorageOptions);

            CachingOptions cachingOptions = new CachingOptions() { UseCache = "false", ConnectionString = "Placeholder", DefaultTimeToLiveInHours = "2"};        
            IOptions<CachingOptions> cachingOptionsWrapper = new OptionsWrapper<CachingOptions>(cachingOptions);

            ApiExternalWebsiteOptions apiExternalWebsiteOptions = new ApiExternalWebsiteOptions() {AltemaCharacterRatingsUrl = "https://altema.jp/ffrk/charahyoka" };
            IOptions<ApiExternalWebsiteOptions> apiExternalWebsiteOptionsWrapper = new OptionsWrapper<ApiExternalWebsiteOptions>(apiExternalWebsiteOptions);


            _fileMergeStorageProviderLogger = new Logger<FileMergeStorageProvider>(new LoggerFactory());
            _cacheProviderLogger = new Logger<CacheProvider>(new LoggerFactory());
            _altemaCharacterRatingLogicLogger = new Logger<CharacterRatingLogic>(new LoggerFactory());

            _cacheProvider = new CacheProvider(cachingOptionsWrapper, _cacheProviderLogger);

            _mergeStorageProvider = new FileMergeStorageProvider(fileMergeStorageOptionsWrapper, _fileMergeStorageProviderLogger);
            _enlirRepository = new EnlirRepository(_mergeStorageProvider);
            _altemaCharacterRatingRepository = new AltemaCharacterRatingWebRepository(apiExternalWebsiteOptionsWrapper);

        }

        [TestInitialize]
        public void InitializeTest()
        {                            
            _altemaCharacterNodeParser = new AltemaCharacterNodeParser();
            _altemaCharacterJapaneseTextMapper = new AltemaCharacterJapaneseTextMapper();
            _altemaCharacterNodeInterpreter = new AltemaCharacterNodeInterpreter(_altemaCharacterJapaneseTextMapper);
            _characterRatingLogic = new CharacterRatingLogic(_enlirRepository, _altemaCharacterRatingRepository, 
                _altemaCharacterNodeParser, _altemaCharacterNodeInterpreter, _cacheProvider, _altemaCharacterRatingLogicLogger);

        }

        [TestMethod]
        public void AltemaCharacterRating_Retrieved_Success()
        {
            IEnumerable<AltemaCharacterInfo> results = _characterRatingLogic.GetAltemaCharacterInfos();

            WriteAltemaCharacterResultToConsole(results);

            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void GetRatingPools_Retrieved_Success()
        {
            IEnumerable<RatingPool> results = _characterRatingLogic.GetRatingPools();

            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void CharacterRatingContextInfos_Retrieved_Success()
        {
            IEnumerable<CharacterRatingContextInfo> results = _characterRatingLogic.GetCharacterRatingContextInfos();

            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void CharacterRatingContextInfosByCharacterId_Retrieved_Success()
        {
            IEnumerable<CharacterRatingContextInfo> results = _characterRatingLogic.GetCharacterRatingContextInfosByCharacterId(1);

            Assert.IsNotNull(results);
            Assert.AreEqual("Tyro", results.First().CharacterName);
        }

        [TestMethod]
        public void CharacterRatingContextInfosByCharacterName_Retrieved_Success()
        {
            IEnumerable<CharacterRatingContextInfo> results = _characterRatingLogic.GetCharacterRatingContextInfosByCharacterName("cid");

            Assert.IsNotNull(results);
            Assert.AreEqual(4, results.Count());
        }

        public void WriteAltemaCharacterResultToConsole(IEnumerable<AltemaCharacterInfo> altemaCharacterResults)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id\tName\tJP Name\tRole\tJP Role\tRating\tImage Url");
            foreach (var characterResult in altemaCharacterResults)
            {
                sb.AppendLine(characterResult.ToString());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
