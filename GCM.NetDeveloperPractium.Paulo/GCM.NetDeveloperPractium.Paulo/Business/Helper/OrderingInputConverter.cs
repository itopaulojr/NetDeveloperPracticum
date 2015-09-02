using GCM.NetDeveloperPractium.Paulo.Business.Enums;
using System;

namespace GCM.NetDeveloperPractium.Paulo.Business.Helper
{
    public class OrderingInputConverter
    {
        public static TimeOfDay? GetTimeOfDay(string strTimeOfDay)
        {
            TimeOfDay? resultTimeOfDay = null;
            
            foreach (TimeOfDay timeOfDay in Enum.GetValues(typeof(TimeOfDay)))
            {
                if (timeOfDay.ToString().ToLower().Trim() == strTimeOfDay.ToLower().Trim())
                {
                    return timeOfDay;
                }
            }
            return resultTimeOfDay;
        }

        public static DishType? GetToDishType(string strDishType)
        {
            int dishTypeId = 0;
            if (int.TryParse(strDishType, out dishTypeId))
            {
                return (DishType)dishTypeId;
            }
            else
            {
                return null;
            }
        }
    }
}
