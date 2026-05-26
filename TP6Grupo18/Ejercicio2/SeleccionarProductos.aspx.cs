using System;

namespace TP6Grupo18.Ejercicio2
{
    public partial class SeleccionarProductos : System.Web.UI.Page {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]

        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack == false) 
            {
                cargaGridView();
            }
        }
        private void cargaGridView() {
            const string consultaSQL = "SELECT IdProducto, NombreProducto, IdProveedor, PrecioUnidad FROM Productos";

            gvSeleccionar.DataSource = new Conexion().ejecutarConsulta(consultaSQL);
            gvSeleccionar.DataBind();
        }
    }
}