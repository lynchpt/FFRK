using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class DamageFormulaTypeList : ITypeList
    {
        private readonly IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                      {
                                                                          new KeyValuePair<int, string>(0, "Unknown"),
                                                                          new KeyValuePair<int, string>(1, String.Empty),
                                                                          new KeyValuePair<int, string>(2, "Hybrid"),
                                                                          new KeyValuePair<int, string>(3, "Magical"),
                                                                          new KeyValuePair<int, string>(4, "Physical")
                                                                      };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
