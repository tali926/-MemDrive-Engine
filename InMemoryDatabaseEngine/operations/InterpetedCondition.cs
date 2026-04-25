using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Memory_DataBase
{

    public class InterpretedCondition : ICondition
    {
        private ICondition InnerCondition;
        public InterpretedCondition(string conditionString)
        {
            InnerCondition = ParseCondition(conditionString);
        }
        // Evaluate פשוט מפנה ל-InnerCondition
        public bool Evaluate(Row row)
        {
            return InnerCondition.Evaluate(row);
        }
        // ------------------- Parser פנימי -------------------
        private ICondition ParseCondition(string input)
        {
            // נפריד על AND בלבד לדוגמה
            string[] parts = input.Split(new string[] { " and ", " AND " }, StringSplitOptions.RemoveEmptyEntries);
            CompositeCondition composite = new CompositeCondition(LogicalOperator.AND);
            foreach (var part in parts)
            {
                string op = null;
                if (part.Contains(">")) op = ">";
                else if (part.Contains("<")) op = "<";
                else if (part.Contains("=")) op = "=";
                else throw new Exception("Operator not recognized");

                var tokens = part.Split(new string[] { op }, StringSplitOptions.None);
                var column = tokens[0].Trim();
                var valueStr = tokens[1].Trim();

                // המרה ל-int אם אפשר, אחרת נשאר מחרוזת
                object value = int.TryParse(valueStr, out int num) ? (object)num : valueStr;
                composite.Add(new SimpleCondition(column, op, value));
            }
            return composite;
        }
    }
}

