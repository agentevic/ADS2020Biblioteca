using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Biblioteca
{
    public partial class Libros : Form
    {
        Class_Libros libro = new Class_Libros();
        Conexion cn = new Conexion();
        public Libros()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            txtid.Clear();
            txtTitulo.Clear();
            txtBuscar.Clear();
            txtcopias.Clear();
        }
        private void Libros_Load(object sender, EventArgs e)
        {
            libro.consultartodos(dataGridView1);
            string consulta = "SELECT Cod_Ed,Nombre_Ed  FROM Editoriales";
            string consult = "Select Id_Autor,Nombre_Autor FROM Autores";
            SqlCommand comando = new SqlCommand(consulta, cn.ObtenerConexion());
            SqlCommand cmd = new SqlCommand(consult, cn.ObtenerConexion());


            try
            {
                SqlDataAdapter seleccionar = new SqlDataAdapter();
                seleccionar.SelectCommand = comando;
                DataTable dtDatos = new DataTable();
                seleccionar.Fill(dtDatos);
                BindingSource formulario = new BindingSource();
                formulario.DataSource = dtDatos;
                comboBox1.DataSource = formulario;
                seleccionar.Update(dtDatos);
                comboBox1.DisplayMember = "Nombre_Ed";
                comboBox1.ValueMember = "Cod_Ed";


                SqlDataAdapter seleccionar2 = new SqlDataAdapter();
                seleccionar2.SelectCommand = cmd;
                DataTable dtDatos2 = new DataTable();
                seleccionar2.Fill(dtDatos2);
                BindingSource formulario2 = new BindingSource();
                formulario2.DataSource = dtDatos2;
                comboBox2.DataSource = formulario2;
                seleccionar2.Update(dtDatos2);
                comboBox2.DisplayMember = "Nombre_Autor";
                comboBox2.ValueMember = "Id_Autor";


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


            generar_codigo();
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
        int id;
        public void generar_codigo()
        {
            Random rnd = new Random();
            for (int ctr = 1; ctr <= 20; ctr++)
            {
                id = rnd.Next(1000, 10001);
                if (ctr % 5 == 0) ;
            }
            string ed = Convert.ToString(id);
            txtid.Text = ed;
            txtid.Enabled = false;
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            generar_codigo();
            if (txtid.Text.Trim() == "" || txtTitulo.Text.Trim() == "" || txtcopias.Text.Trim() == "")
            {
                //errorProvider1.SetError(txtid, "Campo vacio");
                errorProvider1.SetError(txtTitulo, "Campo vacio");
                errorProvider1.SetError(txtcopias, "Campo vacio");
                errorProvider1.SetError(comboBox1, "Seleccione una opción");
                errorProvider1.SetError(comboBox2, "Seleccione una opción");
            }
            else
            {
                errorProvider1.Clear();
                string id_lb = txtid.Text;
                int idl = Convert.ToInt32(id_lb);
                string cod = comboBox1.SelectedValue.ToString();
                int cod_ed = Convert.ToInt32(cod);
                libro.Id_Libro = idl;
                libro.Titulo = txtTitulo.Text.Trim();
                libro.Cod_Ed = cod_ed;
                libro.Num_copias = Convert.ToInt32(txtcopias.Text.Trim());
                libro.Id_autor = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                if (libro.insertar() & libro.insertarcp() & libro.insertar_l())
                {
                    MessageBox.Show("Libro guardado exitosamente...");
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                    generar_codigo();
                }
                generar_codigo();
            }
           

           
          
            libro.consultartodos(dataGridView1);
            generar_codigo();
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            libro.Titulo= txtBuscar.Text.Trim();
            libro.consultar(dataGridView1, txtBuscar.Text);
            limpiar();
            generar_codigo();


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string dato0, dato1, dato2, dato3, dato4;
            dato1 = dataGridView1.CurrentRow.Cells[1].EditedFormattedValue.ToString();
            dato2 = dataGridView1.CurrentRow.Cells[2].EditedFormattedValue.ToString();
            dato0 = dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
            dato3 = dataGridView1.CurrentRow.Cells[3].EditedFormattedValue.ToString();
            dato4 = dataGridView1.CurrentRow.Cells[4].EditedFormattedValue.ToString();


            txtid.Text = dato0;
            txtTitulo.Text = dato1;
            txtcopias.Text = dato4;
            //int x = Convert.ToInt16(dato2);

            //comboBox1.= (row.Cells(0).Value);

            txtid.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnInsertar.Enabled = false; 


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string idl = txtid.Text;
            int id_li = Convert.ToInt32(idl);
            libro.Id_Libro = id_li;
            libro.Id_autor = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            if (libro.eliminarcp())
            {

            }
            if (libro.eliminarl())
            { 
            }
            if (libro.eliminar())
            {

                MessageBox.Show("Eliminado exitosamente");
                generar_codigo();
            }
            else
            {
                MessageBox.Show("Error al Eliminar");
            }
            libro.consultartodos(dataGridView1);
           
            limpiar();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnInsertar.Enabled = true;
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() == "" || txtTitulo.Text.Trim() == "" || txtcopias.Text.Trim() == "")
            {
                errorProvider1.SetError(txtid, "Campo vacio");
                errorProvider1.SetError(txtTitulo, "Campo vacio");
                errorProvider1.SetError(txtcopias, "Campo vacio");
            }
            else
            {

                errorProvider1.Clear();
                string idl = txtid.Text;
                int id_li = Convert.ToInt32(idl);
                libro.Id_Libro = id_li;
                string cod = comboBox1.SelectedValue.ToString();
                int cod_ed = Convert.ToInt32(cod);
                libro.Num_copias = Convert.ToInt32(txtcopias.Text.Trim());
                libro.Titulo = txtTitulo.Text.Trim();
                libro.Cod_Ed = cod_ed;
                libro.Id_autor = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                if (libro.modificar() & libro.modificarcp() & libro.modificar_l())
                {
                    MessageBox.Show("Modificado exitosamente");
                    generar_codigo();
                }
                else
                {
                    MessageBox.Show("Error al Modificar");
                }
            }
         
            libro.consultartodos(dataGridView1);
          
            limpiar();
            btnInsertar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcopias_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar) & e.KeyChar > 8)
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            this.Close();
        }
    }
}
