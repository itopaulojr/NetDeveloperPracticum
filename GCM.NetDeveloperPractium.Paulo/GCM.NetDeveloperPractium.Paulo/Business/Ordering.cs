using GCM.NetDeveloperPractium.Paulo.Business.Enums;
using GCM.NetDeveloperPractium.Paulo.Business.Helper;
using GCM.NetDeveloperPractium.Paulo.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GCM.NetDeveloperPractium.Paulo.Business
{
    public class Ordering
    {
        private const string ERROR_OUTPUT_MESSAGE = "error";
        private const char DISHES_CHAR_SEPARATOR = ',';
        private IMenu menu;
        public Ordering(IMenu menu)
        {
            this.menu = menu;
        }

        public string Order(string timeOfDay, string strdishesTypeIds)
        {
            string[] dishesTypesOrderIds = strdishesTypeIds.Split(',').OrderBy(x => x).ToArray();
            var dishesTypesOrderIdsGroup = dishesTypesOrderIds.GroupBy(x => x);
            TimeOfDay timeOfDayOrder = OrderingInputConverter.ConvertTimeOfDay(timeOfDay);

            string resultOrder = BuildResultOrderMessage(dishesTypesOrderIdsGroup, timeOfDayOrder);
            return resultOrder;
        }

        private string BuildResultOrderMessage(IEnumerable<IGrouping<string, string>> dishesTypesOrderIdsGroup, TimeOfDay timeOfDayOrder)
        {
            MenuItem menuItem = null;
            Dish dish = null;
            string resultOrder = "";
            string validOrderMessage = "";
            string invalidOrderMessage = "";

            foreach (var dishTypeOrderIdGroupItem in dishesTypesOrderIdsGroup)
            {
                DishType? dishType = OrderingInputConverter.GetToDishType(dishTypeOrderIdGroupItem.Key);
                if (dishType == null)
                {
                    invalidOrderMessage += GetErrorMessage();
                    continue;
                }

                menuItem = menu.GetMenuItem(timeOfDayOrder, dishType.Value);
                if (menuItem != null)
                {
                    dish = menuItem.Dish;
                    int dishRepetition = dishTypeOrderIdGroupItem.Count();
                    if (dishRepetition == 1)
                    {
                        validOrderMessage += GetValidMessage(dish.DishTypeTitle);
                    }
                    else
                    {
                        if (menuItem.AllowMultipleOrders)
                        {
                            validOrderMessage += GetValidMessage(dish.DishTypeTitle, dishRepetition);
                        }
                        else
                        {
                            validOrderMessage += GetValidMessage(dish.DishTypeTitle);
                            int invalidRepetitionsCount = dishRepetition - 1;
                            for (int i = 0; i < invalidRepetitionsCount; i++)
                            {
                                invalidOrderMessage += GetErrorMessage();
                            }
                        }
                    }
                }
                else
                {
                    invalidOrderMessage += GetErrorMessage();
                }
            }

            resultOrder = validOrderMessage + invalidOrderMessage;
            resultOrder = resultOrder.Trim().TrimEnd(DISHES_CHAR_SEPARATOR);
            return resultOrder;
        }

        private string GetErrorMessage()
        {
            string errorMessage = string.Format("{0}{1} ", ERROR_OUTPUT_MESSAGE, DISHES_CHAR_SEPARATOR);
            return errorMessage;
        }

        private string GetValidMessage(string dishMessage)
        {
            string validMessage = string.Format("{0}{1} ", dishMessage, DISHES_CHAR_SEPARATOR);
            return validMessage;
        }

        private string GetValidMessage(string dishMessage, int dishRepetition)
        {
            string validMessage = string.Format("{0}(x{1}){2} ", dishMessage, dishRepetition, DISHES_CHAR_SEPARATOR);
            return validMessage;
        }
    }
}
