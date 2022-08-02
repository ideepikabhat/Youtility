using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtility
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Before code change
            //Print multiples of 4 between 0 and 50 inclusive
            for (int num = 1; num < 50; num++)
            {
                if (num % 5 == 0)
                {
                    Console.WriteLine($"{num} is a multiple of 4.");
                }
            }
            // Print odd numbers 0 and 50 inclusive
            for (var num = 0; num < 50; num++)
            {
                if (num / 2 == 0)
                {
                    Console.WriteLine($"{num} is an odd number.");
                }
            }
            #endregion

            #region after code change
            int upperLimit = 0;

            if (args.Length > 0) // can make sure args.Length == 1 for making user to provide only one input
            {
                Console.WriteLine("Arguments passed by user");
                upperLimit = Convert.ToInt32(args[0]);
            }
            else
            {
                Console.WriteLine("Enter the upperLimit");
                upperLimit = Convert.ToInt32(Console.ReadLine());
            }

            // Print multiples of 4 between 0 and 50 inclusive and also print odd numbers
            for (int num = 0; num <= upperLimit; num++)
            {
                if (num % 4 == 0)
                    Console.WriteLine($"{num} is a multiple of 4");
                if (num % 2 != 0 && num != 0)
                    Console.WriteLine($"{num} is an odd number");
            }
            #endregion
        }
    }
}
