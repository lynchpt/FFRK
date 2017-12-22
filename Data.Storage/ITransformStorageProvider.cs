using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirTransform;

namespace FFRKApi.Data.Storage
{
    public interface ITransformStorageProvider
    {
        /// <summary>
        /// Stores the passed in transform results to a storage medium
        /// </summary>
        /// <param name="transformResultsContainer"></param>
        /// <param name="formattedDateString">in format yyyy-MM-dd_hh-mm-ss, if null passed in, implementation should use DateTime.UtcNow</param>
        /// <returns></returns>
        string StoreTransformResults(TransformResultsContainer transformResultsContainer, string formattedDateString);

        /// <summary>
        /// Gets latest transform results.
        /// </summary>
        /// <returns></returns>
        TransformResultsContainer RetrieveTransformResults();

        /// <summary>
        /// Returns the TransformResults at the given path, or empty TransformResultsContainer if nothing exists at that path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        TransformResultsContainer RetrieveTransformResults(string path);
    }
}
