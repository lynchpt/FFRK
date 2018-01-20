﻿using System;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Data.Storage;
using FFRKApi.Logic.Api;
using FFRKApi.Model.EnlirMerge;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Swashbuckle.AspNetCore.Swagger;

namespace FFRKApi.Api.FFRK
{
    public class Startup
    {
        #region Constants

        private const string LoggingOptionsAppComponentNameKey = "AppComponent";
        #endregion

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
                                   {
                                       c.SwaggerDoc("v1", new Info { Title = "FFRK API", Version = "v1" });
                                   });

            ConfigureLogger(services);
        }

        /// <summary>
        /// This method now gets called automatically during the startup process in ASP.NET 2.0
        /// Documentation has not yet been authored by Microsoft
        /// See Issue #3659 here: https://github.com/aspnet/Docs/issues/3659
        /// </summary>
        /// <param name="services"></param>
        public virtual void ConfigureContainer(IServiceCollection services)
        {
            //services.AddMemoryCache();
            services.AddOptions();
            ConfigureOptions(services);
            ConfigureDependencyInjection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
                             {
                                 c.RoutePrefix = "swagger/ui";
                                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "FFRK API v1.0");
                             });

            //var c = app.ApplicationServices.GetService<MergeResultsContainer>();
        }

        #region Private Configuration Methods
        protected virtual void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IMergeStorageProvider, FileMergeStorageProvider>();
            services.AddScoped<IMaintenanceLogic, MaintenanceLogic>();
            services.AddScoped<IIdListsLogic, IdListsLogic>();


            //need to do this last so that other services are all registered and ready for actual use.
            MergeResultsContainer mrc = LoadMergeResultsContainer(services);
            services.AddSingleton<MergeResultsContainer, MergeResultsContainer>(p => mrc);
        }

        private void ConfigureOptions(IServiceCollection services)
        {
            services.Configure<FileMergeStorageOptions>(Configuration.GetSection(nameof(FileMergeStorageOptions)));

            services.Configure<AzureBlobStorageOptions>(Configuration.GetSection(nameof(AzureBlobStorageOptions)));
        }
        #endregion

        #region Private Methods

        private MergeResultsContainer LoadMergeResultsContainer(IServiceCollection services)
        {
            IServiceProvider provider = services.BuildServiceProvider();

            IMaintenanceLogic maintenanceLogic = provider.GetRequiredService<IMaintenanceLogic>();

            MergeResultsContainer mergeResultsContainer = maintenanceLogic.GetLatestMergeResultsContainer();

            return mergeResultsContainer;
        }

        private void ConfigureLogger(IServiceCollection services)
        {
            string appInsightsKey = Configuration["LoggingOptions:ApplicationInsightsKey"];
            string appComponentName = Configuration["LoggingOptions:AppComponentName"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .Enrich.WithProperty(LoggingOptionsAppComponentNameKey, appComponentName)
                //.WriteTo.RollingFile(rollingFileLogPath).MinimumLevel.Information()
                .WriteTo.ApplicationInsightsEvents(appInsightsKey).MinimumLevel.Information()
                .WriteTo.Console(theme: SystemConsoleTheme.Literate).MinimumLevel.Information()
                .WriteTo.Debug().MinimumLevel.Debug()
                .CreateLogger();

            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        }
        #endregion
    }
}
