using System;
using System.Collections.Generic;
using System.Linq;

namespace EstacionamientoCity32
{
    public class EstacionamientoFuncional : Estacionamiento
    {
        private SistemaDePago sistemaDePago;
        public EstacionamientoFuncional(int capacidad, SistemaDePago sistemaDePago) : base(capacidad)
        {
            this.sistemaDePago = sistemaDePago;
        }
        public override void Facturar(Vehiculo vehiculo, DateTime horaSalida)
        {
            double costo = SistemaDePago.CalcularCosto(vehiculo.HoraEntrada, horaSalida);

            C.Cs(ConsoleColor.Yellow); Console.Write($"💵 El costo total es: "); C.Cs(ConsoleColor.White); Console.WriteLine($"${costo}");
            double montoPagado;
            while (true)
            {
                try
                {
                    C.Cs(ConsoleColor.Yellow); Console.Write("📥 Ingrese el monto pagado por el cliente: \n--> ");
                    C.Cs(ConsoleColor.Cyan); montoPagado = Convert.ToDouble(Console.ReadLine());
                    if (montoPagado < costo){C.Cs(ConsoleColor.Red); Console.WriteLine("❌---ERROR, EL MONTO ES MENOR AL PAGO CORRESPONDIENTE.---❌");}
                    else {break;}
                }
                catch (System.Exception)
                {
                    C.Cs(ConsoleColor.Red); Console.WriteLine("❌---ERROR, INTENTE DE NUEVO.---❌");
                }
            }

            SistemaDePago.EmitirRecibo(vehiculo, montoPagado, horaSalida);

            vehiculos.Remove(vehiculo);
        }
        public Vehiculo BuscarVehiculoPorCodigo(string? codigo)
        {
            return vehiculos.FirstOrDefault(v => v.Codigo == codigo);
        }
        public int EspaciosDisponibles()
        {
            return capacidad - vehiculos.Count;
        }
        public IEnumerable<Vehiculo> Vehiculos => vehiculos;
    }
}