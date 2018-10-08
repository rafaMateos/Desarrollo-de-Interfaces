using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_HolaMundo_WindowsFormsC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string nombre;

            nombre = this.txtNombre.Text;

            //MessageBox.Show("Hola" + " " +  nombre);
            //Equivalente a lo de arriba
            //MessageBox.Show(string.Format("Hola {0}",nombre));
            MessageBox.Show($"Hola {nombre}");
            */

            //Esto estara hecho en visualBasic
            clsPersona oPersona = new clsPersona();
            oPersona.nombre = "Rafa";
            oPersona.apellidos = "Mateos";
            MessageBox.Show($"Soy el objeto {oPersona.nombre} {oPersona.apellidos}");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}


