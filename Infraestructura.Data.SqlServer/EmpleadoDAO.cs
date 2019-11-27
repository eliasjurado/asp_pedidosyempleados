using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data.SqlClient;

namespace Infraestructura.Data.SqlServer
{
    public class EmpleadoDAO
    {
        SqlConnection cn;
        Conexion cnx = new Conexion();

        public IEnumerable<Empleado> EmpleadosListar()
        {
            cn = cnx.getConexion();
            List<Empleado> temporal = new List<Empleado>();
            SqlCommand cmd = new SqlCommand("select IdEmpleado, CONCAT( NomEmpleado,' ',ApeEmpleado) as nomempleado from tb_empleados", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Empleado reg = new Empleado
                {
                    idempleado = dr.GetInt32(0),
                    nomempleado = dr.GetString(1)
                };
                temporal.Add(reg);
            }
            dr.Close();
            cn.Close();
            return temporal;
        }
    }
}
