using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirMerge;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

// Namespace for Blob storage types

namespace FFRKApi.Data.Storage
{
    public class AzureBlobStorageProvider:  IImportStorageProvider, ITransformStorageProvider, IMergeStorageProvider
    {
        #region Class Variables
        private readonly AzureBlobStorageOptions _azureBlobStorageOptions;
        private readonly ILogger<AzureBlobStorageProvider> _logger;
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;
        #endregion

        #region Constants
        private const string DateReplacementToken = "{Date}";
        private const string DateFormatSpecifier = "yyyy-MM-dd_hh-mm-ss";
        private const string BackSlash = "\\";
        //private const string ImportResultFileFilterExpression = "ImportsResults*.json";
        //private const string TransformResultFileFilterExpression = "TransformResults*.json";
        //private const string MergeResultFileFilterExpression = "MergeResults*.json";
        #endregion

        #region Constructors
        public AzureBlobStorageProvider(IOptions<AzureBlobStorageOptions> azureBlobStorageOptions, ILogger<AzureBlobStorageProvider> logger)
        {
            _azureBlobStorageOptions = azureBlobStorageOptions.Value;
            _logger = logger;

            _storageAccount = CloudStorageAccount.Parse(_azureBlobStorageOptions.ConnectionString);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _container = _blobClient.GetContainerReference(_azureBlobStorageOptions.ContainerName);
        }
        #endregion

        #region IImportStorageProvider Implementation
        public string StoreImportResults(ImportResultsContainer importResultsContainer)
        {
            string serializedImportResults = JsonConvert.SerializeObject(importResultsContainer);

            string datedFilePath = StoreTextAsBlob(_azureBlobStorageOptions.ImportResultsStoragePath, serializedImportResults);

            return datedFilePath; //this is the identifier of the blob  
        }

        public ImportResultsContainer RetrieveImportResults()
        {

            string fileContents = RetrieveLatestBlobContents(_azureBlobStorageOptions.ImportResultsStoragePath);

            ImportResultsContainer importResultsContainer = JsonConvert.DeserializeObject<ImportResultsContainer>(fileContents);

            return importResultsContainer;

        }

        public ImportResultsContainer RetrieveImportResults(string path)
        {
            ImportResultsContainer importResultsContainer = new ImportResultsContainer();

            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(path);

            string fileContents = blockBlob.DownloadTextAsync().Result;

            importResultsContainer = JsonConvert.DeserializeObject<ImportResultsContainer>(fileContents);

            return importResultsContainer;
        }

        #endregion

        #region ITransformStorageProvider Implementation
        public string StoreTransformResults(TransformResultsContainer transformResultsContainer)
        {
            string serializedTransformResults = JsonConvert.SerializeObject(transformResultsContainer);

            string datedFilePath = StoreTextAsBlob(_azureBlobStorageOptions.TransformResultsStoragePath, serializedTransformResults);

            return datedFilePath; //this is the identifier of the blob 
        }

        public TransformResultsContainer RetrieveTransformResults()
        {
            string fileContents = RetrieveLatestBlobContents(_azureBlobStorageOptions.TransformResultsStoragePath);

            TransformResultsContainer transformResultsContainer = JsonConvert.DeserializeObject<TransformResultsContainer>(fileContents);

            return transformResultsContainer;
        }

        public TransformResultsContainer RetrieveTransformResults(string path)
        {
            TransformResultsContainer transformResultsContainer = new TransformResultsContainer();

            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(path);

            string fileContents = blockBlob.DownloadTextAsync().Result;

            transformResultsContainer = JsonConvert.DeserializeObject<TransformResultsContainer>(fileContents);

            return transformResultsContainer;
        }

        #endregion

        #region IMergeStorageProvider Implementation
        public string StoreMergeResults(MergeResultsContainer mergeResultsContainer)
        {
            string serializedMergeResults = JsonConvert.SerializeObject(mergeResultsContainer);

            string datedFilePath = StoreTextAsBlob(_azureBlobStorageOptions.MergeResultsStoragePath, serializedMergeResults);

            return datedFilePath; //this is the identifier of the blob 
        }

        public MergeResultsContainer RetrieveMergeResults()
        {
            string fileContents = RetrieveLatestBlobContents(_azureBlobStorageOptions.MergeResultsStoragePath);

            MergeResultsContainer mergeResultsContainer = JsonConvert.DeserializeObject<MergeResultsContainer>(fileContents);

            return mergeResultsContainer;
        }

        public MergeResultsContainer RetrieveMergeResults(string path)
        {
            MergeResultsContainer mergeResultsContainer = new MergeResultsContainer();

            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(path);

            string fileContents = blockBlob.DownloadTextAsync().Result;

            mergeResultsContainer = JsonConvert.DeserializeObject<MergeResultsContainer>(fileContents);

            return mergeResultsContainer;
        }

        #endregion

        #region Private Methods

        private string StoreTextAsBlob(string storagePath, string contents)
        {
            string fileDateSegment = DateTimeOffset.UtcNow.ToString(DateFormatSpecifier);
            string datedFilePath = storagePath.Replace(DateReplacementToken, fileDateSegment);

            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(datedFilePath);

            blockBlob.UploadTextAsync(contents).Wait();

            return datedFilePath; //this is the identifier of the blob 
        }

        private string RetrieveLatestBlobContents(string storagePath)
        {
            int slashIndex = storagePath.IndexOf(BackSlash);
            string prefix = storagePath.Substring(0, slashIndex);

            var blobDirectory = _container.GetDirectoryReference(prefix);

            BlobContinuationToken continuationToken = null;
            List<IListBlobItem> blobItems = new List<IListBlobItem>();

            do
            {
                BlobResultSegment blobResultSegment = blobDirectory.ListBlobsSegmentedAsync(continuationToken).Result;
                continuationToken = blobResultSegment.ContinuationToken;
                blobItems.AddRange(blobResultSegment.Results);
            }
            while (continuationToken != null);

            IList<CloudBlockBlob> cloudBlockBlobs = blobItems.OfType<CloudBlockBlob>().OrderByDescending(b => b.Uri.AbsolutePath).ToList();

            CloudBlockBlob latestBlockBlob = cloudBlockBlobs.FirstOrDefault();


            string blobContents = latestBlockBlob.DownloadTextAsync().Result;

            return blobContents;
        }

        #endregion
    }
}
