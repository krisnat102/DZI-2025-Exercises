using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peev.Prosveta._1._28
{
    internal class Drink
    {
        protected string name;
        protected float price;
        protected string size;

        public Drink(string name, float price, string size)
        {
            this.name = name;
            this.price = price;
            this.size = size;
        }
    }
}
