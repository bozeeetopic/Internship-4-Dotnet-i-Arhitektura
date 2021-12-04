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
        public (bool, bool, bool) Discounts { get; set; }
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
        public static double AmountFromExtraComponents(List<Component> ExtraComponents)
        {
            var counter = 0;
            foreach (var component in ExtraComponents)
            {
                counter += component.Price;
            }
            Console.WriteLine(counter);
            Console.ReadLine();
            return counter;
        }
        public double AmountSpent()
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
            var counter = AmountSpent();
            counter *= (100 - PricePercentage);
            if (Discounts.Item2)
            {
                counter -= AmountFromExtraComponents(ExtraComponents());
            }
            counter -= PriceReduction;
            return counter;
        }
        public string ToString(bool discount)
        {
            var stringToReturn = "";
            foreach (var order in Orders)
            {
                stringToReturn += order.ToString() + "\n\n";
            }
            if (discount)
            {
                stringToReturn += "Extra komponente:\n";
                foreach (var component in ExtraComponents())
                {
                    stringToReturn += component.ToString() + "\n";
                }
                stringToReturn += $"Ukupna cijena besplatnih komponenata: \t\t\t\t{AmountFromExtraComponents(ExtraComponents())}kn";
                stringToReturn += $"\n\nPopust u kunama: \t\t{AmountFromExtraComponents(ExtraComponents()) + PriceReduction}kn";
                stringToReturn += $"\nPopust u postotku: \t\t{PricePercentage}%";
                var totalPrice = (int)((AmountSpent() - AmountFromExtraComponents(ExtraComponents())) / 100 * (100 - PricePercentage)) - PriceReduction;
                stringToReturn += $"\n\nUkupno za platiti: \t\t\t\t\t{totalPrice}kn\n\n";
                return stringToReturn;
            }
            else
            {
                stringToReturn += $"\n\nPopust u kunama: \t\t{PriceReduction}kn";
                stringToReturn += $"\nPopust u postotku: \t\t{PricePercentage}%";
                var totalPrice = (int)(AmountSpent() / 100 * (100 - PricePercentage)) - PriceReduction;
                stringToReturn += $"\n\nUkupno za platiti: \t\t\t\t\t{totalPrice}kn\n\n";
                return stringToReturn;
            }
        }
    }
}
