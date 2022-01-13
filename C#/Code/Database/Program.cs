using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLibrary;
namespace DataBase{
    class Program{
        static void Main(string[] args){
// SqlDataAccess da = new SqlDataAccess();
// SqlLiteDataAccess daL = new SqlLiteDataAccess();
// da.LoadConnectionString();
//^^ inheriting from parent "DataAccess" to Child SqlDataAccess
// daL.LoadConnectionString();
//^^ inheriting from parent "DataAccess" to Child SqlLiteDataAccess]

// DataAccess DA = new SqlLiteDataAccess();
// ^^ using DataAccess ^^ making a new SqlLiteDataAccess



            // List<IDataAccess> Database = new List<IDataAccess>(){
            //     new SqlDataAccess(),
            //     new SqlLiteDataAccess()
            // };

            // foreach (var DB in Database){
            //     DB.LoadConnectionString("Test");
            //     DB.LoadData("select * from table");
            //     DB.SaveData("insert into table");
            //     Console.WriteLine();
            // }
            //^^ other way .. less efficient

        List<DataAccess> Database = new List<DataAccess>(){
                new SqlDataAccess(),
                new SqlLiteDataAccess()
            };

            foreach (var DB in Database){
                Console.WriteLine(DB.LoadConnectionString("New"));
                // DB.LoadConnectionString("Test");
                // DB.LoadData("select * from table");
                // DB.SaveData("insert into table");
                Console.WriteLine();
            }
            //other way .. more efficient

            Console.ReadLine();
        }
    }
}