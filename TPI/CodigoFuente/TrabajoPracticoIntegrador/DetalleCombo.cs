using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    class DetalleCombo
    {
        public int codigoCombo { get; set; }
        public string nombreCombo { get; set; }
        public decimal descuento { get; set; }
        public bool disponibilidadCombo { get; set; }//Si al menos 1 producto esta dado de baja, el combo no esta disponible.
        //public List<Producto> nombreProductos { get; set; }
        public string descripcion { get; set; }
        public decimal precioUnitarioCombo { get; set; }
        public int cantidadActualCombo { get; set; }

        public DetalleCombo(int codigoCombo, string nombreCombo, decimal descuento, bool disponibilidadCombo, 
            string descripcion, decimal precioUnitarioCombo, int cantidadActualCombo)
        {
            this.codigoCombo = codigoCombo;
            this.nombreCombo = nombreCombo;
            this.descuento = descuento;
            this.disponibilidadCombo = disponibilidadCombo;
            //this.nombreProductos = nombreProductos;
            this.descripcion = descripcion;
            this.precioUnitarioCombo = precioUnitarioCombo;
            this.cantidadActualCombo = cantidadActualCombo;
        }
    }
}
