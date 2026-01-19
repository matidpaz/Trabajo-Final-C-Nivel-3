using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConexionDB
{
    public class AccesoADB
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoADB()
        {
            conexion = new SqlConnection("algo"); //verificar y meter la direccion de la base de datos
            comando = new SqlCommand();   
        }
        public void setearConsulta(string consulta) 
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura() 
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void cerrarConexion() 
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();  
        }

        public void setearParametro(string nombreParametro, string valor) 
        {
            comando.Parameters.AddWithValue(nombreParametro, valor);
        }

        public void ejecutarAccion() 
        {
            try
            {
                comando.Connection = conexion;
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
