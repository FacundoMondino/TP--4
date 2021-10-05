using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    class Mostrar
    {
        public static void VerProductosRegistrados()
        {
            foreach (var item in RepositorioGlobal.productos)
            {
                Console.WriteLine($"\nCodigo: {item.codigoProducto}\nCategria: {item.categoria}\nModelo: {item.modelo}\nTamaño: {item.tamaño}\nColor: {item.color}\nFecha de ingreso: {item.fechaIngreso.ToShortDateString()}\nEstado de vigencia:{item.EstadoActual}\nNombre: {item.nombre}\nDescripcion: {item.descripcion}\nPrecio unitario: {item.precioUnitario}\nCantidad actual en stock: {item.cantidadActual}\nEstado en stock: {item.disponible}\n");
            }
        }
        public static void VerCombosRegistrados()
        {
            foreach (var item in RepositorioGlobal.combos)
            {
                Console.WriteLine($"\nCodigo: {item.codigoCombo}\nNombre: {item.nombreCombo}\nDescuento: {item.descuento} \nDisponibilidad: {item.disponibilidadCombo}\nPrecio Unitario: {item.precioUnitarioCombo}\n");

                Console.WriteLine("\nLos productos que incluyen el combo son:\n");
                foreach (var itemDos in RepositorioGlobal.productosParaCombo)
                {
                    Console.WriteLine($"Nombre del produto: {itemDos.nombre}");
                }
            }
        }
    }
}
