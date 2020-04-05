using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patext.me.data.Entities
{
    public class Subscriber
    {
        public Guid SubscriberID { get; set; }
        public String Phone { get; set; }
        public String PhoneCountryCode { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String AccessToken { get; set; }
        public Int16 AccessGrantMethod { get; set; }
        public DateTime? AccessGrantDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
