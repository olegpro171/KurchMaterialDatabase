using Backend.Core;
using Backend.Domain;
using Backend.Variables;
using Backend.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Backend.Interfaces;

namespace Backend.Managers
{
    public class IsotopeInFuelManager : BaseRelationManager<IsotopeInFuel>, IIsotopeInFuelManager
    {

        public IsotopeInFuelManager(IDatabaseCore databaseCore)
            : base(databaseCore, TableNames.IsotopeInFuel, TableNames.Isotope, TableNames.Fuel) { }

        public override void Validate(IsotopeInFuel obj)
        {
            ValidateCorrectID(obj);
            ValidateUnique(obj);
        }

        private void ValidateUnique(IsotopeInFuel obj)
        {
            string query = $"SELECT * FROM {TableNames.IsotopeInFuel}";
            dbCore.OpenConnection();
            dbCore.ExecuteSQL(query);
            dbCore.CloseConnection();

            var responceTable = dbCore.ResponceTable;

            foreach (DataRow row in responceTable.Rows)
            {
                if (row.Field<int>("id_1") == obj.ID_1 && row.Field<int>("id_2") == obj.ID_2)
                {
                    throw new DuplicateRelationException($"Relation already exists. id = {row.Field<int>("id")}");
                }
            }
        }

        private void ValidateCorrectID(IsotopeInFuel obj)
        {
            string query1 = $"SELECT * FROM {RelTableName_1} WHERE id = {obj.ID_1}";
            string query2 = $"SELECT * FROM {RelTableName_2} WHERE id = {obj.ID_2}";

            dbCore.OpenConnection();
            dbCore.ExecuteSQL(query1);
            var responceTable1 = dbCore.ResponceTable;
            dbCore.ExecuteSQL(query2);
            var responceTable2 = dbCore.ResponceTable;
            dbCore.CloseConnection();


            if (responceTable1.Rows.Count == 0)
            {
                throw new RecordNotFoundException($"Record with id = {obj.ID_1} not present in table \"{RelTableName_1}\"");
            }

            if (responceTable2.Rows.Count == 0)
            {
                throw new RecordNotFoundException($"Record with id = {obj.ID_2} not present in table \"{RelTableName_2}\"");
            }
        }

        public override Queryset<IsotopeInFuel> Filter<F>(string colName, F value)
        {
            throw new InvalidOperationException();
        }
    }
}
