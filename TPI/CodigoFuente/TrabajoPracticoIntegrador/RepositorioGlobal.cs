using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    class RepositorioGlobal
    {
        public static List<Producto> productos = new List<Producto>();
        public static List<DetalleCombo> combos = new List<DetalleCombo>();
        public static List<Producto> productosParaCombo = new List<Producto>();
    }
}