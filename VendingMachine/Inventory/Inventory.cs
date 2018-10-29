using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public abstract class Inventory
    {
        /// <summary>
        /// Symbol for selecting an inventory item
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Name of the inventory item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of the inventory item
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Quantity of the item in inventory
        /// </summary>
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// Quantity to display based on if item is sold out or not
        /// </summary>
        public string DisplayQuantity
        {
            get
            {
                if (Quantity <= 0)
                {
                    return "SOLD OUT";
                }
                else
                {
                    return Quantity.ToString();
                }
            }
        }
        /// <summary>
        /// Category of inventory item
        /// </summary>
        public virtual string ItemType {get; set;}

        /// <summary>
        /// Noise you make while consuming the inventory item to be overwritten in item classes
        /// </summary>
        public abstract string EatNoise {get;}
    }
}
