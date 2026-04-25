using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class SimpleCondition : ICondition
    {
        private string columnName { get; set; }
        private string operatorType { get; set; }
        private object value { get; set; }
        public SimpleCondition(string columnName, string operatorType, object value)
        {
            this.columnName = columnName;
            this.operatorType = operatorType;
            this.value = value;
        }
        public bool Evaluate(Row row)
        {
            var specificValue = row.values[columnName];
            switch (operatorType)
            {
                case ">":
                    return Convert.ToInt32(specificValue) > Convert.ToInt32(value);
                case "<":
                    return Convert.ToInt32(specificValue) < Convert.ToInt32(value);
                case "=":
                    return specificValue.Equals(value); ;
                default:
                    throw new Exception("invalid data type!");
            }
        }

    }

}