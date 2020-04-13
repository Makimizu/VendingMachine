using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public abstract class VendableItem
    {
        protected decimal price;
        public decimal Price
        {
            get { return this.price; }
        }
        protected string name;
        public string Name
        {
            get { return this.name; }
        }
        public abstract string Consume();
    }
}
