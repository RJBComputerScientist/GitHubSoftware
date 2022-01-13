using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrary{
    public interface IDataAccess{
        string LoadConnectionString(string name);
        void LoadData(string sql);
        void SaveData(string sql);
    }
}