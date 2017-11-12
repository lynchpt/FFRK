using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class IntConverter
    {
        public int ConvertFromStringToInt(string input)
        {
            int result = 0;

            if (!String.IsNullOrWhiteSpace(input))
            {
                //input number from enlir are in French format when using group separators
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ",";
                provider.NumberGroupSeparator = ".";
                provider.NumberGroupSizes = new int[] { 3 };

                bool converted = Int32.TryParse(input, NumberStyles.AllowThousands, provider, out int candidateResult);

                if (converted)
                {
                    result = candidateResult;
                }
            }

            return result;
        }
    }
}
