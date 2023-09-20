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
using Backend.Interfaces;
using Backend.Factory;
using static WinFormsApp.dbConnector;


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

        public static IDatabaseCore dbCore;
        public static IFuelManager FuelManager;
        public static IIsotopeManager IsotopeManager;
        public static IIsotopeInFuelManager IsotopeInFuelManager;


        public enum Table
        {
            FuelMaterials = 0,
            Isotopes = 1,
        }


        static dbConnector()
        {
            dbCore = BackendFactory.GetDatabaseCore();

            FuelManager = BackendFactory.GetFuelManager(dbCore);
            IsotopeManager = BackendFactory.GetIsotopeManager(dbCore);
            IsotopeInFuelManager = BackendFactory.GetIsotopeInFuelManager(dbCore);

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

        public static DataTable GetRelatedMaterialsTable(int isotopeID)
        {
            try
            {
                IsotopeManager.RelatedMaterials(isotopeID);
                _lastOperationSuccesful = true;

                var responceTable = dbCore.ResponceTable;

                var col = responceTable.Columns["id"];
                if (col != null) col.ColumnMapping = MappingType.Hidden;

                col = responceTable.Columns["color"];
                if (col != null) col.ColumnMapping = MappingType.Hidden;

                col = responceTable.Columns["description"];
                if (col != null) col.ColumnMapping = MappingType.Hidden;

                col = responceTable.Columns["density"];
                if (col != null) col.ColumnMapping = MappingType.Hidden;

                col = responceTable.Columns["relation_id"];
                if (col != null) col.ColumnMapping = MappingType.Hidden;


                return PrepareTableFromResponceTable(responceTable);
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
              
                return PrepareTableFromResponceTable(dbCore.ResponceTable);
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

        private static DataTable PrepareTableFromResponceTable(DataTable responceTable)
        {
            var colorColumn = responceTable.Columns["color"];
            if (colorColumn != null)
            {
                colorColumn.ColumnMapping = MappingType.Hidden;
            }

            return responceTable;
        }

        public static DataTable GetRelatedIsotopesTable(int fuelId)
        {
            var isotopes = FuelManager.RelatedIsotopes(fuelId);

            var isoTable = new DataTable("Related isotopes");



            isoTable.Columns.Add(new DataColumn("relation_id", typeof(int)));
            isoTable.Columns.Add(new DataColumn("id", typeof(int)));
            isoTable.Columns.Add(new DataColumn("name", typeof(string)));
            isoTable.Columns.Add(new DataColumn("concentration", typeof(float)));


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
            isoTable.Columns[1].ColumnMapping = MappingType.Hidden;


            return isoTable.Copy();
        }
    }
}
