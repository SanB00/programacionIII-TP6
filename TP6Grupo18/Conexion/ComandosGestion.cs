using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TP6Grupo18
{
    public class ComandosGestion
    {
        public ComandosGestion() 
        {
            
        }

        private DataTable ObtenerTabla(string nombreTabla, string consultaSQL)
        {
            DataSet dataSet = new DataSet();
            Conexion datos = new Conexion();
            SqlDataAdapter sqlDataAdapter = datos.ObtenerAdaptador(consultaSQL);
            sqlDataAdapter.Fill(dataSet, nombreTabla);
            return dataSet.Tables[nombreTabla];
        }

        










    }

}  