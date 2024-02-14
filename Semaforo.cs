namespace ParkingSystem
{
    public class Semaforo
    {
        private string? color;

        public Semaforo()
        {
            color = "verde";
        }

        public string? Color
        {
            get => color;
            private set => color = value;
        }

        public void CambiarColor(string? nuevoColor)
        {
            color = nuevoColor;
            Console.WriteLine($"Semáforo en {color}");
        }
    }
}
