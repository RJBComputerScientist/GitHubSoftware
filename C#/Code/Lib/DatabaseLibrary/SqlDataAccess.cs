using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary{
    // public class SqlDataAccess : IDataAccess{
    public class SqlDataAccess : DataAccess{
    // public string LoadConnectionString(string name){
    //     Console.WriteLine("Load Connection Here");
    //     return "Connecting...";
    // }
    //^^Method In Seperate Class .. Interface "IDataAccess"
    // public void LoadData(string sql){
    //     Console.WriteLine("Loading SQL Data");
    // }

    // public void SaveData(string sql){
    //     Console.WriteLine("Saving Data From SQL Database");
    // }
    //^^ previously instantiated in this class


private string? SQLOutput;
    public override string LoadConnectionString(string name){
        this.SQLOutput = base.LoadConnectionString(name);
        //            ^^^ calling base version
        SQLOutput += " (SQL)";
        // '' is char & "" is string
        return SQLOutput;
    }
    //overriding a optional method

    public override void LoadData(string sql){
        //^^ implementing LoadData from abstract base class
        Console.WriteLine("Loading SQL Data");
    }

    public override void SaveData(string sql){
        //^^ implementing SaveData from abstract base class
        Console.WriteLine("Saving Data From SQL Database");
    }

    }
}