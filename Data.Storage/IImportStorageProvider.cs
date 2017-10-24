using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirImport;

namespace FFRKApi.Data.Storage
{
    public interface IImportStorageProvider
    {
        /// <summary>
        /// Stores the passed in import results to a storage medium
        /// </summary>
        /// <param name="importResultsContainer"></param>
        /// <returns></returns>
        string StoreImportResults(ImportResultsContainer importResultsContainer);

        /// <summary>
        /// Gets latest import results.
        /// </summary>
        /// <returns></returns>
        ImportResultsContainer RetrieveImportResults();
    }
}
