using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FFRKApi.Data.Storage
{
    public class FileMergeStorageProvider : FileStorageProviderBase, IMergeStorageProvider
    {
        #region Class Variables

        private readonly FileMergeStorageOptions _fileMergeStorageOptions;
        #endregion

        #region Constants

        private const string MergeResultFileFilterExpression = "MergeResults*.json";
        #endregion

        #region Constructors
        public FileMergeStorageProvider(IOptions<FileMergeStorageOptions> fileMergeStorageOptions, ILogger<FileMergeStorageProvider> logger) : base(logger)
        {
            _fileMergeStorageOptions = fileMergeStorageOptions.Value;
        }
        #endregion

        public string StoreMergeResults(MergeResultsContainer mergeResultsContainer, string formattedDateString)
        {
            string serializedMergeResults = JsonConvert.SerializeObject(mergeResultsContainer);

            string datedFilePath = StoreSerializedData(serializedMergeResults, formattedDateString, _fileMergeStorageOptions.MergeResultsStoragePath);

            return datedFilePath;
        }

        public MergeResultsContainer RetrieveMergeResults()
        {
            string fileContents = RetrieveSerializedData(_fileMergeStorageOptions.MergeResultsStoragePath, MergeResultFileFilterExpression);

            MergeResultsContainer mergeResultsContainer = JsonConvert.DeserializeObject<MergeResultsContainer>(fileContents);

            return mergeResultsContainer;
        }

        public MergeResultsContainer RetrieveMergeResults(string path)
        {
            string fileContents = RetrieveSerializedData(path);

            MergeResultsContainer mergeResultsContainer = JsonConvert.DeserializeObject<MergeResultsContainer>(fileContents);

            return mergeResultsContainer;
        }
    }
}
