using System;
using System.Collections.Generic;

namespace TP4_Diseño
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creacion de objeos actividad. Aagrega a la lista las actividades consideradas autorizadas.
            Actividad actividadUno = new Actividad("camillero");
            CargarListas.actividadesAutorizadas.Add(actividadUno);
            Actividad actividadDos = new Actividad("estudiante");
            Actividad actividadTres = new Actividad("enfermero");
            CargarListas.actividadesAutorizadas.Add(actividadTres);

            //Creacion de objetos persona. Agrega a la lista todas las personas.
            Persona personaUno = new Persona("Pepito Martinez", "67890098", "domicilioUno", "telefonoUno", "emailUno", actividadUno, DateTime.Parse("19/05/2021"));
            CargarListas.personas.Add(personaUno);
            Persona personaDos = new Persona("Fulanito DeTal", "98765432", "domicilioDos", "telefonoDos", "emailDos", actividadDos, DateTime.Parse("24/05/2021"));
            CargarListas.personas.Add(personaDos);
            Persona personaTres = new Persona("Susana Lopez", "96765430", "domicilioTres", "telefonoTres", "emailTres", actividadTres,DateTime.Parse("25/05/2021"));
            CargarListas.personas.Add(personaTres);

            //Creacion de objetos empresa.
            Empresa empresaUno = new Empresa("EmpresaUno", "100", "DomicilioUno", "LocalidadUno", "emailUno", "telefonoUno", actividadUno);
            Empresa empresaDos = new Empresa("EmpresaDos", "200", "DomicilioDos", "LocalidadDos", "emailDos", "telefonoDos", actividadTres);

            //Muestra la lista con todas las personas que quieren acceder al area. (no se verifico aun).
            Console.WriteLine("\nLISTA DE PERSONAS:\n");
            mostrarListaPersonas();

            //Muestra la lista de todas las actividades que estan autorizadas.
            Console.WriteLine("\nLISTA DE ACTIVIDADES AUTORIZADAS:\n");
            mostrarListaAcividadesAutorizadas();

            Console.WriteLine("\nVERIFICACION DE PEROSNAS SEGUN LA ACTIVIDAD QUE REALIZAN, PREVIO A VERIFICACION CON DNI:\n");
            comprobacion();//Comprueba, de las personas de la lista, si puede o no cirular segun la actividad que realiza.

            Console.WriteLine("\nLISTA DE PEROSNAS QUE EXISTEN Y PUEDEN CIRCULAR:\n");
            mostrarListaPersonasAutorizadas();//Muestra la lista con las personas que realizan una actividad autoriazada.

            //Metodo, verifica si el dni ingresado por teclado corresponde a una persona que existe en la lista.
            //Nota: La persona existe en la lista si realiza una actividad que esta autorizada y si su dni esta cargado en ella.
            sistemaGestor();
        }
        public class Persona//Clase Persona.
        {
            public string nombreApellido { get; set; }
            public string dni { get; set; }
            public string domicilio { get; set; }
            public string telefono { get; set; }
            public string email { get; set; }
            public Actividad nombreActividad { get; set; }
            public DateTime fecha { get; set; }

            //Metodo constructor de la clase Persona.
            public Persona(string nombreApellido, string dni, string domicilio, string telefono, string email, Actividad nombreActividad, DateTime fecha)
            {
                this.nombreApellido = nombreApellido;
                this.dni = dni;
                this.domicilio = domicilio;
                this.telefono = telefono;
                this.email = email;
                this.nombreActividad = nombreActividad;
                this.fecha = fecha;
            }
        }
        public class Actividad//Clase Actividad.
        {
            public string nombreActividad { get; set; }
            public Persona nombrePersona { get; set; }

            public Actividad(string nombreActividad)
            {
                this.nombreActividad = nombreActividad;
            }
        }
        public class CargarListas
        {
            public static List<Persona> personas = new List<Persona>();

            public static List<Actividad> actividadesAutorizadas = new List<Actividad>();

            public static List<Persona> personasAutorizadas = new List<Persona>();
        }
        public class Empresa
        {
            public string razonSocial { get; set;}
            public string cuit { get; set; }
            public string domicilio { get; set; }
            public string localidad { get; set; }
            public string email { get; set; }
            public string telefono { get; set; }
            public Actividad actividadEmpresa { get; set;}

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
            foreach (var a in CargarListas.personas)
            {
                Console.WriteLine($"{a.nombreApellido} - {a.dni} - {a.domicilio} - {a.telefono} - {a.email} - {a.nombreActividad.nombreActividad} - {a.fecha}");
            }
        }
        public static void mostrarListaAcividadesAutorizadas()//Metodo, muestra lista actividades autorizadas.
        {
            foreach (var b in CargarListas.actividadesAutorizadas)
            {
                Console.WriteLine($"{b.nombreActividad}");
            }
        }
        public static void comprobacion()
        {
            foreach (var persona in CargarListas.personas)
            {
                int bandera = 0;
                Actividad actividadA = persona.nombreActividad;

                foreach (var actividad in CargarListas.actividadesAutorizadas)
                {
                    Actividad actividadB = actividad;
                    if (actividadA == actividadB)
                    {
                        bandera = 1;//Se prende la bandera.
                    }
                }
                if (bandera == 1)
                {
                    Console.WriteLine($"La persona {persona.nombreApellido} realiza una actividad que esta autorizada");
                    CargarListas.personasAutorizadas.Add(persona);
                }
                else Console.WriteLine($"La persona {persona.nombreApellido} realiza una actividad que no esta autorizada");
            }
        }
        public static void mostrarListaPersonasAutorizadas()
        {
            foreach (var d in CargarListas.personasAutorizadas)
            {
                Console.WriteLine($"NombreApellido: {d.nombreApellido}\ndni: {d.dni}");
            }
        }
        public static void sistemaGestor()
        {
            string numDni;
            int ban = 0;
            int banDos = 0;

            Console.WriteLine("\nIngrese el DNI de la persona para verificar si existe en la lista:\n");
            numDni = Console.ReadLine();

            foreach (var d in CargarListas.personasAutorizadas)
            {
                if (d.dni == numDni)
                {
                    ban = 1;

                    if (DateTime.Now <= d.fecha)
                    {
                        banDos = 1;
                        Console.WriteLine(d.fecha);
                    }
                }
            }
            if (ban == 1 && banDos == 1)
            {
                Console.WriteLine("\n---LA PERSONA EXISTE EN LA LISTA, REALIZA UNA ACTIVIDAD AUTORIZADA, SU FECHA ES VIGENTE, POR ENDE PUEDE CIRCULAR POR EL AREA---\n");
            }
            if (ban == 1 && banDos != 1)
            {
                Console.WriteLine("\n---LA PERSONA EXISTE EN LA LISTA, REALIZA UNA ACTIVIDAD AUTORIZADA, PERO SU FECHA ESTA VENCIDA, POR ENDE NO PUEDE CIRCULAR POR EL AREA---\n");
            }
            if(ban !=1)
            {
                Console.WriteLine("\n--LA PERSONA NO EXISTE EN LA LISTA---\n");
            }
        }
    }
}