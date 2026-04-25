using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class QueryOperation : IOperation
    {
        private ICondition condition;
        private List<Row> tempResult;
        private string tableName;
        private DataBase db;
        public QueryOperation( string tableName,ICondition condition)
        {
            this.db = DataBase.Instance();
            this.condition = condition;
            this.tableName = tableName;
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
            return GetResult();
        }
        public List<Row> GetResult()
        {
            if (tempResult==null||tempResult.Count==0)
            {
                throw new Exception("no result!");
            }
            return tempResult;
        }
    }
}
