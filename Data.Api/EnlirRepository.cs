using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirMerge;

namespace Data.Api
{
    /// <summary>
    /// Provides Methods to load the Repository with data from the Enlir Merge Operation,
    /// and to serve out that data to callers
    /// </summary>
    public interface IEnlirRepository
    {
        /// <summary>
        /// Loads the latest copy of the Enlir Merge data
        /// </summary>
        void LoadMergeResultsContainer();

        /// <summary>
        /// Returns the currently loaded Enlir Merge data
        /// </summary>
        /// <returns></returns>
        MergeResultsContainer GetMergeResultsContainer();

    }

    /// <summary>
    /// This class is meant to be used as a singleton in the api, so the actual data is held as a property.
    /// That way, although the repository class will be static, the data can be updated live through the Load method
    /// 
    /// The MergeResultsContainer is lazy loaded, so the very first call will incur the cost of loading the big dataset, 
    /// but after that the data is always instantly available in memory
    /// </summary>
    public class EnlirRepository : IEnlirRepository
    {
        #region Class Variables

        private readonly IMergeStorageProvider _mergeStorageProvider;

        private MergeResultsContainer _mergeResultsContainer = null;
        #endregion

        #region Constructors

        public EnlirRepository(IMergeStorageProvider mergeStorageProvider)
        {
            _mergeStorageProvider = mergeStorageProvider;
        }
        #endregion

        public void LoadMergeResultsContainer()
        {
            _mergeResultsContainer = _mergeStorageProvider.RetrieveMergeResults();
        }

        public MergeResultsContainer GetMergeResultsContainer()
        {
            if (_mergeResultsContainer == null)
            {
                LoadMergeResultsContainer();
            }

            return _mergeResultsContainer;
        }
    }
}
