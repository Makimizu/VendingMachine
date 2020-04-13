using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class VendingMachine
    {
        private Dictionary<string, List<VendableItem>> items = new VendingFileReader().StockMachine();
        private List<VendableItem> purchasedItems = new List<VendableItem>();
        private bool isSoldOut;
        private decimal balance = (decimal)0.00;

        public Dictionary<string, List<VendableItem>> Items
        {
            get { return this.items; }
        }

        public decimal Balances
        {
            get { return this.balance; }
        }

        public bool IsSoldOut(string slot)
        {
            return items[slot].Count == 0;
        }

        public void PurchaseMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Pilih jenis Pembayaran : ");
                Console.WriteLine("1 :: Deposit Saldo");
                Console.WriteLine("2 :: Pilih Item");
                Console.WriteLine("3 :: Transaksi selesai?");
                Console.WriteLine("q :: Kembali ke Menu");

                Console.WriteLine($"\nSaldo saat ini : {this.balance}");

                Console.Write("Opsi mana yang Anda pilih? ");
                string input = Console.ReadLine().ToLower();

                if (input == "1")
                {
                    Console.WriteLine(".:: Deposit Saldo ::.");
                    Console.WriteLine("Silahkan masukan uang pecahan [ 2000 | 5000 | 10000 | 20000 | 50000 ] : ");
                    decimal amt = decimal.Parse(Console.ReadLine());
                    if ((amt != 2000) && (amt != 5000) && (amt != 10000) && (amt != 20000) && (amt != 50000))
                    {
                        Console.WriteLine("Masukan uang pecahan sesuai daftar!");
                        break;
                    }
                    this.UangPecahan(amt);
                }
                else if (input == "2")
                {
                    Console.WriteLine(".:: Pilih Item ::.");
                    Console.WriteLine("Slot item mana yang akan Anda pilih? ");
                    string slot = Console.ReadLine().ToUpper();
                    this.Purchase(slot);
                }
                else if (input == "3")
                {
                    Console.WriteLine(".:: Transaksi Selesai ::.");
                    this.CompleteTransaction();
                }
                else if (input == "q")
                {
                    Console.WriteLine("Kembali ke Menu Utama");
                    break;
                }
                else
                {
                    Console.WriteLine("Silahkan coba lagi");
                }
            }
        }

        public void UangPecahan(decimal rupiah)
        {
            VendingFileWriter vfw = new VendingFileWriter();
            vfw.WriteToLog("Uang Pecahan :: Rp " + balance + " Rp " + (balance + rupiah));
            this.balance += rupiah;
        }

        public VendableItem Purchase(string slot)
        {
            if (!IsSoldOut(slot))
            {
                if (items[slot][0].Price <= this.balance)
                {
                    VendableItem selection = items[slot][0];
                    VendingFileWriter vfw = new VendingFileWriter();
                    vfw.WriteToLog($"{items[slot][0].Name} {slot} Rp " + balance + " Rp " + (balance - items[slot][0].Price));
                    balance -= items[slot][0].Price;
                    purchasedItems.Add(items[slot][0]);
                    items[slot].Remove(items[slot][0]);
                   
                    return selection;
                }
                else
                {
                    Console.WriteLine("Uang tidak mencukupi, silahkan deposit lagi.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Item terjual, silakan pilih item lain");
                return null;
            }
        }

        public void CompleteTransaction()
        {
            ChangeMaker c = new ChangeMaker(this.balance);
            c.MakeChange();
            VendingFileWriter vfw = new VendingFileWriter();
            vfw.WriteToLog("Sisa kembalian : Rp " + balance);
            this.balance = 0;
            foreach(VendableItem e in purchasedItems)
            {
                Console.WriteLine(e.Consume());
            }
            purchasedItems.Clear();
        }

    }
}
