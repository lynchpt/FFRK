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
    public class FileMergeStorageProvider : IMergeStorageProvider
    {
        #region Class Variables

        private readonly FileMergeStorageOptions _fileMergeStorageOptions;
        private readonly ILogger<FileMergeStorageProvider> _logger;
        #endregion

        #region Constants

        private const string DateReplacementToken = "{Date}";
        private const string DateFormatSpecifier = "yyyy-MM-dd_hh-mm-ss";
        private const string MergeResultFileFilterExpression = "MergeResults*.json";
        #endregion

        #region Constructors
        public FileMergeStorageProvider(IOptions<FileMergeStorageOptions> fileMergeStorageOptions, ILogger<FileMergeStorageProvider> logger)
        {
            _fileMergeStorageOptions = fileMergeStorageOptions.Value;
            _logger = logger;
        }
        #endregion

        public string StoreMergeResults(MergeResultsContainer mergeResultsContainer)
        {
            string serializedMergeResults = JsonConvert.SerializeObject(mergeResultsContainer);

            string fileDateSegment = DateTimeOffset.UtcNow.ToString(DateFormatSpecifier);

            string datedFilePath = _fileMergeStorageOptions.MergeResultsStoragePath.Replace(DateReplacementToken, fileDateSegment);

            string directory = new FileInfo(datedFilePath).Directory.FullName;


            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (TextWriter writer = File.CreateText(datedFilePath))
            {
                writer.Write(serializedMergeResults);
            }

            return datedFilePath;
        }

        public MergeResultsContainer RetrieveMergeResults()
        {
            MergeResultsContainer mergeResultsContainer = new MergeResultsContainer();

            string directory = new FileInfo(_fileMergeStorageOptions.MergeResultsStoragePath).Directory.FullName;

            IList<string> filepaths = Directory.EnumerateFiles(directory, MergeResultFileFilterExpression).OrderByDescending(p => p).ToList();

            string latestFilepath = filepaths.FirstOrDefault();

            if (latestFilepath != null)
            {
                string fileContents = File.ReadAllText(latestFilepath);

                mergeResultsContainer = JsonConvert.DeserializeObject<MergeResultsContainer>(fileContents);
            }

            return mergeResultsContainer;
        }
    }
}
