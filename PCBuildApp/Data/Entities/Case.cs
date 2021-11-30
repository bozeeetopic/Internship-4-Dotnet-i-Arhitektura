using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Case : Component
    {
        internal protected Enums.Material Material;
        public override string ToString() => $"{Name}\t{Material}\t:\t{Weight}kg {Price}kn";
    }
}
