using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Biblioteca
{
    class Class_Lectores:ClaseDatos
    {
        string numtarjeta;
        string lector_nombre;
        string lector_dir;
        string lec_tel;
        PictureBox foto;
        string descripcion;
        System.IO.MemoryStream ms = new System.IO.MemoryStream();

        public string Numtarjeta
        {
            get
            {
                return numtarjeta;
            }
            set
            {
                numtarjeta = value;
            }
        }

        public string Lector_nombre
        {
            get
            {
                return lector_nombre;
            }
            set
            {
                lector_nombre = value;
            }
        }

        public string Lector_dir
        {
            get
            {
                return lector_dir;
            }
            set
            {
                lector_dir = value;
            }
        }

        public string Lector_tel
        {
            get
            {
                return lec_tel;
            }
            set
            {
                lec_tel = value;
            }
        }

        public PictureBox Foto
        {
            get
            {
                return foto;
            }
            set
            {
                foto = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }
        public string insertarlector(string numTargeta,string NombreLector, string DireccionLector, string TelefonoLector, PictureBox FotoL)
        {
            string mensaje = "Se ingreso lector con exito";
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Lectores(Num_Targeta, Nombre_Lector, Direccion_Lector, Telefono_Lector,Foto) VALUES (@numtargeta, @nombre, @direccion, @telefono,@Imagen)", ObtenerConexion());
                
                cmd.Parameters.Add("@Imagen", SqlDbType.Image);
                cmd.Parameters.Add("@numtargeta", SqlDbType.NChar);
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.NChar) ;
                cmd.Parameters.AddWithValue("@direccion", SqlDbType.NChar);
                cmd.Parameters.AddWithValue("@telefono", SqlDbType.NChar);
               
             
                cmd.Parameters["@numtargeta"].Value = numTargeta;
                cmd.Parameters["@nombre"].Value = NombreLector;
                cmd.Parameters["@direccion"].Value = DireccionLector;
                cmd.Parameters["@telefono"].Value = TelefonoLector;

                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                FotoL.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@Imagen"].Value = ms.GetBuffer();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar lector: " + ex.ToString();
            }
            return mensaje;
        }

        public string Modificarlector(string numTargeta, string NombreLector, string DireccionLector, string TelefonoLector, PictureBox FotoL)
        {
            string mensaje = "Se Modifico lector con exito";
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Lectores SET Nombre_Lector=@nombre, Direccion_Lector=@direccion, Telefono_Lector=@telefono,Foto=@Imagen where Num_Targeta=@numtargeta", ObtenerConexion());

                cmd.Parameters.Add("@Imagen", SqlDbType.Image);
                cmd.Parameters.Add("@numtargeta", SqlDbType.NChar);
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.NChar);
                cmd.Parameters.AddWithValue("@direccion", SqlDbType.NChar);
                cmd.Parameters.AddWithValue("@telefono", SqlDbType.NChar);


                cmd.Parameters["@numtargeta"].Value = numTargeta;
                cmd.Parameters["@nombre"].Value = NombreLector;
                cmd.Parameters["@direccion"].Value = DireccionLector;
                cmd.Parameters["@telefono"].Value = TelefonoLector;

                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                FotoL.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@Imagen"].Value = ms.GetBuffer();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mensaje = "Error al registrar lector: " + ex.ToString();
            }
            return mensaje;
        }

        public override bool eliminar()
        {
            Boolean resp;
            try
            {
                string consulta = "DELETE from Lectores where Num_targeta = @numtargeta";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@numtargeta", Numtarjeta);
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public override bool eliminarl()
        {
            Boolean resp;
            try
            {
                string consulta = "DELETE from Prestamos where Num_targeta = @numtargeta";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@numtargeta", Numtarjeta);
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public override bool modificar()
        {
            Boolean resp;
            try
            {
                string consulta = "UPDATE Lectores SET Nombre_Lector = @nombre, Direccion_Lector = @direccion, Telefono_Lector = @telefono, Foto=@foto where Num_Targeta = @numtargeta";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@numtargeta", Numtarjeta);
                comando.Parameters.AddWithValue("@nombre", Lector_nombre);
                comando.Parameters.AddWithValue("@direccion", Lector_dir);
                comando.Parameters.AddWithValue("@telefono", Lector_tel);
                comando.Parameters.AddWithValue("@foto", Foto);
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public void consultar(DataGridView data, string nomLector)
        {
            SqlCommand comando = new SqlCommand("SELECT * from Lectores where Nombre_Lector like '" + nomLector + "%'", ObtenerConexion());
            comando.Parameters.AddWithValue("@nombre", Lector_nombre);

            try
            {
                SqlDataAdapter seleccionar = new SqlDataAdapter();
                seleccionar.SelectCommand = comando;
                DataTable dtDatos = new DataTable();
                seleccionar.Fill(dtDatos);
                BindingSource formulario = new BindingSource();
                formulario.DataSource = dtDatos;
                data.DataSource = formulario;
                seleccionar.Update(dtDatos);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void consultartodos(DataGridView data)
        {
            string consulta = "SELECT * FROM Lectores";
            SqlCommand comando = new SqlCommand(consulta,ObtenerConexion());


            try
            {
                SqlDataAdapter seleccionar = new SqlDataAdapter();
                seleccionar.SelectCommand = comando;
                DataTable dtDatos = new DataTable();
                seleccionar.Fill(dtDatos);
                BindingSource formulario = new BindingSource();
                formulario.DataSource = dtDatos;
                data.DataSource = formulario;
                seleccionar.Update(dtDatos);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


    }
}
