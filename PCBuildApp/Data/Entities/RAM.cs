using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RAM : Component
    {
        protected internal int GBAmount;
        public override string ToString() => $"{Name}\t{GBAmount} GB\t-\t{Weight}kg\t{Price}kn";
    }
}
