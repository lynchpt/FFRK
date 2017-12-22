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
    public class FileTransformStorageProvider : FileStorageProviderBase,  ITransformStorageProvider
    {
        #region Class Variables

        private readonly FileTransformStorageOptions _fileTransformStorageOptions;
        #endregion

        #region Constants

        private const string TransformResultFileFilterExpression = "TransformResults*.json";
        #endregion

        #region Constructors
        public FileTransformStorageProvider(IOptions<FileTransformStorageOptions> fileTransformStorageOptions, ILogger<FileTransformStorageProvider> logger): base(logger)
        {
            _fileTransformStorageOptions = fileTransformStorageOptions.Value;
        }
        #endregion

        public string StoreTransformResults(TransformResultsContainer transformResultsContainer, string formattedDateString)
        {
            string serializedTransformResults = JsonConvert.SerializeObject(transformResultsContainer);

            string datedFilePath = StoreSerializedData(serializedTransformResults, formattedDateString, _fileTransformStorageOptions.TransformResultsStoragePath);

            return datedFilePath;
        }

        public TransformResultsContainer RetrieveTransformResults()
        {
            string fileContents = RetrieveSerializedData(_fileTransformStorageOptions.TransformResultsStoragePath, TransformResultFileFilterExpression);

            TransformResultsContainer transformResultsContainer = JsonConvert.DeserializeObject<TransformResultsContainer>(fileContents);

            return transformResultsContainer;
        }


        public TransformResultsContainer RetrieveTransformResults(string path)
        {
            string fileContents = RetrieveSerializedData(path);

            TransformResultsContainer transformResultsContainer = JsonConvert.DeserializeObject<TransformResultsContainer>(fileContents);

            return transformResultsContainer;
        }
    }

}
