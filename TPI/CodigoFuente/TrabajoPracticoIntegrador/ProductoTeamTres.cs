using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    class ProductoTeamTres
    {
        public int CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int CantidadActual { get; set; }
        public bool Disponible { get; set; }
        public decimal? precioRangoDosACinco { get; set; }
        public decimal? precioRangoSeisADiez { get; set; }
        public decimal? precioRangoDiezOMas { get; set; }
        public bool estaEnOferta { get; set; }
        public decimal? precioDeOferta { get; set; }
        public DateTime? fechaInicioOferta { get; set; }
        public DateTime? fechaCierreOferta { get; set; }

        public ProductoTeamTres(int CodigoProducto, string Descripcion, decimal PrecioUnitario,
            int CantidadActual, bool Disponible, decimal? precioRangoDosACinco, decimal? precioRangoSeisADiez, 
            decimal? precioRangoDiezOMas, bool estaEnOferta, decimal? precioDeOferta, DateTime? fechaInicioOferta, 
            DateTime? fechaCierreOferta)
        {
            this.CodigoProducto = CodigoProducto;
            this.Descripcion = Descripcion;
            this.PrecioUnitario = PrecioUnitario;
            this.CantidadActual = CantidadActual;
            this.Disponible = Disponible;
            this.precioRangoDosACinco = precioRangoDosACinco;
            this.precioRangoSeisADiez = precioRangoSeisADiez;
            this.precioRangoDiezOMas = precioRangoDiezOMas;
            this.estaEnOferta = estaEnOferta;
            this.precioDeOferta = precioDeOferta;
            this.fechaInicioOferta = fechaInicioOferta;
            this.fechaCierreOferta = fechaCierreOferta;
        }
    }
}