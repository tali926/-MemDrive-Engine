using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase

{
    public class Row
    {
        public Dictionary<string,object>values {  get; set; }
        public Row()
        {
            values = new Dictionary<string, object>();
        }
        public Row(Dictionary<string, object> values)
        {
            this.values = values;
        }
        public Row Clone()
        {
            Dictionary<string, object> newValues =
                new Dictionary<string, object>(this.values);

            return new Row(newValues);
        }
        public object GetValue(string columnName)
        {
            if (values.ContainsKey(columnName))
            {
                return values[columnName];
            }
            return null;
        }

    }
}
