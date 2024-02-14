using System;

namespace ParkingSystem
{
    public class SistemaDePago
    {
        public double CalcularCosto(DateTime horaEntrada, DateTime horaSalida)
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

        public void EmitirRecibo(Vehiculo vehiculo, double cantidadPagada, DateTime horaSalida)
        {
            
            double costo = CalcularCosto(vehiculo.HoraEntrada, horaSalida);

            Console.Clear();
            Console.WriteLine($"\nRecibo de Pago:");
            Console.WriteLine($"Código: {vehiculo.Codigo}");
            Console.WriteLine($"Matrícula: {vehiculo.Matricula}");
            Console.WriteLine($"Hora de Entrada: {vehiculo.HoraEntrada.ToString("dd/MM/yyyy HH:mm")}");
            Console.WriteLine($"Hora de Salida: {horaSalida.ToString("dd/MM/yyyy HH:mm")}");

            TimeSpan tiempoEstacionado = horaSalida - vehiculo.HoraEntrada;
            string? resultadoFormateado = String.Format("{0} horas, {1} minutos", 
                                           tiempoEstacionado.Hours, 
                                           tiempoEstacionado.Minutes);
            Console.WriteLine($"Tiempo en el estacionamiento: {resultadoFormateado}");

            Console.WriteLine($"Costo: ${costo}");
            Console.WriteLine($"Pagado: ${cantidadPagada}");
            Console.WriteLine($"Cambio: ${cantidadPagada - costo}");
        }
    }
}
