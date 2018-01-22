using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class DoubleConverter
    {
        public double ConvertFromStringToDouble(string input)
        {
            double result = 0;

            //the source spreadsheet has number formatted in french way, as in 1,80.
            //However, at least sometimes the Google Sheets api spontaneously converts those number into English format, like 1.80
            //this way we can detect what is coming in and pick the right formula.
            //Obviously, this only works because we know we will not be getting any number greater than the hundreds.
            if (input.Contains(","))
            {
                result = ConvertFromStringToDoubleFrench(input);
            }
            else
            {
                result = ConvertFromStringToDoubleEnglish(input);
            }

            return result;
        }

        private double ConvertFromStringToDoubleFrench(string input)
        {
            double result = 0;

            if (!String.IsNullOrWhiteSpace(input))
            {
                //input number from enlir are in French format when using group separators
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ",";
                provider.NumberGroupSeparator = ".";
                provider.NumberGroupSizes = new int[] { 3 };

                bool converted = Double.TryParse(input, NumberStyles.AllowDecimalPoint, provider, out double candidateResult);

                if (converted)
                {
                    result = candidateResult;
                }
            }

            return result;
        }

        private double ConvertFromStringToDoubleEnglish(string input)
        {
            double result = 0;

            if (!String.IsNullOrWhiteSpace(input))
            {
                //input number from enlir are in French format when using group separators
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";
                provider.NumberGroupSizes = new int[] { 3 };

                bool converted = Double.TryParse(input, NumberStyles.AllowDecimalPoint, provider, out double candidateResult);

                if (converted)
                {
                    result = candidateResult;
                }
            }

            return result;
        }
    }
}
