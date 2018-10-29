using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Drinks : Inventory
    {
        public override string ItemType { get; set; } = "Drink";
        public override string EatNoise { get; } = "Glug Glug, Yum!";
    }
}
