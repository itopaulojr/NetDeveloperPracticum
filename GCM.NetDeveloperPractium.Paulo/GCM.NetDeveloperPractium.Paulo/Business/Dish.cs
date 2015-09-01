using GCM.NetDeveloperPractium.Paulo.Business.Enums;
namespace GCM.NetDeveloperPractium.Paulo.Business
{
    public class Dish
    {
        private string dishTypeTitle;
        private DishType dishType;

        public string DishTypeTitle
        {
            get { return dishTypeTitle; }
        }

        public DishType DishType
        {
            get { return dishType; }
        }

        public Dish(string dishTypeTitle, DishType dishType)
        {
            this.dishTypeTitle = dishTypeTitle;
            this.dishType = dishType;
        }
    }
}
