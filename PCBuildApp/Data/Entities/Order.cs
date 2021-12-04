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
            stringToReturn += $"\nCijena sastavljanja: \t\t\t\t\t\t\t{Computer.AssemblyPrice()}  kn";
            stringToReturn += $"\nCijena transporta: \t\t\t\t\t\t\t{TransportPrice}  kn";
            stringToReturn += $"\n\nUkupna cijena narudžbe: \t\t\t\t\t\t{TransportPrice + Computer.AssemblyPrice() + Computer.ComponentsPrice()}  kn";
            return stringToReturn;
        }
        public double TotalOrderPrice()
        {
            return TransportPrice + Computer.AssemblyPrice() + Computer.ComponentsPrice();
        }
    }
}
