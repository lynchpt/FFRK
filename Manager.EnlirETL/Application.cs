using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Data.Storage;
using FFRKApi.Logic.EnlirImport;
using FFRKApi.Logic.EnlirMerge;
using FFRKApi.Logic.EnlirTransform;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.SheetsApiHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model.EnlirImport;

namespace Manager.EnlirETL
{
    public interface IApplication
    {
        void Run();
    }


    public class Application : IApplication
    {
        #region Class Variables
        private IServiceProvider _serviceProvider;
        private IServiceCollection _servicesCollection;
        private readonly IConfiguration _configuration;
        private IImportManager _importManager;
        private ITransformManager _transformManager;
        private IMergeManager _mergeManager;
        private IImportStorageProvider _importStorageProvider;
        private ITransformStorageProvider _transformStorageProvider;
        private IMergeStorageProvider _mergeStorageProvider;
        private ApplicationOptions _applicationOptions;
        private readonly ILogger<Application> _logger; 
        #endregion


        public Application(IServiceCollection servicesCollection, IConfiguration configuration,
            IOptions<ApplicationOptions> applicationOptionsAccessor, ILogger<Application> logger)
        {
            _servicesCollection = servicesCollection;
            _configuration = configuration;
            _applicationOptions = applicationOptionsAccessor.Value;
            _logger = logger;

            ConfigureServices();
        }

        public void Run()
        {
            try
            {
                Stopwatch stopwatchFull = Stopwatch.StartNew();

                _logger.LogInformation($"{nameof(Application)}.{nameof(Run)} execution invoked");

                _importManager = _serviceProvider.GetService<IImportManager>();
                _importStorageProvider = _serviceProvider.GetService<IImportStorageProvider>();

                _transformManager = _serviceProvider.GetService<ITransformManager>();
                _transformStorageProvider = _serviceProvider.GetService<ITransformStorageProvider>();

                _mergeManager = _serviceProvider.GetService<IMergeManager>();
                _mergeStorageProvider = _serviceProvider.GetService<IMergeStorageProvider>();

                //uncomment below to actually run import and transform stages

                //Import
                Stopwatch stopwatchImport = Stopwatch.StartNew();
                ImportResultsContainer importResultsContainer = _importManager.ImportAll();
                string importStoragePath = _importStorageProvider.StoreImportResults(importResultsContainer, null);
                stopwatchImport.Stop();

                //Transform
                Stopwatch stopwatchTransform = Stopwatch.StartNew();
                TransformResultsContainer transformResultsContainer = _transformManager.TransformAll(importStoragePath);
                string transformStoragePath = _transformStorageProvider.StoreTransformResults(transformResultsContainer, null);
                stopwatchTransform.Stop();

                //Merge
                Stopwatch stopwatchMerge = Stopwatch.StartNew();
                MergeResultsContainer mergeResultsContainer = _mergeManager.MergeAll(transformStoragePath);
                string mergeStoragePath = _mergeStorageProvider.StoreMergeResults(mergeResultsContainer, null);
                stopwatchMerge.Stop();

                //test merge storage
                MergeResultsContainer testMergeResultsContainer = _mergeStorageProvider.RetrieveMergeResults(mergeStoragePath);

                stopwatchFull.Stop();

                _logger.LogInformation("Import Completed in {ImportTime} seconds", stopwatchImport.Elapsed.Seconds);
                _logger.LogInformation("Transform Completed in {TransformTime} seconds", stopwatchTransform.Elapsed.Seconds);
                _logger.LogInformation("Merge Completed in {MergeTime} seconds", stopwatchMerge.Elapsed.Seconds);
                _logger.LogInformation("Full Run Completed in {FullRunTime} seconds", stopwatchFull.Elapsed.Seconds);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                _logger.LogInformation("Error in Top Level Application execution. Import, Transform, and Merge operations were NOT successfully completed. Previously existing data is unchanged");
                throw;
            }


            Console.Read();
        }

