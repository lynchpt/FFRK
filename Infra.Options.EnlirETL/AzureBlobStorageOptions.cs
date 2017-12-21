using System;
using System.Collections.Generic;
using System.Text;

namespace FFRK.Api.Infra.Options.EnlirETL
{
    public class AzureBlobStorageOptions
    {
        public string StorageAccountName { get; set; }
        public string ContainerName { get; set; }
        public string ConnectionString { get; set; }

        public string ImportResultsStoragePath { get; set; }

        public string TransformResultsStoragePath { get; set; }

        public string MergeResultsStoragePath { get; set; }
    }
}
