using GCM.NetDeveloperPractium.Paulo.Business;
using GCM.NetDeveloperPractium.Paulo.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCM.NetDeveloperPractium.Paulo
{
    class Program
    {
        static void Main(string[] args)
        {
            string timeOfDay = "";
            string strdishesTypeIds = "";

            do
            {
                Console.Write("Please, type a valid time of day (morning or night): ");
                timeOfDay = Console.ReadLine();
            }
            while (!OrderInputValidation.IsTimeOfDayInputValid(timeOfDay));

            Console.Write("Please, type order types separeted by comma: ");
            strdishesTypeIds = Console.ReadLine();

            IMenu menu = new MenuFactory().Create();
            Ordering ordering = new Ordering(menu);
            string resultMessage = ordering.Order(timeOfDay, strdishesTypeIds);
            Console.WriteLine("Output: " + resultMessage);
            
            Console.ReadKey();
        }
    }
}
