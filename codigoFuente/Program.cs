using System;
using System.Collections.Generic;

namespace TP4_Diseño
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            //Creacion de objeos actividad. Aagrega a la lista las actividades consideradas autorizadas.
            Actividad actividadUno = new Actividad("camillero");
            CargarListas.actividadesAutorizadas.Add(actividadUno);
            Actividad actividadDos = new Actividad("estudiante");
            Actividad actividadTres = new Actividad("enfermero");
            CargarListas.actividadesAutorizadas.Add(actividadTres);

            //Creacion de objetos empresa. A cada persona se le asignara una empresa.
            Empresa empresaUno = new Empresa("EmpresaUno", "100", "DomicilioUno", "LocalidadUno", "emailUno", "telefonoUno", actividadUno);
            Empresa empresaDos = new Empresa("EmpresaDos", "200", "DomicilioDos", "LocalidadDos", "emailDos", "telefonoDos", actividadTres);
            Empresa empresaTres = new Empresa("EmpresaTres", "300", "DomicilioTres", "LocalidadTres", "emailTres", "telefonoTres", actividadDos);

            //Creacion de objetos persona. Agrega a la lista todas las personas.
            Persona personaUno = new Persona("Pepito Martinez", "67890098", "domicilioUno", "telefonoUno", "emailUno", actividadUno, DateTime.Parse("25/08/2021"), empresaUno);
            CargarListas.personas.Add(personaUno);
            Persona personaDos = new Persona("Fulanito DeTal", "98765432", "domicilioDos", "telefonoDos", "emailDos", actividadDos, DateTime.Parse("27/10/2021"), empresaTres);
            CargarListas.personas.Add(personaDos);
            Persona personaTres = new Persona("Susana Lopez", "96765430", "domicilioTres", "telefonoTres", "emailTres", actividadTres,DateTime.Parse("25/05/2021"), empresaDos);
            CargarListas.personas.Add(personaTres);

            Console.WriteLine("INGRESE 1 PARA INICIAR LA EJECUCION DEL PROGRAMA:");
            a = int.Parse(Console.ReadLine());

            while (a == 1)
            {
                int opcion;

                Console.WriteLine("\nINGRESE LA OPCION QUE DESEA REALIZAR:\n");
                Console.WriteLine("-INGRESE 1 PARA MOSTRAR LA LISTA DE EMPLEADOS");
                Console.WriteLine("-INGRESE 2 PARA MOSTRAR LA LISTA DE ACTIVIDADES AUTORIZADAS");
                Console.WriteLine("-INGRESE 3 PARA VERIFICAR SI UN EMPLEADO PUEDE CIRCULAR POR UN AREA");
                Console.WriteLine("-INGRESE 4 PARA DAR DE BAJA A UN EMPLEADO");
                Console.WriteLine("-INGRESE 5 PARA FINALIZAR");

                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    //Muestra la lista con todas las personas que quieren acceder al area. (no se verifico aun).
                    Console.WriteLine("\nLISTA DE EMPLEADOS:\n");
                    mostrarListaPersonas();
                }
                if (opcion == 2)
                {
                    //Muestra la lista de todas las actividades que estan autorizadas.
                    Console.WriteLine("\nLISTA DE ACTIVIDADES AUTORIZADAS:\n");
                    mostrarListaAcividadesAutorizadas();
                }
                if (opcion == 3)
                {
                    Console.WriteLine("\nVERIFICACION DE EMPLEADOS SEGUN LA ACTIVIDAD QUE REALIZAN:\n");
                    comprobacion();//Comprueba, de las personas de la lista, si puede o no cirular segun la actividad que realiza.

                    Console.WriteLine("\nLISTA DE PEROSNAS QUE EXISTEN Y PUEDEN CIRCULAR:\n");
                    mostrarListaPersonasAutorizadas();//Muestra la lista con las personas que realizan una actividad autoriazada.

                    //Metodo, verifica si el dni ingresado por teclado corresponde a una persona que existe en la lista.
                    //Nota: La persona existe en la lista si realiza una actividad que esta autorizada y si su dni esta cargado en ella.
                    sistemaGestor();
                }
                if (opcion == 4)
                {
                    verifica();//Verifica si se desea dar de baja a un empleado. Caso verdadero, da baja.
                }
                if (opcion == 5)
                {
                    break;//Para salir del ciclo.
                }
            }
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
            public Empresa nombreEmpresa { get; set;  }

            //Metodo constructor de la clase Persona.
            public Persona(string nombreApellido, string dni, string domicilio, string telefono, string email, Actividad nombreActividad, DateTime fecha, Empresa nombreEmpresa)
            {
                this.nombreApellido = nombreApellido;
                this.dni = dni;
                this.domicilio = domicilio;
                this.telefono = telefono;
                this.email = email;
                this.nombreActividad = nombreActividad;
                this.fecha = fecha;
                this.nombreEmpresa = nombreEmpresa;
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

            public static List<Persona> personasNoDadosDeBaja = new List<Persona>();
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
                    Console.WriteLine($"-LA PERSONA {persona.nombreApellido} REALIZA UNA ACTIVIDAD QUE ESTA AUTORIZADA");
                    CargarListas.personasAutorizadas.Add(persona);
                }
                else Console.WriteLine($"-LA PERSONA {persona.nombreApellido} REALIZA UNA ACTIVIDAD QUE NO ESTA AUTORIZADA");
            }
        }
        public static void mostrarListaPersonasAutorizadas()
        {
            foreach (var d in CargarListas.personasAutorizadas)
            {
                Console.WriteLine($"-NOMBRE Y APELLIDO: {d.nombreApellido}\n-DNI: {d.dni}");
            }
        }
        public static void sistemaGestor()
        {
            string numDni;
            int ban = 0;
            int banDos = 0;

            Console.WriteLine("\nVERIFICACION DE EMPLEADOS SEGUN EL DNI:\n");
            Console.WriteLine("\nINGRESE UN DNI PARA VERIFICAR SI EXISTE EN LA LISTA O NO:\n");
            numDni = Console.ReadLine();

            foreach (var d in CargarListas.personasAutorizadas)
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
                }
            }
            if (ban == 1 && banDos == 1)
            {
                Console.WriteLine("\nEL EMPLEADO PUEDE CIRCULAR POR EL AREA, CUMPLE CON LAS TRES CONDICIONES:\n");
                Console.WriteLine("1-EXISTE EN LA LISTA");
                Console.WriteLine("2-REALIZA UNA ACTIVIDAD AUTORIZADA");
                Console.WriteLine("3-SU FECHA ES VIGENTE");
            }
            if (ban == 1 && banDos != 1)
            {
                Console.WriteLine("\nEL EMPLEADO NO PUEDE CIRCULAR POR EL AREA, NO CUMPLE CON LAS TRES CONDICIONES:\n");
                Console.WriteLine("1-EXISTE EN LA LISTA");
                Console.WriteLine("2-REALIZA UNA ACTIVIDAD AUTORIZADA");
                Console.WriteLine("3-SU FECHA ESTA VENCIDA");
            }
            if(ban !=1)//Cuando el empleado realiza una actividad no autorizada, no esta cargado en la lista de personasAutorizadas.
            {
                Console.WriteLine("\n-EL EMPLEADO INGRESADO NO EXISTE EN LA LISTA DE PERSONAS AUTORIZADAS\n");
            }
        }
        public static void verifica()
        {
            int num;
            string numero;

            Console.WriteLine("\nEJECUCION PARA DAR DE BAJA A UN EMPLEADO:\n");
            Console.WriteLine("\n-INGRESE 1 PARA CONTINUAR\n");
            Console.WriteLine("\n-INGRESE 2 PARA FINALIZAR\n");
            num = int.Parse(Console.ReadLine());

            while (num == 1)
            {
                Console.WriteLine("\nINGRESE EL DNI DEL EMPLEADO AL CUAL SE LE DA DE BAJA:\n");
                numero = Console.ReadLine();

                foreach (var e in CargarListas.personas)
                {
                    if(numero != e.dni)
                    {
                        CargarListas.personasNoDadosDeBaja.Add(e);//Se apilan todas las personas de distinto dni al ingresado.
                    }
                    if(numero == e.dni)//Cuando el dni es verdadero con el ingresado, se muestra el nom del empleado con baja.
                    {
                        Console.WriteLine($"-SE DIO DE BAJA AL EMPLEADO: {e.nombreApellido}");
                    }
                }

                Console.WriteLine("\nEJECUCION PARA DAR DE BAJA A UN EMPLEADO:\n");
                Console.WriteLine("\n-INGRESE 1 PARA CONTINUAR\n");
                Console.WriteLine("\n-INGRESE 2 PARA FINALIZAR\n");
                num = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nLISTA DE EMPLEADOS QUE NO FUERON DADOS DE BAJA:\n");
            //Recorro la lista con los empleados que no fueron dados de baja.
            foreach (var f in CargarListas.personasNoDadosDeBaja)
            {
                Console.WriteLine($"{f.nombreApellido}");
            }
        }
    }
}