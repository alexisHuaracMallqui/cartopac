using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using sistema.modelo.entidades;
using System.Windows.Forms;

namespace sistema.modelo.datos
{
    class DAOMascota
    {
        SqlConnection oSqlConnection;
        SqlDataReader oSqlDataReader;

        public Boolean insertarRegistro(mascotas oMascota)
        {
            try
            {
                oSqlConnection = AdministradorDeConexion.getConexion();
                oSqlConnection.Open();
                string sentencia = "INSERT INTO datos_Mascota(nombre_Duenio,nombre_Mascota,tipo_Mascota,peso,raza,edad) values('" +
                            oMascota.NombreDuenio + "','" +
                            oMascota.NombreMascota + "','" +
                            oMascota.TipoMascota + "',"+oMascota.Peso+",'"+oMascota.Raza+"','"+oMascota.Edad+"')";
                SqlCommand oSqlCommand = new SqlCommand(sentencia, oSqlConnection);
                oSqlCommand.ExecuteNonQuery();
                oSqlConnection.Close();
                return true;
            }
            catch (System.Exception e)
            {
                oSqlConnection.Close();
                MessageBox.Show("Error ...!!!" + e.Message);
                return false;
            }
        }


        public List<mascotas> obtenerDatosEnList()
        {
            List<mascotas> oListMascotas = new List<mascotas>();
            try
            {
                oSqlConnection = AdministradorDeConexion.getConexion();
                oSqlConnection.Open();
                String sentencia = "SELECT * FROM datos_Mascota";
                SqlCommand oSqlCommand = new SqlCommand(sentencia, oSqlConnection);
                oSqlDataReader = oSqlCommand.ExecuteReader();
                mascotas oMascota;
                while (oSqlDataReader.Read())
                {
                    oMascota = new mascotas();
                    oMascota.Id_Mascota=((int)oSqlDataReader["id_Mascota"]);
                    oMascota.NombreDuenio=((String)oSqlDataReader["nombre_Duenio"]);
                    oMascota.NombreMascota = ((String)oSqlDataReader["nombre_Mascota"]);
                    oMascota.TipoMascota = ((String)oSqlDataReader["tipo_Mascota"]);
                    oMascota.Peso= ((int)oSqlDataReader["peso"]);
                    oMascota.Raza = ((String)oSqlDataReader["raza"]);
                    oMascota.Edad = ((int)oSqlDataReader["edad"]);
                    oListMascotas.Add(oMascota);
                }
                oSqlDataReader.Close();
                oSqlConnection.Close();
                return oListMascotas;
            }
            catch (System.Exception e)
            {	//oSqlDataReader.Close();
                oSqlConnection.Close();
                MessageBox.Show("Error ...!!!" + e.Message);
                return null;
            }
        }
    }
}
