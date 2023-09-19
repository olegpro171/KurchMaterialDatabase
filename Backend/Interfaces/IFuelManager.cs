using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Managers;
using Backend.Domain;

namespace Backend.Interfaces
{
    public interface IFuelManager
    {
        public Queryset<Isotope> RelatedIsotopes(int id);
        public Queryset<Fuel> Get(int id);
        public Queryset<Fuel> List();
        public void Delete(int id);
        public void Update(int id, Fuel newObject);
        public Queryset<Fuel> Filter<F>(string colName, F value);
        public void CreateTable();
    }
}
