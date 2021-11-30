using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Domain.GetAndSet
{
    public class GetFunctions
    {
        public static List<Data.Entities.Processor> GetProcessors()
        {
            var processors = new List<Data.Entities.Processor>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.Processor)
                {
                    processors.Add(component as Data.Entities.Processor);
                }
            }
            return processors;
        }
        public static List<Data.Entities.RAM> GetRAMs()
        {
            var rams = new List<Data.Entities.RAM>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.RAM)
                {
                    rams.Add(component as Data.Entities.RAM);
                }
            }
            return rams;
        }
        public static List<Data.Entities.HardDisk> GetHardDiscs()
        {
            var hardDiscs = new List<Data.Entities.HardDisk>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.HardDisk)
                {
                    hardDiscs.Add(component as Data.Entities.HardDisk);
                }
            }
            return hardDiscs;
        }
        public static List<Data.Entities.Case> GetCases()
        {
            var cases = new List<Data.Entities.Case>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.Case)
                {
                    cases.Add(component as Data.Entities.Case);
                }
            }
            return cases;
        }
        public static Data.Entities.Computer GetPC()
        {
            return Data.Seed.Computer;
        }
    }
}
