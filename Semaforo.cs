namespace EstacionamientoCity32
{
    public class Semaforo
    {
        private string? color;
        public Semaforo()
        {
            color = "verde";
        }
        public string? Color { get => color; private set => color = value; }
        public void CambiarColor(string? nuevoColor)
        {
            color = nuevoColor;
            C.Cs(ConsoleColor.Yellow); Console.Write("🟢 Semáforo en "); C.Cs(ConsoleColor.Green); Console.WriteLine($"{color}.");
        }
    }
}
