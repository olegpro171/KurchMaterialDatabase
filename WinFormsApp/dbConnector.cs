using Backend.Core;
using Backend.Managers;
using WinFormsApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using Backend.Domain;

namespace WinFormsApp
{
    internal static class dbConnector
    {
        private static bool _lastOperationSuccesful;
        public static bool LastOperationSuccesful
        {
            get { return _lastOperationSuccesful; }
        }

        public static ConnectionData ConnectionData
        {
            set
            {
                dbCore.ConnectionData = value;
            }
        }

        private static string _searchString;
        public static string SearchString
        {
            set { _searchString = value; }
        }

        public static DatabaseCore dbCore;
        public static FuelManager FuelManager;
        public static IsotopeManager IsotopeManager;
        public static IsotopeInFuelManager IsotopeInFuelManager;


        public enum Table
        {
            FuelMaterials = 0,
            Isotopes = 1,
        }


        static dbConnector()
        {
            dbCore = new DatabaseCore();

            FuelManager = new FuelManager(dbCore);
            IsotopeManager = new IsotopeManager(dbCore);
            IsotopeInFuelManager = new IsotopeInFuelManager(dbCore);

            _searchString = string.Empty;
        }


        public static void CreateTablesIfNotExist()
        {
            _lastOperationSuccesful = false;
            try
            {
                IsotopeManager.CreateTable();
                FuelManager.CreateTable();
                IsotopeInFuelManager.CreateTable();
                _lastOperationSuccesful = true;
            }
            catch (Npgsql.PostgresException ex)
            {
                if (ex.Message.StartsWith("28P01:"))
                {
                    throw new InvalidConnectionDataException("CD1: Invalid login or username");
                }

                if (ex.Message.StartsWith("3D000:"))
                {
                    throw new InvalidConnectionDataException("CD2: Invalid database name");
                }
            }
            catch (System.Net.Sockets.SocketException)
            {
                throw new InvalidConnectionDataException("CD3: Invalid host");
            }
        }

        public static DataTable GetMainTable(Table table)
        {
            try
            {
                if (table == Table.FuelMaterials)
                {
                    FuelManager.Filter("name", _searchString);
                    _lastOperationSuccesful = true;
                }

                if (table == Table.Isotopes)
                {
                    IsotopeManager.Filter("name", _searchString);
                    _lastOperationSuccesful = true;
                }

                return dbCore.ResponceTable;

                throw new ArgumentException("Invalid argument");
            }
            catch (Npgsql.PostgresException ex)
            {
                if (ex.Message.StartsWith("42P01:"))
                {
                    throw new InvalidOperationException("O01: Required relations abscent", ex);
                }
                else
                {
                    throw;
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new InvalidOperationException("O02: Connection data was not provided", ex);
            }
        }

        public static DataTable GetRelatedIsotopesTable(int fuelId)
        {
            var isotopes = FuelManager.RelatedIsotopes(fuelId);

            var isoTable = new DataTable("Related isotopes");

            isoTable.Columns.Add(new DataColumn("relation_id", typeof(int)));
            isoTable.Columns.Add(new DataColumn("id", typeof(int)));
            isoTable.Columns.Add(new DataColumn("name", typeof(string)));
            isoTable.Columns.Add(new DataColumn("concentration", typeof(float)));

            isoTable.Columns[0].Caption = "Номер изотопа";
            (isoTable.Columns["name"] ?? throw new Exception("Undefined behavior")).Caption = "Название изотопа";
            (isoTable.Columns["concentration"] ?? throw new Exception("Undefined behavior")).Caption = "Содержание";

            foreach (RelatedObjectWrapper<Isotope> iso in isotopes.Data)
            {
                var row = isoTable.NewRow();
                row["relation_id"] = iso.Relation_ID;
                row["id"] = iso.Id;
                row["name"] = iso.Obj.Name;
                row["concentration"] = iso.Concentration;
                isoTable.Rows.Add(row);
            }
            isoTable.Columns[0].ColumnMapping = MappingType.Hidden;

            return isoTable.Copy();
        }
    }
}
