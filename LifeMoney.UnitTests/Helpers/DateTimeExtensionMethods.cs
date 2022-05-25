using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeMoney.UnitTests
{
    public static class DateTimeExtensionMethods
    {
        public static DateTime GetDateTime(this string dateTimeString)
        {
            return DateTime.ParseExact(dateTimeString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
