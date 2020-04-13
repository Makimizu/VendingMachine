using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class VendingMachineCLI
    {
        public void DisplayMenu()
        {
            VendingMachine vendor = new VendingMachine();

            PrintHeader();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine(":::::::::::::::::::::");
                Console.WriteLine("1] :: Daftar Item");
                Console.WriteLine("2] :: Beli?");
                Console.WriteLine("x] :: Keluar");

                Console.Write("Apa yang Anda inginkan? ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("Daftar Item: ");
                    DisplayItems(vendor);   
                }
                else if (input == "2")
                {
                    vendor.PurchaseMenu();
                }
                else if (input.ToLower() == "x")
                {
                    Console.WriteLine("Terima kasih!");
                    break;
                }
                else
                {
                    Console.WriteLine("Terjadi kesalahan, silakan dicoba lagi...");
                }
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine(".:: Selamat datang di Aplikasi Sederhana Vending Machine ::.");
        }
        public void DisplayItems(VendingMachine v)
        {
            foreach (KeyValuePair<string, List<VendableItem>> kvp in v.Items)
            {
                string temp;
                decimal tempPrice = 0;

                if (kvp.Value.Count == 0)
                {
                    temp = "Terjual!";
                }
                else
                {
                    tempPrice = kvp.Value[0].Price;
                    temp = kvp.Value[0].Name;
                }

                Console.WriteLine(kvp.Key.PadRight(10) + temp.PadRight(20) + tempPrice.ToString().PadRight(10) + "Qty: " + kvp.Value.Count);
            }
        }
    }

}

