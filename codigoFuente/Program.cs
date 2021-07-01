using System;
using System.Collections.Generic;

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
            
            Persona personaUno = new Persona("PepeMartinez", "12345678", "domUno", "telUno", "emailUno", actividadUno, DateTime.Parse("25/08/2021"), empresaUno, DateTime.Parse("29/06/2021 08:25:02 AM"), 32.4, "AA-470-CV", "DestinoUno", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaUno);
            Persona personaDos = new Persona("FulanitoDeTal", "98765432", "domDos", "telDos", "emailDos", actividadDos, DateTime.Parse("27/10/2021"), empresaTres, DateTime.Parse("30/06/2021 17:30:08 PM"), 39.5, "AB-770-WN", "DestinoDos", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaDos);
            Persona personaTres = new Persona("SusiLopez", "45678098", "domTres", "telTres", "emailTres", actividadTres, DateTime.Parse("25/08/2021"), empresaDos, DateTime.Parse("01/07/2021 07:25:10 AM"), 38.1, "AE-571-RL", "DestinoTres", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaTres);
            Persona personaCuatro = new Persona("MarioMartinez", "098234567", "domCuatro", "telCuatro", "emailCuatro", actividadTres, DateTime.Parse("28/06/2021"), empresaDos, DateTime.Parse("02/07/2021 07:35:10 AM"), 36.1, "AB-581-RM", "DestinoCuatro", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaCuatro);
            Persona personaCinco = new Persona("HugoPerez", "453278909", "domCinco", "telCinco", "emailCuatro", actividadTres, DateTime.Parse("30/07/2021"), empresaDos, DateTime.Parse("02/09/2021 07:35:10 AM"), 35.1, "KLS-570", "DestinoCinco", "00:00:00", true);
            RepositorioGlobal.personas.Add(personaCinco);

            Console.WriteLine("Ingrese 1 para iniciar el programa:");
            a = int.Parse(Console.ReadLine());

            comprobacion();

            while (a == 1)
            {
                int opcion;

                Console.WriteLine("\nIngrese la opcion:\n");
                Console.WriteLine("1- Lista de personas");
                Console.WriteLine("2- Lista de actividades autoizadas");
                Console.WriteLine("3- Autorizacion de ingreso");
                Console.WriteLine("4- Dar baja");
                Console.WriteLine("5- Registrar Salida");
                Console.WriteLine("6- Salir");

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
                    RegistrarBaja();
                }
                if (opcion == 5)
                {
                    RegistrarSalida();
                }
                if (opcion == 6)
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
            public string HorarioSalida { get; set; }
            public Boolean estadoActual {get; set;}

            public Persona(string nombreApellido, string dni, string domicilio, string telefono, string email, Actividad nombreActividad, DateTime fecha, Empresa nombreEmpresa, DateTime fechaHoraIngreso, double temperatura, string patente, string destino, string HorarioSalida, Boolean estadoActual)
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
                this.HorarioSalida = HorarioSalida;
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

            public static List<Persona> personasNoDadosDeBaja = new List<Persona>();

            //public static List<String> aux = new List<String>();
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
                Console.WriteLine($"{a.nombreApellido} - {a.dni} - {a.domicilio} - {a.telefono} - {a.email} - {a.nombreActividad.nombreActividad} - {a.fecha} - {a.fechaHoraIngreso} - {a.temperatura} - {a.patente} - {a.destino} - {a.HorarioSalida} - {a.estadoActual}");
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
                        bandera = 1;//Se prende la bandera.
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
            int ban = 0;
            int banDos = 0;
            int banTres = 0;

            Console.WriteLine("\nIngrese DNI del empleado:\n");
            numDni = Console.ReadLine();

            foreach (var d in RepositorioGlobal.personasAutorizadas)
            {
                if (d.dni == numDni)
                {
                    ban = 1;

                    if (DateTime.Now <= d.fecha)
                    {
                        banDos = 1;
                        Console.WriteLine($"-Fecha: {d.fecha}");
                        Console.WriteLine($"-Empleado: {d.nombreApellido}");
                    }
                    if (d.temperatura <= 37)
                    {
                        banTres = 1;
                    }
                }
            }
            if (ban == 1 && banDos == 1 && banTres == 1)
            {
                Console.WriteLine("\n-El emleado puede ingresar por el area, cumple con las condiciones:\n");
                Console.WriteLine("1-Existe en la lista");
                Console.WriteLine("2-Realiza una actividad autorizada");
                Console.WriteLine("3-Su fecha es vigente");
                Console.WriteLine("4-Su temperatura no supera los 37°");
            }
            if (ban == 1 && banDos != 1 && banTres == 1)
            {
                Console.WriteLine("\n-El empleado no puede circular por el area, no cumple con las condiciones:\n");
                Console.WriteLine("1-Existe en la lista");
                Console.WriteLine("2-Realiza una actividad autorizada");
                Console.WriteLine("3-Su fecha esta vencida");
                Console.WriteLine("4-Su temperatura no supera los 37°");
            }
            if (ban == 1 && banDos == 1 && banTres != 1)
            {
                Console.WriteLine("\n-El empleado no puede circular por el area, no cumple con las condiciones:\n");
                Console.WriteLine("1-Existe en la lista");
                Console.WriteLine("2-Realiza una actividad autorizada");
                Console.WriteLine("3-Su fecha es vigente");
                Console.WriteLine("4-Su temperatura supera los 37°");
            }
            if (ban == 1 && banDos != 1 && banTres != 1)
            {
                Console.WriteLine("\n-El empleado no puede circular por el area, no cumple con las condiciones:\n");
                Console.WriteLine("1-Existe en la lista");
                Console.WriteLine("2-Realiza una actividad autorizada");
                Console.WriteLine("3-Su fecha esta vencida");
                Console.WriteLine("4-Su temperatura supera los 37°");
            }
            if (ban != 1)//Cuando el empleado realiza una actividad no autorizada, no esta cargado en la lista de personasAutorizadas.
            {
                Console.WriteLine("\n-El empleado no existe en la lista\n");
            }
        }
        public static void RegistrarBaja()
        {
            string numero;

            Console.WriteLine("\nIngrese DNI del empleado:\n");
            numero = Console.ReadLine();

            foreach (var e in RepositorioGlobal.personasAutorizadas)
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
            
            foreach (var k in RepositorioGlobal.personasAutorizadas)
            {
                if (numero == k.dni)
                {
                    ban = 1;
                    Console.WriteLine("\nIngrese la hora:\n");
                    resultado = k.HorarioSalida = Console.ReadLine();
                    Console.WriteLine($"\nSe Registro la baja del empleado: {k.nombreApellido}\n");
                }
            }
            if(ban != 1)
            {
                Console.WriteLine("El DNI ingresado no es valido");
            }
            return resultado;
        }
    }
}