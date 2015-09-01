using GCM.NetDeveloperPractium.Paulo.Business.Enums;

namespace GCM.NetDeveloperPractium.Paulo.Business
{
    public class MenuItem
    {
        private TimeOfDay timeOfDay;
        private Dish dishType;
        private bool allowMultipleOrders;

        public bool AllowMultipleOrders
        {
            get { return allowMultipleOrders; }
        }

        public TimeOfDay TimeOfDay
        {
            get { return timeOfDay; }
        }

        public Dish Dish
        {
            get { return dishType; }
        }

        public MenuItem(TimeOfDay timeOfDay, Dish dishType, bool allowMultipleOrders)
        {
            this.timeOfDay = timeOfDay;
            this.dishType = dishType;
            this.allowMultipleOrders = allowMultipleOrders;
        }
    }
}
