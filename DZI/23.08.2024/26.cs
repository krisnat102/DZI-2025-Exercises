namespace ConsoleApp1._08._2024;

public class _26 {
    public void Finance()
    {
        var n = int.Parse(Console.ReadLine());
        var m = Console.ReadLine().Split(' ');
        int maxProfitCounter = 1;
        int profitCounter = 1;
        int lowestProfit = 0;
        float minimalProfit = 0;
        int[] months = new int[n];

        for (int i = 0; i < m.Length; i++)
        {
            months[i] = int.Parse(m[i]);
        }

        for (int i = 0; i < months.Length; i++)
        {
            if (months[i] < months[lowestProfit]) lowestProfit = i;
            if (i != 0 && months[i - 1] <= months[i])
            {
                profitCounter++;
                if (maxProfitCounter < profitCounter) maxProfitCounter = profitCounter;
            }
            else profitCounter = 1;
        }
        
        if(lowestProfit != months.Length - 1) minimalProfit = months[lowestProfit] / 1f / months[lowestProfit + 1] * 100f;
        else minimalProfit = months[lowestProfit] / 1f / months[lowestProfit - 1] * 100f;
        
        Console.WriteLine($"Longest period with bigger profit is {maxProfitCounter} months");
        Console.WriteLine($"Smaller with {minimalProfit} %");
    }

    /* static void Main(string[] args)
    {
        _26 a = new _26();
        a.Finance();
    }*/
}