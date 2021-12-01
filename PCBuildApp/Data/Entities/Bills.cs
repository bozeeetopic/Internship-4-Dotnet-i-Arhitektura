using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Bills
    {
        public List<Bill> BillsList { get; set; }
        public double DiscountAmount { get; set; }
    }
}
