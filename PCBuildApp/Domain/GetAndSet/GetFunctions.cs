using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Domain.GetAndSet
{
    public class GetFunctions
    {
        public static List<Data.Entities.Processor> GetProcessors()
        {
            var processors = new List<Data.Entities.Processor>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.Processor)
                {
                    processors.Add(component as Data.Entities.Processor);
                }
            }
            return processors;
        }
        public static List<Data.Entities.RAM> GetRAMs()
        {
            var rams = new List<Data.Entities.RAM>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.RAM)
                {
                    rams.Add(component as Data.Entities.RAM);
                }
            }
            return rams;
        }
        public static List<Data.Entities.HardDisk> GetHardDiscs()
        {
            var hardDiscs = new List<Data.Entities.HardDisk>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.HardDisk)
                {
                    hardDiscs.Add(component as Data.Entities.HardDisk);
                }
            }
            return hardDiscs;
        }
        public static List<Data.Entities.Case> GetCases()
        {
            var cases = new List<Data.Entities.Case>();
            foreach (var component in Data.Seed.Components)
            {
                if (component is Data.Entities.Case)
                {
                    cases.Add(component as Data.Entities.Case);
                }
            }
            return cases;
        }
        public static Data.Entities.Computer GetPC()
        {
            return RunningAppStorage.Computer;
        }
        public static (Data.Entities.User, List<Data.Entities.Bill>) GetUserBills()
        {
            if (RunningAppStorage.BillsOfUser == new Dictionary<Data.Entities.User, Data.Entities.Bills>())
            {
                return (null, null);
            }

            if (!RunningAppStorage.BillsOfUser.ContainsKey(RunningAppStorage.CurrentUser))
            {
                return (null, null);
            }
            else
            {
                return (RunningAppStorage.CurrentUser, RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].BillsList);
            }
        }
        public static int GetDeliveryPrice()
        {
            return (double)RunningAppStorage.Computer.ComputerWeight() switch
            {
                < 3 => (int)(5 * RunningAppStorage.CurrentUser.Distance / 10),
                < 10 => (int)(3 * RunningAppStorage.CurrentUser.Distance / 5),
                _ => 50 + (int)(10 * RunningAppStorage.CurrentUser.Distance / 20),
            };
        }
        public static bool OrdersExist()
        {
            if (RunningAppStorage.Bill.Orders.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static (bool, bool, bool) GetDiscounts()
        {
            var vipDiscount = false;
            var codeDiscount = false;
            if (RunningAppStorage.Bill.VipPriceReduction > 0)
            {
                vipDiscount = true;
            }
            if (RunningAppStorage.Bill.PricePercentageDiscount > 0)
            {
                codeDiscount = true;
            }
            return (vipDiscount, RunningAppStorage.Bill.ExtraPartsDiscount, codeDiscount);
        }
        public static bool AmountSpentIsEnough()
        {
            if (RunningAppStorage.BillsOfUser.ContainsKey(RunningAppStorage.CurrentUser))
            {
                if (RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].DiscountAmount >= 1000)
                {
                    RunningAppStorage.Bill.VipPriceReduction += 100;
                    RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].DiscountAmount = 0;
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsCode(string codeInputedByUser)
        {
            if (RunningAppStorage.UnusedDiscountCodes.ContainsKey(codeInputedByUser))
            {
                RunningAppStorage.Bill.PricePercentageDiscount = RunningAppStorage.UnusedDiscountCodes[codeInputedByUser];
                RunningAppStorage.UnusedDiscountCodes.Remove(codeInputedByUser);
                return true;
            }
            return false;
        }
        public static bool ThereAreThreeSameComponentsInBill()
        {
            if (RunningAppStorage.Bill.ExtraComponents().Count == 0)
            {
                return false;
            }
            return true;
        }
        public static Data.Entities.Bill GetBill()
        {
            return RunningAppStorage.Bill;
        }
    }
}
