using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        #region properties and dictionaries
        public List<Inventory> inventory = new List<Inventory>();
        public List<Inventory> purchasedInventory = new List<Inventory>();
        public Money Money { get; set; } = new Money();
        public Report Report { get; set; } = new Report();
        #endregion

        /// <summary>
        /// Starts the machine
        /// </summary>
        public VendingMachine()
        {
            StockMachine();
            Report.GetOldSalesReport();
        }

        public void MakeChange()
        {
            Money.MakeChange();
            purchasedInventory.Clear();
        }


        /// <summary>
        /// gets position of inventory from list
        /// </summary>
        /// <param name="symbol">Symbol of vending maching item</param>
        /// <returns></returns>
        public Inventory GetInventoryItem(string symbol)
        {
            Inventory item = null;
            foreach (Inventory inv in inventory)
            {
                if (inv.Symbol.ToLower() == symbol.ToLower())
                {
                    item = inv;
                }
            }
            return item;
        }
        
        /// <summary>
        /// Buys an item from the vending machine
        /// </summary>
        /// <param name="item">Inventory object to buy</param>
        public void BuyItem(string item)
        {
            //int currentQuantity = 0;
            var inv = GetInventoryItem(item);
            if (inv.Quantity > 0)
            {
                inv.Quantity--;
                Log.BuyItemLog(inv.Name, Money.Balance, Money.Balance - inv.Price);
                Money.Balance -= inv.Price;
                if (inv.ItemType == "Candy")
                {
                    purchasedInventory.Add(new Candy());
                    Report.PopulateNewReport(inv.Name, inv.Price);
                }
                else if (inv.ItemType == "Gum")
                {
                    purchasedInventory.Add(new Gum());
                    Report.PopulateNewReport(inv.Name, inv.Price);
                }
                else if (inv.ItemType == "Drink")
                {
                    purchasedInventory.Add(new Drinks());
                    Report.PopulateNewReport(inv.Name, inv.Price);
                }
                else if (inv.ItemType == "Chip")
                {
                    purchasedInventory.Add(new Chips());
                    Report.PopulateNewReport(inv.Name, inv.Price);
                }
            }
        }

        /// <summary>
        /// stocks a machine with new items on creation
        /// </summary>
        public void StockMachine()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = @"\..\..\..\etc\vendingmachine.csv";
            string fullPath = directory + fileName;

            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string fullLine = sr.ReadLine();
                    string type = "";
                    string[] lines = fullLine.Split('|');
                    type = lines[3];
                    if (type == "Chip")
                    {
                        Chips chip = new Chips();
                        chip.Symbol = lines[0];
                        chip.Name = lines[1];
                        chip.Price = decimal.Parse(lines[2]);
                        chip.Quantity = 5;
                        inventory.Add(chip);
                    }
                    else if (type == "Candy")
                    {
                        Candy candy = new Candy();
                        candy.Symbol = lines[0];
                        candy.Name = lines[1];
                        candy.Price = decimal.Parse(lines[2]);
                        candy.Quantity = 5;
                        inventory.Add(candy);
                    }
                    else if (type == "Drink")
                    {
                        Drinks drink = new Drinks();
                        drink.Symbol = lines[0];
                        drink.Name = lines[1];
                        drink.Price = decimal.Parse(lines[2]);
                        drink.Quantity = 5;
                        inventory.Add(drink);
                    }
                    else if (type == "Gum")
                    {
                        Gum gum = new Gum();
                        gum.Symbol = lines[0];
                        gum.Name = lines[1];
                        gum.Price = decimal.Parse(lines[2]);
                        gum.Quantity = 5;
                        inventory.Add(gum);
                    }
                }
            }
        }
    }
}
