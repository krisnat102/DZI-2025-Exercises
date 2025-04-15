namespace ConsoleApp1
{
    internal class Dice : IComparable<Dice>
    {
        public int Dice1 { get; private set; }
        public int Dice2 { get; private set; }

        public Dice(int dice1, int dice2)
        {
            Dice1 = dice1;
            Dice2 = dice2;
        }
        public int CompareTo(Dice d)
        {
            if (Dice1 == Dice2 && d.Dice1 == d.Dice2)
            {
                if (Dice1 < d.Dice1) return 1;
                else if (Dice1 == d.Dice1) return 0;
                else return -1;
            }
            else if (Dice1 == Dice2 && d.Dice1 != d.Dice2) return 1;

            else if (Dice1 != Dice2 && d.Dice1 == d.Dice2) return -1;

            else
            {
                if (Dice1 + Dice2 > d.Dice1 + d.Dice2) return 1;

                else if (Dice1 + Dice2 < d.Dice1 + d.Dice2) return -1;

                else
                {
                    if (Dice1 > d.Dice1) return 1;
                    else return -1;
                }
            }
        }

        public override string ToString()
        {
            return $"{Dice1}, {Dice2}";
        }
    }

    public class Game
    {
        private List<Dice> dice;

        public Game(string fname)
        {
            StreamReader reader = new StreamReader(fname);
            string input = reader.ReadLine();
            Dice d;

            while (input != null)
            {
                d = new Dice(input[0] - '0', input[2] - '0');
                dice.Add(d);
                input = reader.ReadLine();
            }
        }

        public override string ToString()
        {
            string text = "";
            foreach (var d in dice)
            {
                text += $"{d},";
            }

            return text;
        }

        public void Sort()
        {
            dice.Sort();
        }
    }
    public class Test
    {
    }
}
