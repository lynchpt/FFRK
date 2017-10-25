using System;
using System.Collections.Generic;
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
                bool converted = Int32.TryParse(input, out int candidateResult);

                if (converted)
                {
                    result = candidateResult;
                }
            }

            return result;
        }
    }
}
