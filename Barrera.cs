using System;
using System.Threading;

namespace EstacionamientoCity32
{
    public class Barrera
    {
        private bool estado;

        public Barrera()
        {
            estado = false;
        }

        public void Levantar()
        {
            estado = true;
            Console.WriteLine("Se abrió la barrera...[ESPERE]");
            Thread.Sleep(5000);
        }

        public void Bajar()
        {
            estado = false;
            Console.WriteLine("Se cerró la barrera, el vehículo ha entrado exitosamente...");
        }

        public bool Estado => estado;
    }
}
