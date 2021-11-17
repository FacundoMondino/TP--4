using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    public class Producto
    {
        public int codigoProducto {get; set;}
        public string nombre { get; set; }
        public DateTime fechaIngreso { get; set; }
        public bool EstadoActual { get; set; }//Estad actual = false si esta vigente, true si esta dado de baja.
        public string descripcion { get; set; }
        public string modelo { get; set; }
        public string tamaño { get; set; }
        public string color { get; set; }
        public decimal precioUnitario { get; set; }
        public int cantidadActual { get; set; }
        public bool disponible { get; set; }
        public string categoria { get; set; }
        public decimal precioRangoDosACinco { get; set; }
        public decimal precioRangoSeisADiez { get; set; }
        public decimal precioRangoDiezOMas { get; set; }
        public DateTime? fechaInicioOferta { get; set; }
        public DateTime? fechaCierreOferta { get; set; }
        public string descripcionOferta { get; set; }
        public bool estaEnOferta { get; set; }
        public decimal? precioDeOferta { get; set; }
        public Producto(int codigoProducto, string categoria, string modelo, string tamaño, string color,
            DateTime fechaIngreso, bool EstadoActual, string nombre, string descripcion, decimal precioUnitario,
            int cantidadActual, bool disponible, decimal precioRangoDosACinco, decimal precioRangoSeisADiez,
            decimal precioRangoDiezOMas, bool estaEnOferta, string descripcionOferta, decimal? precioDeOferta,
            DateTime? fechaCierreOferta, DateTime? fechaInicioOferta)
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
            this.precioRangoDosACinco = precioRangoDosACinco;
            this.precioRangoSeisADiez = precioRangoSeisADiez;
            this.precioRangoDiezOMas = precioRangoDiezOMas;
            this.estaEnOferta = estaEnOferta;
            this.descripcionOferta = descripcionOferta;
            this.precioDeOferta = precioDeOferta;
            this.fechaCierreOferta = fechaCierreOferta;
            this.fechaInicioOferta = fechaInicioOferta;
        }
    }
}