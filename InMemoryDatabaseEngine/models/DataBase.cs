using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public class DataBase
    {
        private string name { get; set; }
        public Dictionary<string, Table> tables;
        private DataBase()
        {
            tables = new Dictionary<string, Table>();
        }
        private DataBase(string name)
        {
            this.name = name;
            tables = new Dictionary<string, Table>();
        }
        private static DataBase instance;
        public static DataBase Instance(string name = "My DB")
        {
            if (instance == null)
            {
                instance = new DataBase(name);
            }
            return instance;
        }
        public Table GetTable(string name)
        {
            if (tables.ContainsKey(name))
            {
                return tables[name];
            }
            else
            {
                return null;
            }
        }
    }
}
