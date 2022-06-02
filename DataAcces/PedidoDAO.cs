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
    public class PedidoDAO
    {
        private static PedidoDAO pedidoDAO = null;
        private PedidoDAO() { }
        public static PedidoDAO GetInstance()
        {
            if (pedidoDAO == null)
            {
                pedidoDAO = new PedidoDAO();
            }
            return pedidoDAO;
        }

        public long CodPedido()
        {
            long codpedido = 0;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "select max(p.CodPedido) from Pedido p";
                scmd.CommandType = System.Data.CommandType.Text;
                codpedido = Convert.ToInt64(scmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                codpedido = 122342123234;
            }
            finally
            {
                con.Close();
            }
            return codpedido;
        }


        public bool registrarpedido(Pedido pedido)
        {
            bool responce = false;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "RegistrarPedido";
                scmd.CommandType = System.Data.CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@Codpedido", pedido.CodPedido);
                scmd.Parameters.AddWithValue("@IdUsuario", pedido.IdUsuario);
                scmd.Parameters.AddWithValue("@NombreCliente", pedido.NombreCliente);
                scmd.Parameters.AddWithValue("@TipoPedido", pedido.TipoPedido);
                scmd.Parameters.AddWithValue("@Direccion", pedido.Direccion);
                scmd.Parameters.AddWithValue("@FechaEntrega", pedido.FechaEntrega);
                scmd.Parameters.AddWithValue("@HoraEntrega", pedido.HoraEntrega);
                scmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                scmd.Parameters.AddWithValue("@Total", pedido.Total);
                int upload = scmd.ExecuteNonQuery();
                if (upload != 0)
                {
                    responce = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return responce;

        }
    }
}
