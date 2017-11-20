using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class ElementList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                                {
                                                                    new KeyValuePair<int, string>(0, "Unknown"),
                                                                    new KeyValuePair<int, string>(1, String.Empty),
                                                                    new KeyValuePair<int, string>(2, "-"),
                                                                    new KeyValuePair<int, string>(3, "Fire"),
                                                                    new KeyValuePair<int, string>(4, "Ice"),
                                                                    new KeyValuePair<int, string>(5, "Lightning"),
                                                                    new KeyValuePair<int, string>(6, "Earth"),
                                                                    new KeyValuePair<int, string>(7, "Wind"),
                                                                    new KeyValuePair<int, string>(8, "Water"),
                                                                    new KeyValuePair<int, string>(9, "Holy"),
                                                                    new KeyValuePair<int, string>(10, "Dark"),
                                                                    new KeyValuePair<int, string>(11, "Poison")
                                                                };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
