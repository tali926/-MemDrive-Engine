using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class RowDelete : IOperation
    {
        private ICondition condition;
        private List<Row> tempResult;
        private string tableName;
        private DataBase db;

        public RowDelete(string tableName, ICondition condition)
        {
            this.condition = condition;
            this.tableName = tableName;
            this.db = DataBase.Instance();
        }
        public void Validation()
        {
            if (condition == null) throw new Exception("send something!");
            if (db.GetTable(tableName) == null) throw new Exception("table does not exist!");
        }
        public List<Row> Execution()
        {
            Validation();
            var table = db.GetTable(tableName);
            tempResult = table.Rows.Where(row => condition.Evaluate(row)).ToList();
            table.Rows.RemoveAll(row => condition.Evaluate(row));
            return GetResult();
        }
        public List<Row> GetResult()
        {
            if (tempResult == null)
            {
                return new List<Row>();
            }
            return tempResult;
        }
    }
}



