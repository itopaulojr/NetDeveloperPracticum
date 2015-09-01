using GCM.NetDeveloperPractium.Paulo.Business.Enums;
using System;

namespace GCM.NetDeveloperPractium.Paulo.Business.Helper
{
    public class OrderingInputConverter
    {
        private const string MORNING = "morning";
        private const string NIGHT = "night";
        private const string INVALID_INPUT_MESSAGE = "Invalid parameter, parameter should be a valid period of day.";
        
        public static TimeOfDay ConvertTimeOfDay(string strTimeOfDay)
        {
            if (strTimeOfDay.ToLower().Trim() == MORNING)
                return TimeOfDay.MORNING;

            if (strTimeOfDay.ToLower().Trim() == NIGHT)
                return TimeOfDay.NIGHT;

            throw new ArgumentException(INVALID_INPUT_MESSAGE);
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
