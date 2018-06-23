using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FFRKApi.Data.Storage
{
    public interface IBannerSpecProvider
    {
        string GetBannerSpec(string bannerPath);

        string GetBannerMetadata(string bannerMetadataPath);

    }

    public class BannerSpecAzureBlobProvider : IBannerSpecProvider
    {
        #region Class Variables
        private readonly AzureBlobStorageOptions _azureBlobStorageOptions;
        private readonly ILogger<BannerSpecAzureBlobProvider> _logger;
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;

        #endregion

        #region Constructors
        public BannerSpecAzureBlobProvider(IOptions<AzureBlobStorageOptions> azureBlobStorageOptions, ILogger<BannerSpecAzureBlobProvider> logger)
        {
            _azureBlobStorageOptions = azureBlobStorageOptions.Value;
            _logger = logger;

            _storageAccount = CloudStorageAccount.Parse(_azureBlobStorageOptions.ConnectionString);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _container = _blobClient.GetContainerReference(_azureBlobStorageOptions.ContainerName);
        }
        #endregion

        #region IBannerSpecProvider Implementation
        public string GetBannerSpec(string bannerPath)
        {
            string bannerSpec = String.Empty;
            if (String.IsNullOrWhiteSpace(bannerPath)) return bannerSpec;

            bannerSpec = RetrieveBlobContents(bannerPath);

            return bannerSpec;
        }

        public string GetBannerMetadata(string bannerMetadataPath)
        {
            string bannerMetadata = String.Empty;
            if (String.IsNullOrWhiteSpace(bannerMetadataPath)) return bannerMetadata;

            bannerMetadata = RetrieveBlobContents(bannerMetadataPath);

            return bannerMetadata;
        }

        #endregion

        #region Private Methods



        private string RetrieveBlobContents(string blobPath)
        {
            string prefix = _azureBlobStorageOptions.BannerStoragePath;

            var blobDirectory = _container.GetDirectoryReference(prefix);

            var bannerSpec = blobDirectory.GetBlockBlobReference(blobPath);

            string blobContents = bannerSpec.DownloadTextAsync().Result;

            return blobContents;
        }
        #endregion
    }
}
