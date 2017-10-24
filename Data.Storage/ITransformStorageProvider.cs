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
        /// <param name="importResultsContainer"></param>
        /// <returns></returns>
        string StoreTransformResults(TransformResultsContainer transformResultsContainer);

        /// <summary>
        /// Gets latest transform results.
        /// </summary>
        /// <returns></returns>
        TransformResultsContainer RetrieveTransformResults();
    }
}
