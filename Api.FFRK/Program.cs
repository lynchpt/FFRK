using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Api.FFRK
{
    public class Program
    {

        #region Constants

        private const string LocalEnvironmentKey = "local";
        private const string ConfigFileName = "config";
        private const string ConfigFileExtension = "json";
        #endregion

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)

        //        .UseStartup<Startup>()
        //        .Build();

        public static IWebHost BuildWebHost(string[] args)
        {
            IWebHost webHost = new WebHostBuilder()
                .UseKestrel()
                .ConfigureAppConfiguration((hostingContext, config) => ConfigureConfiguration(hostingContext, config))
                .UseStartup<Startup>()
                .Build();


            return webHost;
        }

        public static IConfigurationBuilder ConfigureConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder builder)
        {
            var env = hostingContext.HostingEnvironment;

            builder.SetBasePath(Directory.GetCurrentDirectory());

            builder.AddJsonFile("hosting.json", optional: true);

            if (env.IsEnvironment(LocalEnvironmentKey))
            {
                builder.AddJsonFile($"{ConfigFileName}.{LocalEnvironmentKey}.{ConfigFileExtension}", optional: true);
            }
            else
            {
                builder.AddJsonFile($"{ConfigFileName}.{ConfigFileExtension}");
            }

            return builder;
        }
    }
}
