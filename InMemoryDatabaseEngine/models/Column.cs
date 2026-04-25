using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class Column
    {
        public enum DataType
        {
            String, Int, Bool
        }
        public string name { get; private set; }
        public DataType dataType { get; private set; }
        public Column(string name, DataType dataType)
        {
            this.name = name;
            this.dataType = dataType;
        }
    }
}
