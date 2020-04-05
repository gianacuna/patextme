using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patext.me.data.Entities
{
    public class User
    {
        public Guid UserID { get; set; }
        public String Login { get; set; }
        public String PasswordHash { get; set; }
        public String SaltKey { get; set; }
        public Int16 AccessLevel { get; set; }
        public String Email { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
