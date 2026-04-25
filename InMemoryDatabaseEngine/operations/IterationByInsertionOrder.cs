using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{


    public class IterationByInsertionOrder : RowIteration
    {
        private List<Row> tempResult;
        public IterationByInsertionOrder(Table table) : base(table)
        {
        }
        protected override void IterateRows()
        {
            tempResult = table.Rows.ToList();
        }
        protected override List<Row> GetRows()
        {
            return tempResult;
        }
    }
}
