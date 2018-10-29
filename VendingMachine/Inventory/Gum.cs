using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Gum : Inventory
    {
        public override string ItemType { get; set; } = "Gum";
        public override string EatNoise { get; } = "Chew Chew, Yum!";
    }
}
