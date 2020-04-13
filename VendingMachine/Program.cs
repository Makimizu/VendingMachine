using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Classes;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineCLI menu = new VendingMachineCLI();
            menu.DisplayMenu();
            
        }
    }
}
