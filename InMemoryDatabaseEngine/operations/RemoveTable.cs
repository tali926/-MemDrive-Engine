using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    internal class RemoveTable : IOperation
    {
        private DataBase dataBase;
        private string TableName;
        public RemoveTable(string TableNane)
        {
            this.dataBase = DataBase.Instance();
            this.TableName = TableNane;
        }
        public void Validation()
        {
            if (!this.dataBase.tables.ContainsKey(this.TableName))
            {
                throw new Exception("Table does not exist");
            }
        }
        public List<Row> Execution()
        {
            Validation();
            this.dataBase.tables.Remove(this.TableName);
            return GetResult();
        }
        public List<Row> GetResult()
        {
            return new List<Row>();
        }
    }
}
