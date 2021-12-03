﻿using System;
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
            var OrdersCounter = new Dictionary<Component,int>();
            var ExtraComponents = new List<Component>();
            foreach(var order in Orders)
            {
                foreach(var component in order.Computer.Components().Item1)
                {
                    if (OrdersCounter.ContainsKey(component))
                    {
                        if (component is RAM)
                        {
                            OrdersCounter[component] += order.Computer.Components().Item2;
                        }
                        else
                        {
                            OrdersCounter[component]++;
                        }
                    }
                    else
                    {
                        if (component is RAM)
                        {
                            OrdersCounter.Add(component,order.Computer.Components().Item2);
                        }
                        else
                        {
                            OrdersCounter.Add(component, 1);
                        }
                    }
                }
            }
            foreach(var component in OrdersCounter)
            {
                if (component.Value >= 3)
                {
                    var numberOfExtraComponents = (component.Value % 3) / 3;
                    while (numberOfExtraComponents>0)
                    {
                        ExtraComponents.Add(component.Key);
                    }
                }
            }
            return ExtraComponents;
        }
        public static double AmountFromExtraComponents(List<Component> ExtraComponents)
        {
            var counter = 0;
            foreach(var component in ExtraComponents)
            {
                counter += component.Price;
            }
            return counter;
        }
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
        public string ToString(bool discount)
        {
            var stringToReturn = "";
            if (discount)
            {
                foreach(var component in ExtraComponents())
                {
                    stringToReturn += component.ToString() + "\n";
                }
                stringToReturn += $"Ukupna cijena besplatnih komponenata: -{AmountFromExtraComponents(ExtraComponents())}kn";
                stringToReturn += $"\n\nPopust u kunama: -{AmountFromExtraComponents(ExtraComponents())+PriceReduction}kn";
                stringToReturn += $"Popust u postotku: -{PricePercentage}%";
                var totalPrice = ((AmountSpent() - AmountFromExtraComponents(ExtraComponents())) * PricePercentage / 100) - PriceReduction;
                stringToReturn += $"\n\nUkupno za platiti: {totalPrice}";
                return stringToReturn;
            }
            else
            {
                stringToReturn += $"\n\nPopust u kunama: -{PriceReduction}kn";
                stringToReturn += $"Popust u postotku: -{PricePercentage}%";
                var totalPrice = (AmountSpent() * PricePercentage / 100) - PriceReduction;
                stringToReturn += $"\n\nUkupno za platiti: {totalPrice}";
                return stringToReturn;
            }
        }
    }
}
