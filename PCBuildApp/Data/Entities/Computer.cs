using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Computer
    {
        protected internal RAM RAM;
        protected internal int RAMAmount;
        protected internal HardDisk HardDisk;
        protected internal Processor Processor;
        protected internal Case Case;
    }
}
