using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patext.me.data.Entities
{
    public class Client
    {
        public Guid ClientID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Organization { get; set; }
        public Boolean IsEmailVerified { get; set; }
        public Boolean IsPhoneVerified { get; set; }
        public Boolean IsLocked { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
