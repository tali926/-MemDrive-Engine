using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    internal class CreateTable : IOperation
    {
        private DataBase dataBase;
        private Table table;
        public CreateTable(Table table)
        {
            this.table = table;
            this.dataBase = DataBase.Instance();
        }
        public void Validation()
        {
            if (this.dataBase.tables.ContainsKey(this.table.name))
            {
                throw new Exception("Table already exists");
            }
        }
        public List<Row> Execution()
        {
            Validation();
            this.dataBase.tables.Add(this.table.name, this.table);
            return GetResult();
        }
        public List<Row> GetResult()
        {
            return new List<Row>();
        }
    }
}
