using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Computer
    {
        public RAM RAM { get; set; }
        public int RAMAmount { get; set; }
        public HardDisk HardDisk { get; set; }
        public Processor Processor { get; set; }
        public Case ComputerCase { get; set; }

        public double ComputerWeight()
        {
            return (RAM.Weight * RAMAmount + HardDisk.Weight + Processor.Weight + ComputerCase.Weight);
        }
        public int AssemblyPrice()
        {
            return (RAM.Price * RAMAmount + HardDisk.Price + Processor.Price + ComputerCase.Price);
        }
        public override string ToString() => $"Procesor:\t{Processor}\nRAM:\t{RAM}x{RAMAmount}\nHard disk:\t{HardDisk}\nKučište:\t{ComputerCase}";
    }
}
