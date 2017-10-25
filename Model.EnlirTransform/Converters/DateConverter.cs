using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class DateConverter
    {
        public DateTime ConvertFromEuropeanDateString(string europeanDate)
        {
            DateTime utcDate = DateTime.MaxValue;

            if (!String.IsNullOrWhiteSpace(europeanDate))
            {
                try
                {
                    utcDate = DateTime.Parse(europeanDate, new CultureInfo("fr-FR"));
                }
                catch (Exception e)
                {
                    ; //swallow error, it is enough that we report a default data of MaxDate
                }
            }


            return utcDate;
        }
    }
}
