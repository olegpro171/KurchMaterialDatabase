using Backend.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Managers
{
    public abstract class BaseRelationManager<T> : BaseObjectManager<T>
    {
        public string RelTableName_1 { get; set; }
        public string RelTableName_2 { get; set; }

        public BaseRelationManager(DatabaseCore databaseCore, string tableName, string relTableName_1, string relTableName_2)
            : base(databaseCore, tableName)
        {
            RelTableName_1 = relTableName_1;
            RelTableName_2 = relTableName_2;
        }

        public abstract void Validate(T obj);

        public override void Create(T obj)
        {
            Validate(obj);
            base.Create(obj);
        }

        
    }
}
