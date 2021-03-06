﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using FFRKApi.Logic.Validation.Enlir;
using FFRKApi.Logic.Validation.GoogleSheets;

namespace FunctionApp.ETL
{
    public class Startup
    {

        #region Class Variables
        private IConfiguration _configuration;

        #endregion

        #region Constants
        private const string EnvironmentIndicatingEnvironmentVariable = "ASPNETCORE_ENVIRONMENT";
        private const string DirectoryGrandparentPath = @"..\..\";
        private const string LocalEnvironmentKey = "local";
        private const string ConfigFileName = "config";
        private const string ConfigFileExtension = "json";
        private const string LoggingOptionsAppComponentNameKey = "AppComponent";
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
            services.Configure<BraveActionImporterOptions>(_configuration.GetSection(nameof(BraveActionImporterOptions)));
            services.Configure<OtherImporterOptions>(_configuration.GetSection(nameof(OtherImporterOptions)));
            services.Configure<StatusImporterOptions>(_configuration.GetSection(nameof(StatusImporterOptions)));
            services.Configure<RelicImporterOptions>(_configuration.GetSection(nameof(RelicImporterOptions)));
            services.Configure<MagiciteImporterOptions>(_configuration.GetSection(nameof(MagiciteImporterOptions)));
            services.Configure<MagiciteSkillImporterOptions>(_configuration.GetSection(nameof(MagiciteSkillImporterOptions)));
            //services.Configure<DungeonImporterOptions>(_configuration.GetSection(nameof(DungeonImporterOptions)));
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
            services.AddScoped<IGoogleSheetsDataValidator, GoogleSheetsDataValidator>();
            services.AddScoped<IImportValidator, ImportValidator>();
            services.AddScoped<ITypeListValidator, TypeListValidator>();

            services.AddScoped<IRowImporter<CharacterRow>, CharacterImporter>();
            services.AddScoped<IRowImporter<RecordSphereRow>, RecordSphereImporter>();
            services.AddScoped<IRowImporter<LegendSphereRow>, LegendSphereImporter>();
            services.AddScoped<IRowImporter<RecordMateriaRow>, RecordMateriaImporter>();
            services.AddScoped<IRowImporter<LegendMateriaRow>, LegendMateriaImporter>();
            services.AddScoped<IRowImporter<AbilityRow>, AbilityImporter>();
            services.AddScoped<IRowImporter<SoulBreakRow>, SoulBreakImporter>();
            services.AddScoped<IRowImporter<CommandRow>, CommandImporter>();
            services.AddScoped<IRowImporter<BraveActionRow>, BraveActionImporter>();
            services.AddScoped<IRowImporter<OtherRow>, OtherImporter>();
            services.AddScoped<IRowImporter<StatusRow>, StatusImporter>();
            services.AddScoped<IRowImporter<RelicRow>, RelicImporter>();
            services.AddScoped<IRowImporter<MagiciteRow>, MagiciteImporter>();
            services.AddScoped<IRowImporter<MagiciteSkillRow>, MagiciteSkillImporter>();
            //services.AddScoped<IRowImporter<DungeonRow>, DungeonImporter>();
            services.AddScoped<IRowImporter<EventRow>, EventImporter>();
            services.AddScoped<IRowImporter<MissionRow>, MissionImporter>();
            services.AddScoped<IRowImporter<ExperienceRow>, ExperienceImporter>();

            services.AddScoped<IRowTransformer<MissionRow, Mission>, MissionTransformer>();
            services.AddScoped<IRowTransformer<EventRow, Event>, EventTransformer>();
            services.AddScoped<IRowTransformer<ExperienceRow, Experience>, ExperienceTransformer>();
            //services.AddScoped<IRowTransformer<DungeonRow, Dungeon>, DungeonTransformer>();
            services.AddScoped<IRowTransformer<MagiciteSkillRow, MagiciteSkill>, MagiciteSkillTransformer>();
            services.AddScoped<IRowTransformer<MagiciteRow, Magicite>, MagiciteTransformer>();
            services.AddScoped<IRowTransformer<StatusRow, Status>, StatusTransformer>();
            services.AddScoped<IRowTransformer<OtherRow, Other>, OtherTransformer>();
            services.AddScoped<IRowTransformer<CommandRow, Command>, CommandTransformer>();
            services.AddScoped<IRowTransformer<BraveActionRow, BraveAction>, BraveActionTransformer>();            
            services.AddScoped<IRowTransformer<SoulBreakRow, SoulBreak>, SoulBreakTransformer>();
            services.AddScoped<IRowTransformer<RelicRow, Relic>, RelicTransformer>();
            services.AddScoped<IRowTransformer<AbilityRow, Ability>, AbilityTransformer>();
            services.AddScoped<IRowTransformer<LegendMateriaRow, LegendMateria>, LegendMateriaTransformer>();
            services.AddScoped<IRowTransformer<RecordMateriaRow, RecordMateria>, RecordMateriaTransformer>();
            services.AddScoped<IRowTransformer<RecordSphereRow, RecordSphere>, RecordSphereTransformer>();
            services.AddScoped<IRowTransformer<LegendSphereRow, LegendSphere>, LegendSphereTransformer>();
            services.AddScoped<IRowTransformer<CharacterRow, Character>, CharacterTransformer>();


