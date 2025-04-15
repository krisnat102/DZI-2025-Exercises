
namespace ConsoleApp1
{
    internal class ev
    {
        int num;
        int highestEV;
        int evCounter;

        public int EvCalculator()
        {
            var input = Console.ReadLine().Split(' ');
            int input1 = int.Parse(input[0]);
            int input2 = int.Parse(input[1]);

            for (int i = input1; i < input2; i++)
            {
                evCounter = 0;
                var ev = ObichamDankata(i);

                if (ev > highestEV)
                {
                    highestEV = ev;
                    num = i;
                }
            }

            return num;
        }
        
        private int ObichamDankata(int i)
        {
            if (i % 2 == 0)
            {
                evCounter++;
                return ObichamDankata(i / 2);
            }

            return evCounter;
        }
    }
}
