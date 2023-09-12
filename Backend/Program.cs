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


            var testList = isotopeManager.Filter("id", 2);
            //foreach (var item in testList)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            Console.WriteLine();

            //var Replace = new Isotope("NEW ISO");

            //isotopeManager.Update(3, Replace);

            //testList = isotopeManager.List();
            //foreach (var item in testList)
            //{
            //    Console.WriteLine(item.ToString());
            //}
            //isotopeManager.Delete(3);
            //testList = isotopeManager.List();
            //Console.WriteLine("\n\n\n");
            //testList.ForEach(i => Console.Write("{0}\t", i));
            //isotopeManager.Dispose();
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

        }
    }
}