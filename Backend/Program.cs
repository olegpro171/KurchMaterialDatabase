using Backend.Core;
using Backend.Domain;
using Backend.Managers;
using System.Collections.Generic;

namespace Backend
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var database = new DatabaseCore();
            var isotopeManager = new IsotopeManager(database);

            database.ConnectionData = new ConnectionData("localhost", "postgres", "1", "postgres");
            //isotopeManager.Open(connectionData);

            //isotopeManager.CreateTable();

            //isotopeManager.Create(new Isotope("ISO1"));
            //isotopeManager.Create(new Isotope("ISO2"));
            //isotopeManager.Create(new Isotope("ISO3"));
            //isotopeManager.Create(new Isotope("ISO4"));

            //var test = isotopeManager.Get(5);


            //Console.WriteLine(test.ToString());

            //for (int i = 0; i < testList.Lenght; i++)
            //{
            //    Console.WriteLine($"id = {testList.IDs[i]}; value = {testList.Values[i]}");
            //} 

            var testList = isotopeManager.List();
            foreach (var item in testList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            var Replace = new Isotope("NEW ISO");

            isotopeManager.Update(34, Replace);

            testList = isotopeManager.filter("h");
            foreach (var item in testList)
            {
                Console.WriteLine(item.ToString());
            }
            //isotopeManager.Delete(3);
            //testList = isotopeManager.List();
            //Console.WriteLine("\n\n\n");
            //testList.ForEach(i => Console.Write("{0}\t", i));
            //isotopeManager.Dispose();
        }
    }
}