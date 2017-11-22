using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.Converters
{
    public class PercentConverter
    {
        #region Constants

        private char[] _percentCharArray = "%".ToCharArray();
        private const int percentageConversionFactor = 100;
        #endregion

        //e.g., from "65%" to 0.65
        public double ConvertFromStringToDouble(string input)
        {
            double result = 0;

            if (!String.IsNullOrWhiteSpace(input))
            {
                //input number from enlir are in French format when using group separators
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ",";
                provider.NumberGroupSeparator = ".";
                provider.NumberGroupSizes = new int[] { 3 };

                //cleanse input
                string cleansedInput = input.TrimEnd(_percentCharArray).Trim();

                bool converted = Double.TryParse(cleansedInput, NumberStyles.AllowDecimalPoint, provider, out double candidateResult);

                if (converted)
                {
                    //result would still be a number greater than 1 (e.g. 65), so we need to divide by 100
                    result = (double)candidateResult / percentageConversionFactor;
                }
            }

            return result;
        }
    }
}
