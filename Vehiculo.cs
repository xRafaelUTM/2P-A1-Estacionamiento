using System;

namespace EstacionamientoCity32
{
    public class Vehiculo
    {
        private string? codigo;
        private string? matricula;
        private DateTime horaEntrada;
        public Vehiculo(string? matricula)
        {
            // Genera un código aleatorio de 4 dígitos.
            Random random = new Random();
            this.codigo = random.Next(1000, 9000).ToString();
            C.Cs(ConsoleColor.Yellow); Console.Write($"📌 Su codigo es: "); C.Cs(ConsoleColor.White); Console.WriteLine($"{codigo}");
            this.matricula = matricula;
            this.horaEntrada = DateTime.Now;
        }
        public string? Codigo { get => codigo; set => codigo = value; }
        public string? Matricula { get => matricula; set => matricula = value; }
        public DateTime HoraEntrada { get => horaEntrada; set => horaEntrada = value; }
    }
}