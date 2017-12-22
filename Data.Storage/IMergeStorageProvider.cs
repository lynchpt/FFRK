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
        /// <param name="mergeResultsContainer"></param>
        /// <param name="formattedDateString">in format yyyy-MM-dd_hh-mm-ss, if null passed in, implementation should use DateTime.UtcNow</param>
        /// <returns></returns>
        string StoreMergeResults(MergeResultsContainer mergeResultsContainer, string formattedDateString);

        /// <summary>
        /// Gets latest transform results.
        /// </summary>
        /// <returns></returns>
        MergeResultsContainer RetrieveMergeResults();

        /// <summary>
        /// Returns the MergeResults at the given path, or empty MergeResultsContainer if nothing exists at that path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        MergeResultsContainer RetrieveMergeResults(string path);
    }
}
