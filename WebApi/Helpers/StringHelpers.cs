using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class StringHelpers
    {
        public static bool CompareAndIgnoreCase(string string1, string string2)
        {
            var lowerValue1 = string1.ToLower();
            var lowerValue2 = string2.ToLower();

            return lowerValue1 == lowerValue2 ? true : false;
        }
    }
}
