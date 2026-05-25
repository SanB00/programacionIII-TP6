using System;

namespace TP6Grupo18.Ejercicio1 {
    public partial class Ejercicio1 : System.Web.UI.Page {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]

        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                cargarProductos();
            }
        }

        private void cargarProductos() {
           
            const string consultaSQL = "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos";

            gvProductos.DataSource = new Conexion().ejecutarConsulta(consultaSQL);
            gvProductos.DataBind();
        
            // ComandosGestion objComandosGestion = new ComandosGestion();
            // const string nombreTabla = "Productos";
            // const string consultaSQL = "SELECT * FROM Productos";
            // gvProductos.DataSource = objComandosGestion.ObtenerTabla(nombreTabla, consultaSQL);
        }

        protected void gvProductos_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e) {
            gvProductos.PageIndex = e.NewPageIndex;
            cargarProductos();
        }
        protected void gvProductos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e) {

            int idProducto = Convert.ToInt32(gvProductos.DataKeys[e.RowIndex].Value);

            string consultaSQL = "DELETE FROM Productos " + "WHERE IdProducto = " + idProducto;

            Conexion conexion = new Conexion();

            conexion.ejecutarTransaccion(consultaSQL);

            cargarProductos();
        }

    }
}