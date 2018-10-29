using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{

    public class VendingMenus
    {

        #region Constructor
        private VendingMachine _vm = null;
        public VendingMenus(VendingMachine vm)
        {
            _vm = vm;
        }
        #endregion


        /// <summary>
        /// Initializes main menu
        /// </summary>
        public void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();

                Console.Title = "Vendo-Matic 500";
                string title = @"
                                                                  _                            _          _   _                     
                                                     __      _____| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___            
                                                     \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \           
                                                      \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/           
                                                       \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|           
                                                     __     __             _             __  __       _   _        ____   ___   ___  
                                                     \ \   / /__ _ __   __| | ___       |  \/  | __ _| |_(_) ___  | ___| / _ \ / _ \ 
                                                      \ \ / / _ \ '_ \ / _` |/ _ \ _____| |\/| |/ _` | __| |/ __| |___ \| | | | | | |
                                                       \ V /  __/ | | | (_| | (_) |_____| |  | | (_| | |_| | (__   ___) | |_| | |_| |
                                                        \_/ \___|_| |_|\__,_|\___/      |_|  |_|\__,_|\__|_|\___| |____/ \___/ \___/ 
                                                                ____________________________________________
                                                                |############################################|
                                                                |#|                           |##############|
                                                                |#|  =====  ..--''`  |~~``|   |##|````````|##|
                                                                |#|  |   |  \     |  :    |   |##| Please |##|
                                                                |#|  |___|   /___ |  | ___|   |##| Insert |##|
                                                                |#|  /=__\  ./.__\   |/,__\   |##| Money  |##|
            1) Display Vending Machine Items                    |#|  \__//   \__//    \__//   |##|________|##|
                                                                |#|===========================|##############|
            2) Purchase                                         |#|```````````````````````````|##############|                 
                                                                |#| =.._      +++     //////  |##############|
            Q) Exit                                             |#| \/  \     | |     \    \  |#|`````````|##|                  
                                                                |#|  \___\    |_|     /___ /  |#| _______ |##|
                                                                |#|  / __\\  /|_|\   // __\   |#| |1|2|3| |##|                  
                                                                |#|  \__//-  \|_//   -\__//   |#| |4|5|6| |##|
                                                                |#|===========================|#| |7|8|9| |##|                  
                                                                |#|```````````````````````````|#| ``````` |##|
                                                                |#| ..--    ______   .--._.   |#|[=======]|##|
                                                                |#| \   \   |    |   |    |   |#|  _   _  |##|
                                                                |#|  \___\  : ___:   | ___|   |#| ||| ( ) |##|
                                                                |#|  / __\  |/ __\   // __\   |#| |||  `  |##|
                                                                |#|  \__//   \__//  /_\__//   |#|  ~      |##|
                                                                |#|===========================|#|_________|##|
                                                                |#|```````````````````````````|##############|
                                                                |############################################|
                                                                |#|||||||||||||||||||||||||||||####```````###|
                                                                |#||||||||||||PUSH|||||||||||||####\|||||/###|
                                                                |############################################|
                                                                \\\\\\\\\\\\\\\\\\\\\\///////////////////////
                                                                 |________________________________|CR98|___|
                                                                                 
                                                                                ";
                Console.WriteLine(title);
                Console.WriteLine($"\t\tYou have inserted {_vm.Money.Balance.ToString("C")} total");
                char input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    DisplayMenu();
                }
                else if (input == '2')
                {
                    PurchaseMenu();
                }
                else if (input == 'Q' || input == 'q')
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Not a valid selection.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Displays all current inventory in machine
        /// </summary>
        public void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"| {"Symbol".PadRight(4)} | " +
                             $"| {"Name".PadRight(20)} |" +
                             $"| {"Price".PadRight(10)} | " +
                             $"{"Qty".PadRight(10)} |");

                foreach (Inventory item in _vm.inventory)
                {
                    {
                        Console.WriteLine($"| {item.Symbol.PadRight(6)} | " +
                            $"| {item.Name.PadRight(20)} |" +
                            $"| {item.Price.ToString("C").PadRight(10)} |" +
                            $" {item.DisplayQuantity.PadRight(10)} |");
                    }
                }
                Console.WriteLine("Press any key to return to the previous menu");
                Console.ReadKey();
                exit = true;
            }
        }

        /// <summary>
        /// Menu for purchasing items
        /// </summary>
        public void PurchaseMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1) Feed money\n");
                Console.WriteLine("2) Select product\n");
                Console.WriteLine("3) Finish Transaction\n");
                Console.WriteLine("Q) Return to main menu\n");
                Console.WriteLine($"You have inserted {_vm.Money.Balance.ToString("C")} total");
                char input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    FeedMoneyMenu();
                }
                else if (input == '2')
                {
                    ProductSelection();
                }
                else if (input == '3')
                {
                    FinishTransactionMenu();
                }                
                else if (input == 'Q' || input == 'q')
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Not a valid selection.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Menu for feeidng money
        /// </summary>
        public void FeedMoneyMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Please select an amount to feed:\n");
                Console.WriteLine("1) $1 Bill");
                Console.WriteLine("2) $2 Bill");
                Console.WriteLine("3) $5 Bill");
                Console.WriteLine("4) $10 Bill");
                Console.WriteLine("5) $20 Bill");
                Console.WriteLine("Q) Go back\n");
                Console.WriteLine($"You have inserted {_vm.Money.Balance.ToString("C")} total");                
                char input = Console.ReadKey().KeyChar;

                if (input == '1')
                {
                    _vm.Money.FeedMoney(1.0M);
                    Console.WriteLine($"You have inserted $1.00.");
                    Console.ReadKey();
                }
                else if (input == '2')
                {

                    _vm.Money.FeedMoney(2.0M);
                    Console.WriteLine($"You have inserted $2.00");
                    Console.ReadKey();
                }
                else if (input == '3')
                {
                    _vm.Money.FeedMoney(5.0M);
                    Console.WriteLine($"You have inserted $5.00.");
                    Console.ReadKey();
                }
                else if (input == '4')
                {
                    _vm.Money.FeedMoney(10.0M);
                    Console.WriteLine($"You have inserted $10.00.");
                    Console.ReadKey();
                }
                else if (input == '5')
                {
                    _vm.Money.FeedMoney(20.0M);
                    Console.WriteLine($"You have inserted $20.00.");
                    Console.ReadKey();
                }
                else if (input == 'Q' || input == 'q')
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Input is invalid.");
                    Console.ReadKey();
                }
            }
            
        }
        
        /// <summary>
        /// Menu for selecting a product from a display
        /// </summary>
        public void ProductSelection()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                VendingMachineContents();
                Console.WriteLine($"Current Balance: {_vm.Money.Balance.ToString("C")}");
                Console.WriteLine("What would you like to purchase today?");
                Console.WriteLine("Enter Q to return to previous menu");
                Console.WriteLine("Input Item Symbol: \n");
                string buyItem = Console.ReadLine();
                var inv = _vm.GetInventoryItem(buyItem);

                if (buyItem.ToUpper() == "Q")
                {
                    exit = true;
                }
                else if (_vm.inventory.Contains(inv))
                {
                    if (inv.Quantity > 0)
                    {
                        if (_vm.Money.Balance > inv.Price)
                        {
                            _vm.BuyItem(buyItem);
                            Console.WriteLine($"{inv.Name} has been dispensed to you.");
                            Console.WriteLine("Press Enter to add another item, or hit Q to return to the previous menu");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough money.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("SOLD OUT");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Selection.");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Menu for dispensing change and ending transaction
        /// </summary>
        public void FinishTransactionMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Would you like to finish your transaction?");
                Console.WriteLine($"Y) to dispense change");
                Console.WriteLine($"Q) to return to previous menu");
                string input = Console.ReadLine();
                Console.Clear();
                if (input.ToUpper() == "Y")
                {
                    Console.Clear();
                    //prints out item sounds
                    foreach (Inventory item in _vm.purchasedInventory)
                    {
                        Console.WriteLine($"{item.EatNoise}");
                        Console.WriteLine();
                    }

                    _vm.MakeChange();
                    Console.WriteLine($"Your change is being returned as {_vm.Money.Quarters} Quarters, " +
                        $"{_vm.Money.Dimes} dimes, and {_vm.Money.Nickles} nickles.");

                    Console.WriteLine("Thank you for your business!");
                    Console.ReadKey();
                    exit = true;
                }
                else if (input.ToUpper() == "Q")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Please only enter /'Y/' to complete transaction or /'Q/' to return");
                }
            }
        }

        /// <summary>
        /// shows current contents of machine
        /// </summary>
        public void VendingMachineContents()
        {
            Console.WriteLine($"| {"Symbol".PadRight(4)} | " +
                             $"| {"Name".PadRight(20)} |" +
                             $"| {"Price".PadRight(10)} | " +
                             $"{"Qty".PadRight(10)} |");

            foreach (Inventory item in _vm.inventory)
            {
                {
                    Console.WriteLine($"| {item.Symbol.PadRight(6)} | " +
                        $"| {item.Name.PadRight(20)} |" +
                        $"| {item.Price.ToString("C").PadRight(10)} |" +
                        $" {item.DisplayQuantity.PadRight(10)} |");
                }
            }
        }
    }
}
