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
    public partial class Autores : Form
    {
        public Autores()
        {
            InitializeComponent();
        }
        Class_Autor autor = new Class_Autor();
        Class_Libros libros = new Class_Libros();
        Class_Prestamo prestamos = new Class_Prestamo();
        int id;
        private void Autores_Load(object sender, EventArgs e)
        {
            autor.consultartodos(dataGridView1);
            generar_clave();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 10;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.btnModificar, "Modificar");
            toolTip1.SetToolTip(this.btnInsertar, "Guardar");
            toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            toolTip1.SetToolTip(this.btnBuscar, "Buscar");

        }
        public void limpiar()
        {
            txtnom_actor.Clear();
        }
        public void generar_clave()
        {
            Random rnd = new Random();
            for (int ctr = 1; ctr <= 20; ctr++)
            {
                id = rnd.Next(1000, 10001);
                if (ctr % 5 == 0) ;
            }
            string ida = Convert.ToString(id);
            txtid.Text = ida;
            txtid.Enabled = false;
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if ( txtnom_actor.Text.Trim() == "" )
            {
                errorProvider1.SetError(txtid, "Campo vacio");
                errorProvider1.SetError(txtnom_actor, "Campo vacio");

            }
            else
            {
                errorProvider1.Clear();
                autor.Id_autor = Convert.ToInt32(txtid.Text.Trim());
                autor.Autor_nombre = txtnom_actor.Text.Trim();


                if (autor.insertar())
                {
                    MessageBox.Show("Usuario guardado exitosamente...");
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
            }
          
            autor.consultartodos(dataGridView1);
            generar_clave();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
            
            autor.Id_autor = Convert.ToInt32(txtid.Text.Trim());
          
                if (autor.eliminarl())
                {

                }
              
               
                if (autor.eliminar())
                {
                    MessageBox.Show("Eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al Eliminar");
                }

         
           
           


            autor.consultartodos(dataGridView1);
            generar_clave();
            limpiar();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnInsertar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() == "" || txtnom_actor.Text.Trim() == "")
            {
                errorProvider1.SetError(txtid, "Campo vacio");
                errorProvider1.SetError(txtnom_actor, "Campo vacio");

            }
            else
            {
                errorProvider1.Clear();
                autor.Id_autor = Convert.ToInt32(txtid.Text.Trim());
                autor.Autor_nombre = txtnom_actor.Text.Trim();
                if (autor.modificar())
                {
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al modificar");
                }
            }
           
            autor.consultartodos(dataGridView1);
            generar_clave();
            limpiar();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnInsertar.Enabled = true;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            autor.Autor_nombre = txtBuscar.Text.Trim();
            autor.consultar(dataGridView1, txtBuscar.Text);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            string dato0, dato1;
            dato0 = dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
            dato1 = dataGridView1.CurrentRow.Cells[1].EditedFormattedValue.ToString();
          
            txtid.Text = dato0;
            txtnom_actor.Text = dato1;
            txtid.Enabled = false;

            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnInsertar.Enabled = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtnom_actor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //permite el ingreso de numeros
                if (char.IsLetter(e.KeyChar) & e.KeyChar > 8)
                {
                    e.Handled = false;
                }
                //permite borrar
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                //permite poner espacios
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                //no permite numeros
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            groupBox2.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            this.Close();
        }
    }
}
