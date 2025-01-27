using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peev.Prosveta._1
{
    internal class _25
    {
        public static void SpecialNum()
        {
            string input = Console.ReadLine();

            if (input == null || Int32.TryParse(input, out int result) || result <= 0)
            {
                Console.WriteLine("Something went wrong!");
                return;
            }

            int inputNum = Int32.Parse(input);

            foreach(char c in input)
            {
                int cNum = c - '0';
                if(inputNum % cNum != 0)
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }
    }
}
