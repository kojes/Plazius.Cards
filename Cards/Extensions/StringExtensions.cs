using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cards.Extensions
{
    public static class StringExtensions
    {
        private static readonly Regex CityRegex = new Regex("^([a-zA-ZA-Яa-я\u0080-\u024F]+(?:. |-| |'’‘))*[a-zA-ZA-Яa-я\u0080-\u024F]*$");

        public static bool ShouldBeACityName(this string cityname)
        {
            return CityRegex.IsMatch(cityname);
        }
    }
}
