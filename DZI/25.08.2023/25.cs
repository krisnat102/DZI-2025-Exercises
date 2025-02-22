using System;
using System.Linq;

namespace ConsoleApp1._08._2023
{
    internal class _25
    {
        public void Palindrome()
        {
            string num, part1, part2Temp, part2;
            part2 = "";
            int i;

            num = Console.ReadLine();

            try
            {
                i = int.Parse(num);

                if(i < 1 || i > 10000000) Console.WriteLine("Incorrectly entered number");
            }
            catch
            {
                Console.WriteLine("Incorrectly entered number");
            }

            if(num.Length % 2 == 1) part1 = num.Substring(0, num.Length / 2 + 1);
            else part1 = num.Substring(0, num.Length / 2);
            
            part2Temp = num.Substring(num.Length / 2);

            foreach(var c in part2Temp.Reverse())
            {
                part2 += c.ToString();
            }

            if (part1 == part2)
            {
                Console.WriteLine($"{num} is a palindrome");
                return;
            }

            Console.WriteLine($"{num} is NOT a palindrome");
        }
    }
}
