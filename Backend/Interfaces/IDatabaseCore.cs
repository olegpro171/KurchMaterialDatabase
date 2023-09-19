using System.Data;
using Backend.Core;

namespace Backend.Interfaces
{
    public interface IDatabaseCore
    {
        ConnectionData ConnectionData { set; }
        DataTable ResponceTable { get; }
        bool isConnected { get; }
        void OpenConnection();
        void CloseConnection();
        bool ExecuteSQL(string sql);
        public void AddParamWithValue(string name, object value);
        public void ClearParams();
    }
}
