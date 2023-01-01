
using System.Data.SqlClient;

namespace DataAcces
{
    public class ConnectionDB
    {
        protected SqlConnection GetSqlConnection()
        {
            SqlConnection con = new SqlConnection
            {
                ConnectionString = "Server=(local);Database=Pedidos;Integrated Security=True"
            };
            return con;
        }
    }
}
