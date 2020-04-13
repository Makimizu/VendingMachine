using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Chips: VendableItem
    {
        public override string Consume()
        {
            return "Enak....Guys !!!";
        }
        public Chips(decimal price, string name)
        {
            base.price = price;
            base.name = name;
        }
    }
}
