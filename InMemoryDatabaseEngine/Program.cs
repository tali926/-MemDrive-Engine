using In_Memory_DataBase;
using System;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            DbClient db = new DbClient();
            //יצירת טבלה
           // var result = db.CreateTable(
           //     "Users",
           //     new List<(string name, Column.DataType type)>
           //     {
           //   ("Id", Column.DataType.Int),
           //   ("Name", Column.DataType.String),
           //   ("Age", Column.DataType.Int)
           //     }
           // );
           // Console.WriteLine("Table created successfully!");

           // // הכנסה לטבלה 
           // db.Insert(
           //     "Users",
           //     new Row(new Dictionary<string, object>
           //     {
           //            {"Id", 1},
           //            {"Name", "Diana"},
           //            {"Age", 20}
           //     })
           // );
           // Console.WriteLine("Row inserted successfully!");

           // db.Insert("Users",
           //     new Row(new Dictionary<string, object>
           //     {
           //            {"Id", 2},
           //            {"Name", "Bob"},
           //            {"Age", 25}
           //     })
           // );
           // db.Insert("Users",
           //    new Row(new Dictionary<string, object>
           //    {
           //            {"Id", 4},
           //            {"Name", "Bob"},
           //            {"Age", 45}
           //    })
           //);
           // Console.WriteLine("Row inserted successfully!");
           // db.Insert("Users",
           //    new Row(new Dictionary<string, object>
           //    {
           //            {"Id", 5},
           //            {"Name", "Bob"},
           //            {"Age", 21}
           //    })
           //);
           // Console.WriteLine("Row inserted successfully!");

           // //מעבר  באיטרציות
           // var rows = db.Iterate("Users", "Name");
           // foreach (var row in rows)
           // {
           //     Console.WriteLine(row.GetValue("Name"));
           // }
           // Console.WriteLine("Press any key to exit...");
           // Console.ReadKey();
           // var otherRows = db.Iterate("Users");
           // foreach (var row in otherRows)
           // {
           //     Console.WriteLine($"Id: {row.GetValue("Id")}, Name: {row.GetValue("Name")}, Age: {row.GetValue("Age")}");
           //     // }
           //     // //run this in the end so basic table doesn't get deleted and we can see the results of the other operations

           //     //מחיקת טבלה
           //     Console.WriteLine("Enter table name to remove:");
           // string tableName = Console.ReadLine();
           // try
           // {
           //     db.RemoveTable(tableName);
           //     Console.WriteLine("Table removed successfully.");
           // }
           // catch (Exception ex)
           // {
           //     Console.WriteLine(ex.Message);
           // }
           // Console.ReadLine();

           // var otherResult = db.CreateTable(
           //    "UsersCopy",
           //     new List<(string name, Column.DataType type)>
           //    {
           //   ("Id", Column.DataType.Int),
           //  ("Name", Column.DataType.String),
           //   ("Age", Column.DataType.Int)
           //    }
           // );
           // try
           // {
           //     string source = "Users";      // הטבלה הקיימת
           //     string newName = "UsersCopy2"; // השם החדש
           //     var rows2 = db.CloneTable("Users", "UsersCopy2");
           //     Console.WriteLine($"Table '{source}' was copied to '{newName}' successfully!");
           //     Console.WriteLine($"Number of rows copied: {rows2.Count}");
           //     foreach (var row in rows2)
           //     {
           //         foreach (var kvp in row.values)
           //         {
           //             Console.Write($"{kvp.Key}: {kvp.Value}, ");
           //         }
           //         Console.WriteLine();
           //     }
           // }
           // catch (Exception ex)
           // {
           //     Console.WriteLine("Error: " + ex.Message);
           // }

           // Console.ReadLine();
           // db.CreateTable(
           //     "People",
           //     new List<(string name, Column.DataType type)>
           //     {
           //         ("Id", Column.DataType.Int),
           //         ("Name", Column.DataType.String),
           //         ("LastName", Column.DataType.String)
           //     }
           // );
           // db.Insert(
           //     "People",
           //     new Row(new Dictionary<string, object>
           //     {
           //         {"Id", 1},
           //         {"Name", "Alice"},
           //         {"LastName", "Smith"}
           //     })
           // );
           // Console.WriteLine(" person inserted succesfully");

           // // qurey
           // ICondition cond = new InterpretedCondition("Name=Bob and LastName=Johnson");
           // var rows = db.Query("People", cond);

           // Console.WriteLine("Query Results:");
           // foreach (var row in rows)
           // {
           //     Console.WriteLine($"Id: {row.GetValue("Id")}, Name: {row.GetValue("Name")}, LastName: {row.GetValue("LastName")}");
           // }
           // ICondition cond2 = new InterpretedCondition("LastName= Smith");

           // //מחיקת שורה
           // db.Delete("People", cond2);
           // var rowsAfterDelete = db.Iterate("People", "LastName");
           // Console.WriteLine("\nRows after delete:");
           // foreach (var row in rowsAfterDelete)
           // {
           //     Console.WriteLine(
           //         $"Id: {row.GetValue("Id")}, " +
           //         $"Name: {row.GetValue("Name")}, " +
           //         $"LastName: {row.GetValue("LastName")}"
           //     );
           // }
           // Console.WriteLine("\nPress any key to exit...");
           // Console.ReadKey();

            //( עדכון טבלה (לפי תנאי
            ICondition complexCond = new InterpretedCondition("Name=Bob and LastName=Johnson");
            db.UpdateRow("People", "LastName", "Smith", complexCond);
            Console.WriteLine("\nUpdate finished using InterpretedCondition.");

            //העתקת טבלה 
            db.CloneTable("Users", "new_users");
        }
    }
}


