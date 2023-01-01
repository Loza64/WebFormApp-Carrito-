using Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DataAcces
{
    public class DetallePedidoDAO : ConnectionDB
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

        SqlConnection con = null;
        SqlCommand scmd = null;

        public void RegistrarDetallePedido(DetallePedido detallePedido)
        {
            using (con = GetSqlConnection())
            {
                using (scmd = new SqlCommand())
                {
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
                        int upload = scmd.ExecuteNonQuery();
                        if (upload != 0)
                        {
                            long cantidad = ProductoDAO.GetInstance().GetStockProduct(detallePedido.IdProducto) - detallePedido.cantidad;
                            if (cantidad < 0)
                            {
                                ProductoDAO.GetInstance().UpdateStock(0, detallePedido.IdProducto);
                                ProductoDAO.GetInstance().UpdateStateProduct(detallePedido.IdProducto);
                            }
                            else
                            {
                                ProductoDAO.GetInstance().UpdateStock(cantidad, detallePedido.IdProducto);
                            }
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
        }
    }
}
