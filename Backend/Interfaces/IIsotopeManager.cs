using Backend.Domain;
using Backend.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IIsotopeManager
    {
        public Queryset<Fuel> RelatedMaterials(int id);
        public Queryset<Isotope> Get(int id);
        public Queryset<Isotope> List();
        public void Delete(int id);
        public void Update(int id, Isotope newObject);
        public Queryset<Isotope> Filter<F>(string colName, F value);
        public void CreateTable();
    }
}
