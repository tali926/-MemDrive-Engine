using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class DbClient
    {
        private DataBase database;
        public DbClient()
        {
            database = DataBase.Instance();
        }
        public List<Row> Insert(string tableName, Row row)
        {
            RowInsert insert = new RowInsert(tableName, row);
            return insert.Execution();
        }
        public List<Row> Delete(string tableName, ICondition condition)
        {
            RowDelete delete = new RowDelete(tableName, condition);
            return delete.Execution();
        }
        public List<Row> Query(string tableName, ICondition condition)
        {
            QueryOperation query = new QueryOperation(tableName, condition);
            return query.Execution();
        }
        public List<Row> Iterate(string tableName, string? columnName = null, ICondition? condition = null)
        {
            if (columnName != null)
            {
                IterationByColumn iteration = new IterationByColumn(database.GetTable(tableName), columnName);
                return iteration.Execute();
            }
            else if (condition != null)
            {
                ConditionIterator iteration = new ConditionIterator(database.GetTable(tableName), condition);
                return iteration.Execute();
            }
            else
            {
                IterationByInsertionOrder iteration = new IterationByInsertionOrder(database.GetTable(tableName));
                return iteration.Execute();
            }
        }
        public List<Row> UpdateRow(string tableName, string columnToUpdate, object newValue, ICondition condition)
        {
            IOperation op = new UpdateRows(tableName, columnToUpdate, newValue, condition);
            return op.Execution();
        }
        public List<Row> CreateTable(string tableName, List<(string, Column.DataType)> columns)
        {
            Schema schema = new Schema();
            TableBuilder builder = new TableBuilder(tableName, schema);
            foreach (var column in columns)
            {
                builder.AddColumn(column.Item1, column.Item2);
            }
            Table table = builder.Build();
            CreateTable createOp = new CreateTable(table);
            return createOp.Execution();
        }
        public List<Row> RemoveTable(string tableName)
        {
            IOperation op = new RemoveTable(tableName);
            return op.Execution();
        }
        public List<Row> CloneTable(string sourceTableName, string newTableName)
        {
            var table = DataBase.Instance().tables[sourceTableName];
            if (table == null)
                throw new Exception("Table not found");

            Table clonedTable = table.Clone(newTableName);
            DataBase.Instance().tables.Add(newTableName, clonedTable);
            return clonedTable.Rows;
        }
    }
}




