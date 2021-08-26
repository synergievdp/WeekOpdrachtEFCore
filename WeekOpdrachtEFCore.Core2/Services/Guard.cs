using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOpdrachtEFCore.Core2.Services
{
    public static class Guard
    {
        public static void IsMoreThan(int minValue, int argumentValue, string argumentName)
        {
            if (argumentValue <= minValue)
            {
                throw new ArgumentException(null, argumentName);
            }
        }

        public static void IsNotNullOrWhiteSpace(string argumentValue, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argumentValue))
                throw new ArgumentNullException(argumentName);
        }
    }
}
