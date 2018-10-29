using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Money
    {
        #region Properties
        /// <summary>
        /// Current Working Balance
        /// </summary>
        public decimal Balance { get; set; }

        //properties to hold the number of coins to be returned
        public int Quarters { get; private set; }
        public int Dimes { get; private set; }
        public int Nickles { get; private set; }
        #endregion
        
        /// <summary>
        /// Makes nickle, dime, and quarter coin change based on current balance.
        /// 
        /// Sets balance equal to zero.
        /// </summary>
        public void MakeChange()
        {
            Log.GiveChangeLog(Balance);
            //resets values to zero on method start
            Quarters = 0;
            Dimes = 0;
            Nickles = 0;
            while (Balance - .25M >= 0)
            {
                Balance -= .25M;
                Quarters++;
            }
            while (Balance - .1M >= 0)
            {
                Balance -= .1M;
                Dimes++;
            }
            while (Balance > 0)
            {
                Balance -= .05M;
                Nickles++;
            }
            Balance = 0;
        }

        /// <summary>
        /// Allows user to feed an amount of money into the machine
        ///
        /// </summary>
        /// <param name="amount">amount of money to feed</param>
        public void FeedMoney(decimal amount)
        {
            Balance += amount;
            Log.FeedMoneyLog(amount, Balance);
        }
        
    }
}
