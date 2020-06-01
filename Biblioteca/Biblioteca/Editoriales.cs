using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class Editoriales : Form
    {
        Class_Editoriales editorial = new Class_Editoriales();
        Class_Libros libros = new Class_Libros();
        public Editoriales()
        {
            InitializeComponent();
            List<TextBox> tlist = new List<TextBox>();
            List<string> slist = new List<string>();
            tlist.Add(txttel);
            slist.Add("ej.23239834"); 
            SetCueBanner(ref tlist, slist);
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr i, string str);
        void SetCueBanner(ref List<TextBox> TextBox, List<string> CueText)
        {

            for (int x = 0; x < TextBox.Count; x++)
            {
                SendMessage(TextBox[x].Handle, 0x1501, (IntPtr)1, CueText[x]);
            }
        }
        public void limpiar()
        {
            txtnom.Clear();
            txtpais.Clear();
            txttel.Clear();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtnom.Text.Trim() == "" || txtpais.Text.Trim() == "" || txttel.Text.Trim() == "")
            {
                errorProvider1.SetError(txtnom, "Campo vacio");
                errorProvider1.SetError(txtpais, "Campo vacio");
                errorProvider1.SetError(txttel, "Campo vacio");
            }
            else
            {
                errorProvider1.Clear();
                string id_Ed = txtid.Text;
                int cod = Convert.ToInt32(id_Ed);
                editorial.Cod_editorial = cod;
                editorial.Ed_nombre = txtnom.Text.Trim();
                editorial.Ed_pais = txtpais.Text.Trim();
                editorial.Ed_tel = txttel.Text.Trim();
                if (editorial.insertar())
                {
                    MessageBox.Show("Editorial guardada exitosamente...");
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
            }
          
            editorial.consultartodos(dataGridView1);
            generar_codigo();
            limpiar();
         

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string id_Ed = txtid.Text;
            int cod = Convert.ToInt32(id_Ed);
            editorial.Cod_editorial = cod;
            libros.Cod_Ed = cod;
       
            if (editorial.eliminar())
            {
                MessageBox.Show("Eliminado exitosamente");
            }
            else
            {
                MessageBox.Show("Error al Eliminar");
            }
            editorial.consultartodos(dataGridView1);
            generar_codigo();
            limpiar();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtnom.Text.Trim() == "" || txtpais.Text.Trim() == "" || txttel.Text.Trim() == "")
            {
                errorProvider1.SetError(txtnom, "Campo vacio");
                errorProvider1.SetError(txtpais, "Campo vacio");
                errorProvider1.SetError(txttel, "Campo vacio");
            }
            else
            {
                errorProvider1.Clear();
                string id_Ed = txtid.Text;
                int cod = Convert.ToInt32(id_Ed);
                editorial.Cod_editorial = cod;
                editorial.Ed_nombre = txtnom.Text.Trim();
                editorial.Ed_pais = txtpais.Text.Trim();
                editorial.Ed_tel = txttel.Text.Trim();
                if (editorial.modificar())
                {
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al guardar");
                }
            }
                
            editorial.consultartodos(dataGridView1);
            generar_codigo();
            limpiar();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            editorial.Ed_nombre = txtBuscar.Text.Trim();
            editorial.consultar(dataGridView1, txtBuscar.Text);
        }
        int id;
        private void Editoriales_Load(object sender, EventArgs e)
        {
            editorial.consultartodos(dataGridView1);
            generar_codigo();
            limpiar();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            string dato0, dato1, dato2, dato3;
            dato1 = dataGridView1.CurrentRow.Cells[1].EditedFormattedValue.ToString();
            dato2 = dataGridView1.CurrentRow.Cells[2].EditedFormattedValue.ToString();
            dato3 = dataGridView1.CurrentRow.Cells[3].EditedFormattedValue.ToString();
            dato0 = dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
            txtid.Text = dato0;
            txtnom.Text = dato1;
            txtpais.Text = dato2;
            txttel.Text = dato3;
            txtid.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnInsertar.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
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
            if (txttel.Text.Length == 8)
            {
                errorProvider1.SetError(txttel, "Verifique cantidad de numeros");
            }
            else
            {
                errorProvider1.Clear();
            }
        
        }

        private void txtpais_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtpais_TextChanged(object sender, EventArgs e)
        {

        }

        private void Código_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Inicio ini = new Inicio();
            ini.Show();
            this.Close();
        }
    }
}
