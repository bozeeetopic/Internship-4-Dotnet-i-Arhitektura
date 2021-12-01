using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Domain.GetAndSet
{
    public class SetFunctions
    {
        public static void AddUser(string name, string surname, string adress, int distance)
        {
            Data.Seed.CurrentUser.Populate(name, surname, adress, distance);
        }
        public static int AddProcessor(int userChoice, List<Data.Entities.Processor> processors)
        {
            if(Seed.Computer.Processor==null)
            {
                Seed.Computer.Processor = processors[userChoice];
                return 8;
            }
            Seed.Computer.Processor = processors[userChoice];
            return 0;
        }
        public static int AddRAM(int userChoice, List<Data.Entities.RAM> rams, int ramAmount)
        {
            if (Seed.Computer.RAM == null)
            {
                Seed.Computer.RAMAmount = ramAmount;
                Seed.Computer.RAM = rams[userChoice];
                return 4;
            }
            Seed.Computer.RAMAmount = ramAmount;
            Seed.Computer.RAM = rams[userChoice];
            return 0;
        }
        public static int AddHardDisk(int userChoice, List<Data.Entities.HardDisk> hardDiscs)
        {
            if (Seed.Computer.HardDisk == null)
            {
                Seed.Computer.HardDisk = hardDiscs[userChoice];
                return 2;
            }
            Seed.Computer.HardDisk = hardDiscs[userChoice];
            return 0;
        }
        public static int AddCase(int userChoice, List<Data.Entities.Case> cases)
        {
            if (Seed.Computer.ComputerCase == null)
            {
                Seed.Computer.ComputerCase = cases[userChoice];
                return 1;
            }
            Seed.Computer.ComputerCase = cases[userChoice];
            return 0;
        }
        public static void PutOrderIntoList(int travelPrice)
        {
            var order = new Data.Entities.Order
            {
                Computer = Data.Seed.Computer,
                TransportPrice = travelPrice
            };
            Data.Seed.Computer = new();
            Data.Seed.Orders.Add(order);
        }
        public static void AddBill()
        {
            var bill = new Data.Entities.Bill()
            {
                Orders = Data.Seed.Orders,
                PricePercentage = Data.Seed.Discount.percentage,
                PriceReduction = Data.Seed.Discount.amount
            };
            if (Data.Seed.BillsOfUser.ContainsKey(Data.Seed.CurrentUser))
            {
                Data.Seed.BillsOfUser[Data.Seed.CurrentUser].BillsList.Add(bill);
                Data.Seed.BillsOfUser[Data.Seed.CurrentUser].DiscountAmount += bill.AmountSpent();
            }
            else
            {
                Data.Seed.BillsOfUser.Add(Data.Seed.CurrentUser, new Data.Entities.Bills());
                Data.Seed.BillsOfUser[Data.Seed.CurrentUser].BillsList.Add(bill);
                Data.Seed.BillsOfUser[Data.Seed.CurrentUser].DiscountAmount += bill.AmountSpent();
            }
            Data.Seed.Discount = (0, 0);
            Data.Seed.Orders = new();
        }
    }
}
