using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirMerge;

namespace FFRKApi.Logic.Api
{

    public interface IListLogic
    {
        IList<KeyValuePair<int, string>> GetAbilityTypeList();
    }

    public class ListLogic : IListLogic
    {
        #region Class Variables

        private readonly MergeResultsContainer _mergeResultsContainer;
        #endregion

        #region Constructors

        public ListLogic(MergeResultsContainer mergeResultsContainer)
        {
            _mergeResultsContainer = mergeResultsContainer;
        }
        #endregion

        #region IListLogic Implementation
        public IList<KeyValuePair<int, string>> GetAbilityTypeList()
        {
            return _mergeResultsContainer.AbilityTypeList;
        } 
        #endregion
    }
}
