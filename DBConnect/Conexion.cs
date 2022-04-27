using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class Conexion
    {
        private static Conexion cn = null;
        private Conexion() { }
        public static Conexion GetInstance()
        {
            if(cn == null)
            {
                cn = new Conexion();
            }
            return cn;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=(local);Database=Pedidos;Integrated Security=True";
            return con;
        }
    }
}
