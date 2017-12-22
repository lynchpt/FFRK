using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirMerge;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FFRKApi.Data.Storage
{
    public class FileStorageProviderBase
    {
        #region Class Variables

        protected readonly ILogger<FileStorageProviderBase> _logger;
        #endregion

        #region Constants

        protected const string DateReplacementToken = "{Date}";
        protected const string DateFormatSpecifier = "yyyy-MM-dd_hh-mm-ss";
        #endregion

        #region Constructors

        public FileStorageProviderBase(ILogger<FileStorageProviderBase> logger)
        {
            _logger = logger;
        }
        #endregion

        protected string StoreSerializedData(string serializedData, string formattedDateString, string storagePath)
        {

            if (String.IsNullOrWhiteSpace(formattedDateString))
            {
                formattedDateString = DateTimeOffset.UtcNow.ToString(DateFormatSpecifier);
            }

            string datedFilePath = storagePath.Replace(DateReplacementToken, formattedDateString);

            string directory = new FileInfo(datedFilePath).Directory.FullName;


            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (TextWriter writer = File.CreateText(datedFilePath))
            {
                writer.Write(serializedData);
            }

            _logger.LogInformation("stored serialized data in file {DatedFilePath}", datedFilePath);

            return datedFilePath;
        }

        protected string RetrieveSerializedData(string storagePath, string fileFilterExpression)
        {
            string serializedData = null;

            string directory = new FileInfo(storagePath).Directory.FullName;

            IList<string> filepaths = Directory.EnumerateFiles(directory, fileFilterExpression).OrderByDescending(p => p).ToList();

            string latestFilepath = filepaths.FirstOrDefault();

            serializedData = RetrieveSerializedData(latestFilepath);

            return serializedData;
        }

        protected string RetrieveSerializedData(string path)
        {
            string serializedData = null;

            if (path != null && File.Exists(path))
            {
                serializedData = File.ReadAllText(path);
            }

            _logger.LogInformation("retrieved serialized data from file {DatedFilePath}", path);

            return serializedData;
        }
    }
}
