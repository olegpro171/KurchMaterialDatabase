using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public abstract class BaseM2MRelation
    {
        public int ID_1 { get; set; }
        public int ID_2 { get; set; }

        //public string TableName_1 { get; set; }
        //public string TableName_2 { get; set; }


        public BaseM2MRelation(int id_1, int id_2)
        {
            this.ID_1 = id_1;
            this.ID_2 = id_2;
        }

        public BaseM2MRelation()
        {
            ID_1 = -1; ID_2 = -1;
        }
    }
}
