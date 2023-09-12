using Backend.Core;
using Backend.Domain;
using Backend.Exceptions;
using System.Data;
using System.Reflection;
using System.Text;

namespace Backend.Managers
{
    public abstract class BaseObjectManager<T>
    {
        protected readonly DatabaseCore dbCore;
        protected readonly string tableName;


        public BaseObjectManager(DatabaseCore databaseCore, string tableName)
        {
            this.dbCore = databaseCore;
            this.tableName = tableName;
        }

        public static T MapDataRowToObject(DataTable dataTable, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataTable.Rows.Count)
            {
                throw new ArgumentException("Invalid rowIndex");
            }

            DataRow row = dataTable.Rows[rowIndex];

            return MapDataRowToObject(row);

        }

        public static T MapDataRowToObject(DataRow row)
        {
            T obj = Activator.CreateInstance<T>();

            // Get the properties of the class T
            PropertyInfo[] properties = typeof(T).GetProperties();

            int propertiesMapped = 0;
            int propertiesTotal = properties.Length;

            foreach (PropertyInfo property in properties)
            {
                string columnName = property.Name;
                if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                {
                    object value = row[columnName];
                    property.SetValue(obj, value);
                    propertiesMapped++;
                }
            }
            if (propertiesMapped != propertiesTotal)
            {
                throw new ObjectMappingException($"Could not map data from table \"{row.Table.TableName}\" to object of type \"{typeof(T).FullName}\"");
            }

            return obj;
        }

        private int FindRowIndexById(DataTable dataTable, int id)
        {
            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                DataRow row = dataTable.Rows[rowIndex];
                if (row["id"] != DBNull.Value && Convert.ToInt32(row["id"]) == id)
                {
                    return rowIndex;
                }
            }

