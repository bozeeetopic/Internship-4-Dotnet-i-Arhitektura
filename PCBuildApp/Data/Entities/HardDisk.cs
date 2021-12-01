using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class HardDisk : Component
    {
        internal protected int TBAmount;
        internal protected Enums.HardDiskType HardDiskType;
        public override string ToString() => $"{Name}\t{HardDiskType}\t{TBAmount}TB\t-\t{Weight}kg\t{Price}kn";
    }
}
