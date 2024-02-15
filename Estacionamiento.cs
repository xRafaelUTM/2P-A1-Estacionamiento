using System;
using System.Collections.Generic;
using System.Linq;

namespace EstacionamientoCity32
{
    public abstract class Estacionamiento
    {
        protected int capacidad;
        protected List<Vehiculo> vehiculos;
        protected Barrera barrera;
        protected Semaforo semaforo;
        public Estacionamiento(int capacidad)
        {
            this.capacidad = capacidad;
            vehiculos = new List<Vehiculo>();
            barrera = new Barrera();
            semaforo = new Semaforo();
        }
        public virtual void IngresarVehiculo(Vehiculo vehiculo)
        {
            semaforo.CambiarColor("verde");
            vehiculos.Add(vehiculo);
            barrera.Levantar();
            barrera.Bajar();
            Console.WriteLine($"\n Presione enter...");
            Console.ReadKey();
        }
        public virtual Vehiculo SalirVehiculo(string? codigo)
        {
            var vehiculo = vehiculos.FirstOrDefault(v => v.Codigo == codigo);

            vehiculos.Remove(vehiculo);
            barrera.Levantar();
            Console.WriteLine("Se cerró la barrera, el vehículo ha salido exitosamente...");

            return vehiculo;
        }
        public abstract void Facturar(Vehiculo vehiculo, DateTime horaSalida);
    }
}