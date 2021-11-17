using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTresPatronAbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Concesionario fabricaUno = new ConcesionarioFord();//Instancio fabricaConcretaUno;

            Auto autoUno = fabricaUno.crearAuto();
            Camioneta camionetaUno = fabricaUno.crearCamioneta();

            Console.WriteLine("\nConcesionario Ford:\n");
            Console.WriteLine($"Auto: {autoUno.DescripcionUno}\nCamioneta: {camionetaUno.DescripcionDos}");

            Concesionario fabricaDos = new ConcesionarioVolkswagen();//Instancio fabricaConcretaDos;

            Auto autoDos = fabricaDos.crearAuto();
            Camioneta camionetaDos = fabricaDos.crearCamioneta();

            Console.WriteLine("\nConcesionario Volkswagen:\n");
            Console.WriteLine($"Auto: {autoDos.DescripcionUno}\nCamioneta: {camionetaDos.DescripcionDos}");
        }
    }

    //Producto abstracto A;
    public abstract class Auto//Tendra su descripcion;
    {
        protected string descripcionUno;

        public object DescripcionUno
        {
            get
            {
                return descripcionUno;
            }
        }
    }

    //Producto abstracto B;
    public abstract class Camioneta
    {
        protected string descripcionDos;

        public object DescripcionDos
        {
            get
            {
                return descripcionDos;
            }
        }
    }

    //Producto Concreto A1;
    public class AutoFocus : Auto
    {
        public AutoFocus()
        {
            descripcionUno = "Auto Ford Focus";
        }
    }

    //Producto Concreto B1;
    public class CamionetaRanger: Camioneta
    {
        public CamionetaRanger()
        {
            descripcionDos = "Camioneta Ford Ranger";
        }
    }

    //Producto Concreto A2;
    public class AutoVento : Auto
    {
        public AutoVento()
        {
            descripcionUno = "Auto Volkswagen Vento";
        }
    }

    //Producto Concreto B2;
    public class CamionetaAmarok : Camioneta
    {
        public CamionetaAmarok()
        {
            descripcionDos = "Camioneta Volkswagen Amarok";
        }
    }

    //Fabrica abstracta;
    public abstract class Concesionario
    {
        //Crea un auto abstracto y una camioneta abstracta;
        //Esto provoca que se haga concreto en alguna clase concreta;
        public abstract Auto crearAuto();
        public abstract Camioneta crearCamioneta();
    }

    //FabricaConcretaUno. Implementa la clase Concesionario;
    public class ConcesionarioFord: Concesionario
    {
        public override Auto crearAuto()
        {
            return new AutoFocus();//Se instancia el tipo de Auto;
        }
        public override Camioneta crearCamioneta()
        {
            return new CamionetaRanger();
        }
    }

    //FabricaConcretaDos;
    public class ConcesionarioVolkswagen: Concesionario
    {
        public override Auto crearAuto()
        {
            return new AutoVento();
        }
        public override Camioneta crearCamioneta()
        {
            return new CamionetaAmarok();
        }
    }
}