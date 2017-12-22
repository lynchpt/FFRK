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
    public class FileImportStorageProvider : FileStorageProviderBase, IImportStorageProvider
    {
        #region Class Variables

        private readonly FileImportStorageOptions _fileImportStorageOptions;
        #endregion

        #region Constants

        private const string ImportResultFileFilterExpression = "ImportsResults*.json";
        #endregion

        #region Constructors
        public FileImportStorageProvider(IOptions<FileImportStorageOptions> fileImportStorageOptions, ILogger<FileImportStorageProvider> logger): base(logger)
        {
            _fileImportStorageOptions = fileImportStorageOptions.Value;

        }
        #endregion

        public string StoreImportResults(ImportResultsContainer importResultsContainer, string formattedDateString)
        {
            string serializedImportResults = JsonConvert.SerializeObject(importResultsContainer);

            string datedFilePath = StoreSerializedData(serializedImportResults, formattedDateString, _fileImportStorageOptions.ImportResultsStoragePath);

            return datedFilePath;
        }

        public ImportResultsContainer RetrieveImportResults()
        {
            string fileContents = RetrieveSerializedData(_fileImportStorageOptions.ImportResultsStoragePath, ImportResultFileFilterExpression);

            ImportResultsContainer importResultsContainer = JsonConvert.DeserializeObject<ImportResultsContainer>(fileContents);

            return importResultsContainer;
        }


        public ImportResultsContainer RetrieveImportResults(string path)
        {
            string fileContents = RetrieveSerializedData(path);

            ImportResultsContainer importResultsContainer = JsonConvert.DeserializeObject<ImportResultsContainer>(fileContents);

            return importResultsContainer;
        }
    }
}
