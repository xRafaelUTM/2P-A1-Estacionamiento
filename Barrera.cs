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
            C.Cs(ConsoleColor.Yellow); Console.Write("⚠️  Se abrió la barrera..."); C.Cs(ConsoleColor.Red); Console.WriteLine("[ESPERE]");
            Thread.Sleep(5000);
        }
        public void Bajar()
        {
            estado = false;
            C.Cs(ConsoleColor.Yellow); Console.WriteLine("✅ Se cerró la barrera, el vehículo ha entrado exitosamente...");
        }
        public bool Estado => estado;
    }
}
