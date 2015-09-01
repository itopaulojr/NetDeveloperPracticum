using GCM.NetDeveloperPractium.Paulo.Business.Enums;
using GCM.NetDeveloperPractium.Paulo.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GCM.NetDeveloperPractium.Paulo.Business
{
    public class Menu : IMenu
    {
        private List<MenuItem> menuItems = new List<MenuItem>();

        public void AddMenu(TimeOfDay timeOfDay, Dish dishType, bool allowMultipleOrders)
        {
            MenuItem newMenuItem = new MenuItem(timeOfDay, dishType, allowMultipleOrders);
            menuItems.Add(newMenuItem);
        }

        public MenuItem GetMenuItem(TimeOfDay timeOfDay, DishType dishType)
        {
            MenuItem menuItem = menuItems.FirstOrDefault(x => x.Dish.DishType == dishType && x.TimeOfDay == timeOfDay);
            return menuItem;
        }
    }
}
