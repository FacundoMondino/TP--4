using System;
using Xunit;
using TrabajoPracticoIntegrador;
using System.Linq;
using Newtonsoft.Json;

namespace TestProject1
{
    public class TestUnitario
    {
        [Fact]
        public void PruebaListaProductos()
        {
            Assert.NotNull(RepositorioGlobal.productos);
        }
        [Fact]
        public void PruebaListaCombos()
        {
            Assert.NotNull(RepositorioGlobal.combos);
        }
        [Fact]
        public void ElProductoEstaDadoDeBaja()
        {
            Producto productoTestUnit = new Producto(1, "cat1", "mod1", "tam1", "col1", DateTime.Now, false, "nom1", "desc1", 1000, 0, false, 1200, 950, 930, false, null, null, null, null);
            RepositorioGlobal.productos.Add(productoTestUnit);

            foreach (var productoActual in RepositorioGlobal.productos)
            {
                if (productoActual.cantidadActual < 1)
                {
                    productoActual.EstadoActual = true;
                }
                Assert.True(productoActual.EstadoActual);
            }
        }
        [Fact]
        public void ElProductoEsDisponibleParaVenta()
        {
            Producto productoTestUnit = new Producto(1, "cat1", "mod1", "tam1", "col1", DateTime.Now, false, "nom1", "desc1", 1000, 66, false, 1200, 950, 930, false, null, null, null, null);
            RepositorioGlobal.productos.Add(productoTestUnit);

            bool resultado = false;

            foreach (var productoActual in RepositorioGlobal.productos)
            {
                if (productoActual.cantidadActual > 0)
                {
                    resultado = true;
                }
                Assert.True(resultado);
            }
        }
        [Fact]
        public void ElProductoTieneOferta()
        {
            Producto productoTestUnit = new Producto(1, "cat1", "mod1", "tam1", "col1", DateTime.Now, false, "nom1", "desc1", 1000, 66, false, 1200, 950, 930, false, null, null, null, null);
            RepositorioGlobal.productos.Add(productoTestUnit);

            bool resultado = false;

            foreach (var productoActual in RepositorioGlobal.productos)
            {
                if (productoActual.estaEnOferta == true)
                {
                    resultado = true;
                }
                Assert.False(resultado);//falla, nunaca setea el valor.
            }
        }
        [Fact]
        public void ElComboEstaDisponible()
        {
            DetalleCombo comboTestUnitario = new DetalleCombo(160, "nom1", 0.20M, true, "descr1", 1000.20M, 9);
            RepositorioGlobal.combos.Add(comboTestUnitario);

            bool resultado = false;

            foreach (var comboActual in RepositorioGlobal.combos)
            {
                if (comboActual.disponibilidadCombo == true)
                {
                    resultado = true;
                }
            }
            Assert.True(resultado);
        }
        [Fact]
        public void EsCorrectoElDescuentoPorOferta()
        {
            Producto productoTestUnit = new Producto(1, "cat1", "mod1", "tam1", "col1", DateTime.Now, false, "nom1", "desc1", 1000.30M, 66, false, 1200, 950, 930, true, "oferta1", 900.27M, DateTime.Now, DateTime.Now);
            RepositorioGlobal.productos.Add(productoTestUnit);

            const decimal descuentoPorOferta = 0.10M;//falla para cualquier valor de descuento que no es usado para el calculo en la clase RegistroGlobal;
            foreach (var productoActual in RepositorioGlobal.productos)
            {
                decimal precioParaOferta = productoActual.precioUnitario - (productoActual.precioUnitario * descuentoPorOferta);
                decimal? precioOfertaCalculadoEnRegistro = productoActual.precioDeOferta;
                Assert.Equal(precioParaOferta, precioOfertaCalculadoEnRegistro);
            }
        }
        [Fact]
        public void EsCorrectoElPrecioRangoDosACinco()
        {
            Producto productoTestUnit = new Producto(1, "cat1", "mod1", "tam1", "col1", DateTime.Now, false, "nom1", "desc1", 1000.30M, 66, false, 970.291M, 950.285M, 930.279M, true, "oferta1", 700.21M, DateTime.Now, DateTime.Now);
            RepositorioGlobal.productos.Add(productoTestUnit);

            const decimal descuentorRangoDosACinco = 0.04M;//Si se utiliza el descuento que se empleo para el calculo en la clase RegistroGlobal (0.03M) pasa la prueba.
            decimal precioConOfertaParaDosACinco;
            foreach (var productoActual in RepositorioGlobal.productos)
            {
                decimal precioParaDosACinco = productoActual.precioUnitario - (productoActual.precioUnitario * descuentorRangoDosACinco);
                precioConOfertaParaDosACinco = productoActual.precioRangoDosACinco;
                Assert.Equal(precioParaDosACinco, precioConOfertaParaDosACinco);
            }
        }
        [Fact]
        public void EsCorrectoElPrecioRangoSeisADiez()
        {
            Producto productoTestUnit = new Producto(1, "cat1", "mod1", "tam1", "col1", DateTime.Now, false, "nom1", "desc1", 1000.30M, 66, false, 970.291M, 950.285M, 930.279M, true, "oferta1", 700.21M, DateTime.Now, DateTime.Now);
            RepositorioGlobal.productos.Add(productoTestUnit);

            const decimal descuento = 0.05M;//falla para cualquier valor de descuento que no es usado para el calculo en la clase RegistroGlobal;
            decimal precioConOfertaParaSeisADiez;
            foreach (var productoActual in RepositorioGlobal.productos)
            {
                decimal precioParaSeisADiez = productoActual.precioUnitario - (productoActual.precioUnitario * descuento);
                precioConOfertaParaSeisADiez = productoActual.precioRangoSeisADiez;
                Assert.Equal(precioParaSeisADiez, precioConOfertaParaSeisADiez);
            }
        }
        [Fact]
        public void EsCorrectoElPrecioRangoDiez0Mas()
        {
            Producto productoTestUnit = new Producto(1, "cat1", "mod1", "tam1", "col1", DateTime.Now, false, "nom1", "desc1", 1000.30M, 66, false, 970.291M, 950.285M, 930.279M, true, "oferta1", 700.21M, DateTime.Now, DateTime.Now);
            RepositorioGlobal.productos.Add(productoTestUnit);

            const decimal descuento = 0.09M;//Si se utiliza el descuento que se empleo para el calculo en la clase RegistroGlobal (0.07M) pasa la prueba.
            decimal precioConOfertaParaDiezOMas;
            foreach (var productoActual in RepositorioGlobal.productos)
            {
                decimal precioParaDiezOMas = productoActual.precioUnitario - (productoActual.precioUnitario * descuento);
                precioConOfertaParaDiezOMas = productoActual.precioRangoDiezOMas;
                Assert.Equal(precioParaDiezOMas, precioConOfertaParaDiezOMas);
            }
        }
    }
}
