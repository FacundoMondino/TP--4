using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    class ProductoTeamDos
    {
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public string  Color { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }

        public ProductoTeamDos(int CodigoProducto, string NombreProducto, decimal Precio, string Descripcion, string Color, int Stock, string Categoria)
        {
            this.CodigoProducto = CodigoProducto;
            this.NombreProducto = NombreProducto;
            this.Precio = Precio;
            this.Descripcion = Descripcion;
            this.Color = Color;
            this.Stock = Stock;
            this.Categoria = Categoria;
        }
    }
}
