using Backend.Core;
using Backend.Domain;
using Backend.Managers;
using System.Collections.Generic;

namespace Backend
{
    internal class Program
    {
        static void Isotopes(DatabaseCore database)
        {
            
            var isotopeManager = new IsotopeManager(database);

            isotopeManager.CreateTable();

            var testList = isotopeManager.RelatedFuel(1);
        }
        

        public static void IsotopeInFuel(DatabaseCore database)
        {
            var manager = new IsotopeInFuelManager(database);

            manager.CreateTable();

            manager.Create(new Domain.IsotopeInFuel(2, 1, 0.6f));
        }

        public static void fuelTest(DatabaseCore database)
        {
            var manager = new FuelManager(database);

            var list = manager.RelatedIsotopes(1);


            var filteredQueryset = list.Filter("id", 3);
        }

        static void Main(string[] args)
        {
            var database = new DatabaseCore();
            database.ConnectionData = new ConnectionData("localhost", "postgres", "1", "postgres");

            //IsotopeInFuel(database);

            fuelTest(database);
            Isotopes(database);

        }
    }
}