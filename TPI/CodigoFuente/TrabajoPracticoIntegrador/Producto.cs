using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    class Producto
    {
        public int codigoProducto {get; set;}
        public string nombre { get; set; }
        public DateTime fechaIngreso { get; set; }
        public bool EstadoActual { get; set; }//Estad actual = false si esta vigente, true si esta dado de baja.
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public double tamaño { get; set; }
        public string color { get; set; }
        public decimal precioUnitario { get; set; }
        public int cantidadActual { get; set; }
        public bool disponible { get; set; }
        public string categoria { get; set; }

        public Producto(int codigoProducto, string categoria, string modelo, double tamaño, string color, DateTime fechaIngreso, bool EstadoActual, string nombre, string descripcion, decimal precioUnitario, int cantidadActual, bool disponible)
        {
            this.codigoProducto = codigoProducto;
            this.categoria = categoria;
            this.modelo = modelo;
            this.tamaño = tamaño;
            this.color = color;
            this.nombre = nombre;
            this.fechaIngreso = fechaIngreso;
            this.EstadoActual = EstadoActual;//Indica si el producto esta dado de baja o no.
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            this.cantidadActual = cantidadActual;
            this.disponible = disponible;//Indica si el producto tiene o no stock.
        }
    }
}