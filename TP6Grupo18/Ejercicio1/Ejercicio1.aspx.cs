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
            gvProductos.DataSource = new Conexion().ejecutarConsulta("SELECT * FROM Productos");
            gvProductos.DataBind();
            // error CS0122: 'ComandosGestion.ObtenerTabla(string,string)' is inaccessible due to its protection level
            // ComandosGestion objComandosGestion = new ComandosGestion();
            // const string nombreTabla = "Productos";
            // const string consultaSQL = "SELECT * FROM Productos";
            // gvProductos.DataSource = objComandosGestion.ObtenerTabla(nombreTabla, consultaSQL);
        }

        protected void gvProductos_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e) {
            gvProductos.PageIndex = e.NewPageIndex;
            cargarProductos();
        }

    }
}