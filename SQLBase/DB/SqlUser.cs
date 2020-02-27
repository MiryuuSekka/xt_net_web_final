using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBase.DB
{
    internal class SqlUser : SqlAccess
    {
        public SqlUser(string Table) : base(Table)
        {
            Table = "Users";
        }
    }
}
