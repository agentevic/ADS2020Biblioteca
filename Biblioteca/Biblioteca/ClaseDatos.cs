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
    class ClaseDatos
    {
        public SqlConnection comando
        {
            get
            {
                return comando;
            }

            set
            {
                comando = value;
            }

            
        }

        SqlConnection con;
        public SqlConnection ObtenerConexion()
        {
            con = new Conexion().ObtenerConexion();
            return con;
        }

        public void cerrarConexion()
        {
            con.Close();
        }

        public virtual Boolean insertar()
        {
            return true;

        }
        public virtual Boolean insertar_l()
        {
            return true;

        }
        public virtual Boolean insertarcp()
        {
            return true;
        }


        public virtual Boolean modificar()
        {
            return true;
        }
        public virtual Boolean modificarcp()
        {
            return true;
        }
        public virtual Boolean modificar_l()
        {
            return true;
        }


        public virtual Boolean eliminar()
        {
            return true;
        }
        public virtual Boolean eliminarcp()
        {
            return true;
        }
        public virtual Boolean eliminarl()
        {
            return true;
        }

        public virtual Boolean eliminarl_E1()
        {
            return true;
        }
        public virtual Boolean eliminarl_E2()
        {
            return true;
        }
        public virtual Boolean eliminarl_E3()
        {
            return true;
        }

        public Boolean ejecutarSentencia(SqlCommand comando)
        {
            try
            {
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public Boolean ejecutarSentencia2(SqlCommand comando, SqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }
    }
}
