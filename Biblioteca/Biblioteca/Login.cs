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
    public partial class Login : Form
    {
        public void SetMaximizeBox(bool setValue)

        {

            foreach (Form form in Application.OpenForms)

                form.MaximizeBox = setValue;

        }
        Usuarios login = new Usuarios();
        public Login()
        {
            InitializeComponent();

            txtcontraseña.PasswordChar = '*';
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text.Trim() == "" || txtcontraseña.Text.Trim() == "")
            {
                errorProvider1.SetError(txtusuario, "Ingrese nombre de Usuario");
                errorProvider1.SetError(txtcontraseña, "Ingrese contraseña");


            }
            else if (txtusuario.Text == "Admin" && txtcontraseña.Text == "1234")
            {
                Inicio ini = new Inicio();
                ini.Show();
                this.Close();
            }
            else if (txtusuario.Text != "Admin" && txtcontraseña.Text != "1234")
            {
                MessageBox.Show("Usuario o contraseña incorrecto");
                txtcontraseña.Clear();
                txtusuario.Clear();
            }

            //else
            //{
            //    errorProvider1.Clear();
            //    login.Usuario = txtusuario.Text.Trim();
            //    login.Contraseña = txtcontraseña.Text.Trim();
            //    login.IniciarSesión();

            //    Inicio ini = new Inicio();
            //    ini.Show();
            //    this.Close();
            //}
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtcontraseña.Text.Length >= 8)
            {
                errorProvider1.SetError(txtcontraseña, "Excede cantidad de caracteres");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
