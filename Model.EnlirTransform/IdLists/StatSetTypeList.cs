using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class StatSetTypeList : ITypeList
    {
        private readonly IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                      {
                                                                          new KeyValuePair<int, string>(0, "Unknown"),
                                                                          new KeyValuePair<int, string>(1, "Base"),
                                                                          new KeyValuePair<int, string>(2, "Standard"),
                                                                          new KeyValuePair<int, string>(3, "Max")
                                                                      };


        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
