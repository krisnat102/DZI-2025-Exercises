using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peev.Prosveta._1._28
{
    internal class Tea : Drink
    {
        string type;

        public Tea(string name, float price, string size, string type) : base(name, price, size)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return "Tea: " + name + " ,Size: " + size + " ,Type: " + type + " ,Price: " + price;
        }
    }
}
