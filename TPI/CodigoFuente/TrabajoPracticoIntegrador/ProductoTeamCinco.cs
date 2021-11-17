using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    public class ProductoTeamCinco
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public ProductoTeamCinco(string Nombre, string Descripcion, decimal Precio)
        {
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Precio = Precio;
        }
    }
}