using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core
{
    public class ConnectionData
    {
        public string host;
        public string database;
        public string username;
        public string password;

        public ConnectionData(string host, string username, string password, string database)
        {
            this.host = host;
            this.username = username;
            this.password = password;
            this.database = database;
        }

        public override string ToString()
        {
            return $"Host={host};Username={username};Password={password};Database={database}";
        }
    }
}
