namespace TP6Grupo18
{
    public class Sucursal
    {
        private string id;
        private string nombre;
        private string descripcion;
        private string direccion;
        private string idProvincia;

        public Sucursal(string id, string nombre, string descripcion, string direccion, string idProvincia) {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.direccion = direccion;
            this.idProvincia = idProvincia;
        }

        public string getId() { return id; }
        public string getNombre() { return nombre; }
        public string getDescripcion() { return descripcion; }
    }
}