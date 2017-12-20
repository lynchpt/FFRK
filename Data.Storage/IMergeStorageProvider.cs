using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirMerge;

namespace FFRKApi.Data.Storage
{
   
    public interface IMergeStorageProvider
    {
        /// <summary>
        /// Stores the passed in transform results to a storage medium
        /// </summary>
        /// <param name="importResultsContainer"></param>
        /// <returns></returns>
        string StoreMergeResults(MergeResultsContainer transformResultsContainer);

        /// <summary>
        /// Gets latest transform results.
        /// </summary>
        /// <returns></returns>
        MergeResultsContainer RetrieveMergeResults();
    }
}
