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
            string input = "";

            Console.WriteLine("To quit, press q.");
            IMenu menu = new MenuFactory().Create();

            while (true)
            {
                Console.Write("Please, input your order: ");
                input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                Ordering ordering = new Ordering(menu);
                string resultMessage = ordering.Order(input);
                Console.WriteLine("Output: " + resultMessage);
            }
        }
    }
}
