using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    public class RepositorioGlobal
    {
        public static List<Producto> productos = new List<Producto>();
        public static List<DetalleCombo> combos = new List<DetalleCombo>();
        public static List<Producto> productosParaCombo = new List<Producto>();
        public static List<ProductoTeamDos> productoTeamDos = new List<ProductoTeamDos>();
        public static List<ProductoTeamTres> productoTeamTres = new List<ProductoTeamTres>();
        public static List<ProductoTeamCinco> productoTeamCinco = new List<ProductoTeamCinco>();
        public static List<DetalleComboTeamDos> detalleComboTeamDos = new List<DetalleComboTeamDos>();
    }
}