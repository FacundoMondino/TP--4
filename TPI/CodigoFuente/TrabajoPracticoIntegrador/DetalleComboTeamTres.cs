using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    public class DetalleComboTeamTres
    {
        public int CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int CantidadActual { get; set; }
        public int cantidadActualCombo { get; set; }
        public bool DisponibilidadComboALaVenta { get; set; }
        public DateTime? fechaInicioOferta { get; set; }
        public DateTime? fechaCierreOferta { get; set; }
        public bool estaEnOferta { get; set; }
        public decimal? descuentoPorOferta { get; set; }
        public decimal? descuentoRangoDosACinco { get; set; }
        public decimal? descuentoRangoSeisADiez { get; set; }
        public decimal? descuentoRangoDiezOMas { get; set; }

        public DetalleComboTeamTres(int CodigoProducto, string Descripcion, decimal PrecioUnitario, 
            int CantidadActual, int cantidadActualCombo, bool DisponibilidadComboALaVenta, DateTime? fechaInicioOferta, DateTime? fechaCierreOferta, 
            bool estaEnOferta, decimal? descuentoPorOferta, decimal? descuentoRangoDosACinco,
            decimal? descuentoRangoSeisADiez, decimal? descuentoRangoDiezOMas)
        {
            this.CodigoProducto = CodigoProducto;
            this.Descripcion = Descripcion;
            this.PrecioUnitario = PrecioUnitario;
            this.CantidadActual = CantidadActual;
            this.cantidadActualCombo = cantidadActualCombo;
            this.DisponibilidadComboALaVenta = DisponibilidadComboALaVenta;
            this.fechaInicioOferta = fechaInicioOferta;
            this.fechaCierreOferta = fechaCierreOferta;
            this.estaEnOferta = estaEnOferta;
            this.descuentoPorOferta = descuentoPorOferta;
            this.descuentoRangoDosACinco = descuentoRangoDosACinco;
            this.descuentoRangoSeisADiez = descuentoRangoSeisADiez;
            this.descuentoRangoDiezOMas = descuentoRangoDiezOMas;
        }
    }
}
