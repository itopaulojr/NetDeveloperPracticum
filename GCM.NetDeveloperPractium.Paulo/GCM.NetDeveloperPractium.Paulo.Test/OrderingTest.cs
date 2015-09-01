using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCM.NetDeveloperPractium.Paulo.Business;

namespace GCM.NetDeveloperPractium.Paulo.Test
{
    [TestClass]
    public class OrderingTest
    {
        [TestMethod]
        public void Order_OrderMorning123_ShowseggsToastCoffeeSucessfully()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("morning", "1,2,3");

            Assert.AreEqual(orderResult, "eggs, toast, coffee");
        }

        [TestMethod]
        public void Order_OrderMorning231_ShowseggsToastCoffeeSucessfully()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("morning", "1,2,3");

            Assert.AreEqual(orderResult, "eggs, toast, coffee");
        }

        [TestMethod]
        public void Order_OrderMorningNotApplicableDish_ShowErrorMessageAfterValidMessages()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("morning", "1,2,3,4");

            Assert.AreEqual(orderResult, "eggs, toast, coffee, error");
        }

        [TestMethod]
        public void Order_OrderMorningMultipleDrinks_ReturnDrinkWithMultiplicitySignal()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("morning", "1,2,3,3,3");

            Assert.AreEqual(orderResult, "eggs, toast, coffee(x3)");
        }

        [TestMethod]
        public void Order_OrderMorningInvalidDishRepetition_ShowMultipleErros()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("morning", "1,2,2,3");

            Assert.AreEqual(orderResult, "eggs, toast, coffee, error");
        } 

        [TestMethod]
        public void Order_OrderNight1234_ShowSteakPotatoWineCake()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("night", "1,2,3,4");

            Assert.AreEqual(orderResult, "steak, potato, wine, cake");
        }

        [TestMethod]
        public void Order_OrderNight1244_ShowMultipleSides()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("night", "1,2,2,4");

            Assert.AreEqual(orderResult, "steak, potato(x2), cake");
        }

        [TestMethod]
        public void Order_OrderNightInvalidDishRepetition_ShowMultipleErros()
        {
            Ordering ordering = new Ordering(new MenuFactory().Create());
            string orderResult = ordering.Order("night", "1,2,2,2,3,3,3,4");

            Assert.AreEqual(orderResult, "steak, potato(x3), wine, cake, error, error");
        } 
    }
}
