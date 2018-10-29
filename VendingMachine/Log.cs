using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone
{
    public class Log
    {
        /// <summary>
        /// Writes a log to the current folder that shows data surrounding transactions
        /// </summary>
        /// <param name="kindOfTransaction">The kind of transaction you want to record</param>
        /// <param name="dollarValue">Dollar value that is being added or removed</param>
        /// <param name="balance">Ending balance after transaction</param>
        private static void WriteToLog(string kindOfTransaction, decimal dollarValue, decimal balance)
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "log.txt";
            string fullPath = Path.Combine(directory, fileName);
            string updated = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt"); //formats time
            string logText = $"{updated} {kindOfTransaction} {dollarValue.ToString("C")} {balance.ToString("C")}\r\n";

            File.AppendAllText(fullPath, logText);
        }

        public static void FeedMoneyLog(decimal moneyFed, decimal balance)
        {
            WriteToLog("FEED MONEY:", moneyFed, balance);
        }

        public static void BuyItemLog(string itemName, decimal startingBalance, decimal endingBalance)
        {
            WriteToLog(itemName, startingBalance, endingBalance); 
        }

        public static void GiveChangeLog(decimal balance)
        {
            WriteToLog("GIVE CHANGE:", balance, 0);
        }
    }
}
