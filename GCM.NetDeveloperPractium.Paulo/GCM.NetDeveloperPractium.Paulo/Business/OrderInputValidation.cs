using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCM.NetDeveloperPractium.Paulo.Business
{
    public class OrderInputValidation
    {
        private static string[] validTimesOfDay = { "morning", "night" };

        public static bool IsTimeOfDayInputValid(string timeOfDayInput)
        {
            return validTimesOfDay.Contains(timeOfDayInput);
        }
    }
}
