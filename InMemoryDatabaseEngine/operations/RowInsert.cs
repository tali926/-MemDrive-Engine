using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class RowInsert : IOperation
    {
        private Row row;
        private DataBase db;
        private string tableName;
        public RowInsert(string tableName, Row row)
        {
            this.row = row;
            this.db = DataBase.Instance();
            this.tableName = tableName;
        }
        public void Validation()
        {
            if (row == null) throw new Exception("Row requires!");
            if (db.GetTable(tableName) == null)
            {
                throw new Exception("table does not exist!");
            }
            var table = db.GetTable(tableName);
            var columns = table.Schema.Columns;

            foreach (var key in row.values.Keys)
            {
                if (!columns.Any(c => c.name == key))
                {
                    throw new Exception($"column {key} does not exist in table {tableName}!");
                }
            }
            foreach (var column in columns)
            {
                if (!row.values.ContainsKey(column.name))
                {
                    throw new Exception($"column {column} is required in table {tableName}!");
                }
                var value = row.values[column.name];
                switch (column.dataType)
                {
                    case Column.DataType.String:
                        if (!(value is string))
                        {
                            throw new Exception($"column {column.name} requires a string value!");
                        }
                        break;
                    case Column.DataType.Int:
                        if (!(value is int))
                        {
                            throw new Exception($"column {column.name} requires an int value!");
                        }
                        break;
                    case Column.DataType.Bool:
                        if (!(value is bool))
                        {
                            throw new Exception($"column {column.name} requires a bool value!");
                        }
                        break;
                }
            }
        }
        public List<Row> Execution()
        {
            Validation();
            var table = db.GetTable(tableName);
            table.Rows.Add(row);
            return GetResult();
        }
        public List<Row> GetResult()
        {
            return new List<Row>() { row };
        }
    }
}
