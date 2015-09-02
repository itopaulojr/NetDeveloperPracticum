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

        public string Order(string orderInput)
        {
            string[] inputArray = orderInput.Split(',').ToArray();

            string timeOfDay = inputArray[0];
            TimeOfDay? timeOfDayOrder = OrderingInputConverter.GetTimeOfDay(timeOfDay);

            if (timeOfDayOrder == null)
                return GetErrorMessage().Trim().TrimEnd(DISHES_CHAR_SEPARATOR);

            string[] dishesTypesOrderIds = GetOnlyDishesTypes(inputArray);

            string resultOrder = BuildResultOrderMessage(dishesTypesOrderIds, timeOfDayOrder.Value);
            return resultOrder;
        }

        private string[] GetOnlyDishesTypes(string[] inputArray)
        {
            var auxInputList = inputArray.ToList();
            if (auxInputList.Count > 0)
                auxInputList.RemoveAt(0);

            string[] dishesTypesOrderIds = auxInputList.ToArray();
            return dishesTypesOrderIds;
        }

        private string BuildResultOrderMessage(string[] dishesTypesOrderIds, TimeOfDay timeOfDayOrder)
        {
            MenuItem availableMenuItem = null;
            Dish dish = null;
            string resultOrder = "";
            string errorMessage = "";

            var dishesTypesOrderIdsGroup = dishesTypesOrderIds.OrderBy(x => x).GroupBy(x => x);

            foreach (var dishTypeOrderIdGroupItem in dishesTypesOrderIdsGroup)
            {
                DishType? currentDishType = OrderingInputConverter.GetToDishType(dishTypeOrderIdGroupItem.Key);
                availableMenuItem = menu.GetMenuItem(timeOfDayOrder, currentDishType.Value);

                int dishRepetition = dishTypeOrderIdGroupItem.Count();

                if (!IsValidDishType(currentDishType))
                {
                    errorMessage = GetErrorMessage();
                    continue;
                }

                if (!IsMenuItemAvailable(availableMenuItem))
                {
                    errorMessage = GetErrorMessage();
                    continue;
                }
                dish = availableMenuItem.Dish;

                if (dishRepetition == 1)
                {
                    resultOrder += GetValidMessage(dish.DishTypeTitle);
                    continue;
                }
                else
                {
                    if (availableMenuItem.AllowMultipleOrders)
                    {
                        resultOrder += GetValidMessage(dish.DishTypeTitle, dishRepetition);
                    }
                    else
                    {
                        errorMessage = GetErrorMessage();
                    }
                }
            }
            resultOrder = resultOrder + errorMessage;
            resultOrder = resultOrder.Trim().TrimEnd(DISHES_CHAR_SEPARATOR);
            return resultOrder;
        }

        private static bool IsValidDishType(DishType? dishType)
        {
            return dishType != null;
        }

        private bool IsMenuItemAvailable(MenuItem menuItem)
        {
            return menuItem != null;
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
