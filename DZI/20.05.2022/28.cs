using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZI.DZI._20._05._2022
{
    internal class _28
    {
        public List<int> Test(List<int> list, int k)
        {
            var tempList = new List<int>();

            foreach (int i in list)
            {
                if (NumSum(i) % k != 0) tempList.Add(i);
            }

            list = tempList;

            return list;
        }

        public List<int> Sort(List<int> list)
        {
            var numList =
                from i in list
                orderby NumSum(i)
                select i;

            return numList.ToList();
        }

        public List<int> ReadFile(string name)
        {
            try
            {
                StreamReader file = new StreamReader(name);

                file.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int NumSum(int i)
        {
            string num = i + "";
            int sum = 0;

            foreach (char c in num)
            {
                sum += c - '0';
            }

            return sum;
        }
    }
}
