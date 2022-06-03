using DataAcces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return PedidoDAO.GetInstance().CodPedido();
        }

        public bool registrarpedido(Pedido pedido, DataTable listacarrito)
        {
            try
            {
                return PedidoDAO.GetInstance().registrarpedido(pedido, listacarrito);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
