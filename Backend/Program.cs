using Backend.Core;
using Backend.Domain;
using Backend.Managers;
using Backend.Variables;
using System.Collections.Generic;

namespace Backend
{
    internal class Program
    {
        private static ConnectionData connectionData = new ConnectionData("localhost", "postgres", "1", "postgres");
        private static DatabaseCore dbCore = new DatabaseCore(connectionData);
        private static IsotopeManager IsotopeManager = new IsotopeManager(dbCore);
        private static FuelManager FuelManager = new FuelManager(dbCore);
        private static IsotopeInFuelManager IsotopeInFuelManager = new IsotopeInFuelManager(dbCore);

        private static readonly List<string> IsotopeNames =
            new List<string> { "U34", "U35", "U36", "U38", "Pu38", "Pu39", "Pu40", "Pu41", "Pu42" };


        private static void DropAllTables()
        {            
            List<string> tables = new List<string>();
            tables.Add(TableNames.Fuel);
            tables.Add(TableNames.IsotopeInFuel);
            tables.Add(TableNames.Isotope);

            Console.WriteLine("Подключение к БД");
            dbCore.OpenConnection();
            foreach (var tableName in tables) 
            {
                var sql = $"DROP TABLE {tableName}";
                Console.Write(sql + "...");
                try
                {
                    dbCore.ExecuteSQL(sql);
                    Console.WriteLine("OK");
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("42P01:"))
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    else
                        throw;
                }
            }
            dbCore.CloseConnection();
            Console.WriteLine("Подключение закрыто");
        }

        private static void ResetIsotopes()
        {
            var sql = $"DROP TABLE {TableNames.Isotope}";
            Console.WriteLine("Подключение к БД");
            dbCore.OpenConnection();
            Console.Write(sql + "...");
            try
            {
                dbCore.ExecuteSQL(sql);
                Console.WriteLine("OK");
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("42P01:"))
                {
                    Console.WriteLine(ex.Message);
                }
                else
                    throw;
            }
            dbCore.CloseConnection();
            Console.WriteLine("Подключение закрыто");

            Console.Write("IsotopeManager.CreateTable()");
            IsotopeManager.CreateTable();
            Console.WriteLine(" -> OK");

            foreach (var isotopeName in IsotopeNames)
            {
                var isotopeObject = new Isotope(isotopeName);
                Console.Write($"IsotopeManager.Create({isotopeName})");
                IsotopeManager.Create(isotopeObject);
                Console.WriteLine(" -> OK");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Material database Backend v1");
            var actionsPrompt =
                "Выберите действие:\n" +
                "\t1. Сброс таблицы изотопов и заполнение тестовым набором\n" +
                "\t2. Сброс всех таблиц\n" +
                "\t3. Закрыть программу\n" +
                "\t\"help\" - показать команды\n";
            Console.WriteLine(actionsPrompt);

            while (true)
            {
                try
                {
                    Console.Write(">>> ");
                    var choice = Console.ReadLine();
                    if (choice == null) { continue; }

                    if (choice.ToLower() == "help")
                    {
                        Console.WriteLine(actionsPrompt); continue;
                    }

                    var intChoice = int.Parse(choice);

                    if (connectionData == null)
                    {
                        connectionData = new ConnectionData("localhost", "postgres", "1", "postgres");
                        Console.WriteLine("Установлены стандартные данные для подключения.");
                    }

                    switch (intChoice)
                    {
                        case 1:
                            ResetIsotopes();
                            continue;
                        case 2:
                            DropAllTables();
                            continue;
                        case 3:
                            return;
                    }
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}