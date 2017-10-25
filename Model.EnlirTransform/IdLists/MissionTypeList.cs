using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class MissionTypeList
    {
        public IList<KeyValuePair<int, string>> MissionTypes = new List<KeyValuePair<int, string>>()
                                                                {
                                                                    new KeyValuePair<int, string>(0, "Unknown"),
                                                                    new KeyValuePair<int, string>(1, "Normal"),
                                                                    new KeyValuePair<int, string>(2, "Wayfarer"),
                                                                    new KeyValuePair<int, string>(3, "Special")
                                                                   
                                                                };
    }
}
