using System;
using System.Data;
using System.Web.UI.WebControls;

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

        protected void gvProductos_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e) {

           gvProductos.EditIndex = e.NewEditIndex;
           cargarProductos();
        }

        protected void gvProductos_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e) {
            gvProductos.EditIndex = -1;
            cargarProductos();
        }

        protected void gvProductos_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e) {

            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_eit_IdProducto")).Text;
            string nombreProducto = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl ("txt_eit_NombreProducto")).Text;
            string cantidadPorUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_CantidadPorUnidad")).Text;
            string precioUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_PrecioUnidad")).Text;

            string consultaSQL =
        "UPDATE Productos SET " +
        "NombreProducto = '" + nombreProducto + "', " +
        "CantidadPorUnidad = '" + cantidadPorUnidad + "', " +
        "PrecioUnidad = '" + precioUnidad + "' " +
        "WHERE IdProducto = " + idProducto;

            Conexion conexion = new Conexion();

            conexion.ejecutarTransaccion(consultaSQL);

            gvProductos.EditIndex = -1;

            cargarProductos();
        }
    }
}