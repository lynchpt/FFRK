using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirMerge;

namespace FFRKApi.Logic.Api
{
    public interface IMaintenanceLogic
    {
        MergeResultsContainer GetLatestMergeResultsContainer();
    }

    public class MaintenanceLogic : IMaintenanceLogic
    {
        #region Class Variables

        private readonly IMergeStorageProvider _mergeStorageProvider;
        #endregion


        #region Constructors

        public MaintenanceLogic(IMergeStorageProvider mergeStorageProvider)
        {
            _mergeStorageProvider = mergeStorageProvider;
        }
        #endregion


        #region IMaintenanceController Implementation
        public MergeResultsContainer GetLatestMergeResultsContainer()
        {
            MergeResultsContainer mergeResultsContainer = _mergeStorageProvider.RetrieveMergeResults();

            return mergeResultsContainer;
        }
        #endregion
    }
}
