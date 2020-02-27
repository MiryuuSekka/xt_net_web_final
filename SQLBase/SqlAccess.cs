using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLBase
{
    public class SqlAccess
    {
        private string TableName;
        private string ConnectionString;
        private string SqlCommand;

        public SqlAccess(string Table)
        {
            TableName = Table;
        }

        public void Add()
        {

        }

        public void Delete()
        {

        }

        public void Edit()
        {

        }

        public void Get()
        {

        }
    }
}
