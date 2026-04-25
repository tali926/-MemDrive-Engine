using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{
    public enum LogicalOperator
    {
        AND,
        OR
    }
    public class CompositeCondition : ICondition
    {
        private LogicalOperator LogicalOperator { get; set; }
        private List<ICondition> conditions = new List<ICondition>();
        public CompositeCondition(LogicalOperator logicalOperator)
        {
            LogicalOperator = logicalOperator;
        }
        public void Add(ICondition condition)
        {
            conditions.Add(condition);
        }
        public bool Evaluate(Row row)
        {
            if (LogicalOperator == LogicalOperator.OR)
            {
                foreach (var condition in conditions)
                {
                    if (condition.Evaluate(row))
                    {
                        return true;
                    }
                }
                return false;
            }
            else if (LogicalOperator == LogicalOperator.AND)
            {
                foreach (var condition in conditions)
                {
                    if (!condition.Evaluate(row))
                    {
                        return false;
                    }
                }
                return true;
            }
            throw new Exception("Invalid logical operator");
        }
    }
}
