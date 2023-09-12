using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Backend.Domain;
using Backend.Core;
using Backend.Managers;
using System.Data;

namespace Backend.Managers
{
    public class IsotopeManager : BaseObjectManager<Isotope>
    {
        public IsotopeManager(DatabaseCore databaseCore) : base(databaseCore, Variables.TableNames.Isotope)
        {
            
        }

        public List<ObjectWrapper<Isotope>> filter(string name)
        {
            dbCore.OpenConnection();

            string query = $"SELECT * FROM {tableName} WHERE LOWER(name) LIKE '%{name.ToLower()}%'";
            dbCore.ExecuteSQL(query);

            var responceTable = dbCore.ResponceTable;
            responceTable.TableName = this.tableName;
            var ResultList = new List<ObjectWrapper<Isotope>>();

            foreach (DataRow row in responceTable.Rows)
            {
                ResultList.Add(new ObjectWrapper<Isotope>(row.Field<int>("id"), MapDataRowToObject(row)));
            }

            dbCore.CloseConnection();
            return ResultList;
        }
    }
}
