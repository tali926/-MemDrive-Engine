using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public interface IOperation
    {
        List<Row> Execution();
        void Validation();
        List<Row> GetResult();
    }
}

