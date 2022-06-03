using DBConnect;
using Entities;
using System;
using System.Data;
using System.Data.SqlClient;

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
                codpedido = 1123124231251;
            }
            finally
            {
                con.Close();
            }
            return codpedido;
        }
        public bool registrarpedido(Pedido pedido, DataTable listacarrito)
        {
            bool responce = false;
            SqlConnection con = Conexion.GetInstance().GetConnection();
            SqlCommand scmd = new SqlCommand();
            try
            {
                con.Open();
                scmd.Connection = con;
                scmd.CommandText = "insert into Pedido(CodPedido,IdUsuario,NombreCliente,TipoPedido,Direccion,FechaEntrega,HoraEntrega,Estado,SubTotal,PagoTotal) values(@Codpedido,@IdUsuario,@NombreCliente,@TipoPedido,@Direccion,@FechaEntrega,@HoraEntrega,@Estado,@SubTotal,@Total)";
                scmd.CommandType = System.Data.CommandType.Text;
                scmd.Parameters.Add("@Codpedido", SqlDbType.BigInt).Value = pedido.CodPedido;
                scmd.Parameters.Add("@IdUsuario", SqlDbType.BigInt).Value = pedido.IdUsuario;
                scmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar).Value = pedido.NombreCliente;
                scmd.Parameters.Add("@TipoPedido", SqlDbType.VarChar).Value = pedido.TipoPedido;
                scmd.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = pedido.Direccion;
                scmd.Parameters.AddWithValue("@FechaEntrega", pedido.FechaEntrega);
                scmd.Parameters.AddWithValue("@HoraEntrega", pedido.HoraEntrega);
                scmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = pedido.Estado;
                scmd.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = pedido.SubTotal;
                scmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = pedido.Total;
                int upload = scmd.ExecuteNonQuery();
                if (upload != 0)
                {
                    foreach (DataRow Row in listacarrito.Rows)
                    {
                        double TotalDePagar = (Convert.ToDouble(Row[6]) * 0.13) + Convert.ToDouble(Row[6]);
                        DetallePedido detalle = new DetallePedido()
                        {
                            CodPedido = pedido.CodPedido,
                            IdProducto = Convert.ToInt64(Row[0]),
                            Precio = Convert.ToDecimal(Row[4]),
                            cantidad = Convert.ToInt32(Row[5]),
                            SubTotal = Convert.ToDecimal(Row[6]),
                            TotalPagar = Math.Round((decimal)TotalDePagar, 2, MidpointRounding.AwayFromZero)
                        };
                        DetallePedidoDAO.GetInstance().RegistrarDetallePedido(detalle);
                    }
                    responce = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (TimeoutException ex)
            {
                throw ex;
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
