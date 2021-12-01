using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Enums
{
    public enum ComponentsChoice
    {
        Processor = 1,
        RAM = 2,
        HardDisc = 3,
        Case = 4,
        Done = 5
    }
    public enum MainMenuChoice
    {
        LogIn = 1,
        Exit = 2
    }
    public enum MainAppChoice
    {
        AddOrder = 1,
        ListOrders = 2,
        LogOut = 3
    }
    public enum OrderChoice
    {
        Order = 1,
        Discount = 2,
        Bill = 3,
        Exit = 4
    }
    public enum ShipmentChoice
    {
        Self = 1,
        Delivery = 2
    }
    public enum DiscountChoice
    {
        VIP = 1,
        Amount = 2,
        Code = 3,
        Back = 4
    }
}
