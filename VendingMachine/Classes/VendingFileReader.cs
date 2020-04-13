using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace VendingMachine.Classes
{
    public class VendingFileReader
    {
        public Dictionary<string, List<VendableItem>> StockMachine()
        {
            Dictionary<string, List<VendableItem>> inventory = new Dictionary<string, List<VendableItem>>();

            string directory = Directory.GetCurrentDirectory();
            string filename = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, filename);

            try
            {
                using (StreamReader str = new StreamReader(fullPath))
                {
                    while (!str.EndOfStream)
                    {
                        List<VendableItem> itemsList = new List<VendableItem>();
                        string line = str.ReadLine();
                        string[] parts = line.Split('|');

                        if (parts[0].StartsWith("A"))
                        {
                            for(int i = 0; i < 5; i++)
                            {
                                itemsList.Add(new Chips(decimal.Parse(parts[2]), parts[1]));
                            }
                            inventory.Add(parts[0], itemsList);
                        }
                    }
                }
                
                return inventory;

            }
            catch (IOException e)
            {
                Console.WriteLine("Couldn't read file. " + e.Message);
                return inventory;
            }

        }
    }

}
