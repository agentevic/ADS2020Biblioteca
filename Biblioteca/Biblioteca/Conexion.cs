using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
namespace Biblioteca
{
    public class Conexion
    {       
        public SqlConnection ObtenerConexion()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conec"].ConnectionString);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();
            }
            return con;          
        }      
    }
}
