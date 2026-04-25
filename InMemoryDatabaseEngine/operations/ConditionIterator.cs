using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class ConditionIterator : RowIteration
    {
        private ICondition condition;
        private List<Row> tempResult;
        public ConditionIterator(Table table, ICondition condition) : base(table)
        {
            this.condition = condition;
        }
        protected override void IterateRows()
        {
            tempResult = new List<Row>();
            foreach (Row row in table.Rows)
            {
                if (condition.Evaluate(row))
                {
                    tempResult.Add(row);
                }
            }
        }
        protected override List<Row> GetRows()
        {
            return tempResult;
        }
    }
}
