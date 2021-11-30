using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Seed
    {
        public static Computer Computer = new();
        public static Processor Processor { get; set; }
        public static RAM RAM { get; set; }
        public static Case Case { get; set; }
        public static HardDisk HardDisk { get; set; }

        private static readonly List<Manufacturer> manufacturers = new()
        {
            new Manufacturer { ManufacturerName = "AMD", Description = "This is bad but cheap" },
            new Manufacturer { ManufacturerName = "Intel", Description = "Very good" }
        };

        public static readonly List<Component> Components = new()
        {
            new RAM { Name = "Kineska kartica", GBAmount = 4, Price = 60, Weight = 0.2 },
            new RAM { Name = "Original iz Njemačke", GBAmount = 8, Price = 200, Weight = 0.2 },

            new HardDisk { Name = "Sanaderov najdraži SSD", HardDiskType = Enums.HardDiskType.SSD, TBAmount = 2, Price = 300, Weight = 0.1 },
            new HardDisk { Name = "Mesićev SSD", HardDiskType = Enums.HardDiskType.SSD, TBAmount = 1, Price = 100, Weight = 0.1 },
            new HardDisk { Name = "Skripto-držać", HardDiskType = Enums.HardDiskType.HDD, TBAmount = 2, Price = 60, Weight = 2 },
            new HardDisk { Name = "Nj", HardDiskType = Enums.HardDiskType.HDD, TBAmount = 1, Price = 20, Weight = 1 },

            new Case { Name = "Teško kučište", Material = Enums.Material.metal, Price = 100, Weight = 1.5 },
            new Case { Name = "Coca-Cola Kučište", Material = Enums.Material.plastika, Price = 20, Weight = 1 },
            new Case { Name = "Rastavljena F1", Material = Enums.Material.karbon, Price = 300, Weight = 0.5 },

            new Processor { Name = "Super Mega Good CPU", ProcessorType = Enums.ProcessorType.Deca, Price = 300, Weight = 0.1, Manufacturer = manufacturers[0] },
            new Processor { Name = "Still good CPU", ProcessorType = Enums.ProcessorType.Octa, Price = 100, Weight = 0.1, Manufacturer = manufacturers[0] },
            new Processor { Name = "DeGud CPU yes", ProcessorType = Enums.ProcessorType.Octa, Price = 500, Weight = 0.1, Manufacturer = manufacturers[1] },
            new Processor { Name = "AMD benchmarker", ProcessorType = Enums.ProcessorType.Quad, Price = 200, Weight = 0.1, Manufacturer = manufacturers[1] }
        };
    }
}
