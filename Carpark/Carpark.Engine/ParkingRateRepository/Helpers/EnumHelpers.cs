using Carpark.Engine.RateRepository.Rates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpark.Engine.ParkingRateRepository.Helpers
{
    public static class EnumHelpers
    {
        public static string GetEnumDescription(this Type enumType, int? rateCode)
        {
            if (!typeof(Enum).IsAssignableFrom(enumType))
            {
                throw new ArgumentException("Type must be an enum");
            }

            return GetItemDisplayName(enumType, Enum.GetName(enumType, rateCode)); 
        }

        private static string GetItemDisplayName(Type enumType, string name)
        {
            var result = name;

            var attribute = enumType
                .GetField(name)
                .GetCustomAttributes(inherit: false)
                .OfType<DisplayAttribute>()
                .FirstOrDefault();

            if (attribute != null)
            {
                result = attribute.GetName();
            }

            return result;
        }
    }
}
