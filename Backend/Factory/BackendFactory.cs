using Backend.Core;
using Backend.Interfaces;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Factory
{
    public static class BackendFactory
    {
        public static IDatabaseCore GetDatabaseCore()
        {
            return new DatabaseCore();
        }

        public static IDatabaseCore GetDatabaseCore(ConnectionData connectionData)
        {
            return new DatabaseCore(connectionData);
        }

        public static IIsotopeManager GetIsotopeManager(IDatabaseCore core)
        {
            return new IsotopeManager(core);
        }

        public static IFuelManager GetFuelManager(IDatabaseCore core)
        {
            return new FuelManager(core);
        }

        public static IIsotopeInFuelManager GetIsotopeInFuelManager(IDatabaseCore core)
        {
            return new IsotopeInFuelManager(core);
        }
    }
}
