using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class UpdateRows : IOperation
    {
        private DataBase dataBase;
        private string tableName;
        private string columnToUpdate;
        private object newValue;
        private ICondition condition;
        private List<Row> updatedRows;

        public UpdateRows( string tableName, string columnToUpdate, object newValue, ICondition condition)
        {
            this.dataBase = DataBase.Instance();
            this.tableName = tableName;
            this.columnToUpdate = columnToUpdate;
            this.newValue = newValue;
            this.condition = condition;
            this.updatedRows=new List<Row>();
        }
        public void Validation()
        {
            if (!dataBase.tables.ContainsKey(tableName))
                throw new Exception("Table not found");
        }
        public List<Row> Execution()
        {
            Validation();
            var table = dataBase.tables[tableName];
            foreach (var row in table.Rows)
            {
                if ( condition.Evaluate(row))
                {
                    row.values[columnToUpdate] = newValue;
                    updatedRows.Add(row);
                }
            }
            return GetResult();
        }
        public List<Row> GetResult()
        {
            return updatedRows;
        }
    }
}

    

