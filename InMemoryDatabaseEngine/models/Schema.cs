using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class Schema
    {
        private List<Column> columns;
        public List<Column> Columns
        {
            get { return columns; }
        }
        public Schema()
        {
            this.columns = new List<Column>();

        }
    }
}
