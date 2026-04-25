using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class IterationByColumn : RowIteration
    {
        private List<Row> tempResult;
        private string columnName;
        public IterationByColumn(Table table, string columnName) : base(table)
        {
            this.columnName = columnName;
        }
        protected override void IterateRows()
        {
            tempResult = new List<Row>();
            tempResult = table.Rows.OrderBy(r => (IComparable)r.GetValue(columnName)).ToList();
        }
        protected override List<Row> GetRows()
        {
            return tempResult;
        }
    }
}
