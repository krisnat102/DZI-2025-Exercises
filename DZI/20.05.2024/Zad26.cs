using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peev.DZI._20._05._2024
{
    internal class Zad26
    {
        public static void NumberCounter()
        {
            int[] nums = new int[10];

            long input1 = long.Parse(Console.ReadLine());
            long input2 = long.Parse(Console.ReadLine());

            int maxNum = 0;

            for (long i = input1; i < input2; i++)
            {
                string numString = i.ToString();

                foreach (char c in numString)
                {
                    int num = c - '0';
                    nums[num]++;
                }
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[maxNum] < nums[i])
                {
                    maxNum = i;
                }
            }

            Console.WriteLine($"Digit {maxNum} - {nums[maxNum]} times");
        }
    }
}
