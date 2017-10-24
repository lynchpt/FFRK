using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FFRKApi.Data.Storage
{
    public class FileTransformStorageProvider : ITransformStorageProvider
    {
        #region Class Variables

        private readonly FileTransformStorageOptions _fileTransformStorageOptions;
        private readonly ILogger<FileTransformStorageProvider> _logger;
        #endregion

        #region Constants

        private const string DateReplacementToken = "{Date}";
        private const string DateFormatSpecifier = "yyyy-MM-dd_hh-mm-ss";
        private const string TransformResultFileFilterExpression = "TransformResults*.json";
        #endregion

        #region Constructors
        public FileTransformStorageProvider(IOptions<FileTransformStorageOptions> fileTransformStorageOptions, ILogger<FileTransformStorageProvider> logger)
        {
            _fileTransformStorageOptions = fileTransformStorageOptions.Value;
            _logger = logger;
        }
        #endregion

        public string StoreTransformResults(TransformResultsContainer transformResultsContainer)
        {
            string serializedImportResults = JsonConvert.SerializeObject(transformResultsContainer);

            string fileDateSegment = DateTimeOffset.UtcNow.ToString(DateFormatSpecifier);

            string datedFilePath = _fileTransformStorageOptions.TransformResultsStoragePath.Replace(DateReplacementToken, fileDateSegment);

            string directory = new FileInfo(datedFilePath).Directory.FullName;


            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (TextWriter writer = File.CreateText(datedFilePath))
            {
                writer.Write(serializedImportResults);
            }

            return datedFilePath;
        }

        public TransformResultsContainer RetrieveTransformResults()
        {
            TransformResultsContainer transformResultsContainer = new TransformResultsContainer();

            string directory = new FileInfo(_fileTransformStorageOptions.TransformResultsStoragePath).Directory.FullName;

            IList<string> filepaths = Directory.EnumerateFiles(directory, TransformResultFileFilterExpression).OrderByDescending(p => p).ToList();

            string latestFilepath = filepaths.FirstOrDefault();

            if (latestFilepath != null)
            {
                string fileContents = File.ReadAllText(latestFilepath);

                transformResultsContainer = JsonConvert.DeserializeObject<TransformResultsContainer>(fileContents);
            }

            return transformResultsContainer;
        }
    }
}
