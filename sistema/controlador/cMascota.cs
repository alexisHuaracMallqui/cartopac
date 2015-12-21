using sistema.modelo.entidades;
using sistema.modelo.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema.controlador
{
    class cMascota
    {

        public Boolean insertarRegistro(mascotas oMascota)
        {
            DAOMascota oDao = new DAOMascota();
            return oDao.insertarRegistro(oMascota);
        }

        public List<mascotas> obtenerDatosEnList()
        {
            DAOMascota oCDCliente = new DAOMascota();
            return oCDCliente.obtenerDatosEnList();
        }
    }
}
