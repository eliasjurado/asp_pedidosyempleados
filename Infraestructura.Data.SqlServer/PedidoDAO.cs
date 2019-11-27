using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entities;
using System.Data.SqlClient;

namespace Infraestructura.Data.SqlServer
{
    public class PedidoDAO
    {
        SqlConnection cn;
        Conexion cnx = new Conexion();

        public IEnumerable<Pedido> PedidoListar()
        {
            cn = cnx.getConexion();
            List<Pedido> temporal = new List<Pedido>();
            SqlCommand cmd = new SqlCommand("select * from tb_pedidos", cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pedido reg = new Pedido
                {
                    idped = dr.GetInt32(0),
                    fechaped = dr.GetDateTime(1),
                    idempleado = dr.GetInt32(2),
                    detped = dr.GetString(3),
                    costoped = dr.GetDecimal(4)
                };
                temporal.Add(reg);
            }
            dr.Close();
            cn.Close();
            return temporal;
        }

        public string PedidoAgregar(Pedido reg)
        {
            cn = cnx.getConexion();
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into tb_pedidos values(@cod,@fec,@idemp,@det,@cost)", cn);
                cmd.Parameters.AddWithValue("@cod", reg.idped);
                cmd.Parameters.AddWithValue("@fec", reg.fechaped);
                cmd.Parameters.AddWithValue("@idemp", reg.idempleado);
                cmd.Parameters.AddWithValue("@det", reg.detped);
                cmd.Parameters.AddWithValue("@cost", reg.costoped);

                int i = cmd.ExecuteNonQuery();
                mensaje = i.ToString() + " registro agregado";
            }
            catch (SqlException e)
            {
                mensaje = e.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }
    }
}
