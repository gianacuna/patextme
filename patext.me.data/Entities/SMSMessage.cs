using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patext.me.data.Entities
{
    public class SMSMessage
    {
        public Guid SMSMessageID { get; set; }
        public Guid ClientID { get; set; }
        public String Message { get; set; }
        public Boolean IsSuccess { get; set; }
        public DateTime CreateDate { get; set; }

    }
}
