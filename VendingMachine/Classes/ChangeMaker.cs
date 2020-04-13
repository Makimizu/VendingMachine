using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class ChangeMaker
    {
        private decimal balance;
        public ChangeMaker(decimal balance)
        {
            this.balance = balance;
        }

        public List<int> MakeChange()
        {
            List<int> coinCount = new List<int>();
            Console.WriteLine("Sisa kembalian : Rp " + balance);
            return coinCount;
        }

    }
}
