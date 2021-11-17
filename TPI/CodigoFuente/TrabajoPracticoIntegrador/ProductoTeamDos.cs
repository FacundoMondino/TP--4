using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    public class ProductoTeamDos
    {
        public int codProducto { get; set; }
        public string nomProducto { get; set; }
        public decimal precio { get; set; }
        public string desc { get; set; }
        public string  color { get; set; }
        public int stockProducto { get; set; }
        public string categoria { get; set; }
        public decimal? precioDosCinco { get; set; }
        public decimal? precioSeisDiez { get; set; }
        public decimal? precioDiezMas { get; set; }
        public bool estaOferta { get; set; }
        public string desOferta { get; set; }
        public decimal? precioOferta{ get; set; }
        public DateTime? fechaInOferta{ get; set; }
        public DateTime? fechaFinOferta { get; set; }
        public ProductoTeamDos(int codProducto, string nomProducto, decimal precio, string desc, string color,
           int stockProducto, string categoria, decimal? precioDosCinco, decimal? precioSeisDiez, 
           decimal? precioDiezMas, bool estaOferta, string desOferta, decimal? precioOferta,
           DateTime? fechaInOferta, DateTime? fechaFinOferta)
        {
            this.codProducto = codProducto;
            this.nomProducto = nomProducto;
            this.precio = precio;
            this.desc = desc;
            this.color = color;
            this.stockProducto = stockProducto;
            this.categoria = categoria;
            this.precioDosCinco = precioDosCinco;
            this.precioSeisDiez = precioSeisDiez;
            this.precioDiezMas = precioDiezMas;
            this.estaOferta = estaOferta;
            this.desOferta = desOferta;
            this.precioOferta = precioOferta;
            this.fechaInOferta = fechaInOferta;
            this.fechaFinOferta = fechaFinOferta;
        }
    }
}