using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirImport;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FFRKApi.Data.Storage
{
    public class FileImportStorageProvider : IImportStorageProvider
    {
        #region Class Variables

        private readonly FileImportStorageOptions _fileImportStorageOptions;
        private readonly ILogger<FileImportStorageProvider> _logger;
        #endregion

        #region Constants

        private const string DateReplacementToken = "{Date}";
        private const string DateFormatSpecifier = "yyyy-MM-dd_hh-mm-ss";
        private const string ImportResultFileFilterExpression = "ImportsResults*.json";
        #endregion

        #region Constructors
        public FileImportStorageProvider(IOptions<FileImportStorageOptions> fileImportStorageOptions, ILogger<FileImportStorageProvider> logger)
        {
            _fileImportStorageOptions = fileImportStorageOptions.Value;
            _logger = logger;
        } 
        #endregion

        public string StoreImportResults(ImportResultsContainer importResultsContainer)
        {
            string serializedImportResults = JsonConvert.SerializeObject(importResultsContainer);

            string fileDateSegment = DateTimeOffset.UtcNow.ToString(DateFormatSpecifier);

            string datedFilePath = _fileImportStorageOptions.ImportResultsStoragePath.Replace(DateReplacementToken, fileDateSegment);

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

        public ImportResultsContainer RetrieveImportResults()
        {
            ImportResultsContainer importResultsContainer = new ImportResultsContainer();

            string directory = new FileInfo(_fileImportStorageOptions.ImportResultsStoragePath).Directory.FullName;

            IList<string> filepaths = Directory.EnumerateFiles(directory, ImportResultFileFilterExpression).OrderByDescending(p =>p).ToList();

            string latestFilepath = filepaths.FirstOrDefault();

            if (latestFilepath != null)
            {
                string fileContents = File.ReadAllText(latestFilepath);

                importResultsContainer = JsonConvert.DeserializeObject<ImportResultsContainer>(fileContents);
            }

            return importResultsContainer;
        }
    }
}
