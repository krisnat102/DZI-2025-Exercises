using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peev.Prosveta._1._28
{
    internal class Coffee : Drink
    {
        int strength;

        public Coffee(string name, float price, string size, int strength) : base(name, price, size)
        {
            this.strength = strength;
        }

        public override string ToString()
        {
            return "Coffee: " + name + " ,Size: " + size + " ,Strength: " + strength + " ,Price: " + price;
        }
    }
}
