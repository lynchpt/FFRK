using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirMerge;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{

    public interface IIdListsLogic
    {
        IEnumerable<KeyValuePair<int, string>> GetAbilityTypeList();
    }

    public class IdListsLogic : IIdListsLogic
    {
        #region Class Variables

        private readonly MergeResultsContainer _mergeResultsContainer;
        private readonly ILogger<IdListsLogic> _logger;
        #endregion

        #region Constructors

        public IdListsLogic(MergeResultsContainer mergeResultsContainer, ILogger<IdListsLogic> logger)
        {
            _mergeResultsContainer = mergeResultsContainer;
            _logger = logger;
        }
        #endregion

        #region IIdListsLogic Implementation
        public IEnumerable<KeyValuePair<int, string>> GetAbilityTypeList()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilityTypeList)}");

            return _mergeResultsContainer.AbilityTypeList;
        } 
        #endregion
    }
}
