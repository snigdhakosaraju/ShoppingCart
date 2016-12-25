using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            POSEntities.CalculateCartTotal(new List<string>() { "apple", "apple", "orange" ,"apple"});
            POSEntities.PrintRecipt();
            Console.WriteLine("==============================================================================================");
            Console.WriteLine("Enter 'exit' to Exit from Program");
            Console.WriteLine("Enter items in comma separated, Available items are 'apple' and 'orange'");
            string cmdLineArgs = Console.ReadLine();
            while (cmdLineArgs != "exit")
            {
                POSEntities.CalculateCartTotal(cmdLineArgs.Split(new char[]{','}).Select(x=> x.ToString()).ToList()  );
                POSEntities.PrintRecipt();
                Console.WriteLine("==============================================================================================");
                Console.WriteLine("Enter 'exit' to Exit from Program");
                Console.WriteLine("Enter items in comma separated, Available items are 'apple' and 'orange'");

                cmdLineArgs = Console.ReadLine();
               
            }
           
        }
    }
}
