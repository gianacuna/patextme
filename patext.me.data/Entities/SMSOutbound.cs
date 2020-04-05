using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patext.me.data.Entities
{
    class SMSOutbound
    {
        public Guid SMSOutboundID { get; set; }
        public Guid SMSMessageID { get; set; }
        public Guid SubscriberID { get; set; }
        public String Address { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
