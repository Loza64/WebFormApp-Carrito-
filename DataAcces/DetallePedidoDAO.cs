using DBConnect;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public  class DetallePedidoDAO
    {
        private static DetallePedidoDAO detalle = null;
        private DetallePedidoDAO() { }
        public static DetallePedidoDAO GetInstance()
        {
            if(detalle == null)
            {
                detalle = new DetallePedidoDAO();
            }
            return detalle;
        }

        public void RegistrarDetallePedido(DetallePedido detallePedido)
        {
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "RegistrarDetallePedido";
                scmd.CommandType = System.Data.CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@codpedido", detallePedido.CodPedido);
                scmd.Parameters.AddWithValue("@idProducto", detallePedido.IdProducto);
                scmd.Parameters.AddWithValue("@cantidad", detallePedido.cantidad);
                scmd.Parameters.AddWithValue("@subtotal", detallePedido.SubTotal);
                scmd.Parameters.AddWithValue("@totalpagar", detallePedido.TotalPagar);
                int upload = scmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                scmd.Parameters.Clear();
            }
        }               
    }
}
