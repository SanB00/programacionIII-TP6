using System;
using System.Data;
using System.Web.UI.WebControls;

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
        protected void gvSeleccionar_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gvSeleccionar.PageIndex = e.NewPageIndex;
            cargaGridView();
        }
        protected void gvSeleccionar_SelectedIndexChanged(object sender, EventArgs e) {
            string idProducto = ((Label)gvSeleccionar.SelectedRow.FindControl("lbl_it_idProdu")).Text;
            string nombreProducto = ((Label)gvSeleccionar.SelectedRow.FindControl("lb_it_NombreProd")).Text;
            string idProveedor = ((Label)gvSeleccionar.SelectedRow.FindControl("lb_it_Prov")).Text;
            string precioUnidad = ((Label)gvSeleccionar.SelectedRow.FindControl("lb_it_PrecioU")).Text;

            if (Session["tabla"] == null) {
                Session["tabla"] = crearTabla();
            }
            
            DataTable tablaSession = (DataTable)Session["tabla"];

            agregarFila(tablaSession, idProducto, nombreProducto, idProveedor, precioUnidad);

            lblSelect.Text = "Artículo agregado: " + nombreProducto;
        }
        private DataTable crearTabla() {
            DataTable dataTable = new DataTable();

            DataColumn dataColumn = new DataColumn("IdProducto", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("NombreProducto", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("IdProveedor", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("PrecioUnidad", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);

            return dataTable;
        }

        private DataTable agregarFila(DataTable dataTable, string idProducto, string nombreProducto, string idProveedor, string precioUnidad) {
            DataRow dataRow = dataTable.NewRow();

            dataRow["IdProducto"] = idProducto;
            dataRow["NombreProducto"] = nombreProducto;
            dataRow["IdProveedor"] = idProveedor;
            dataRow["PrecioUnidad"] = precioUnidad;

            dataTable.Rows.Add(dataRow);

            return dataTable;
        }


    }

}