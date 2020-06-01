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
    class Class_Editoriales:ClaseDatos
    {
        int cod_editorial;
        string ed_nombre;
        string ed_pais;
        string ed_tel;

        public int Cod_editorial
        {
            get
            {
                return cod_editorial;
            }
            set
            {
                cod_editorial = value;
            }
        }

        public string Ed_nombre
        {
            get
            {
                return ed_nombre;
            }
            set
            {
                ed_nombre = value;
            }
        }

        public string Ed_pais
        {
            get
            {
                return ed_pais;
            }
            set
            {
                ed_pais = value;
            }
        }

        public string Ed_tel
        {
            get
            {
                return ed_tel;
            }
            set
            {
                ed_tel = value;
            }
        }


        public override bool insertar()
        {
            bool resp;
            try
            {
                string consulta = "INSERT INTO Editoriales(Cod_Ed,Nombre_Ed,Pais_Ed,Telefono_Ed) VALUES (@cod, @nombre, @pais, @telefono)";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@cod", Cod_editorial);
                comando.Parameters.AddWithValue("@nombre", Ed_nombre);
                comando.Parameters.AddWithValue("@pais", Ed_pais);
                comando.Parameters.AddWithValue("@telefono", Ed_tel);
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            finally
            {

            }
            return resp;
        }
        public override bool eliminar()
        {
            Boolean resp;
            try
            {
                string consulta = "DELETE from Editoriales where Cod_Ed= @cod";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@cod", Cod_editorial);
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public override bool eliminarl_E1()
        {
            Boolean resp;
            try
            {
                string consulta = "DELETE FROM Copias_Libros where Id_libro=@idc";

                SqlCommand cmd = new SqlCommand(consulta, ObtenerConexion());
                


                return ejecutarSentencia(cmd);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public override bool eliminarl_E2()
        {
            Boolean resp;
            try
            {
                string consulta = "DELETE FROM Autores_Libros where Id_Autor=@autor and Id_Libro=@libro";

                SqlCommand cmd = new SqlCommand(consulta, ObtenerConexion());
              

                return ejecutarSentencia(cmd);
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
                string consulta = "DELETE from Libros where Cod_Ed= @cod";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@cod", Cod_editorial);
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
                string consulta = "UPDATE Editoriales SET Nombre_Ed = @nombre, Pais_Ed = @pais, Telefono_Ed = @telefono where Cod_Ed = @cod";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@cod", Cod_editorial);
                comando.Parameters.AddWithValue("@nombre",Ed_nombre);
                comando.Parameters.AddWithValue("@pais", Ed_pais);
                comando.Parameters.AddWithValue("@telefono",Ed_tel);
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }


        public void consultar(DataGridView data, string nomEditorial)
        {
            SqlCommand comando = new SqlCommand("SELECT * from Editoriales where Nombre_Ed like '" + nomEditorial + "%'", ObtenerConexion());
            comando.Parameters.AddWithValue("@nombre", Ed_nombre);

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
            string consulta = "SELECT * FROM Editoriales";
            SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());


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
