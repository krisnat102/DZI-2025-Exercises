using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    public static long Couples()
    {
        long result;
        Dictionary<long, int> list = new();
        long input = Int64.Parse(Console.ReadLine());

        while (input != 0)
        {
            if (list.TryGetValue(input, out int value))
            {
                list[input]++;
            }
            else
            {
                list.Add(input, 1);
            }
            input = Int64.Parse(Console.ReadLine());
        }

        foreach(var i in list)
        {
            if (i.Value == 1) return i.Key;
        }

        return 0;
    }
}
