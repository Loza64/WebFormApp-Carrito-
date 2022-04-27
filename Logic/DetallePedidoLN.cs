using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DetallePedidoLN
    {
        private static DetallePedidoLN detallePedidoLN = null;
        private DetallePedidoLN() { }
        public static DetallePedidoLN GetInstance()
        {
            if(detallePedidoLN == null)
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
