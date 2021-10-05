using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoIntegrador
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("Ingrese la opcion que desee ejecutar:");
                Console.WriteLine("\n1-Registrar Producto");
                Console.WriteLine("\n2-Mostrar Producto Registrados");
                Console.WriteLine("\n3-Registrar Combo");
                Console.WriteLine("\n4-Mostrar Combo Registrados");
                Console.WriteLine("\n5-Actualizar Stock");
                Console.WriteLine("\n6-Registrar baja");
                int opcionAingresar = int.Parse(Console.ReadLine());

                switch (opcionAingresar)
                {
                    case 1: RegistroGlobal.RegistrarProducto(); 
                    break;
                    case 2: Mostrar.VerProductosRegistrados();
                    break;
                    case 3: RegistroGlobal.RegistrarCombo();
                    break;
                    case 4: Mostrar.VerCombosRegistrados();
                    break;
                    case 5: RegistroGlobal.ActualizarStock();
                    break;
                    case 6: RegistroGlobal.RegistrarBajaDelProducto();
                    break;
                }

                do//valido que solo ingrese 1 o 2.
                {
                    Console.WriteLine("\n-Ingrese 1 para continuar ejecutando una opcion\n");
                    Console.WriteLine("\n-Ingrese 2 para finalizar\n");
                    opcion = int.Parse(Console.ReadLine());
                } while (opcion != 1 && opcion != 2);

            } while(opcion == 1);
        }
    }
}
