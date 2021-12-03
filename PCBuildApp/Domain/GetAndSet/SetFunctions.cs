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
        public static void PullDiscountCodesFromData()
        {
            RunningAppStorage.UnusedDiscountCodes = Data.Seed.CheatCodes;
        }
        public static void AddUser(string name, string surname, string adress, int distance)
        {
            RunningAppStorage.CurrentUser.Populate(name, surname, adress, distance); 
        }
        public static int AddProcessor(int userChoice, List<Data.Entities.Processor> processors)
        {
            if(RunningAppStorage.Computer.Processor==null)
            {
                RunningAppStorage.Computer.Processor = processors[userChoice];
                return 8;
            }
            RunningAppStorage.Computer.Processor = processors[userChoice];
            return 0;
        }
        public static int AddRAM(int userChoice, List<Data.Entities.RAM> rams, int ramAmount)
        {
            if (RunningAppStorage.Computer.RAM == null)
            {
                RunningAppStorage.Computer.RAMAmount = ramAmount;
                RunningAppStorage.Computer.RAM = rams[userChoice];
                return 4;
            }
            RunningAppStorage.Computer.RAMAmount = ramAmount;
            RunningAppStorage.Computer.RAM = rams[userChoice];
            return 0;
        }
        public static int AddHardDisk(int userChoice, List<Data.Entities.HardDisk> hardDiscs)
        {
            if (RunningAppStorage.Computer.HardDisk == null)
            {
                RunningAppStorage.Computer.HardDisk = hardDiscs[userChoice];
                return 2;
            }
            RunningAppStorage.Computer.HardDisk = hardDiscs[userChoice];
            return 0;
        }
        public static int AddCase(int userChoice, List<Data.Entities.Case> cases)
        {
            if (RunningAppStorage.Computer.ComputerCase == null)
            {
                RunningAppStorage.Computer.ComputerCase = cases[userChoice];
                return 1;
            }
            RunningAppStorage.Computer.ComputerCase = cases[userChoice];
            return 0;
        }
        public static void PutOrderIntoList(int travelPrice)
        {
            var order = new Data.Entities.Order
            {
                Computer = RunningAppStorage.Computer,
                TransportPrice = travelPrice
            };
            RunningAppStorage.Computer = new();
            if (RunningAppStorage.Bill == null)
            {
                RunningAppStorage.Bill = new();
                if (RunningAppStorage.Bill.Orders == null)
                {
                    RunningAppStorage.Bill.Orders = new();
                }
            }
            RunningAppStorage.Bill.Orders.Add(order);
        }
        public static void AddBill()
        {
            if (RunningAppStorage.BillsOfUser.ContainsKey(RunningAppStorage.CurrentUser))
            {
                RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].BillsList.Add(RunningAppStorage.Bill);
                RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].DiscountAmount += RunningAppStorage.Bill.AmountSpentCountingDiscounts();
            }
            else
            {
                RunningAppStorage.BillsOfUser.Add(RunningAppStorage.CurrentUser, new Data.Entities.Bills());
                RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].BillsList = new();
                RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].BillsList.Add(RunningAppStorage.Bill);
                RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].DiscountAmount += RunningAppStorage.Bill.AmountSpentCountingDiscounts();
            }
            RunningAppStorage.Bill = new();
            RunningAppStorage.Bill.Orders = new();
        }
        public static void SetDiscounts((bool VIP,bool amount,bool code) discounts)
        {
            RunningAppStorage.Bill.Discounts = discounts;
        }
    }
}
