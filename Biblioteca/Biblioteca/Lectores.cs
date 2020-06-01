using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //para trabajar con marca de agua
namespace Biblioteca
{
    public partial class Lectores : Form
    {
        Class_Lectores lector = new Class_Lectores();
        public Lectores()
        {
            InitializeComponent();
            //ASIGNACION DE VARIABLES PARA CREAR LA MASCARA EN EL TEXBOX DEL TELEFONO
            List<TextBox> tlist = new List<TextBox>();
            List<string> slist = new List<string>();
            tlist.Add(txttel);
            slist.Add("ej.23239834"); //DEFINIENDO LO Q MOSTRARA LA MARCA DE AGUA
            SetCueBanner(ref tlist, slist);//LLAMANDO METODO

          

        }

        //CODIGO PARA GENERAR MARCA DE AGUA A UN TEXTBOX
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd,uint msg, IntPtr i, string str);

        //METODO PARA VALIDAR MASCARA CUANDO SE VAYA ESCRIBIENDO
        void SetCueBanner(ref List<TextBox> TextBox,List<string> CueText)
        {
            
            for(int x=0;x<TextBox.Count;x++)
            {
                SendMessage(TextBox[x].Handle, 0x1501, (IntPtr)1, CueText[x]);
            }
        }

        //fin del metodo para crear marca de agua
        int id;
        public void limpiar()
        {
            txtdir.Clear();
            txtcarnet.Clear();
            txtnombre.Clear();
            txtBuscar.Clear();
            pictureBox1.Image = null;
            txttel.Clear();
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
            txtcarnet.Text = ed;
            txtcarnet.Enabled = false;
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            
            if (txtnombre.Text.Trim() == "" || txtdir.Text.Trim()=="" || txttel.Text.Trim()=="")
            {
                errorProvider1.SetError(txtnombre, "Campo vacío ingrese dato solicitado");
                errorProvider1.SetError(txtdir, "Campo vacío ingrese dato solicitado");
                errorProvider1.SetError(txttel, "Campo vacío ingrese dato solicitado");
                
            }
            else
            {

                errorProvider1.Clear();
                MessageBox.Show(lector.insertarlector(txtcarnet.Text, txtnombre.Text, txtdir.Text, txttel.Text, pictureBox1));
                limpiar();
                lector.consultartodos(dataGridView1);
                generar_codigo();


            }
            
        }
        int carnet;
        private void btbGenerar_Click(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            for (int ctr = 1; ctr <= 20; ctr++)
            {
                  carnet=rnd.Next(1000, 10001);
                if (ctr % 5 == 0) ;
            }
            string tarjeta = Convert.ToString(carnet);
            txtcarnet.Text = tarjeta;
            txtcarnet.Enabled = false;
        }

        private void Lectores_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            lector.consultartodos(dataGridView1); //carga los datos de la bd
            generar_codigo();
            //desactivar botonos eliminar y modificar
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            //configuracion del tooltip
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 10;
            toolTip1.ReshowDelay = 500;

            toolTip1.ShowAlways = true;
            //tooltip para los botones
            toolTip1.SetToolTip(this.btnModificar, "Modificar");
            toolTip1.SetToolTip(this.btnInsertar, "Guardar");
            toolTip1.SetToolTip(this.btnEliminar, "Eliminar");
            toolTip1.SetToolTip(this.Buscar, "Buscar");
            toolTip1.SetToolTip(this.button1, "Buscar fotografía");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //validando que los campos no esten vacios
            if (txtnombre.Text.Trim() == "" || txtdir.Text.Trim() == "" || txttel.Text.Trim() == "")
            {
                errorProvider1.SetError(txtnombre, "Campo vacío ingrese dato solicitado");
                errorProvider1.SetError(txtdir, "Campo vacío ingrese dato solicitado");
                errorProvider1.SetError(txttel, "Campo vacío ingrese dato solicitado");

            }
            else
            {

                errorProvider1.Clear();
                lector.Numtarjeta = txtcarnet.Text;
                //eliminando antes la tabla q contiene como foranea la lleva primeria 
                if (lector.eliminarl()) { }
                if (lector.eliminar())
                {
                    MessageBox.Show("Eliminado exitosamente");
                }
                else
                {
                    MessageBox.Show("Error al Eliminar");
                }
                lector.consultartodos(dataGridView1);
                limpiar();
            }
            generar_codigo();

