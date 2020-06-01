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
    class Class_Autor:ClaseDatos
    {
        int id_autor;
        string autor_nombre;
         
        public int Id_autor
        {
            get
            {
                return id_autor;
            }
            set
            {
                id_autor = value;
            }
        }

        public string Autor_nombre
        {
            get
            {
                return autor_nombre;
            }
            set
            {
                autor_nombre = value;
            }
        }

        public override bool insertar()
        {
            bool resp;
            try
            {
                string consulta = "INSERT INTO Autores(Id_Autor,Nombre_Autor) VALUES (@id, @nombre)";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id",Id_autor);
                comando.Parameters.AddWithValue("@nombre", Autor_nombre);
          
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
                string consulta = "DELETE from Autores where Id_Autor = @id";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id", Id_autor);
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
                string consulta = "DELETE from Autores_Libros where Id_Autor = @id ";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id", Id_autor);
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public override bool eliminarcp()
        {
            Boolean resp;
            try
            {
                string consulta = "DELETE from Libros where Id_Autor = @id ";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id", Id_autor);
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
                string consulta = "UPDATE Autores SET Nombre_Autor = @nombre where Id_Autor = @id";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id", Id_autor);
                comando.Parameters.AddWithValue("@nombre", Autor_nombre);
                
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }

        public void consultar(DataGridView data, string nomAutor)
        {
            SqlCommand comando = new SqlCommand("SELECT * from Lectores where Nombre_Lector like '" + nomAutor + "%'", ObtenerConexion());
            comando.Parameters.AddWithValue("@nombre", Autor_nombre);

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
            string consulta = "SELECT * FROM Autores";
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
