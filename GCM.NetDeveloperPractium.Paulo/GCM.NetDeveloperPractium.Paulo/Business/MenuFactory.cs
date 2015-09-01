using GCM.NetDeveloperPractium.Paulo.Business.Enums;
using GCM.NetDeveloperPractium.Paulo.Business.Interfaces;
namespace GCM.NetDeveloperPractium.Paulo.Business
{
    public class MenuFactory
    {
        public IMenu Create()
        {
            IMenu menu = new Menu();
            menu.AddMenu(TimeOfDay.MORNING, new Dish("eggs", DishType.ENTREE));
            menu.AddMenu(TimeOfDay.MORNING, new Dish("toast", DishType.SIDE));
            menu.AddMenu(TimeOfDay.MORNING, new Dish("coffee", DishType.DRINK), true);

            menu.AddMenu(TimeOfDay.NIGHT, new Dish("steak", DishType.ENTREE));
            menu.AddMenu(TimeOfDay.NIGHT, new Dish("potato", DishType.SIDE), true);
            menu.AddMenu(TimeOfDay.NIGHT, new Dish("wine", DishType.DRINK));
            menu.AddMenu(TimeOfDay.NIGHT, new Dish("cake", DishType.DESERT));
            return menu;
        }
    }
}
