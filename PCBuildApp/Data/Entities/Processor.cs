﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Processor : Component
    {
        internal protected Enums.ProcessorType ProcessorType;
        internal protected Manufacturer Manufacturer;
        public override string ToString() => $"{Name}\t{ProcessorType}Core\t{Manufacturer.ManufacturerName}\t:\t{Weight}kg {Price}kn";
    }
}
