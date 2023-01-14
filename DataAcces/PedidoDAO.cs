using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAcces
{
    public class PedidoDAO : ConnectionDB
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

        SqlConnection con = null;
        SqlCommand scmd = null;

        public long CodPedido()
        {
            long codpedido = 0;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
                    try
                    {
                        con.Open();
                        scmd.Connection = con;
                        scmd.CommandText = "select max(p.CodPedido) from Pedido p";
                        scmd.CommandType = System.Data.CommandType.Text;
                        if (DBNull.Value.Equals(scmd.ExecuteScalar()))
                        {
                            codpedido = 34512345;
                        }
                        else
                        {
                            codpedido = Convert.ToInt64(scmd.ExecuteScalar());
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    catch (SqlNullValueException ex)
                    {
                        throw ex;
                    }
                    catch (TimeoutException ex)
                    {
                        throw ex;
                    }
                    catch (NullReferenceException ex)
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
                }
            }
            return codpedido;
        }
        public bool NewPedido(Pedido pedido, List<ListadoCarrito> listacarrito)
        {
            bool responce = false;
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
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
                        scmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = pedido.PagoTotal;
                        int upload = scmd.ExecuteNonQuery();
                        if (upload != 0)
                        {
                            foreach (ListadoCarrito carrito in listacarrito)
                            {
                                DetallePedido detalle = new DetallePedido
                                {
                                    CodPedido = pedido.CodPedido,
                                    IdProducto = carrito.IdProducto,
                                    Precio = carrito.Precio,
                                    cantidad = carrito.Cantidad,
                                    SubTotal = carrito.SubTotal,
                                    TotalPagar = carrito.Total
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
                    catch (SqlNullValueException ex)
                    {
                        throw ex;
                    }
                    catch (TimeoutException ex)
                    {
                        throw ex;
                    }
                    catch (NullReferenceException ex)
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
                }
            }
            return responce;
        }
    }
}
