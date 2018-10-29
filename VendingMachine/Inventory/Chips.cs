using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Chips : Inventory
    {
        public override string ItemType { get; set; } = "Chip";
        public override string EatNoise { get; } = "Munch Munch, Yum!";
    }
}
