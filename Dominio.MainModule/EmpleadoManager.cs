using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Data.SqlServer;
using Dominio.Core.Entities;

namespace Dominio.MainModule
{
    public class EmpleadoManager
    {
        EmpleadoDAO emp = new EmpleadoDAO();
        public IEnumerable<Empleado> ListaEmpleados()
        {
            return emp.EmpleadosListar();
        }
    }
}
