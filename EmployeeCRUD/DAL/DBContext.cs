using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeCRUD.DAL
{
    public class DBContext
    {
        private SqlConnection con;

        // Funtion to get connection string from Web.config
        private void Connection() 
        {
            string constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
               con = new SqlConnection(constring);
        }
        // Return SQL connection whenever needed
        public SqlConnection GetConnection() 
        {
            Connection();
            return con;
        }
    }

}