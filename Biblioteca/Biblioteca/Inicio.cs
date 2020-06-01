using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Inicio : Form
    {

        Lectores lectr = new Lectores();
        Editoriales ed = new Editoriales();
        Libros lb = new Libros();
        Autores au = new Autores();
        Prestamos pr = new Prestamos();
       

        public Inicio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            Conexion cn = new Conexion();
            cn.ObtenerConexion();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 10;
            toolTip1.ReshowDelay = 500;
            toolTip1.SetToolTip(this.btnautor, "Agregar Autor");
            toolTip1.SetToolTip(this.btn_lector, "Registrar Lector");
            toolTip1.SetToolTip(this.btn_libros, "Agregar Libro");
            toolTip1.SetToolTip(this.btn_prestamo, "Nuevo Prestamo");
            toolTip1.SetToolTip(this.agregar_editorial, "Registrar Editorial");


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_lector_Click(object sender, EventArgs e)
        {
            lectr.Show();
            this.Close();
           // ini.Close();
        }

        private void label1_DpiChangedAfterParent(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_libros_Click(object sender, EventArgs e)
        {
             lb.Show();
            this.Close();

            // ini.Close();

        }

        private void agregar_editorial_Click(object sender, EventArgs e)
        {
            ed.Show();
            this.Close();

            //ini.Close();

        }

        private void btn_prestamo_Click(object sender, EventArgs e)
        {
           pr.Show();
            this.Close();

            // ini.Close();

        }

        private void btneditorial_Click(object sender, EventArgs e)
        {
            au.Show();
            this.Close();

            // ini.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
                
        }
    }
}
