using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sistema.modelo.datos
{
    class AdministradorDeConexion
    {

        static SqlConnection conexion;
        static public SqlConnection getConexion()
        {
            conexion = new SqlConnection("Data Source=(local);Initial Catalog=mascotas;Integrated Security=True");
            return conexion;
        }  
    }
}
