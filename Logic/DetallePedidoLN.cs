using DataAcces;
using Entities;
using System;
using System.Data.SqlClient;

namespace Logic
{
    public class DetallePedidoLN
    {
        private static DetallePedidoLN detallePedidoLN = null;
        private DetallePedidoLN() { }
        public static DetallePedidoLN GetInstance()
        {
            if (detallePedidoLN == null)
            {
                detallePedidoLN = new DetallePedidoLN();
            }
            return detallePedidoLN;
        }

        public void RegistrarDetallePedido(DetallePedido detallePedido)
        {
            try
            {
                DetallePedidoDAO.GetInstance().RegistrarDetallePedido(detallePedido);
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
        }

    }
}
