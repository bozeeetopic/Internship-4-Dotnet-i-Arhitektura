using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class RunningAppStorage
    {
        internal static Dictionary<Data.Entities.User, Data.Entities.Bills> BillsOfUser = new();
        internal static Data.Entities.User CurrentUser = new();
        internal static Data.Entities.Computer Computer = new();
        public static Data.Entities.Bill Bill = new() { Orders = new() };
        internal static Dictionary<string, int> UnusedDiscountCodes = new();
    }
}
