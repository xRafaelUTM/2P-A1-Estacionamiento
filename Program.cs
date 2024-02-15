using System;
using System.Text;

namespace EstacionamientoCity32
{
    class Program
    {
        static EstacionamientoFuncional estacionamiento = new EstacionamientoFuncional(5, new SistemaDePago()); 
        static Registro registro = new Registro();

        static void Main(string[] args)
        {
            // Establecer la codificación predeterminada a UTF-8
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("H");
            
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();
                Console.WriteLine("\n\"Estacionamiento City 32\"");
                Console.WriteLine("1. Entrada de vehículo.");
                Console.WriteLine("2. Salida de vehículo.");
                Console.WriteLine("3. Facturas.");
                Console.WriteLine("4. Carros en el estacionamiento");
                Console.WriteLine("5. Salir.");
                Console.Write("Seleccione una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        EntradaVehiculo();
                        break;
                    case "2":
                        SalidaVehiculo();
                        break;
                    case "3":
                        MostrarFacturas();
                        break;
                    case "4":
                        MostrarVehiculosEstacionados();
                        break;
                    case "5":
                        ejecutando = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }

        static void EntradaVehiculo()
        {
            if (estacionamiento.EspaciosDisponibles() > 0)
            {
                Console.Clear();
                Console.WriteLine("Semáforo en verde. Ingrese la matrícula del vehículo:");
                string? matricula = Console.ReadLine();
                Vehiculo nuevoVehiculo = new Vehiculo(matricula);
                estacionamiento.IngresarVehiculo(nuevoVehiculo);
                registro.RegistrarEntrada(nuevoVehiculo);
                Console.WriteLine($"Se ha asignado la tarjeta con código {nuevoVehiculo.Codigo} al vehículo con matrícula {matricula}.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Semáforo en rojo. No hay espacios disponibles.");
                Console.WriteLine($"\n Presione enter...");
                Console.ReadKey();
            }
        }


        static void SalidaVehiculo()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el código de la tarjeta del vehículo:");
            string? codigo = Console.ReadLine();
            

            Vehiculo vehiculo = estacionamiento.BuscarVehiculoPorCodigo(codigo);
            if (vehiculo != null)
            {
                            
                Console.WriteLine("Ingrese la hora de salida [FORMATO: [HH:MM] FORMATO: [24H]].");
                string? horaSalidaInput = Console.ReadLine();
                DateTime horaSalida;
                DateTime fechaActual = DateTime.Now;

                while (!DateTime.TryParseExact(horaSalidaInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out horaSalida))
                {
                    Console.WriteLine("Formato inválido. Por favor, ingrese la hora en FORMATO: [HH:MM] FORMATO: [24H].");
                    horaSalidaInput = Console.ReadLine();
                }

                
                horaSalida = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, horaSalida.Hour, horaSalida.Minute, 0);

                string? factura = registro.FacturarSalida(vehiculo, horaSalida);
                //Console.WriteLine($"\nFactura generada:\n{factura}");

                estacionamiento.Facturar(vehiculo, horaSalida);
                


                estacionamiento.SalirVehiculo(codigo);
                Console.WriteLine($"\n Presione enter...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Código no encontrado.");
                Console.WriteLine($"\n Presione enter...");
                Console.ReadKey();
            }
        }


        static void MostrarFacturas()
        {
            Console.Clear();
            foreach (var factura in registro.Facturas)
            {
                Console.WriteLine(factura);
            }
            Console.WriteLine($"\n Presione enter...");
            Console.ReadKey();
        }


        static void MostrarVehiculosEstacionados()
        {
            Console.Clear();
            foreach (var vehiculo in estacionamiento.Vehiculos)
            {
                Console.WriteLine($"Código: {vehiculo.Codigo}, Matrícula: {vehiculo.Matricula}, Hora de Entrada: {vehiculo.HoraEntrada}");
            }
            Console.WriteLine($"\n Presione enter...");
            Console.ReadKey();
        }

    }
}
