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
        public int VipPriceReduction { get; set; }
        public int PricePercentageDiscount { get; set; }
        public bool ExtraPartsDiscount { get; set; }
        public List<Component> ExtraComponents()
        {
            var OrdersCounter = new Dictionary<Component, int>();
            var ExtraComponents = new List<Component>();
            foreach (var order in Orders)
            {
                foreach (var component in order.Computer.Components())
                {
                    if (OrdersCounter.ContainsKey(component))
                    {
                        OrdersCounter[component]++;
                    }
                    else
                    {
                        OrdersCounter.Add(component, 1);
                    }
                }
            }
            foreach (var component in OrdersCounter)
            {
                if (component.Value >= 3)
                {
                    var numberOfExtraComponents = (component.Value - component.Value % 3) / 3;
                    while (numberOfExtraComponents > 0)
                    {
                        ExtraComponents.Add(component.Key);
                        numberOfExtraComponents--;
                    }
                }
            }
            return ExtraComponents;
        }
        public static double TotalPriceOfExtraComponents(List<Component> ExtraComponents)
        {
            var counter = 0;
            foreach (var component in ExtraComponents)
            {
                counter += component.Price;
            }
            return counter;
        }
        public double BillAmount()
        {
            var counter = 0.0;
            foreach (var order in Orders)
            {
                counter += order.TotalOrderPrice();
            }
            return counter;
        }
        public double AmountSpentCountingDiscounts()
        {
            var counter = BillAmount();
            if (ExtraPartsDiscount)
            {
                counter -= TotalPriceOfExtraComponents(ExtraComponents());
            }
            counter *= (100 - PricePercentageDiscount);
            counter -= VipPriceReduction;
            return counter;
        }
        public string ToString(bool discount)
        {
            var stringToReturn = "";
            var i = 1;
            foreach (var order in Orders)
            {
                stringToReturn += $"{i}. {order}\n\n";
                i++;
            }
            if (discount)
            {
                stringToReturn += "Gratis komponente:\n";
                foreach (var component in ExtraComponents())
                {
                    stringToReturn +=$"\t{component}\n";
                }
                stringToReturn += $"\n\tUkupna cijena besplatnih komponenata: \t\t\t\t{TotalPriceOfExtraComponents(ExtraComponents())}kn";
                stringToReturn += $"\n\nPopust u kunama: \t\t\t\t\t\t\t\t-{TotalPriceOfExtraComponents(ExtraComponents()) + VipPriceReduction}kn";
                stringToReturn += $"\nPopust u postotku: \t\t\t\t\t\t\t\t-{PricePercentageDiscount}%";
                var totalPrice = (int)((BillAmount() - TotalPriceOfExtraComponents(ExtraComponents())) / 100 * (100 - PricePercentageDiscount)) - VipPriceReduction;
                stringToReturn += $"\n\nUkupno za platiti: \t\t\t\t\t\t\t\t{totalPrice}kn\n\n";
                return stringToReturn;
            }
            else
            {
                stringToReturn += $"\n\nPopust u kunama: \t\t\t\t\t\t\t\t-{VipPriceReduction}kn";
                stringToReturn += $"\nPopust u postotku: \t\t\t\t\t\t\t\t-{PricePercentageDiscount}%";
                var totalPrice = (int)(BillAmount() / 100 * (100 - PricePercentageDiscount)) - VipPriceReduction;
                stringToReturn += $"\n\nUkupno za platiti: \t\t\t\t\t\t\t\t{totalPrice}kn\n\n";
                return stringToReturn;
            }
        }
    }
}
