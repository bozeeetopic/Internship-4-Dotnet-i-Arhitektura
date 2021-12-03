using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order
    {
        public Computer Computer { get; set; }
        public int TransportPrice { get; set; }
        public override string ToString()
        {
            var stringToReturn = "PC:\n";
            stringToReturn += Computer.ToString();
            stringToReturn += $"\nCijena sastavljanja: {Computer.AssemblyPrice()}  kn";
            stringToReturn += $"\nCijena transporta: {TransportPrice}  kn";
            stringToReturn += $"\nUkupna cijena: {TransportPrice + Computer.AssemblyPrice() + Computer.ComponentsPrice()}  kn";
            return stringToReturn;
        }
        public double TotalOrderPrice()
        {
            return TransportPrice + Computer.AssemblyPrice() + Computer.ComponentsPrice();
        }
    }
}
