using System;
using System.Collections.Generic;

namespace EstacionamientoCity32
{
    public class Registro
    {
        private List<Vehiculo> vehiculosRegistrados;
        private List<string?> facturasEmitidas;
        public Registro()
        {
            vehiculosRegistrados = new List<Vehiculo>();
            facturasEmitidas = new List<string?>();
        }
        public void RegistrarEntrada(Vehiculo vehiculo)
        {
            vehiculosRegistrados.Add(vehiculo);
        }
        public string? FacturarSalida(Vehiculo vehiculo, DateTime horaSalida)
        {
            TimeSpan tiempoEstacionado = horaSalida - vehiculo.HoraEntrada;
            string? resultadoFormateado = String.Format("{0} horas, {1} minutos", 
                                           tiempoEstacionado.Hours, 
                                           tiempoEstacionado.Minutes);

            double total = CalcularCosto(tiempoEstacionado);
            string? factura = $"Código: {vehiculo.Codigo} \nMatrícula: {vehiculo.Matricula} " +
                             $"\nHora Entrada: {vehiculo.HoraEntrada.ToString("dd/MM/yyyy HH:mm")} \nHora Salida: {horaSalida.ToString("dd/MM/yyyy HH:mm")}" +
                             $"\nTiempo Consumido: {resultadoFormateado} \nPrecio: ${total} \n";

            facturasEmitidas.Add(factura);
            vehiculosRegistrados.Remove(vehiculo);
            return factura;
        }
        private double CalcularCosto(TimeSpan tiempoEstacionado)
        {
            double costo = 20.00; // Costo base por la primera hora
            if (tiempoEstacionado.TotalMinutes > 60)
            {
                // Calcula el costo adicional por cada fracción de 15 minutos después de la primera hora
                int fracciones = (int)Math.Ceiling((tiempoEstacionado.TotalMinutes - 60) / 15);
                costo += fracciones * 5.00;
            }
            return costo;
        }
        public IEnumerable<string?> Facturas => facturasEmitidas;
    }
}
