using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6Grupo18.Ejercicio1 {
    public partial class ClaseProducto : System.Web.UI.Page {
        public class Producto {
            private int idProducto;
            private string nombreProducto;
            private int cantidadPorUnidad;
            private float precioUnidad;

            public Producto() {

            }

            public Producto(int idProducto, string nombreProducto, int cantidadPorUnidad, float precioUnidad) {
                this.idProducto = idProducto;
                this.nombreProducto = nombreProducto;
                this.cantidadPorUnidad = cantidadPorUnidad;
                this.precioUnidad = precioUnidad;
            }

            public int IdProducto {
                get { return idProducto; }
                set { idProducto = value; }
            }

            public string NombreProducto {
                get { return nombreProducto; }
                set { nombreProducto = value; }
            }

            public int CantidadPorUnidad {
                get { return cantidadPorUnidad; }
                set { cantidadPorUnidad = value; }
            }

            public float PrecioUnidad {
                get { return precioUnidad; }
                set { precioUnidad = value; }
            }
        }
    }
}