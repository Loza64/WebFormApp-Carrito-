using DBConnect;
using Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class DetallePedidoDAO
    {
        private static DetallePedidoDAO detalle = null;
        private DetallePedidoDAO() { }
        public static DetallePedidoDAO GetInstance()
        {
            if (detalle == null)
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
                scmd.CommandText = "insert into DetallePedido(CodPedido,IdProducto,Precio,Cantidad,SubTotal,TotalPagar) values(@codpedido,@idproducto,@precio,@cantidad,@subtotal,@totalpagar)";
                scmd.CommandType = System.Data.CommandType.Text;
                scmd.Parameters.Add("@codpedido", SqlDbType.BigInt).Value = detallePedido.CodPedido;
                scmd.Parameters.Add("@idProducto", SqlDbType.BigInt).Value = detallePedido.IdProducto;
                scmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = detallePedido.Precio;
                scmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = detallePedido.cantidad;
                scmd.Parameters.Add("@subtotal", SqlDbType.Decimal).Value = detallePedido.SubTotal;
                scmd.Parameters.Add("@totalpagar", SqlDbType.Decimal).Value = detallePedido.TotalPagar;
                scmd.ExecuteNonQuery();
            }
            catch (Exception ex)
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
