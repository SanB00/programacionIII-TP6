using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TP6Grupo18
{
    public class Conexion
    {
        private const string cadenaConexion = @"Data Source=localhost\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //private const string cadenaConexion = @"Data Source=localhost;Initial Catalog=Neptuno;Integrated Security=True;Trust Server Certificate=True";

        //private const string cadenaConexion = @"Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno;Integrated Security=True";
        /*
        cadenaParaEntrega
			 private const string cadenaConexion = @"Data Source=localhost\\sqlexpress; Initial Catalog=Neptuno;Integrated Security=True";
		
        Franco
             private const string cadenaConexion = @"Data Source=localhost\sqlexpress;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
			 
		Lautaro
			 private const string cadenaConexion= @"Data Source=localhost;Initial Catalog=Neptuno;Integrated Security=True;Trust Server Certificate=True";
        
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

        public SqlConnection obtenerConexion()
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

        public SqlDataAdapter obtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, obtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public int ejecutarProcedimientoAlmacenado(SqlCommand comandoSQL, string nombreProcedimientoAlmacenado) 
        {
            int filasCambiadas;
            SqlConnection conexion = obtenerConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = comandoSQL;
            sqlCommand.Connection = conexion;
            sqlCommand.CommandType = CommandType.StoredProcedure;   
            sqlCommand.CommandText = nombreProcedimientoAlmacenado; 
            filasCambiadas = sqlCommand.ExecuteNonQuery();          
            return filasCambiadas;
        }
        #region ANTERIOR CLASE CONEXION.CS
        public string obtenerCadenaDeConexion(string nombreBBDD) {
            const string webconfigAttribute = "dbBase";
            try {
                string dbBaseWebconfig = ConfigurationManager.ConnectionStrings[webconfigAttribute].ConnectionString;
                return $"{dbBaseWebconfig};Initial Catalog = {nombreBBDD}";
            }
            catch (Exception e) {
                throw new Exception($"Error al obtener la cadena de conexión '{webconfigAttribute}'. Revisar WEB.CONFIG: \n\n" + e.Message);
            }
    }

        /* @autor Santi | Elián
         * ejecutarConsulta antes llamado obtenerTablaDeLaBaseDeDatos
         * @param consultaSQL: La consulta SQL a ejecutar. Ejemplo: "SELECT * FROM Sucursal WHERE Ciudad = @Ciudad";
         * @param parametros: Un array de SqlParameter para evitar inyecciones SQL. Ejemplo: new SqlParameter[] { new SqlParameter("@Ciudad", "Buenos Aires") }
         * @return DataTable con los resultados de la consulta. Si no hay resultados, devuelve un DataTable vacío (sin filas).
         * @throws Exception con mensaje detallado en caso de error de conexión o consulta.
         */
        public DataTable ejecutarConsulta(string consultaSQL, SqlParameter[] parametros = null) {
            string connectionString = string.IsNullOrEmpty(cadenaConexion) ? this.obtenerCadenaDeConexion("Neptuno") : cadenaConexion;
            DataTable dataTable = new DataTable();

            // El bloque 'using' asegura que la conexión se cierre SIEMPRE, incluso si hay error
            using (SqlConnection sqlConnection = new SqlConnection(connectionString)) {
                try {
                    SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);
                    if (parametros != null) {
                        sqlCommand.Parameters.AddRange(parametros);
                    }
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlConnection.Open();
                    sqlDataAdapter.Fill(dataTable);
                }
                catch (Exception e) {
                    if ((e is SqlException ex)) {
                        switch (ex.Number) {
                            // Connection & String Errors
                            case -1: // Connection timeout
                            case 2:  // Connection pool empty or server not found
                            case 53: // Network-related/instance-specific error (Server not found)
                            case 40: // Could not open connection to server
                            case 18456: // Login failed for user (Wrong credentials in string)
                                throw new Exception($"Connection Error: Revisar WEB.CONFIG Check your connection string or server status. Details: \n{e.Message} ");
                            default:
                                throw new Exception($"SQL Error ({ex.Number}): {ex.Message}");
                        }
                    }
                    else
                        throw new Exception($"Error al consultar la base de datos: \n{e.Message}");
                }
            }
            return dataTable;
        }

        /* @autor: Lautaro
         * Ejecuta una consulta SQL de tipo INSERT, UPDATE o DELETE y devuelve la cantidad de filas afectadas.
         * @param consultaSQL: La consulta SQL a ejecutar. Ejemplo:´ "UPDATE Empleados SET Salario = Salario * 1.1 WHERE Departamento = 'Ventas'";
         */
        public int ejecutarTransaccion(string consultaSQL) {
            string connectionString = string.IsNullOrEmpty(cadenaConexion) ? this.obtenerCadenaDeConexion("BDSucursales") : cadenaConexion;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(consultaSQL, sqlConnection);

            int filasAfectadas = sqlCommand.ExecuteNonQuery(); /// INSERT, UPDATE, DELETE

            sqlConnection.Close();
            return filasAfectadas;
        }

        public DataTable obtenerSucursalesPorNombre(string nombre) {
            string consultaSQL = $"SELECT * FROM Sucursal WHERE UPPER(NombreSucursal) LIKE '{nombre.ToUpper()}%'";
            return this.ejecutarConsulta(consultaSQL); ;
        }
        #endregion ANTERIOR CLASE CONEXION.CS
    }
}