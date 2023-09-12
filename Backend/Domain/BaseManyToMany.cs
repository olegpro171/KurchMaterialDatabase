using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public abstract class BaseManyToMany
    {
        protected int id_1;
        protected int id_2;

        public int ID_1 { get { return id_1; } }
        public int ID_2 { get { return id_2; } }


        public BaseManyToMany(int id_1, int id_2)
        {
            this.id_1 = id_1;
            this.id_2 = id_2;
        }   
    }
}
