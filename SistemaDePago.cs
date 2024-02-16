using System;

namespace EstacionamientoCity32
{
    public class SistemaDePago
    {
        public static double CalcularCosto(DateTime horaEntrada, DateTime horaSalida)
        {
            TimeSpan tiempoEstacionado = horaSalida - horaEntrada;
            double costo = 20.00; 
            if (tiempoEstacionado.TotalMinutes > 60)
            {
               
                int fracciones = (int)Math.Ceiling((tiempoEstacionado.TotalMinutes - 60) / 15);
                costo += fracciones * 5.00;
            }
            return costo;
        }
        public static void EmitirRecibo(Vehiculo vehiculo, double cantidadPagada, DateTime horaSalida)
        {
            double costo = CalcularCosto(vehiculo.HoraEntrada, horaSalida);

            Console.Clear();
            C.Cs(ConsoleColor.Yellow); Console.WriteLine($"\n🧾 Recibo de Pago:");
            C.Cs(ConsoleColor.Yellow); Console.Write($"🪪  Código: "); C.Cs(ConsoleColor.White); Console.WriteLine($"{vehiculo.Codigo}");
            C.Cs(ConsoleColor.Yellow); Console.Write($"📋 Matrícula: "); C.Cs(ConsoleColor.White); Console.WriteLine($"{vehiculo.Matricula}");
            C.Cs(ConsoleColor.Yellow); Console.Write($"⏰ Hora de Entrada: "); C.Cs(ConsoleColor.White); Console.WriteLine($"{vehiculo.HoraEntrada.ToString("dd/MM/yyyy HH:mm")}");
            C.Cs(ConsoleColor.Yellow); Console.Write($"⏰ Hora de Salida: "); C.Cs(ConsoleColor.White); Console.WriteLine($"{horaSalida.ToString("dd/MM/yyyy HH:mm")}");

            TimeSpan tiempoEstacionado = horaSalida - vehiculo.HoraEntrada;
            string? resultadoFormateado = String.Format("{0} horas, {1} minutos", 
                                           tiempoEstacionado.Hours, 
                                           tiempoEstacionado.Minutes);
            C.Cs(ConsoleColor.Yellow); Console.Write($"⏲️  Tiempo en el estacionamiento: "); C.Cs(ConsoleColor.White); Console.WriteLine($"{resultadoFormateado}");

            C.Cs(ConsoleColor.Yellow); Console.Write($"💵 Costo: "); C.Cs(ConsoleColor.White); Console.WriteLine($"${costo}");
            C.Cs(ConsoleColor.Yellow); Console.Write($"📥 Pagado: "); C.Cs(ConsoleColor.White); Console.WriteLine($"${cantidadPagada}");
            C.Cs(ConsoleColor.Yellow); Console.Write($"💰 Cambio: "); C.Cs(ConsoleColor.White); Console.WriteLine($"${cantidadPagada - costo}");
        }
    }
}
