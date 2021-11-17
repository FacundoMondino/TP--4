using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace TrabajoPracticoIntegrador
{
    public class RegistroGlobal
    {
        public static void RegistrarProducto()
        {
            int codigoProducto;
            bool codigoConNumeroEntero;
            bool estaDisponibleParaVenta = true;
            bool estaDadoDeBaja = true;
            bool estaEnOferta = true;
            decimal descuentoOferta;
            decimal? precioDeOferta = null;
            DateTime? fechaInicioOferta = null;
            DateTime? fechaCierreOferta = null;
            string descripcionOferta = "";
            int decisionParaOferta;
            Console.WriteLine("\n--Usted selecciono la opcion para registrar un producto--");


            do
            {
                Console.WriteLine("\nIngrese el codigo:\n");
                codigoConNumeroEntero = int.TryParse(Console.ReadLine(), out codigoProducto);
                if(!codigoConNumeroEntero)
                {
                    Console.WriteLine("\n--El codigo del producto ingresado corresponde a un tipo de dato no entero--\n");
                }
                if (codigoProducto < 0)
                {
                    Console.WriteLine("\n--El codigo del producto ingresado corresponde a un entero negativo--\n");
                }
            } while (!codigoConNumeroEntero || codigoProducto < 0);

            Console.WriteLine("\nIngrese el nombre:\n");
            string nombreProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese la categoria:\n");
            string categoriaPrdoucto = Console.ReadLine();

            Console.WriteLine("\nIngrese el modelo:\n");
            string modeloProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese el tamaño:\n");
            string tamañoProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese el color:\n");
            string colorProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese la descripcion:\n");
            string descripcionProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese la fecha de ingreso:\n");
            DateTime fechaIngresoProducto = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la cantidad de unidades en stock:\n");
            int cantidadActualDeProducto = int.Parse(Console.ReadLine());
            
            Console.WriteLine("\nIngrese el precio unitario:\n");
            decimal precioUnitarioProducto = decimal.Parse(Console.ReadLine());

            if (cantidadActualDeProducto > 0)
            {
                estaDisponibleParaVenta = true;
                estaDadoDeBaja = false;//es el atributo estadoActual en Producto;
            }
            if (cantidadActualDeProducto < 0)
            {
                estaDisponibleParaVenta = false;//es el atributo disponible en Producto;
            }

            decimal precioRangoDosACinco = precioUnitarioProducto - (precioUnitarioProducto * 0.03M);

            decimal precioRangoSeisADiez = precioUnitarioProducto - (precioUnitarioProducto * 0.05M);

            decimal precioRangoDiezOMas = precioUnitarioProducto - (precioUnitarioProducto * 0.07M);

            do
            {
                Console.WriteLine("\nDesea que el producto actual este en oferta?\n");
                Console.WriteLine("Elija una opcion:");
                Console.WriteLine("1-SI");
                Console.WriteLine("2-NO");
                decisionParaOferta = int.Parse(Console.ReadLine());
                
            } while (decisionParaOferta != 1 && decisionParaOferta != 2);
            
            if (decisionParaOferta == 1)
            {
                Console.WriteLine("\nIngrese el motivo de la oferta:\n");
                descripcionOferta = Console.ReadLine();

                Console.WriteLine("\nIngrese la fecha que indique el inicio de la oferta\n");
                fechaInicioOferta = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\nIngrese la fecha que indique el limite de vigencia de la oferta\n");
                fechaCierreOferta = DateTime.Parse(Console.ReadLine());

                do
                {
                    Console.WriteLine("\nIngrese de descuento para aplicarle al calculo del precio de la oferta:  FORMATO EJEMPLO: 0,10\n");
                    descuentoOferta = Decimal.Parse(Console.ReadLine());
                } while (descuentoOferta <= 0.00M);
                
                precioDeOferta = precioUnitarioProducto - (precioUnitarioProducto * descuentoOferta);

                Producto nuevoProducto = new Producto(codigoProducto, categoriaPrdoucto, modeloProducto, tamañoProducto, colorProducto, fechaIngresoProducto, estaDadoDeBaja, nombreProducto, descripcionProducto, precioUnitarioProducto, cantidadActualDeProducto, estaDisponibleParaVenta, precioRangoDosACinco, precioRangoSeisADiez, precioRangoDiezOMas, estaEnOferta, descripcionOferta, precioDeOferta, fechaCierreOferta, fechaInicioOferta);
                RepositorioGlobal.productos.Add(nuevoProducto);
            }
            else if(decisionParaOferta == 2)
            {
                estaEnOferta = false;

                Producto nuevoProducto = new Producto(codigoProducto, categoriaPrdoucto, modeloProducto, tamañoProducto, colorProducto, fechaIngresoProducto, estaDadoDeBaja, nombreProducto, descripcionProducto, precioUnitarioProducto, cantidadActualDeProducto, estaDisponibleParaVenta, precioRangoDosACinco, precioRangoSeisADiez, precioRangoDiezOMas, estaEnOferta, descripcionOferta, precioDeOferta, fechaCierreOferta, fechaInicioOferta);
                RepositorioGlobal.productos.Add(nuevoProducto);
            }
        }
        public static void RegistrarCombo()
        {
            int opcion;
            bool codigoComboConNumeroEntero;
            bool estaDisponible = true;
            decimal sumaDePreciosDeCadaCombo = 0;
            string productosAñadidos = "";
            decimal descuentoCombo;
            int cantidadActualCombo;
            int codigoCombo;
        
            RepositorioGlobal.productosParaCombo.Clear();

            Console.WriteLine("\n--Usted selecciono la opcion para registrar un combo--");
            do
            {
                Console.WriteLine("\nIngrese el codigo:\n");
                codigoComboConNumeroEntero = int.TryParse(Console.ReadLine(), out codigoCombo);

                if (!codigoComboConNumeroEntero)
                {
                    Console.WriteLine("\n--El codigo del combo ingresado corresponde a un tipo de dato no entero--\n");
                }
                if(codigoCombo < 0)
                {
                    Console.WriteLine("\n--El codigo del combo ingresado corresponde a un entero negativo--\n");
                }
            } while (!codigoComboConNumeroEntero || codigoCombo < 0);

            Console.WriteLine("\nIngrese el nombre:\n");
            string nombreCombo = Console.ReadLine();
           
            do
            {
                Console.WriteLine("\nIngrese el codigo del producto que desea añadir:\n");
                int codigoProductoParaCombo = int.Parse(Console.ReadLine());

                foreach (var valorActual in RepositorioGlobal.productos)
                {
                    if(valorActual.codigoProducto == codigoProductoParaCombo)
                    {
                        if (valorActual.cantidadActual > 0 && valorActual.EstadoActual == false)
                        {
                            estaDisponible = true;
                            productosAñadidos = $"{productosAñadidos}{valorActual.nombre}  ";
                            RepositorioGlobal.productosParaCombo.Add(valorActual);
                        }
                        else
                        {
                            Console.WriteLine("--El producto ingresado no cumple con las condiciones para añadirlo a combo--");
                        } 
                    }
                }

                do
                {
                    Console.WriteLine("\n-Ingrese 1 para continuar agregando produtos a combo\n");
                    Console.WriteLine("\n-Ingrese 2 si no se desea agregar mas productos a combo\n");
                    opcion = int.Parse(Console.ReadLine());

                } while (opcion != 1 && opcion != 2);

            } while (opcion == 1);
            do
            {
                Console.WriteLine("\nIngrese el descuento: FORMATO EJEMPLO: 0,10\n");
                descuentoCombo = decimal.Parse(Console.ReadLine());

            } while (descuentoCombo == 0.00M);

            foreach (var item in RepositorioGlobal.productosParaCombo)
            {
                sumaDePreciosDeCadaCombo = sumaDePreciosDeCadaCombo + item.precioUnitario;
            }

            decimal precioUnitarioCombo = sumaDePreciosDeCadaCombo - (sumaDePreciosDeCadaCombo * descuentoCombo);

            do
            {
                Console.WriteLine("\nIngrese la cantidad actual de unidades de combo que hay en stock:\n");
                cantidadActualCombo = int.Parse(Console.ReadLine());
            } while (cantidadActualCombo < 0);

            DetalleCombo nuevoCombo = new DetalleCombo(codigoCombo, nombreCombo, descuentoCombo, estaDisponible,
                productosAñadidos, precioUnitarioCombo, cantidadActualCombo);
            RepositorioGlobal.combos.Add(nuevoCombo);
        }
        public static void ActualizarStock()
        {
            Console.WriteLine("\n--Usted selecciono la opcion para actualizar el stock de un producto--");

            Console.WriteLine("\nIngrese el codigo del producto para actualizar su stock:\n");
            int codigoProductoAcambiarSrock = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la cantidad de unidades de stock a agregar:\n");
            int cantidadAAgregar = int.Parse(Console.ReadLine());

            foreach (var item in RepositorioGlobal.productos)
            {
                if(item.codigoProducto == codigoProductoAcambiarSrock)
                {
                    item.cantidadActual = item.cantidadActual + cantidadAAgregar;
                    if (item.cantidadActual <= 0)
                    {
                        item.disponible = false;//producto sin stock.
                        item.EstadoActual = true;//producto dado de baja. False indica que está no esta dado de baja, es decir que hay stock cargado.
                    }
                }
            }
            foreach (var valorListaCombo in RepositorioGlobal.combos)
            {
                foreach (var valorListaProductosParaCombo in RepositorioGlobal.productosParaCombo)
                {
                    if (valorListaProductosParaCombo.codigoProducto == codigoProductoAcambiarSrock)
                    {
                        if (valorListaProductosParaCombo.cantidadActual <= 0)
                        {
                            valorListaCombo.disponibilidadCombo = false;//Combo no disponible.
                        }
                    }
                }
            }
        }
        public static void RegistrarBajaDelProducto()
        {
            Console.WriteLine("\n--Usted selecciono la opcion para registrar la baja de un producto--");
            Console.WriteLine("\nIngrese el codigo del producto para registrar la baja del producto:\n");

            int codigoProductoParaDarBaja = int.Parse(Console.ReadLine());

            foreach (var valorListaCombo in RepositorioGlobal.combos)
            {
                valorListaCombo.disponibilidadCombo = true;

                foreach (var valorListaProductosParaCombo in RepositorioGlobal.productosParaCombo)
                {
                    if (valorListaProductosParaCombo.codigoProducto == codigoProductoParaDarBaja)
                    {
                        valorListaProductosParaCombo.EstadoActual = true;//Producto dado de baja.
                        valorListaCombo.disponibilidadCombo = false;//Combo dado de baja.
                        Console.WriteLine("\n--Se dio de baja el producto ingresado--\n");
                    }
                }
            }
        }
        public static void CrearJsonProductoTeamDos()
        {
            foreach (var valorActual in RepositorioGlobal.productos)
            {
                int codProducto = valorActual.codigoProducto;
                string nomProducto = valorActual.nombre;
                decimal precio = valorActual.precioUnitario;
                string desc = valorActual.descripcion;
                string color = valorActual.color;
                int stockProducto = valorActual.cantidadActual;
                string categoria = valorActual.categoria;
                decimal? precioDosCinco = valorActual.precioRangoDosACinco;
                decimal? precioSeisDiez = valorActual.precioRangoSeisADiez;
                decimal? precioDiezMas = valorActual.precioRangoDiezOMas;
                bool estaOferta = valorActual.estaEnOferta;
                string desOferta = valorActual.descripcionOferta;
                decimal? precioOferta = valorActual.precioDeOferta;
                DateTime? fechaInOferta = valorActual.fechaInicioOferta;
                DateTime? fechaFinOferta = valorActual.fechaCierreOferta;

                ProductoTeamDos productoTeamDos = new ProductoTeamDos(codProducto, nomProducto, precio, desc, color, stockProducto,
                    categoria, precioDosCinco, precioSeisDiez, precioDiezMas, estaOferta, desOferta,
                    precioOferta, fechaInOferta, fechaFinOferta);
                RepositorioGlobal.productoTeamDos.Add(productoTeamDos);
            }
            Console.WriteLine("\n--Se creo correctamente el JSON de Producto para el team dos--\n");
        }
        public static void CrearJsonProductoTeamTres()
        {
            foreach (var valorActual in RepositorioGlobal.productos)
            {
                int codigoProducto = valorActual.codigoProducto;
                string descripcion = valorActual.descripcion;
                decimal precioUnitario = valorActual.precioUnitario;
                int cantidadActual = valorActual.cantidadActual;
                bool disponible = valorActual.disponible;
                DateTime? fechaInicioOferta = valorActual.fechaInicioOferta;
                DateTime? fechaCierreOferta = valorActual.fechaCierreOferta;
                bool estaEnOferta = valorActual.estaEnOferta;
                decimal? descuentoPorOferta = 0.10M;
                decimal descuentoRangoDosACinco = 0.03M;
                decimal descuentoRangoSeisADiez = 0.05M;
                decimal descuentoRangoDiezOMas = 0.07M;

                ProductoTeamTres productoTeamTres = new ProductoTeamTres(codigoProducto, descripcion, precioUnitario, cantidadActual, disponible, fechaInicioOferta, fechaCierreOferta, estaEnOferta, descuentoPorOferta, descuentoRangoDosACinco, descuentoRangoSeisADiez, descuentoRangoDiezOMas);
                RepositorioGlobal.productoTeamTres.Add(productoTeamTres);
            }
            foreach (var item in RepositorioGlobal.combos)
            {
                int codigoProducto = item.codigoCombo;
                decimal precioUnitario = item.precioUnitarioCombo;
                string descripcion = item.descripcion;
                int cantidadActual = item.cantidadActualCombo;
                bool disponible = item.disponibilidadCombo;
                DateTime? fechaInicioOferta = null;
                DateTime? fechaCierreOferta = null;
                bool estaEnOferta = false;
                decimal? precioDeOferta = null;
                decimal? precioRangoDosACinco = null;
                decimal? precioRangoSeisADiez = null;
                decimal? precioRangoDiezOMas = null;
                
                ProductoTeamTres detalleComboTeamTres = new ProductoTeamTres(codigoProducto, descripcion, precioUnitario, cantidadActual, disponible, fechaInicioOferta, fechaCierreOferta, estaEnOferta, precioDeOferta, precioRangoDosACinco, precioRangoSeisADiez, precioRangoDiezOMas);
                RepositorioGlobal.productoTeamTres.Add(detalleComboTeamTres);
            }
            Console.WriteLine("\n--Se creo correctamente el JSON de Producto para el team tres--\n");
        }
        public static void CrearJsonProductoTeamCinco()
        {
            foreach (var valorActual in RepositorioGlobal.productos)
            {
                string nombreProducto = valorActual.nombre;
                string descripcion = valorActual.descripcion;
                decimal precioUnitario = valorActual.precioUnitario;

                ProductoTeamCinco productoTeamCinco = new ProductoTeamCinco(nombreProducto, descripcion, precioUnitario);
                RepositorioGlobal.productoTeamCinco.Add(productoTeamCinco);
            }
            Console.WriteLine("\n--Se creo correctamente el JSON de Producto para el team cinco--\n");
        }
        public static void CrearJsonDetalleComboTeamDos()
        {
            foreach (var valorActual in RepositorioGlobal.combos)
            {
                int codigoProducto = valorActual.codigoCombo;
                string nombreProducto = valorActual.nombreCombo;
                decimal precioUnitario = valorActual.precioUnitarioCombo;
                string descripcionCombo = valorActual.descripcion;
                int cantidadActual = valorActual.cantidadActualCombo;

                DetalleComboTeamDos detalleComboTeamDos = new DetalleComboTeamDos(codigoProducto, nombreProducto, precioUnitario, descripcionCombo, cantidadActual);
                RepositorioGlobal.detalleComboTeamDos.Add(detalleComboTeamDos);
            }
            Console.WriteLine("\n--Se creo correctamente el JSON de Combo para el team dos--\n");
        }
    }
}