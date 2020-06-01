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
    class Class_Infoprestamos:ClaseDatos
    {
        string lector;
        public string Lector
        {
            get
            {
                return lector;
            }
            set
            {
                lector = value;
            }
        }

        public void consultar(DataGridView data, string nombre)
        {
            //APLICACION DE PROCEDIMIENTO ALMACENADO
            DataTable dt = new DataTable();
            string procedimiento;
            procedimiento = "Prestamos_persona";
            
            try
            {
               
                SqlDataAdapter da = new SqlDataAdapter(procedimiento, ObtenerConexion());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //enviando variable al procedimiento
                da.SelectCommand.Parameters.Add("@nombre", SqlDbType.Char).Value = Lector;
                da.Fill(dt);
                BindingSource formulario = new BindingSource();
                formulario.DataSource = dt;
                data.DataSource = formulario;
                da.Update(dt);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public void consultartodos(DataGridView data)
        {
            //string consulta = "SELECT Id_Prestamos,Nombre_Lector as [Lector ],Titulo,Fecha_salida as [Fecha de Prestamo],Fecha_Devol as [Fecha de Devolucion] from Prestamos as p inner join Libros  as  l on p.Id_Libro =l.Id_Libro inner join Lectores as lc on lc.Num_Targeta=p.Num_Targeta";
            //SqlCommand comando = new SqlCommand(consulta, ObtenerConexion());
            //APLICACION DE PROCEDIMIENTO ALMACENADO
            DataTable dt = new DataTable();
            string procedimiento;
            procedimiento = "Detalle_Prestamos";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(procedimiento, ObtenerConexion());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                
                da.Fill(dt);
                BindingSource formulario = new BindingSource();
                formulario.DataSource = dt;
                data.DataSource = formulario;
                da.Update(dt);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
