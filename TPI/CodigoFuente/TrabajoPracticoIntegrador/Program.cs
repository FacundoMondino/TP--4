using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace TrabajoPracticoIntegrador
{
    public class Program
    {
        private static string _path = @"C:\JSON\miJson.json";//RUTA DE LA CARPETA DONDE SE GUARDAN LOS JSON CREADOS.
        private static string _path2 = @"C:\JSON\.JsonTeamDosjson";//RUTA JSON TEAM DOS.
        private static string _path3 = @"C:\JSON\.JsonTeamTresjson";//RUTA JSON TEAM TRES.
        private static string _path5 = @"C:\JSON\.JsonTeamCincojson";//RUTA JSON TEAM CINCO.
        private static string _path6 = @"C:\JSON\.JsonComboTeamDosjson";//RUTA JSON COMBO TEAM DOS.
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
                Console.WriteLine("\n7-Registrar DTO team dos");
                Console.WriteLine("\n8-Registrar DTO team tres");
                Console.WriteLine("\n9-Registrar DTO team cinco");
                Console.WriteLine("\n10-Registrar DTO De combo para team dos");
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
                    case 7: RegistroGlobal.CrearJsonProductoTeamDos();
                    break;
                    case 8: RegistroGlobal.CrearJsonProductoTeamTres();
                    break;
                    case 9: RegistroGlobal.CrearJsonProductoTeamCinco();
                    break;
                    case 10: RegistroGlobal.CrearJsonDetalleComboTeamDos();
                    break;
                    default: Console.WriteLine("\n--Error en el ingreso de opcion, ingrese un valor contemplado en el menu de opciones--\n");
                    break;
                }

                do
                {
                    Console.WriteLine("\n-Ingrese 1 para continuar ejecutando una opcion\n");
                    Console.WriteLine("\n-Ingrese 2 para finalizar\n");
                    opcion = int.Parse(Console.ReadLine());
                } while (opcion != 1 && opcion != 2);

            } while(opcion == 1);

            string miJson = JsonConvert.SerializeObject(RepositorioGlobal.productos);
            File.WriteAllText(_path, miJson);
            string JsonProductoTeamDos = JsonConvert.SerializeObject(RepositorioGlobal.productoTeamDos);
            File.WriteAllText(_path2, JsonProductoTeamDos);
            string JsonProductoTeamTres = JsonConvert.SerializeObject(RepositorioGlobal.productoTeamTres);
            File.WriteAllText(_path3, JsonProductoTeamTres);
            string JsonProductoTeamCinco = JsonConvert.SerializeObject(RepositorioGlobal.productoTeamCinco);
            File.WriteAllText(_path5, JsonProductoTeamCinco);
            string JsonComboTeamDos = JsonConvert.SerializeObject(RepositorioGlobal.detalleComboTeamDos);
            File.WriteAllText(_path6, JsonComboTeamDos);
        }
    }
}
