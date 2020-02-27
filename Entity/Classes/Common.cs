using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Common
    {
        public enum Role
        {
            Admin,
            Seller,
            Customer,
            Guest
        }
        public enum Status
        {
            New,
            NotOpened,
            SmallDefects,
            MediumDefects,
            BigDefects
        }
    }
}
