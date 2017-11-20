using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class MissionTypeList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                 new KeyValuePair<int, string>(0, "Unknown"),
                                                                 new KeyValuePair<int, string>(1, "Normal"),
                                                                 new KeyValuePair<int, string>(2, "Wayfarer"),
                                                                 new KeyValuePair<int, string>(3, "Special")

                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
