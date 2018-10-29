using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Candy : Inventory
    {
        public override string ItemType { get; set; } = "Candy";
        public override string EatNoise { get; } = "Crunch Crunch, Yum!";
    }
}
