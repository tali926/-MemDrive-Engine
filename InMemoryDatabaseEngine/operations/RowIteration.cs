using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public abstract class RowIteration
    {
        protected Table table;
        public RowIteration(Table table)
        {
            this.table = table;
        }
        protected abstract void IterateRows();
        protected abstract List<Row> GetRows();

        public List<Row> Execute()
        {
            IterateRows();
            return GetRows();
        }
    }
}