            throw new RecordNotFoundException($"Row with id = {id} not present in table {this.tableName}");
        }


        public virtual Queryset<T> Get(int id)
        {
            string query = $"SELECT * FROM {this.tableName} WHERE id = {id}";
            dbCore.OpenConnection();
            dbCore.ExecuteSQL(query);
            dbCore.CloseConnection();

            var responceTable = dbCore.ResponceTable;
            responceTable.TableName = this.tableName;

            DataRow row;
            try
            {
                row = responceTable.Rows[0];
            }
            catch (IndexOutOfRangeException)
            {
                throw new RecordNotFoundException($"Record with id = {id} not present in table \"{this.tableName}\"");
            }

            var resultQueryset = new Queryset<T>();
            resultQueryset.Data.Add(new ObjectWrapper<T>(row.Field<int>("id"), MapDataRowToObject(row)));
            return resultQueryset;
        }

        public virtual Queryset<T> List()
        {
            string query = $"SELECT * FROM {this.tableName}";
            dbCore.OpenConnection();
            dbCore.ExecuteSQL(query);
            dbCore.CloseConnection();

            var responceTable = dbCore.ResponceTable;
            responceTable.TableName = this.tableName;

            var resultQueryset = new Queryset<T>();

            foreach (DataRow row in responceTable.Rows)
            {
                resultQueryset.Data.Add(new ObjectWrapper<T>(row.Field<int>("id"), MapDataRowToObject(row)));
            }
            return resultQueryset;
        }


        public virtual void Delete(int id)
        {
            string query = $"DELETE FROM {this.tableName} WHERE id = {id}";
            dbCore.OpenConnection();
            var rowsAffected = dbCore.ExecuteSQL(query);
            dbCore.CloseConnection();

            if (!rowsAffected)
            {
                throw new RecordNotFoundException($"Record with id = {id} not present in table \"{this.tableName}\"");
            }
        }

        public virtual void Create(T obj)
        {
            dbCore.OpenConnection();

            PropertyInfo[] properties = typeof(T).GetProperties();

            string tableName = this.tableName;
            string columnNames = string.Join(", ", properties.Select(p => p.Name));
            string parameterNames = string.Join(", ", properties.Select(p => "@" + p.Name));

            string query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

            foreach (PropertyInfo property in properties)
            {
                string paramName = "@" + property.Name;
                object? value = property.GetValue(obj);

                if (value != null)
                {
                    dbCore.AddParamWithValue(paramName, value);
                }
            }

            dbCore.ExecuteSQL(query);

            dbCore.CloseConnection();
        }

        public virtual void Update(int id, T newObject)
        {
            dbCore.OpenConnection();

            StringBuilder query = new StringBuilder("", 256);
            query.AppendFormat("UPDATE {0} SET ", tableName);

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string columnName = property.Name;
                string paramName = "@" + property.Name;
                var paramValue = property.GetValue(newObject);

                if (paramValue != null)
                {
                    dbCore.AddParamWithValue(paramName, paramValue);
                    query.AppendFormat("{0} = {1}, ", columnName, paramName);
                }
            }
            // Removing last ", "
            query.Remove(query.Length - 2, 2);

            query.AppendFormat(" WHERE id = {0}", id);

            dbCore.ExecuteSQL(query.ToString());

            dbCore.CloseConnection();
        }

        public virtual Queryset<T> Filter<F>(string colName, F value)
        {
            string query;
            switch (value)
            {
                case string strValue:
                    query = $"SELECT * FROM {tableName} WHERE LOWER({colName}) LIKE '%{strValue.ToLower()}%'";
                    break;

                case int intValue:
                    query = $"SELECT * FROM {tableName} WHERE {colName} = {intValue}";
                    break;

                case float floatValue:
                    query = $"SELECT * FROM {tableName} WHERE {colName} = {floatValue}";
                    break;

                case null:
                default:
                    throw new ArgumentException($"Type {typeof(F).FullName} not supported");
            }

            dbCore.OpenConnection();
            dbCore.ExecuteSQL(query);
            dbCore.CloseConnection();

            var responceTable = dbCore.ResponceTable;
            responceTable.TableName = this.tableName;
            var resultQueryset = new Queryset<T>();

            foreach (DataRow row in responceTable.Rows)
            {
                resultQueryset.Data.Add(new ObjectWrapper<T>(row.Field<int>("id"), MapDataRowToObject(row)));
            }

            return resultQueryset;
        }

        protected virtual Queryset<R> Related<R>(string query)
        {
            dbCore.OpenConnection();
            dbCore.ExecuteSQL(query);
            dbCore.CloseConnection();

            var responceTable = dbCore.ResponceTable;
            responceTable.TableName = "Inner join";

            var resultQueryset = new Queryset<R>();

            if (typeof(R) == typeof(Isotope))
            {
                foreach (DataRow row in responceTable.Rows)
                {
                    resultQueryset.Data.Add(
                        new RelatedObjectWrapper<R>(
                            row.Field<int>("id"),
                            (R)(object)IsotopeManager.MapDataRowToObject(row),
                            row.Field<float>("amount")
                            )
                        );
                }
                return resultQueryset;
            }
            if (typeof(R) == typeof(Fuel))
            {
                foreach (DataRow row in responceTable.Rows)
                {
                    resultQueryset.Data.Add(
                        new RelatedObjectWrapper<R>(
                            row.Field<int>("id"),
                            (R)(object)FuelManager.MapDataRowToObject(row),
                            row.Field<float>("amount")
                            )
                        );
                }
                return resultQueryset;
            }
            throw new NotImplementedException();
        }

        private string GetColumnType(Type type)
        {
            if (type == typeof(int))
            {
                return "integer";
            }
            else if (type == typeof(float))
            {
                return "real";
            }
            else if (type == typeof(string))
            {
                return "text";
            }
            else
            {
                throw new NotSupportedException($"Type {type.Name} is not supported.");
            }
        }

        public void CreateTable()
        {
            dbCore.OpenConnection();

            StringBuilder query = new StringBuilder("", 256);
            query.AppendFormat("CREATE TABLE IF NOT EXISTS {0} (id serial PRIMARY KEY, ", tableName);

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                query.AppendFormat("{0} {1}, ", property.Name, GetColumnType(property.PropertyType));
            }

            // Removing last ", " and replacing it with ");"
            query.Remove(query.Length - 2, 2);
            query.Append(");");

            dbCore.ExecuteSQL(query.ToString());

            dbCore.CloseConnection();
        }
    }
}
