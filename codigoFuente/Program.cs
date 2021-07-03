using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace TP4_Diseño
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
      
            //ObjetoActividad y agrego a lista de actividadesAutorizadas.

            Actividad actividadUno = new Actividad("camillero");
            RepositorioGlobal.actividadesAutorizadas.Add(actividadUno);
            Actividad actividadDos = new Actividad("estudiante");
            Actividad actividadTres = new Actividad("enfermero");
            RepositorioGlobal.actividadesAutorizadas.Add(actividadTres);

            //ObjetoEmpresa. Cada Empresa tiene su Actividad.

            Empresa empresaUno = new Empresa("EmpresaA", "100", "DomEmpresaA", "LocalidadA", "emailEmpresaA", "telA", actividadUno);
            Empresa empresaDos = new Empresa("EmpresaB", "200", "DomEmpresaB", "LocalidadB", "emailEmpresaB", "telB", actividadTres);
            Empresa empresaTres = new Empresa("EmpresaC", "300", "DomEmpresaC", "LocalidadC", "emailEmpresaC", "telC", actividadDos);

            //ObjetosPersona y agrego a lista de personas. TRUE = activa = trabajando y FALSE = no activa = no trabaja.
            
            Persona personaUno = new Persona("PepeMartinez", "12345678", "domUno", "telUno", "emailUno", actividadUno, DateTime.Parse("25/08/2021"), empresaUno, DateTime.Parse("29/07/2021 08:25:02 AM"), 32.4, "AA-470-CV", "DestinoUno", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaUno);
            Persona personaTres = new Persona("SusiLopez", "45678098", "domTres", "telTres", "emailTres", actividadTres, DateTime.Parse("25/08/2021"), empresaDos, DateTime.Parse("20/07/2021 07:25:10 AM"), 38.1, "AE-571-RL", "DestinoTres", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaTres);
            Persona personaCuatro = new Persona("MarioMartinez", "098234567", "domCuatro", "telCuatro", "emailCuatro", actividadTres, DateTime.Parse("28/06/2021"), empresaDos, DateTime.Parse("30/07/2021 07:35:10 AM"), 36.1, "AB-581-RM", "DestinoCuatro", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaCuatro);

            Console.WriteLine("Ingrese 1 para iniciar el programa:");
            a = int.Parse(Console.ReadLine());

            comprobacion();

            while (a == 1)
            {
                int opcion;

                Console.WriteLine("\nIngrese la opcion:\n");
                Console.WriteLine("1- Lista de personas");
                Console.WriteLine("2- Lista de actividades autorizadas");
                Console.WriteLine("3- Autorizacion de ingreso");
                Console.WriteLine("4- Dar baja");
                Console.WriteLine("5- Registrar Salida");
                Console.WriteLine("6- Generar Codigo QR");
                Console.WriteLine("7- Salir");

                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.WriteLine("\nLista de personas:\n");
                    mostrarListaPersonas();
                }
                if (opcion == 2)
                {
                    Console.WriteLine("\nLista de actividades actualizadas:\n");
                    mostrarListaAcividadesAutorizadas();
                }
                if (opcion == 3)
                {
                    AutorizarIngreso();
                }
                if (opcion == 4)
                {
                    Console.WriteLine("Verificar estado de actividad vigente de empleado:");
                    AutorizarIngreso();
                    Console.WriteLine("Verificacion correcta, puede continuar:");
                    RegistrarBaja();
                }
                if (opcion == 5)
                {
                    Console.WriteLine("Verificar si el empleado esta trabajando en este momento:");
                    AutorizarIngreso();
                    Console.WriteLine("Verificacion correcta, puede continuar:");
                    RegistrarSalida();
                }
                if (opcion == 6)
                {
                    Console.WriteLine("Verificar si el empleado existe en la empresa");
                    AutorizarIngreso();
                    Console.WriteLine("Verificacion correcta, puede continuar:");
                    GenerarCodigoQR();
                }
                if (opcion == 7)
                {
                    break;
                }
            }
        }
        public class Persona
        {
            public string nombreApellido { get; set; }
            public string dni { get; set; }
            public string domicilio { get; set; }
            public string telefono { get; set; }
            public string email { get; set; }
            public Actividad nombreActividad { get; set; }
            public DateTime fecha { get; set; }
            public Empresa nombreEmpresa { get; set; }
            public DateTime fechaHoraIngreso { get; set; }
            public double temperatura { get; set; }
            public string patente { get; set; }
            public string destino { get; set; }
            public string horarioSalida { get; set; }
            public Boolean estadoActual {get; set;}

            public Persona(string nombreApellido, string dni, string domicilio, string telefono, string email, Actividad nombreActividad, DateTime fecha, Empresa nombreEmpresa, DateTime fechaHoraIngreso, double temperatura, string patente, string destino, string horarioSalida, Boolean estadoActual)
            {
                this.nombreApellido = nombreApellido;
                this.dni = dni;
                this.domicilio = domicilio;
                this.telefono = telefono;
                this.email = email;
                this.nombreActividad = nombreActividad;
                this.fecha = fecha;
                this.nombreEmpresa = nombreEmpresa;
                this.fechaHoraIngreso = fechaHoraIngreso;
                this.temperatura = temperatura;
                this.patente = patente;
                this.destino = destino;
                this.horarioSalida = horarioSalida;
                this.estadoActual = estadoActual;
            }
        }
        public class Actividad
        {
            public string nombreActividad { get; set; }
            public Persona nombrePersona { get; set; }

            public Actividad(string nombreActividad)
            {
                this.nombreActividad = nombreActividad;
            }
        }
        public class RepositorioGlobal
        {
            public static List<Persona> personas = new List<Persona>();

            public static List<Actividad> actividadesAutorizadas = new List<Actividad>();

            public static List<Persona> personasAutorizadas = new List<Persona>();

            public static List<Persona> personasAutorizadasFecha = new List<Persona>();

            public static List<Persona> personasAutorizadasTemp = new List<Persona>();
        }
        public class Empresa
        {
            public string razonSocial { get; set; }
            public string cuit { get; set; }
            public string domicilio { get; set; }
            public string localidad { get; set; }
            public string email { get; set; }
            public string telefono { get; set; }
            public Actividad actividadEmpresa { get; set; }

            public Empresa(string razonSocial, string cuit, string domicilio, string localidad, string email, string telefono, Actividad actividadEmpresa)
            {
                this.razonSocial = razonSocial;
                this.cuit = cuit;
                this.domicilio = domicilio;
                this.localidad = localidad;
                this.email = email;
                this.telefono = telefono;
                this.actividadEmpresa = actividadEmpresa;
            }
        }
        public static void mostrarListaPersonas()//Metodo, muestra lista con personas.
        {
            foreach (var a in RepositorioGlobal.personas)
            {
                Console.WriteLine($"{a.nombreApellido} - {a.dni} - {a.domicilio} - {a.telefono} - {a.email} - {a.nombreActividad.nombreActividad} - {a.fecha} - {a.fechaHoraIngreso} - {a.temperatura} - {a.patente} - {a.destino} - {a.horarioSalida} - {a.estadoActual}");
            }
        }
        public static void mostrarListaAcividadesAutorizadas()//Metodo, muestra lista actividades autorizadas.
        {
            foreach (var b in RepositorioGlobal.actividadesAutorizadas)
            {
                Console.WriteLine($"{b.nombreActividad}");
            }
        }
        public static void comprobacion()
        {
            foreach (var persona in RepositorioGlobal.personas)
            {
                int bandera = 0;
                Actividad actividadA = persona.nombreActividad;

                foreach (var actividad in RepositorioGlobal.actividadesAutorizadas)
                {
                    Actividad actividadB = actividad;
                    if (actividadA == actividadB)
                    {
                        bandera = 1;
                    }
                }
                if (bandera == 1)
                {
                    RepositorioGlobal.personasAutorizadas.Add(persona);
                }
            }
        }
        public static void AutorizarIngreso()
        {
            string numDni;

            Console.WriteLine("\nIngrese DNI del empleado:\n");
            numDni = Console.ReadLine();

            foreach (var d in RepositorioGlobal.personasAutorizadas)
            {
                if (d.dni == numDni)
                {
                    if (DateTime.Now <= d.fechaHoraIngreso)
                    {
                        RepositorioGlobal.personasAutorizadasFecha.Add(d);
                    }
                    else
                    {
                        Console.WriteLine("\nEl empleado no esta autorizado para circular\n");
                    }
                }
            }
            foreach (var m in RepositorioGlobal.personasAutorizadasFecha)
            {
                if (numDni == m.dni)
                {
                    if (m.temperatura <= 37)
                    {
                        RepositorioGlobal.personasAutorizadasTemp.Add(m);
                        Console.WriteLine($"\nEl empleado: {m.nombreApellido} esta autorizado para circular por el area\n");
                    }
                    else
                    {
                        Console.WriteLine("\nEl empleado no esta autorizado para circular\n");
                    }
                }
            }
        }
        public static void RegistrarBaja()
        {
            string numero;

            Console.WriteLine("\nIngrese DNI del empleado:\n");
            numero = Console.ReadLine();

            foreach (var e in RepositorioGlobal.personasAutorizadasTemp)
            {
                if (numero == e.dni)
                {
                    e.estadoActual = false;
                    Console.WriteLine($"\nSe registro la salida del empleado: {e.nombreApellido}\n");
                }
            }
            Console.WriteLine("Empleados activos:");
            foreach (var l in RepositorioGlobal.personas)
            {
                if(l.estadoActual == true)
                {
                    Console.WriteLine(l.nombreApellido);
                }
            }
        }
        public static string RegistrarSalida()
        {
            string numero;
            string resultado="00:00:00";
            int ban = 0;
            
            Console.WriteLine("\nIngrese DNI del empleado:\n");
            numero = Console.ReadLine();
            
            foreach (var k in RepositorioGlobal.personasAutorizadasTemp)
            {
                if (numero == k.dni)
                {
                    ban = 1;
                    Console.WriteLine("\nIngrese la hora:\n");
                    resultado = k.horarioSalida = Console.ReadLine();
                    Console.WriteLine($"\nSe Registro la baja del empleado: {k.nombreApellido}\n");
                }
            }
            if(ban != 1)
            {
                Console.WriteLine("El DNI ingresado no es valido");
            }
            return resultado;
        }
        public static void GenerarCodigoQR()
        {
            string numero;

            Console.WriteLine("\nIngrese DNI del empleado para generar codigo QR:\n");
            numero = Console.ReadLine();

            foreach (var m in RepositorioGlobal.personasAutorizadas)
            {
                if(m.dni == numero)
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter.GetInstance(doc, new FileStream($@"C:\Users\Usuario\Desktop\TPMenosCuatroMondinoFacundoDiseño\QR\QR{m.nombreApellido}.pdf", FileMode.Create));
                    doc.Open();
                    BarcodeQRCode codigoQR = new BarcodeQRCode(m.nombreApellido, 1000, 1000, null);
                    Image codeQRImage = codigoQR.GetImage();
                    codeQRImage.ScaleAbsolute(200, 200);
                    doc.Add(codeQRImage);
                    doc.Close();
                    Console.WriteLine($"\nSe genero correctamente el Codigo QR del empleado: {m.nombreApellido}\n");
                }
            }
        }
    }
}