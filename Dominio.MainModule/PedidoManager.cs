using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SqlServer;
using Dominio.Core.Entities;

namespace Dominio.MainModule
{
    public class PedidoManager
    {
        PedidoDAO sol = new PedidoDAO();
        public IEnumerable<Pedido> ListaPedidos()
        {
            return sol.PedidoListar();
        }
        public string AgregarPedido(Pedido reg)
        {
            return sol.PedidoAgregar(reg);
        }
    }
}
