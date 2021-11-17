using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    public class DetalleComboTeamDos
    {
        public int CodigoCombo { get; set; }
        public string NombreCombo { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }

        public DetalleComboTeamDos(int CodigoCombo, string NombreCombo, decimal Precio,string Descripcion,  int Stock)
        {
            this.CodigoCombo = CodigoCombo;
            this.NombreCombo = NombreCombo;
            this.Precio = Precio;
            this.Descripcion = Descripcion;
            this.Stock = Stock;
        }
    }
}