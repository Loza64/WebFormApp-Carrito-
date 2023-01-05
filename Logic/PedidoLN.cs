using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Logic
{
    public class PedidoLN
    {
        private static PedidoLN pedidoln = null;
        private PedidoLN() { }
        public static PedidoLN GetInstance()
        {
            if (pedidoln == null)
            {
                pedidoln = new PedidoLN();
            }
            return pedidoln;
        }

        public long CodPedido()
        {
            try
            {
                return PedidoDAO.GetInstance().CodPedido();
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
        }

        public bool NewPedido(Pedido pedido, List<ListadoCarrito> listacarrito)
        {
            try
            {
                return PedidoDAO.GetInstance().NewPedido(pedido, listacarrito);
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
        }
    }
}
