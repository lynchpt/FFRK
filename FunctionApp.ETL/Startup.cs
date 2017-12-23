using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Data.Storage;
using FFRKApi.Logic.EnlirImport;
using FFRKApi.Logic.EnlirMerge;
using FFRKApi.Logic.EnlirTransform;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.SheetsApiHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Model.EnlirImport;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace FunctionApp.ETL
{
    public class Startup
    {

        #region Class Variables
        private IConfiguration _configuration;

        #endregion

        #region Constants
        private const string EnvironmentIndicatingEnvironmentVariable = "ASPNETCORE_ENVIRONMENT";
        private const string LocalEnvironmentKey = "local";
        private const string ConfigFileName = "config";
        private const string ConfigFileExtension = "json";
        #endregion

        #region Constructors

        public Startup()
        {
            InitializeConfiguration();
        }
        #endregion

        #region Conventional Startup Methods
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            ConfigureLogger(services);

            //options
            services.Configure<ApplicationOptions>(_configuration.GetSection(nameof(ApplicationOptions)));
            services.Configure<LoggingOptions>(_configuration.GetSection(nameof(LoggingOptions)));

            services.Configure<SheetsServiceOptions>(_configuration.GetSection(nameof(SheetsServiceOptions)));
            services.Configure<CharacterImporterOptions>(_configuration.GetSection(nameof(CharacterImporterOptions)));
            services.Configure<RecordSphereImporterOptions>(_configuration.GetSection(nameof(RecordSphereImporterOptions)));
            services.Configure<LegendSphereImporterOptions>(_configuration.GetSection(nameof(LegendSphereImporterOptions)));
            services.Configure<RecordMateriaImporterOptions>(_configuration.GetSection(nameof(RecordMateriaImporterOptions)));
            services.Configure<LegendMateriaImporterOptions>(_configuration.GetSection(nameof(LegendMateriaImporterOptions)));
            services.Configure<AbilityImporterOptions>(_configuration.GetSection(nameof(AbilityImporterOptions)));
            services.Configure<SoulBreakImporterOptions>(_configuration.GetSection(nameof(SoulBreakImporterOptions)));
            services.Configure<CommandImporterOptions>(_configuration.GetSection(nameof(CommandImporterOptions)));
            services.Configure<OtherImporterOptions>(_configuration.GetSection(nameof(OtherImporterOptions)));
            services.Configure<StatusImporterOptions>(_configuration.GetSection(nameof(StatusImporterOptions)));
            services.Configure<RelicImporterOptions>(_configuration.GetSection(nameof(RelicImporterOptions)));
            services.Configure<MagiciteImporterOptions>(_configuration.GetSection(nameof(MagiciteImporterOptions)));
            services.Configure<MagiciteSkillImporterOptions>(_configuration.GetSection(nameof(MagiciteSkillImporterOptions)));
            services.Configure<DungeonImporterOptions>(_configuration.GetSection(nameof(DungeonImporterOptions)));
            services.Configure<EventImporterOptions>(_configuration.GetSection(nameof(EventImporterOptions)));
            services.Configure<MissionImporterOptions>(_configuration.GetSection(nameof(MissionImporterOptions)));
            services.Configure<ExperienceImporterOptions>(_configuration.GetSection(nameof(ExperienceImporterOptions)));

            services.Configure<FileImportStorageOptions>(_configuration.GetSection(nameof(FileImportStorageOptions)));
            services.Configure<FileTransformStorageOptions>(_configuration.GetSection(nameof(FileTransformStorageOptions)));
            services.Configure<FileMergeStorageOptions>(_configuration.GetSection(nameof(FileMergeStorageOptions)));

            services.Configure<AzureBlobStorageOptions>(_configuration.GetSection(nameof(AzureBlobStorageOptions)));



            //services
            services.AddSingleton<ILoggerFactory, LoggerFactory>(); //was already singleton
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>)); //was already singleton


            services.AddSingleton<ISheetsApiHelper, SheetsApiHelper>();//was already singleton

            services.AddSingleton<IRowImporter<CharacterRow>, CharacterImporter>();
            services.AddSingleton<IRowImporter<RecordSphereRow>, RecordSphereImporter>();
            services.AddSingleton<IRowImporter<LegendSphereRow>, LegendSphereImporter>();
            services.AddSingleton<IRowImporter<RecordMateriaRow>, RecordMateriaImporter>();
            services.AddSingleton<IRowImporter<LegendMateriaRow>, LegendMateriaImporter>();
            services.AddSingleton<IRowImporter<AbilityRow>, AbilityImporter>();
            services.AddSingleton<IRowImporter<SoulBreakRow>, SoulBreakImporter>();
            services.AddSingleton<IRowImporter<CommandRow>, CommandImporter>();
            services.AddSingleton<IRowImporter<OtherRow>, OtherImporter>();
            services.AddSingleton<IRowImporter<StatusRow>, StatusImporter>();
            services.AddSingleton<IRowImporter<RelicRow>, RelicImporter>();
            services.AddSingleton<IRowImporter<MagiciteRow>, MagiciteImporter>();
            services.AddSingleton<IRowImporter<MagiciteSkillRow>, MagiciteSkillImporter>();
            services.AddSingleton<IRowImporter<DungeonRow>, DungeonImporter>();
            services.AddSingleton<IRowImporter<EventRow>, EventImporter>();
            services.AddSingleton<IRowImporter<MissionRow>, MissionImporter>();
            services.AddSingleton<IRowImporter<ExperienceRow>, ExperienceImporter>();

            services.AddSingleton<IRowTransformer<MissionRow, Mission>, MissionTransformer>();
            services.AddSingleton<IRowTransformer<EventRow, Event>, EventTransformer>();
            services.AddSingleton<IRowTransformer<ExperienceRow, Experience>, ExperienceTransformer>();
            services.AddSingleton<IRowTransformer<DungeonRow, Dungeon>, DungeonTransformer>();
            services.AddSingleton<IRowTransformer<MagiciteSkillRow, MagiciteSkill>, MagiciteSkillTransformer>();
            services.AddSingleton<IRowTransformer<MagiciteRow, Magicite>, MagiciteTransformer>();
            services.AddSingleton<IRowTransformer<StatusRow, Status>, StatusTransformer>();
            services.AddSingleton<IRowTransformer<OtherRow, Other>, OtherTransformer>();
            services.AddSingleton<IRowTransformer<CommandRow, Command>, CommandTransformer>();
            services.AddSingleton<IRowTransformer<SoulBreakRow, SoulBreak>, SoulBreakTransformer>();
            services.AddSingleton<IRowTransformer<RelicRow, Relic>, RelicTransformer>();
            services.AddSingleton<IRowTransformer<AbilityRow, Ability>, AbilityTransformer>();
            services.AddSingleton<IRowTransformer<LegendMateriaRow, LegendMateria>, LegendMateriaTransformer>();
            services.AddSingleton<IRowTransformer<RecordMateriaRow, RecordMateria>, RecordMateriaTransformer>();
            services.AddSingleton<IRowTransformer<RecordSphereRow, RecordSphere>, RecordSphereTransformer>();
            services.AddSingleton<IRowTransformer<LegendSphereRow, LegendSphere>, LegendSphereTransformer>();
            services.AddSingleton<IRowTransformer<CharacterRow, Character>, CharacterTransformer>();


            services.AddSingleton<IImportStorageProvider, FileImportStorageProvider>();
            services.AddSingleton<ITransformStorageProvider, FileTransformStorageProvider>();
            services.AddSingleton<IMergeStorageProvider, FileMergeStorageProvider>();

            //services.AddSingleton<IImportStorageProvider, AzureBlobStorageProvider>();
            //services.AddSingleton<ITransformStorageProvider, AzureBlobStorageProvider>();
            //services.AddSingleton<IMergeStorageProvider, AzureBlobStorageProvider>();

            services.AddSingleton<IImportManager, ImportManager>();
            services.AddSingleton<ITransformManager, TransformManager>();
            services.AddSingleton<IMergeManager, MergeManager>();
        }

        #endregion

        #region Private Methods
        private void InitializeConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable(EnvironmentIndicatingEnvironmentVariable);

            string dir = Environment.CurrentDirectory;

            if (environmentName == LocalEnvironmentKey)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile($"{ConfigFileName}.{environmentName}.{ConfigFileExtension}", optional: true);

                _configuration = builder.Build();
            }
            else
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile($"{ConfigFileName}.{ConfigFileExtension}", optional: true);

                _configuration = builder.Build();
            }
        }

        private void ConfigureLogger(IServiceCollection services)
        {
            string rollingFileLogPath = _configuration.GetSection($"{nameof(LoggingOptions)}:{nameof(LoggingOptions.LogFilePath)}").Value;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(rollingFileLogPath).MinimumLevel.Information()
                .WriteTo.Console(theme: SystemConsoleTheme.Literate).MinimumLevel.Information()
                .WriteTo.Debug().MinimumLevel.Debug()
                .CreateLogger();

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        }
        #endregion
    }
}
