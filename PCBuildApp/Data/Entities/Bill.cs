using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Bill
    {
        public List<Order> Orders { get; set; }
        public int PriceReduction { get; set; }
        public int PricePercentage { get; set; }

        public double AmountSpent()
        {
            var counter = 0;
            foreach(var order in Orders)
            {
                counter += order.TransportPrice + order.Computer.AssemblyPrice();
            }
            counter -= PriceReduction;
            counter *= PricePercentage / 100;
            return counter;
        }
    }
}
