namespace ConsoleApp1._05._2022;

public class _25 {
    public void Problem25()
    {
        var nums = new Dictionary<int, int>();

        try
        {
            int inputLength = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLength; i++)
            {
                var input = Console.ReadLine();

                int num = int.Parse(input);
                if (nums.ContainsKey(num))
                {
                    nums[num]++;
                }
                else nums.Add(num, 1);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        foreach (var num in nums)
        {
            Console.WriteLine($"число: {num.Key},  брой: {num.Value}");
        }
    }
    
    /*public static void Main(string[] args)
    {
        _25 problem25 = new _25();
        problem25.Problem25();
    }*/
}