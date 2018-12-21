using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirTransform.IdLists;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class TypeListConverter
    {
        #region Class Variables
        private readonly ITypeList _typeList;
        #endregion

        #region Constants

        protected const string CommaCharacter = ",";

        #endregion

        #region Constructors
        public TypeListConverter(ITypeList typeList)
        {
            _typeList = typeList;
        }
        #endregion

        #region Public Methods

        public int ConvertFromNameToId(string input)
        {
            int id = 0;

            try
            {
                id = _typeList.TypeList.SingleOrDefault(r => r.Value == input.Trim()).Key;
            }
            catch (Exception e)
            {
                id = 0;
            }
            return id;
        }


  

        public IEnumerable<int> ConvertFromCommaSeparatedListToIds(string input)
        {
            IList<int> ids = new List<int>();

            IList<string> inputParts = ConvertCommaSeparatedStringToList(input);

            foreach (var part in inputParts)
            {
                int id = _typeList.TypeList.SingleOrDefault(r => r.Value == part.Trim()).Key;

                if (!ids.Contains(id))
                {
                    ids.Add(id);
                }

            }

            return ids;
        } 
        #endregion

        #region Private Methods
        private IList<string> ConvertCommaSeparatedStringToList(string input)
        {
            IList<string> results = new List<string>();

            if (!String.IsNullOrWhiteSpace(input))
            {
                results = input.Split(new string[] { CommaCharacter }, StringSplitOptions.None).Select(s => s.Trim()).ToList();
            }

            return results;
        }
        #endregion
    }
}
