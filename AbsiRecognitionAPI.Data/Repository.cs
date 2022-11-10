
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace AbsiRecognitionAPI.Data
{
    public class Repository
    {
        public IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
}