            //DESACTIVO BOTON ELIMINAR Y MODIFICAR
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnInsertar.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Trim() == "" || txtdir.Text.Trim() == "" || txttel.Text.Trim() == "")
            {
                errorProvider1.SetError(txtnombre, "Campo vacío ingrese dato solicitado");
                errorProvider1.SetError(txtdir, "Campo vacío ingrese dato solicitado");
                errorProvider1.SetError(txttel, "Campo vacío ingrese dato solicitado");

            }
            else
            {

                errorProvider1.Clear();
            }
            MessageBox.Show(lector.Modificarlector(txtcarnet.Text, txtnombre.Text, txtdir.Text, txttel.Text, pictureBox1));
            lector.consultartodos(dataGridView1);
            limpiar();
            generar_codigo();
            //DESACTIVO BOTON ELIMINAR Y MODIFICAR
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnInsertar.Enabled = true;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            lector.Lector_nombre = txtBuscar.Text.Trim();
            lector.consultar(dataGridView1,txtBuscar.Text);
            limpiar();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            errorProvider1.Clear();
            string dato0, dato1, dato2, dato3;
            PictureBox dato4;
            try
            {

            
            dato1 = dataGridView1.CurrentRow.Cells[1].EditedFormattedValue.ToString();
            dato2 = dataGridView1.CurrentRow.Cells[2].EditedFormattedValue.ToString();
            dato3 = dataGridView1.CurrentRow.Cells[3].EditedFormattedValue.ToString();
            dato0 = dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
           
           
            byte[] imageBuffer = (byte[])dataGridView1.CurrentRow.Cells[4].Value; //almacenas la imagen de la datagrib
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);//
            pictureBox1.Image = Image.FromStream(ms);//le asignas al pictureBox
            txtcarnet.Text = dato0;
            txtnombre.Text = dato1;
            txtdir.Text = dato2;
            txttel.Text = dato3;
            txtcarnet.Enabled = false;

                //activando botones modificar y eliminar y desactivando el de guardar
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnInsertar.Enabled = false;
           }
            catch (Exception er)
            {
                MessageBox.Show("Error:" + er);
            }
            btnInsertar.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtdir_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (this.openFileDialog1.FileName.Equals("") == false)
                {
                    pictureBox1.Load(this.openFileDialog1.FileName);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen: " + ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_Validated(object sender, EventArgs e)
        {
           
        }

        //validacion para que solo acepte letras 
        //se crea el evento Keypress
        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //permite el ingreso de letras
                if (char.IsLetter(e.KeyChar))
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
            catch (Exception )
            {
                
            }
        }

        private void txtdir_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //permite el ingreso de letras
                if (char.IsLetter(e.KeyChar))
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

        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //permite el ingreso de numeros
                if (char.IsNumber(e.KeyChar) & e.KeyChar>8)
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
            if (txttel.Text.Length==8)
            {
                errorProvider1.SetError(txttel, "Excede cantidad de numeros");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void Lectores_MouseHover(object sender, EventArgs e)
        {
         
        }

        //CREACION DEL EVENTO PARA EL USO DEL TOOLTIP
        private void btnEliminar_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnEliminar, "Eliminar");
        }

        private void btnInsertar_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnInsertar, "Guardar");
        }

        private void txtcarnet_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void atras_Click(object sender, EventArgs e)
        {

            Inicio ini = new Inicio();
            ini.Show();
            this.Close();

        }
    }
}
