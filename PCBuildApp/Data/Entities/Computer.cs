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

        public List<Component> Components()
        {
            var list = new List<Component>() { HardDisk, Processor, ComputerCase };
            for(var i = 0; i < RAMAmount; i++)
            {
                list.Add(RAM);
            }
            return list;
        }
        public double ComputerWeight()
        {
            return (RAM.Weight * RAMAmount + HardDisk.Weight + Processor.Weight + ComputerCase.Weight);
        }
        public int ComponentsPrice()
        {
            return (RAM.Price * RAMAmount + HardDisk.Price + Processor.Price + ComputerCase.Price);
        }
        public int AssemblyPrice()
        {
            return (3 + RAMAmount) * 25;
        }
        public override string ToString() => $"Procesor:\t{Processor}\nRAM:\t\t{RAM} x{RAMAmount}\nHard disk:\t{HardDisk}\nKučište:\t{ComputerCase}\n";
    }
}
