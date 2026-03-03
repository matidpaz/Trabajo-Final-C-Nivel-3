using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

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
            try
            {
                //conexion = new SqlConnection("server=.\\MSSQLocalDB; database=CATALOGO_WEB_DB; integrated security = true"); //verificar y meter la direccion de la base de datos
                //conexion = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CATALOGO_WEB_DB;Integrated Security=True;Connect Timeout=30"); //verificar y meter la direccion de la base de datos
                conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]); 
                comando = new SqlCommand();   
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setearConsulta(string consulta) 
        {
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        public void setearParametro(string nombreParametro, object valor) 
        {
            try
            {
                comando.Parameters.AddWithValue(nombreParametro, valor);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ejecutarAccion() 
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                cerrarConexion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setearConsultaConSP(string sp) 
        {
            try
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = sp;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int ejecutarAccionScalar() 
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                int idRetornado = int.Parse(comando.ExecuteScalar().ToString());
                cerrarConexion();
                return idRetornado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Object ejecutarAccionScalarParaEmail()
        {
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                object idRetornado = comando.ExecuteScalar();
                cerrarConexion();
                return idRetornado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
