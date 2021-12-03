using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class RunningAppStorage
    {
        internal static (int amount, int percentage) Discount = (0, 0);
        internal static Dictionary<Data.Entities.User, Data.Entities.Bills> BillsOfUser;
        internal static Data.Entities.User CurrentUser;
        internal static Data.Entities.Computer Computer;
        internal static List<Data.Entities.Order> Orders;
        internal static Data.Entities.Bill Bill;
        internal static Dictionary<string, int> UnusedDiscountCodes;
    }
}