            //services.AddScoped<IImportStorageProvider, FileImportStorageProvider>();
            //services.AddScoped<ITransformStorageProvider, FileTransformStorageProvider>();
            //services.AddScoped<IMergeStorageProvider, FileMergeStorageProvider>();

            services.AddScoped<IImportStorageProvider, AzureBlobStorageProvider>();
            services.AddScoped<ITransformStorageProvider, AzureBlobStorageProvider>();
            services.AddScoped<IMergeStorageProvider, AzureBlobStorageProvider>();

            services.AddScoped<IImportManager, ImportManager>();
            services.AddScoped<ITransformManager, TransformManager>();
            services.AddScoped<IMergeManager, MergeManager>();
        }

        #endregion

        #region Private Methods
        private void InitializeConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable(EnvironmentIndicatingEnvironmentVariable);

            //string dir = Environment.CurrentDirectory;

            //get the function app compiled dll location
            //example (local): file:///D:/Code/FFRKApi/FFRKApi.ETL/FunctionApp.ETL/bin/Debug/net461/bin/FunctionApp.ETL.dll
            //example (Azure): file:///D:/home/site/wwwroot/bin/FunctionApp.ETL.dll
            string functionDllLocation = Assembly.GetExecutingAssembly().CodeBase;

            //get rid of the file moniker so that other path methods work
            //example (local): D:\Code\FFRKApi\FFRKApi.ETL\FunctionApp.ETL\bin\Debug\net461\bin\FunctionApp.ETL.dll
            //example (Azure): D:/home/site/wwwroot/bin/FunctionApp.ETL.dll
            string functionDllLocationAsPath = new Uri(functionDllLocation).LocalPath;

            //now navigate up two directories to get to the function project directory. This contains the config file.
            //example (local): D:\Code\FFRKApi\FFRKApi.ETL\FunctionApp.ETL\bin\Debug\net461\
            //example (Azure): D:/home/site/wwwroot/
            string configFileDir = Path.GetFullPath(Path.Combine(functionDllLocationAsPath, DirectoryGrandparentPath));


            if (environmentName == LocalEnvironmentKey)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(configFileDir)
                    .AddJsonFile($"{ConfigFileName}.{environmentName}.{ConfigFileExtension}", optional: true);

                builder.AddEnvironmentVariables();

                _configuration = builder.Build();
            }
            else
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(configFileDir)
                    .AddJsonFile($"{ConfigFileName}.{ConfigFileExtension}", optional: true);

                builder.AddEnvironmentVariables();

                _configuration = builder.Build();
            }

           
        }

        private void ConfigureLogger(IServiceCollection services)
        {
            //string rollingFileLogPath = _configuration.GetSection($"{nameof(LoggingOptions)}:{nameof(LoggingOptions.LogFilePath)}").Value;

            string appInsightsKey = _configuration["LoggingOptions:ApplicationInsightsKey"];
            string appComponentName = _configuration["LoggingOptions:AppComponentName"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .Enrich.WithProperty(LoggingOptionsAppComponentNameKey, appComponentName)
                //.WriteTo.RollingFile(rollingFileLogPath).MinimumLevel.Information()
                .WriteTo.ApplicationInsightsEvents(appInsightsKey).MinimumLevel.Information()
                .WriteTo.Console(theme: SystemConsoleTheme.Literate).MinimumLevel.Information()
                .WriteTo.Debug().MinimumLevel.Information()
                .CreateLogger();

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        }
        #endregion
    }
}
