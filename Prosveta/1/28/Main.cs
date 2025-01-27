using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peev.Prosveta._1._28
{
    internal class Main
    {
        public static void Drinks()
        {
            string inputs = Console.ReadLine();
            string[] input = new string[4];
            List<Drink> drinks = new List<Drink>();

            while (inputs != null)
            {
                input = inputs.Split(",");
                Drink drink;
                switch (input[0])
                {
                    case "Coffee":
                        drinks.Add(drink = new Coffee(input[1], float.Parse(input[4]), input[3], Int32.Parse(input[2])));
                        break;
                    case "Tea":
                        drinks.Add(drink = new Tea(input[1], float.Parse(input[4]), input[3],input[2]));
                        break;
                }
                inputs = Console.ReadLine();
            }

            foreach(Drink drink in drinks)
            {
                drink.ToString();
            }
        }
    }
}
