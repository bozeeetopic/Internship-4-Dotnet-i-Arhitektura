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
        public static (Data.Entities.User , List<Data.Entities.Bill>) GetUserBills()
        {
            if (RunningAppStorage.BillsOfUser.Count == 0)
            {
                return (null, null);
            }

            try
            {
                if (!RunningAppStorage.BillsOfUser.ContainsKey(RunningAppStorage.CurrentUser))
                {
                    return (null, null);
                }
                else
                {
                    if (RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].BillsList is null)
                    {
                        return (null, null);
                    }
                    return (RunningAppStorage.CurrentUser, RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].BillsList);
                }
            }
            catch
            {
                return (null, null);
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
            if(RunningAppStorage.Bill.Orders is null)
            {
                return false;
            }
            return true;
        }
        public static (bool,bool,bool) GetDiscounts()
        {
            return RunningAppStorage.Bill.Discounts;
        }
        public static bool AmountSpentIsEnough()
        {
            if (RunningAppStorage.BillsOfUser.ContainsKey(RunningAppStorage.CurrentUser))
            {
                if(RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].DiscountAmount >= 1000)
                {
                    RunningAppStorage.Bill.PriceReduction += 100;
                    RunningAppStorage.BillsOfUser[RunningAppStorage.CurrentUser].DiscountAmount = 0;
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsCode(string code)
        {
            if (RunningAppStorage.UnusedDiscountCodes.ContainsKey(code))
            {
                RunningAppStorage.Bill.PricePercentage = RunningAppStorage.UnusedDiscountCodes[code];
                RunningAppStorage.UnusedDiscountCodes.Remove(code);
                return true;
            }
            return false;
        }
    }
}
