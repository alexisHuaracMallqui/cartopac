
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sistema.modelo.entidades;
using sistema.controlador;

namespace sistema.vista
{
    public partial class registro : Form
    {
        public registro()
        {
            InitializeComponent();
          //  mostrarData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            mascotas oMascota = new mascotas();
            cMascota oc= new cMascota();

            oMascota.NombreDuenio=txtDuenio.Text;
            oMascota.NombreMascota = txtMascota.Text;
            oMascota.TipoMascota = txtTipo.Text;
            oMascota.Peso = Int32.Parse(txtPeso.Text);
            oMascota.Raza = txtRaza.Text;
            oMascota.Edad = Int32.Parse(txtEdad.Text);
            bool valor = oc.insertarRegistro(oMascota);
           dataGridView1.DataSource = null;
            //mostrarData();
       
          
            if(valor){
            MessageBox.Show("Transacción Exitosa");
            }
            else{
            MessageBox.Show("No se pudo grabar");
            }



        }

        private void mostrarData()
        {
            mascotas oMascota = new mascotas();
            cMascota oc = new cMascota();
            List<mascotas> oLstVenta = new List<mascotas>();
            oLstVenta = oc.obtenerDatosEnList();
            int rowCount = oLstVenta.Count;
          //  MessageBox.Show("dd"+rowCount);


            for (int i = 0; i < oLstVenta.Count; i++)
            {
                mascotas oMascotas = new mascotas();
               dataGridView1.Rows[i].Cells[0].Value = oLstVenta[i].Id_Mascota;
                dataGridView1.Rows[i].Cells[1].Value = oLstVenta[i].NombreDuenio;
                dataGridView1.Rows[i].Cells[2].Value = oLstVenta[i].NombreMascota;
                dataGridView1.Rows[i].Cells[3].Value = oLstVenta[i].TipoMascota;
                dataGridView1.Rows[i].Cells[4].Value = oLstVenta[i].Peso;
                dataGridView1.Rows[i].Cells[5].Value = oLstVenta[i].Raza;
                dataGridView1.Rows[i].Cells[6].Value = oLstVenta[i].Edad;
               // dataGridView1.RowContextMenuStripChanged
                oLstVenta.Add(oMascota);
            }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDuenio.Text = "";
            txtEdad.Text = "";
            txtMascota.Text = "";
            txtPeso.Text = "";
            txtRaza.Text = "";
            txtTipo.Text = "";
        }

        private void registro_Load(object sender, EventArgs e)
        {
            //mostrarData();
        }
    }
}
