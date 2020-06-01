using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca
{
    class Class_Prestamo:ClaseDatos
    {
        int id_prestamo;
        int id_libro;
        string num_targeta;
        string fecha_salida;
        string fecha_devolucion;


        public int Id_prestamo
        {
            get
            {
                return id_prestamo;
            }
            set
            {
                id_prestamo = value;
            }
        }
        
        public int Id_libro
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


        public string Num_targeta
        {
            get
            {
                return num_targeta;
            }
            set
            {
                num_targeta = value;
            }
        }

        public string Fecha_salida
        {
            get
            {
                return fecha_salida;
            }
            set
            {
                fecha_salida = value;
            }
        }

        public string Fecha_Devolucion
        {
            get
            {
                return fecha_devolucion;
            }
            set
            {
                fecha_devolucion = value;
            }
        }


        public override bool insertar()
        {
            bool resp;
            try
            {
                string consulta = "INSERT INTO Prestamos(Id_Prestamos,Id_libro,Num_Targeta,Fecha_Salida,Fecha_Devol ) VALUES (@idprestamo, @idlibro, @targeta, @fechasal,@fechadevo)";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@idprestamo", Id_prestamo);
                comando.Parameters.AddWithValue("@idlibro", Id_libro);
                comando.Parameters.AddWithValue("@targeta", Num_targeta);
                comando.Parameters.AddWithValue("@fechasal", Fecha_salida);
                comando.Parameters.AddWithValue("@fechadevo", Fecha_Devolucion);
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
                string consulta = "DELETE from Prestamos where Id_Prestamos = @idprestamo";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@idprestamo", Id_prestamo);
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
                string consulta = "UPDATE Prestamos SET  Id_libro= @idlibro,Num_Targeta= @targeta,Fecha_Salida= @fechasal,Fecha_Devol=@fechadevo where Id_Prestamos = @idprestamo";
                SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
                comando.Parameters.AddWithValue("@idlibro", Id_libro);
                comando.Parameters.AddWithValue("@targeta", Num_targeta);
                comando.Parameters.AddWithValue("@fechasal",Fecha_salida);
                comando.Parameters.AddWithValue("@fechadevo", Fecha_Devolucion);
                comando.Parameters.AddWithValue("idprestamo", Id_prestamo);
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
            SqlCommand comando = new SqlCommand("SELECT * from Prestamo where Id_Prestamo=@idprestamo", ObtenerConexion());
            comando.Parameters.AddWithValue("@idprestamo", Id_prestamo);

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
            string consulta = "SELECT Id_Prestamos as [ID Prestamos],Id_Libro,Num_Targeta as [Targeta Lector],Fecha_Salida,Fecha_Devol from Prestamos";
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
