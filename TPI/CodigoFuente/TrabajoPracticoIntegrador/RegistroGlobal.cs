using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace TrabajoPracticoIntegrador
{
    class RegistroGlobal
    {
        public static void RegistrarProducto()
        {
            bool disponibilidadProducto = false;

            Console.WriteLine("\nCARGA DE DATOS DE UN PRODUCTO");

            Console.WriteLine("\nIngrese el codigo:\n");
            int codigoProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la categoria:\n");
            string categoriaPrdoucto = Console.ReadLine();

            Console.WriteLine("\nIngrese el modelo:\n");
            string modeloProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese el tamaño:\n");
            double tamañoProducto = double.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el color:\n");
            string colorProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese la fecha de ingreso:\n");
            DateTime fechaIngresoProducto = DateTime.Parse(Console.ReadLine());

            bool EstadoActualProducto = true;//Por defecto esta dado de baja, es decir que no haya stock cargado.

            Console.WriteLine("\nIngrese el nombre:\n");
            string nombreProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese la descripcion:\n");
            string descripcionProducto = Console.ReadLine();

            Console.WriteLine("\nIngrese el precio unitario:\n");
            decimal precioUnitarioProducto = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la cantidad de unidades en stock:\n");
            int cantidadActualDeProducto = int.Parse(Console.ReadLine());

            if(cantidadActualDeProducto > 0)
            {
                disponibilidadProducto = true;
                //EstadoActualProducto indica la vigencia del producto, si esta dado de baja o no.
                //False indica que está no esta dado de baja, es decir que hay stock cargado.
                EstadoActualProducto = false;
            }

            Producto nuevoProducto = new Producto(codigoProducto, categoriaPrdoucto, modeloProducto, tamañoProducto, colorProducto, fechaIngresoProducto, EstadoActualProducto, nombreProducto, descripcionProducto, precioUnitarioProducto, cantidadActualDeProducto, disponibilidadProducto);
            RepositorioGlobal.productos.Add(nuevoProducto);
        }
        public static void RegistrarCombo()
        {
            int opcion;
            bool disponibilidadDelCombo = true;//true = combo disponible; false = combo no disponible por falta de stock.
            decimal sumaDePreciosDeCadaCombo = 0;

            Console.WriteLine("\nCARGA DE DATOS DE UN COMBO");

            Console.WriteLine("\nIngrese el codigo:\n");
            int codigoCombo = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese el nombre:\n");
            string nombreCombo = Console.ReadLine();
           
            do//Para añadir los productos al combo.
            {
                Console.WriteLine("\nIngrese el codigo del producto a agregar:\n");
                int codigoDelProductoParaCombo = int.Parse(Console.ReadLine());

                foreach (var item in RepositorioGlobal.productos)
                {
                    if(item.codigoProducto == codigoDelProductoParaCombo)//NOTA:AGREGAR CONDICION DE QUE PRODUCTO NO ESTE DADO DE BAJA;
                    {
                        if (item.cantidadActual > 0)
                        {
                            disponibilidadDelCombo = true;
                            RepositorioGlobal.productosParaCombo.Add(item);//se guardan los producto que se agregaran a combo.
                        }
                        else
                        {
                            Console.WriteLine("No hay stock del producto ingresado");
                        } 
                    }
                }

                do//valido que solo ingrese 1 o 2.
                {
                    Console.WriteLine("\n-Ingrese 1 para continuar agregando produtos a combo\n");
                    Console.WriteLine("\n-Ingrese 2 si no se desea agregar mas productos a combo\n");
                    opcion = int.Parse(Console.ReadLine());

                } while (opcion != 1 && opcion != 2);

            } while (opcion == 1);

            Console.WriteLine("\nIngrese el descuento:\n");
            decimal descuentoCombo = decimal.Parse(Console.ReadLine());

            foreach (var item in RepositorioGlobal.productosParaCombo)
            {
                sumaDePreciosDeCadaCombo = sumaDePreciosDeCadaCombo + item.precioUnitario;
            }

            decimal precioUnitarioCombo = sumaDePreciosDeCadaCombo - ((sumaDePreciosDeCadaCombo * descuentoCombo) / 100);

            DetalleCombo nuevoCombo = new DetalleCombo(codigoCombo, nombreCombo, descuentoCombo, disponibilidadDelCombo, RepositorioGlobal.productosParaCombo, precioUnitarioCombo);
            RepositorioGlobal.combos.Add(nuevoCombo);
        }
        public static void ActualizarStock()
        {
            Console.WriteLine("\nIngrese el codigo del producto para actalizar stock:\n");
            int codigoDelProductoParaActulizarStock = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIngrese la cantidad de unidades de stock a agregar:\n");
            int cantidad = int.Parse(Console.ReadLine());

            foreach (var item in RepositorioGlobal.productos)
            {
                if(item.codigoProducto == codigoDelProductoParaActulizarStock)
                {
                    item.cantidadActual = item.cantidadActual + cantidad;
                    if (item.cantidadActual <= 0)
                    {
                        item.disponible = false;//producto sin stock.
                        item.EstadoActual = true;//producto dado de baja. False indica que está no esta dado de baja, es decir que hay stock cargado.
                    }
                }
            }
            foreach (var itemA in RepositorioGlobal.combos)
            {
                foreach (var itemDos in RepositorioGlobal.productosParaCombo)
                {
                    if (itemDos.codigoProducto == codigoDelProductoParaActulizarStock)
                    {
                        if (itemDos.cantidadActual <= 0)
                        {
                            itemA.disponibilidadCombo = false;//Combo no disponible.
                        }
                    }
                }
            }
        }
        public static void RegistrarBajaDelProducto()
        {
            Console.WriteLine("\nIngrese el codigo del producto para actalizar stock:\n");
            int codigoDelProductoParaRegistrarBaja = int.Parse(Console.ReadLine());

            foreach (var itemA in RepositorioGlobal.combos)
            {
                foreach (var itemDos in RepositorioGlobal.productosParaCombo)
                {
                    if (itemDos.codigoProducto == codigoDelProductoParaRegistrarBaja)
                    {
                        if (itemDos.EstadoActual == false)
                        {
                            itemDos.EstadoActual = true;//Producto dado de baja.
                            itemA.disponibilidadCombo = false;//Combo dado de baja.
                        }
                    }
                }
            }
        }
    }
}