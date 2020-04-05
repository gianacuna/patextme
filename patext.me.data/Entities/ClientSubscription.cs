using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patext.me.data.Entities
{
    public class ClientSubscription
    {
        public Guid ClientSubscriptionID { get; set; }
        public Guid ClientID { get; set; }
        public Guid SubscriberID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
