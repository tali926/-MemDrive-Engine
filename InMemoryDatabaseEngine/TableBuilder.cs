using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class TableBuilder
    {
        private Table table;
        public TableBuilder(string name, Schema schema)
        {
            this.table = new Table(name, schema);
        }
        public TableBuilder AddColumn(string columnName, Column.DataType dataType)
        {
            this.table.Schema.Columns.Add(new Column(columnName, dataType));
            return this;
        }
        public Table Build()
        {
            return this.table;
        }
    }
}

