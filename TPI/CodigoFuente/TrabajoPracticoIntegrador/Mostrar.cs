using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    public class Mostrar
    {
        public static void VerProductosRegistrados()
        {
            foreach (var item in RepositorioGlobal.productos)
            {
                if(item.estaEnOferta == true)
                {
                    Console.WriteLine($"\nCodigo: {item.codigoProducto}\nCategria: {item.categoria}\nModelo: {item.modelo}" +
                    $"\nTamaño: {item.tamaño}\nColor: {item.color}\nFecha de ingreso: {item.fechaIngreso.ToShortDateString()}" +
                    $"\nEstado de vigencia:{item.EstadoActual}\nNombre: {item.nombre}\nDescripcion: {item.descripcion}\n" +
                    $"Precio unitario: {item.precioUnitario}\nCantidad actual en stock: {item.cantidadActual}" +
                    $"\nEstado en stock: {item.disponible}\nPrecio de oferta en rango 2 a 5 productos: {item.precioRangoDosACinco}" +
                    $"\nPrecio de oferta en rango 6 a 10 productos: {item.precioRangoSeisADiez}" +
                    $"\nPrecio de oferta en rango 10 o mas productos: {item.precioRangoDiezOMas}\nFecha de inicio de la oferta: {item.fechaInicioOferta}" +
                    $"\nEstado actual de oferta: {item.estaEnOferta}\nDescripcion de la oferta: {item.descripcionOferta}\n" +
                    $"\nFecha de cierre de la oferta: {item.fechaCierreOferta}\nPrecio de la oferta: {item.precioDeOferta}");
                }
                else
                {
                    Console.WriteLine($"\nCodigo: {item.codigoProducto}\nCategria: {item.categoria}\nModelo: {item.modelo}" +
                    $"\nTamaño: {item.tamaño}\nColor: {item.color}\nFecha de ingreso: {item.fechaIngreso.ToShortDateString()}" +
                    $"\nEstado de vigencia:{item.EstadoActual}\nNombre: {item.nombre}\nDescripcion: {item.descripcion}\n" +
                    $"Precio unitario: {item.precioUnitario}\nCantidad actual en stock: {item.cantidadActual}" +
                    $"\nEstado en stock: {item.disponible}\nPrecio de oferta en rango 2 a 5 productos: {item.precioRangoDosACinco}" +
                    $"\nPrecio de oferta en rango 6 a 10 productos: {item.precioRangoSeisADiez}" +
                    $"\nPrecio de oferta en rango 10 o mas productos: {item.precioRangoDiezOMas}\n" +
                    $"\nEstado actual de oferta: {item.estaEnOferta}");
                }
            }
        }
        public static void VerCombosRegistrados()
        {
            foreach (var item in RepositorioGlobal.combos)
            {
                Console.WriteLine($"\nCodigo: {item.codigoCombo}\nNombre: {item.nombreCombo}" +
                    $"\nDescuento: {item.descuento}\nDisponibilidad: {item.disponibilidadCombo}" +
                    $"\nDescripcion: {item.descripcion}\nPrecio Unitario: {item.precioUnitarioCombo}" +
                    $"\nCantidad Actual: {item.cantidadActualCombo}");
            }
        }
    }
}