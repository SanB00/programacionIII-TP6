using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TP6Grupo18
{
    public class Conexion
    {

        //private const string cadenaConexion = @"Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno;Integrated Security=True";
        /*
        cadenaParaEntrega
			 private const string cadenaConexion = @"Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno;Integrated Security=True";
		
        Franco
             private const string cadenaConexion = @"Data Source=localhost\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
			 
		Lautaro*/
			 private const string cadenaConexion= @"Data Source=localhost;Initial Catalog=Neptuno;Integrated Security=True;Trust Server Certificate=True";
        /*
  		Santi
			 private const string cadenaConexion=@"Initial Catalog=Neptuno;Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True";

        Elian 
			 private const string cadenaConexion=@"Initial Catalog=Neptuno;Data Source=localhost;Integrated Security=True";
         
		Yulieth 
			 private const string cadenaConexion=@"Initial Catalog=Neptuno;Data Source=DESKTOP-RFDMNU2\SQLEXPRESS;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";			 	 
			 
		Guillermo
			 private const string cadenaConexion=@"Initial Catalog=Neptuno;Data Source=localhost;Integrated Security=True";
         */
        public Conexion()
        {

        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(cadenaConexion);
            try
            {
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand comandoSQL, string nombreProcedimientoAlmacenado) 
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = comandoSQL;
            sqlCommand.Connection = Conexion;
            sqlCommand.CommandType = CommandType.StoredProcedure;   
            sqlCommand.CommandText = nombreProcedimientoAlmacenado; 
            FilasCambiadas = sqlCommand.ExecuteNonQuery();          
            return FilasCambiadas;
        }
    }

}