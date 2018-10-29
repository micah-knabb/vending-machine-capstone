using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Capstone
{ 
    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void ReportTests()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "sales_report.txt";
            string fullPath = Path.Combine(directory, fileName);
            
            File.Delete(fullPath); //deletes the pevious file in order to start a new report file to test.
            VendingMachine vmTest1 = new VendingMachine();
            
            vmTest1.BuyItem("A1");
            string value = "";            
            using (StreamReader sr = new StreamReader(fullPath))
            {
                value = sr.ReadLine();
            }
            Assert.AreEqual("Potato Crisps|1", value, "After buying A1, report should say 'Potato Crisps|1'");

            vmTest1.BuyItem("A1");
            using (StreamReader sr = new StreamReader(fullPath))
            {
                value = sr.ReadLine();
            }
            Assert.AreEqual("Potato Crisps|2", value, "After buying A1 twice, new report should say 'Potato Crisps|2'");

            vmTest1.BuyItem("A1");
            using (StreamReader sr = new StreamReader(fullPath))
            {
                value = sr.ReadLine();
            }
            Assert.AreEqual("Potato Crisps|3", value, "After buying A1 three times, new report should say 'Potato Crisps|3'");

            vmTest1.BuyItem("A1");

        }

        [TestMethod]
        public void MoneyTest()
        {
            Money monTest = new Money();
            VendingMachine vmTest = new VendingMachine();
            
            Assert.AreEqual(0.00M, monTest.Balance, "starting balance should be 0");

            monTest.FeedMoney(2.15M);
            Assert.AreEqual(2.15M, monTest.Balance, "balance should be $2.15");

            monTest.MakeChange();
            Assert.AreEqual(8, monTest.Quarters, "Change is $2.15");
            Assert.AreEqual(1, monTest.Dimes, "Change is $2.15");
            Assert.AreEqual(1, monTest.Nickles, "Change is $2.15");
            
        }

        [TestMethod]
        public void VendingTest() 
        {
            VendingMachine vmTest = new VendingMachine();
            
            vmTest.BuyItem("A1");
            var item1 = vmTest.GetInventoryItem("A1");
            Assert.AreEqual("4", item1.Quantity.ToString());
            Assert.AreEqual(1, vmTest.purchasedInventory.Count, "purchasedInventory list should contain 1 object");

            vmTest.BuyItem("A1");
            Assert.AreEqual("3", item1.Quantity.ToString());
            Assert.AreEqual(2, vmTest.purchasedInventory.Count, "purchasedInventory list should contain 2 objects");

            vmTest.BuyItem("A1");
            Assert.AreEqual("2", item1.Quantity.ToString());
            Assert.AreEqual(3, vmTest.purchasedInventory.Count, "purchasedInventory list should contain 3 objects");

            vmTest.BuyItem("A1");
            Assert.AreEqual("1", item1.Quantity.ToString());
            Assert.AreEqual(4, vmTest.purchasedInventory.Count, "purchasedInventory list should contain 4 objects");

            vmTest.BuyItem("A1");
            Assert.AreEqual("0", item1.Quantity.ToString());
            Assert.AreEqual(5, vmTest.purchasedInventory.Count, "purchasedInventory list should contain 5 objects");

            vmTest.BuyItem("A1");
            Assert.AreEqual("SOLD OUT", item1.Quantity.ToString());
            Assert.AreEqual(5, vmTest.purchasedInventory.Count, "purchasedInventory list should contain 5 objects");

            vmTest.Money.FeedMoney(10);
            vmTest.MakeChange();
            Assert.AreEqual(0, vmTest.purchasedInventory.Count);
            
        }

        [TestMethod]
        public void StockTest()
        {
            VendingMachine vmTest = new VendingMachine();
            Assert.AreEqual(16, vmTest.inventory.Count, "You should have 16 total items after the vending machine StockMachine() is invoked.");

            var inventoryItem = vmTest.GetInventoryItem("A1");
            Assert.AreEqual("5", inventoryItem.Quantity.ToString(), "Each item should have a quantity of 5 after the vending machine StockMachine() is invoked.");
            Assert.AreEqual(3.05M, inventoryItem.Price, "A1 should have a price of $3.05");
            Assert.AreEqual("Potato Crisps", inventoryItem.Name, "Item should have a name of Potato Crisps");
            Assert.AreEqual("A1", inventoryItem.Symbol, "Item should have a symbol of A1");
            Assert.AreEqual("Chip", inventoryItem.ItemType, "Item should be of type Chip, and be placed in that class");
            Assert.AreEqual("Capstone.Chips", inventoryItem.GetType().ToString(), "Should be");
            

        }
    }
}
