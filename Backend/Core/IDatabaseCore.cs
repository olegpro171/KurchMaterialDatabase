using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Core
{
    internal interface IDatabaseCore
    {
        ConnectionData ConnectionData { set; }
        void OpenConnection();
        void CloseConnection();
        bool IsConnected();
        bool ExecuteSQL(string sql);
        DataTable ResponceTable { get; }
    }
}
