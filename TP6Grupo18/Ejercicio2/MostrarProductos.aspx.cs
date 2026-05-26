using System;
using System.Data;

namespace TP6Grupo18.Ejercicio2 {
    public partial class MostrarProductos : System.Web.UI.Page {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["tabla"] != null) {
                    gvProductos.DataSource = (DataTable)Session["tabla"];
                    gvProductos.DataBind();
                }
            }
        }
    }
}