        private void ConfigureServices()
        {
            //options
            _servicesCollection.Configure<SheetsServiceOptions>(_configuration.GetSection(nameof(SheetsServiceOptions)));
            _servicesCollection.Configure<CharacterImporterOptions>(_configuration.GetSection(nameof(CharacterImporterOptions)));
            _servicesCollection.Configure<RecordSphereImporterOptions>(_configuration.GetSection(nameof(RecordSphereImporterOptions)));
            _servicesCollection.Configure<LegendSphereImporterOptions>(_configuration.GetSection(nameof(LegendSphereImporterOptions)));
            _servicesCollection.Configure<RecordMateriaImporterOptions>(_configuration.GetSection(nameof(RecordMateriaImporterOptions)));
            _servicesCollection.Configure<LegendMateriaImporterOptions>(_configuration.GetSection(nameof(LegendMateriaImporterOptions)));
            _servicesCollection.Configure<AbilityImporterOptions>(_configuration.GetSection(nameof(AbilityImporterOptions)));
            _servicesCollection.Configure<SoulBreakImporterOptions>(_configuration.GetSection(nameof(SoulBreakImporterOptions)));
            _servicesCollection.Configure<CommandImporterOptions>(_configuration.GetSection(nameof(CommandImporterOptions)));
            _servicesCollection.Configure<OtherImporterOptions>(_configuration.GetSection(nameof(OtherImporterOptions)));
            _servicesCollection.Configure<StatusImporterOptions>(_configuration.GetSection(nameof(StatusImporterOptions)));
            _servicesCollection.Configure<RelicImporterOptions>(_configuration.GetSection(nameof(RelicImporterOptions)));
            _servicesCollection.Configure<MagiciteImporterOptions>(_configuration.GetSection(nameof(MagiciteImporterOptions)));
            _servicesCollection.Configure<MagiciteSkillImporterOptions>(_configuration.GetSection(nameof(MagiciteSkillImporterOptions)));
            _servicesCollection.Configure<DungeonImporterOptions>(_configuration.GetSection(nameof(DungeonImporterOptions)));
            _servicesCollection.Configure<EventImporterOptions>(_configuration.GetSection(nameof(EventImporterOptions)));
            _servicesCollection.Configure<MissionImporterOptions>(_configuration.GetSection(nameof(MissionImporterOptions)));
            _servicesCollection.Configure<ExperienceImporterOptions>(_configuration.GetSection(nameof(ExperienceImporterOptions)));

            _servicesCollection.Configure<FileImportStorageOptions>(_configuration.GetSection(nameof(FileImportStorageOptions)));
            _servicesCollection.Configure<FileTransformStorageOptions>(_configuration.GetSection(nameof(FileTransformStorageOptions)));
            _servicesCollection.Configure<FileMergeStorageOptions>(_configuration.GetSection(nameof(FileMergeStorageOptions)));

            _servicesCollection.Configure<AzureBlobStorageOptions>(_configuration.GetSection(nameof(AzureBlobStorageOptions)));



            //services
            _servicesCollection.AddSingleton<ISheetsApiHelper, SheetsApiHelper>();
            _servicesCollection.AddScoped<IRowImporter<CharacterRow>, CharacterImporter>();
            _servicesCollection.AddScoped<IRowImporter<RecordSphereRow>, RecordSphereImporter>();
            _servicesCollection.AddScoped<IRowImporter<LegendSphereRow>, LegendSphereImporter>();
            _servicesCollection.AddScoped<IRowImporter<RecordMateriaRow>, RecordMateriaImporter>();
            _servicesCollection.AddScoped<IRowImporter<LegendMateriaRow>, LegendMateriaImporter>();
            _servicesCollection.AddScoped<IRowImporter<AbilityRow>, AbilityImporter>();
            _servicesCollection.AddScoped<IRowImporter<SoulBreakRow>, SoulBreakImporter>();
            _servicesCollection.AddScoped<IRowImporter<CommandRow>, CommandImporter>();
            _servicesCollection.AddScoped<IRowImporter<OtherRow>, OtherImporter>();
            _servicesCollection.AddScoped<IRowImporter<StatusRow>, StatusImporter>();
            _servicesCollection.AddScoped<IRowImporter<RelicRow>, RelicImporter>();
            _servicesCollection.AddScoped<IRowImporter<MagiciteRow>, MagiciteImporter>();
            _servicesCollection.AddScoped<IRowImporter<MagiciteSkillRow>, MagiciteSkillImporter>();
            _servicesCollection.AddScoped<IRowImporter<DungeonRow>, DungeonImporter>();
            _servicesCollection.AddScoped<IRowImporter<EventRow>, EventImporter>();
            _servicesCollection.AddScoped<IRowImporter<MissionRow>, MissionImporter>();
            _servicesCollection.AddScoped<IRowImporter<ExperienceRow>, ExperienceImporter>();

            _servicesCollection.AddScoped<IRowTransformer<MissionRow, Mission>, MissionTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<EventRow, Event>, EventTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<ExperienceRow, Experience>, ExperienceTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<DungeonRow, Dungeon>, DungeonTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<MagiciteSkillRow, MagiciteSkill>, MagiciteSkillTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<MagiciteRow, Magicite>, MagiciteTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<StatusRow, Status>, StatusTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<OtherRow, Other>, OtherTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<CommandRow, Command>, CommandTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<SoulBreakRow, SoulBreak>, SoulBreakTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<RelicRow, Relic>, RelicTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<AbilityRow, Ability>, AbilityTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<LegendMateriaRow, LegendMateria>, LegendMateriaTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<RecordMateriaRow, RecordMateria>, RecordMateriaTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<RecordSphereRow, RecordSphere>, RecordSphereTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<LegendSphereRow, LegendSphere>, LegendSphereTransformer>();
            _servicesCollection.AddScoped<IRowTransformer<CharacterRow, Character>, CharacterTransformer>();


            //_servicesCollection.AddScoped<IImportStorageProvider, FileImportStorageProvider>();
            //_servicesCollection.AddScoped<ITransformStorageProvider, FileTransformStorageProvider>();
            //_servicesCollection.AddScoped<IMergeStorageProvider, FileMergeStorageProvider>();

            _servicesCollection.AddScoped<IImportStorageProvider, AzureBlobStorageProvider>();
            _servicesCollection.AddScoped<ITransformStorageProvider, AzureBlobStorageProvider>();
            _servicesCollection.AddScoped<IMergeStorageProvider, AzureBlobStorageProvider>();

            _servicesCollection.AddScoped<IImportManager, ImportManager>();
            _servicesCollection.AddScoped<ITransformManager, TransformManager>();
            _servicesCollection.AddScoped<IMergeManager, MergeManager>();

            _serviceProvider = _servicesCollection.BuildServiceProvider();
        }
    }
}
