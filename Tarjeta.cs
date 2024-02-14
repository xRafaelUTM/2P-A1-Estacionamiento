namespace ParkingSystem
{
    public class Tarjeta
    {
        private string? codigo;

        public Tarjeta(string? codigo)
        {
            this.codigo = codigo;
        }

        public string? Codigo
        {
            get => codigo;
            set => codigo = value;
        }
    }
}
