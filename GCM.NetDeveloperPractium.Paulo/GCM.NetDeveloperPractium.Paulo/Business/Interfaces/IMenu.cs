using GCM.NetDeveloperPractium.Paulo.Business.Enums;
namespace GCM.NetDeveloperPractium.Paulo.Business.Interfaces
{
    public interface IMenu
    {
        void AddMenu(TimeOfDay timeOfDay, Dish dish, bool allowMultipleOrders = false);

        MenuItem GetMenuItem(TimeOfDay timeOfDay, DishType dishType);
    }
}
