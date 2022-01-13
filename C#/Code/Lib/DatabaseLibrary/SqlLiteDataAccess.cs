using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary{
    public class SqlLiteDataAccess : DataAccess{
    // public string LoadConnectionString(string name){
    //     Console.WriteLine("Load Connection Here");
    //     return "Connecting...";
    // }
    //^^Method In Seperate Class .. from Interface "IDataAccess"

    // public void LoadData(string sql){
    //     Console.WriteLine("Loading SQL Lite Data");
    // }

    // public void SaveData(string sql){
    //     Console.WriteLine("Saving Data From SQL Lite Database");
    // }

        //^^ previously instantiated in this class

private string? SQLiteOutput;
    public override string LoadConnectionString(string name){
        this.SQLiteOutput = base.LoadConnectionString(name);
        //            ^^^ calling base version
        SQLiteOutput += " (SQLite)";
        // '' is char & "" is string
        return SQLiteOutput;
    }
    //overriding a optional method

    public override void LoadData(string sql){
        //^^ implementing LoadData from abstract base class
        Console.WriteLine("Loading SQL Lite Data");
    }

    public override void SaveData(string sql){
        //^^ implementing SaveData from abstract base class
        Console.WriteLine("Saving Data From SQL Lite Database");
    }

    }
}