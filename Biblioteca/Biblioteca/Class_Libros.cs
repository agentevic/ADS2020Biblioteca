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
    
    class Class_Libros:ClaseDatos
    {
        int id_libro;
        int id_lector;
        string titulo;
        int cod_ed;
        int num_copias;
        int id_autor;
        
      
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
        public int Num_copias
        {
            get
            {
                return num_copias;
            }
            set
            {
                num_copias = value;
            }
        }
        public int Id_Libro
        {
            get
            {
                return id_libro;
            }
            set
            {
                id_libro = value;
            }
        }

        
        public string Titulo
        {
            get
            {
                return titulo;
            }
            set
            {
                titulo = value;
            }
        }

        public int Cod_Ed
        {
            get
            {
                return cod_ed;
            }
            set
            {
                cod_ed = value;
            }
        }
        

        public override bool insertar()
        {
            bool resp;
            try
            {
                string consulta = "INSERT INTO Libros(Id_Libro,Titulo,Cod_Ed) VALUES (@id, @titulo, @cod)";
               
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                
                comando.Parameters.AddWithValue("@id",Id_Libro);
                comando.Parameters.AddWithValue("@titulo", Titulo);
                comando.Parameters.AddWithValue("@cod", Cod_Ed);
               
                return ejecutarSentencia(comando);
            }
            catch (Exception error)
            {
                resp = false;
            }
            finally
            {

            }
            return resp;
        }
        public override bool insertar_l()
        {
            bool resp;
            try
            {
                string consult = "INSERT INTO Autores_Libros values (@idlibro,@idautor)";
                SqlCommand cmd = new SqlCommand(consult, ObtenerConexion());
                cmd.Parameters.AddWithValue("@idlibro", Id_Libro);
                cmd.Parameters.AddWithValue("idautor", Id_autor);
                return ejecutarSentencia(cmd);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
           
        }
        public override bool insertarcp()
        {
            bool resp;
            try
            {
                
                string consulta = "INSERT INTO  Copias_Libros(Id_Libro,Num_Copias) values (@idcp,@numcp)";
              
                SqlCommand cmd = new SqlCommand(consulta, ObtenerConexion());
              
                cmd.Parameters.AddWithValue("@idcp", Id_Libro);
                cmd.Parameters.AddWithValue("@numcp", Num_copias);
                return ejecutarSentencia(cmd);
            }
            catch (Exception ex)
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
                string consulta = "DELETE Libros where Id_Libro = @id ";
               
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                
                comando.Parameters.AddWithValue("@id", Id_Libro);
              
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
                string consulta = "DELETE FROM Copias_Libros where Id_libro=@idc";
               
                SqlCommand cmd = new SqlCommand(consulta, ObtenerConexion());
                cmd.Parameters.AddWithValue("@idc", Id_Libro);
        

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
                string consulta = "DELETE FROM Autores_Libros where Id_Autor=@autor and Id_Libro=@libro";

                SqlCommand cmd = new SqlCommand(consulta, ObtenerConexion());
                cmd.Parameters.AddWithValue("@libro", Id_Libro);
                cmd.Parameters.AddWithValue("@autor", Id_autor);

                return ejecutarSentencia(cmd);
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
                string consulta = "UPDATE Libros SET Titulo = @titulo, Cod_Ed = @editorial where Id_Libro = @id";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id", Id_Libro);
                comando.Parameters.AddWithValue("@titulo",Titulo);
                comando.Parameters.AddWithValue("@editorial", Cod_Ed);
              
                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public override bool modificarcp()
        {
            Boolean resp;
            try
            {
                string consulta = "UPDATE Copias_Libros  SET Num_Copias=@num where Id_Libro = @id";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id", Id_Libro);
                comando.Parameters.AddWithValue("@num", Num_copias);

                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public override bool modificar_l()
        {
            Boolean resp;
            try
            {
                string consulta = "UPDATE Autores_Libros  SET Id_Autor=@num where Id_Libro = @id ";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@id", Id_Libro);
                comando.Parameters.AddWithValue("@num", Id_autor);

                return ejecutarSentencia(comando);
            }
            catch (Exception err)
            {
                resp = false;
            }
            return resp;
        }
        public void consultar(DataGridView data, string ltitulo)
        {
           
            SqlCommand comando = new SqlCommand("SELECT lb.Id_Libro, Titulo,Nombre_Autor as [Autor] ,Nombre_Ed as [Editorial], Num_Copias as [Copias] FROM Autores_Libros as al INNER JOIN Autores as a ON a.Id_Autor=al.Id_Autor inner join Libros as lb on lb.Id_Libro=al.Id_Libro inner join Copias_libros as cp on cp.Id_Libro=lb.Id_Libro INNER JOIN Editoriales as ed ON lb.Cod_Ed = ed.Cod_Ed where Titulo like'%" + ltitulo + "%' ", ObtenerConexion());
            comando.Parameters.AddWithValue("@titulo", Titulo);

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
            string consulta = "SELECT lb.Id_Libro, Titulo,Nombre_Autor as [Autor] ,Nombre_Ed as [Editorial], Num_Copias FROM Autores_Libros as al INNER JOIN Autores as a ON a.Id_Autor=al.Id_Autor inner join Libros as lb on lb.Id_Libro=al.Id_Libro  inner join Copias_libros as cp on cp.Id_Libro=lb.Id_Libro INNER JOIN Editoriales as ed ON lb.Cod_Ed = ed.Cod_Ed";
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
