using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFRKApi.Model.EnlirTransform.IdLists;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class EventTypeConverter
    {
        public int ConvertFromNameToId(string name)
        {
            int id = 0;

            EventTypeList eventTypeList = new EventTypeList();

            id = eventTypeList.EventTypes.SingleOrDefault(r => r.Value == name.Trim()).Key;

            return id;
        }
    }
}
