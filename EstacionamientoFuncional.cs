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

            Console.WriteLine($"El costo total es: ${costo}");
            double montoPagado;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el monto pagado por el cliente:");
                    montoPagado = Convert.ToDouble(Console.ReadLine());
                    if (montoPagado < costo){Console.WriteLine("---ERROR, EL MONTO ES MENOR AL PAGO CORRESPONDIENTE.---");}
                    else {break;}
                }
                catch (System.Exception)
                {
                    Console.WriteLine("---ERROR, INTENTE DE NUEVO.---");
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