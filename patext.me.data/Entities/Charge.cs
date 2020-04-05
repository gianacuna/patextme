using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patext.me.data.Entities
{
    public class Charge
    {
        public Guid ChargeID { get; set; }
        public String ChargeCode { get; set; }
        public Guid ClientID { get; set; }
        public Decimal Amount { get; set; }
        public String Status { get; set; }
        public String ReferenceCode { get; set; }
        public String ResponseCode { get; set; }
        public String InvoiceNo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
