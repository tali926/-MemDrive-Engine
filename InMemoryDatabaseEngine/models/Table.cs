using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace In_Memory_DataBase
{
    public class Table
    {
        public string name { get; private set; }
        private Schema schema;
        private List<Row> rows { get; set; }
        public List<Row> Rows => rows; // Expose rows as a read-only property... כשמישהו רוצה לקרוא את השורות, הוא יכול לקרוא את זה אבל לא לשנות את זה
        public Schema Schema
        {
            get { return schema; }
        }
        public Table(string name, Schema schema)
        {
            this.name = name;
            this.schema = schema;
            this.rows = new List<Row>();
        }
        public void AddRow(Row row)
        {
            rows.Add(row);
        }
        public Table Clone(string newTableName)
        {
            Table clonedTable = new Table(newTableName, this.schema);

            foreach (var row in this.Rows)
            {
                Row newRow = row.Clone();
                clonedTable.AddRow(newRow);
            }
            return clonedTable;
        }
    }
}
