using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infrastructure.Common
{
    public class AzCultureInfos
    {
        public CultureInfo AzCulture()
        {
            return CultureInfo.GetCultureInfo("az-Latn-AZ");
        }

        public string ToAzDateTimeFormatFull(DateTime date)
        {
            var cultureinfo = AzCulture();
            var azDateTime = date.ToAzDateTime();
            return azDateTime.ToString("D", cultureinfo);
        }

        public string ToAzDateTimeFormatShort(DateTime dateTime)
        {
            var cultInfo = AzCulture();
            var azDateTime = dateTime.ToAzDateTime();
            return azDateTime.ToString("dd-MMM-yyyy", cultInfo);
        }


        public TimeSpan Difference(DateTime left, DateTime right)
        {
            return left.Difference(right);
        }


        public string AzCurrency(decimal value)
        {
            return value.AzCurrency();
        }
    }
}
