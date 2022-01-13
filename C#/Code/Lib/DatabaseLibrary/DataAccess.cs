using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary{
    public abstract class DataAccess {
        //^^ allows classes to override methods inside
        /*^^ helps prevent bad code practices like directly 
        using this method when know you code inherit it
        in other classes
        */
    //      public string LoadConnectionString(string name){
    //     Console.WriteLine("Load Connection Here");
    //     return "Connecting...";
    // }
    //^^ NOT OVERRIDABLE

    public virtual string LoadConnectionString(string name){
        Console.WriteLine("Load Connection Here");
        return "Connecting...";
    }
    /*^^ THIS IS OVERRIDABLE .. if not overrided than 
    it will say this by default
    */

    public abstract void LoadData(string sql);

    public abstract void SaveData(string sql);

    //^^ making this abstract to use in a inteface way

    }
}