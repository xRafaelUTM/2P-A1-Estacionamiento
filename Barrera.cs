using System;
using System.Threading;

namespace ParkingSystem
{
    public class Barrera
    {
        private bool estado; // false: bajada, true: levantada

        public Barrera()
        {
            estado = false; // Barrera comienza bajada
        }

        public void Levantar()
        {
            estado = true;
            Console.WriteLine("Se abrió la barrera...[ESPERE]");
            // Simula el tiempo que la barrera se mantiene abierta
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
