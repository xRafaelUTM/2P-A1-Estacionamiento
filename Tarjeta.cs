namespace EstacionamientoCity32
{
    public class Tarjeta(string? codigo)
    {
        private string? codigo = codigo;
        public string? Codigo { get => codigo; set => codigo = value; }
    }
}