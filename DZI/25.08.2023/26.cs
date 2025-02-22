using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1._08._2023
{
    internal class _26
    {
        public void CheckResults()
        {
            int n = int.Parse(Console.ReadLine());
            List<float> parsedRes,results = new List<float>();

            for (int i = 0; i < n; i ++)
            {
                float result = float.Parse(Console.ReadLine());
                results.Add(result);
            }

            parsedRes = ReadPoints(results);

            Console.WriteLine($"valid works - {parsedRes.Count}");
            Console.WriteLine($"minimal difference - {MinDPoints(parsedRes)} p.");
            Console.WriteLine($"laureates - {Laureates(parsedRes)}");
        }

        public List<float> ReadPoints(List<float> results)
        {
            var parsedRes = new List<float>();
            foreach (var result in results)
            {
                if (result > 0)
                {
                    parsedRes.Add(result);
                }
            }

            return parsedRes;
        }

        public float MinDPoints(List<float> results)
        {
            float minDif = 100;

            for (int i = 0; i < results.Count; i ++)
            {
                float res = results[i];

                for (int j = 0; j < results.Count; j++)
                {
                    float dif = MathF.Abs(results[i] - results[j]);
                    if (j != i && dif != 0 && minDif > dif) minDif = dif;
                }
            }

            return MathF.Round(minDif, 3);
        }

        public int Laureates(List<float> results)
        {
            var sorted =
                (from num in results
                orderby num descending
                select num).ToArray();

            int counter = 0;
            int iCounter = 0;

            for (int i = 1; counter < 4; i++)
            {
                if (results[i] != results[i - 1]) counter++;
                iCounter = i;
            }

            return iCounter;
        }
    }
}
