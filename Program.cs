using System;
using System.Text;
using System.Media;
using System.Drawing;

namespace EstacionamientoCity32
{
    class Program
    {
        static EstacionamientoFuncional estacionamiento = new EstacionamientoFuncional(2, new SistemaDePago()); 
        static Registro registro = new Registro();

        static void Main(string[] args)
        {
            // Establecer la codificación predeterminada a UTF-8
            Console.OutputEncoding = Encoding.UTF8;
            
            bool ejecutando = true;
            while (ejecutando)
            {
                Console.Clear();

                
                C.Cs(ConsoleColor.Yellow); Console.WriteLine("🚗 Estacionamiento \"City 32\" 🚙");
                C.Cs(ConsoleColor.Yellow); Console.Write("🚥 1. "); C.Cs(ConsoleColor.White); Console.WriteLine("Entrada de vehículo.");
                C.Cs(ConsoleColor.Yellow); Console.Write("🔚 2. "); C.Cs(ConsoleColor.White); Console.WriteLine("Salida de vehículo.");
                C.Cs(ConsoleColor.Yellow); Console.Write("💸 3. "); C.Cs(ConsoleColor.White); Console.WriteLine("Facturas.");
                C.Cs(ConsoleColor.Yellow); Console.Write("🔎 4. "); C.Cs(ConsoleColor.White); Console.WriteLine("Carros en el estacionamiento");
                C.Cs(ConsoleColor.Yellow); Console.Write("❌ 5. "); C.Cs(ConsoleColor.Red); Console.WriteLine("Salir.");
                C.Cs(ConsoleColor.Yellow); Console.Write("📍 Seleccione una opción: ");

                C.Cs(ConsoleColor.Cyan); string? opcion = Console.ReadLine();
                
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
                C.Cs(ConsoleColor.Yellow); Console.Write("🟢 Semáforo en "); C.Cs(ConsoleColor.Green); Console.WriteLine("verde.");
                C.Cs(ConsoleColor.Yellow); Console.Write("🪪  Ingrese la matrícula del vehículo: \n--> ");
                string? matricula;     
                do
                {
                    C.Cs(ConsoleColor.Cyan); matricula = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(matricula))
                    {
                        C.Cs(ConsoleColor.Red); Console.Write("❌ El valor ingresado no es válido. Intente nuevamente."); C.Cs(ConsoleColor.Yellow); Console.Write("\n--> ");
                    }
                    else {break;}

                } while (true);
                
                
                Vehiculo nuevoVehiculo = new Vehiculo(matricula);
                estacionamiento.IngresarVehiculo(nuevoVehiculo);
                registro.RegistrarEntrada(nuevoVehiculo);
                //C.Cs(ConsoleColor.Yellow); Console.Write($"✅ Se ha asignado la tarjeta con código "); C.Cs(ConsoleColor.White); Console.WriteLine($"{nuevoVehiculo.Codigo}"); C.Cs(ConsoleColor.Yellow); Console.WriteLine($"al vehículo con matrícula ");  C.Cs(ConsoleColor.White); Console.WriteLine($"{matricula}.");
            }
            else
            {
                Console.Clear();
                C.Cs(ConsoleColor.Yellow); Console.Write("🔴 Semáforo en "); C.Cs(ConsoleColor.Red); Console.WriteLine("rojo.");
                C.Cs(ConsoleColor.Yellow); Console.WriteLine("❌ No hay espacios disponibles.");
                Console.WriteLine($"\n Presione enter...");
                Console.ReadKey();
            }
        }


        static void SalidaVehiculo()
        {
            Console.Clear();
            C.Cs(ConsoleColor.Yellow); Console.Write("🪪  Ingrese el código de la tarjeta del vehículo: \n--> ");
            C.Cs(ConsoleColor.Cyan); string? codigo = Console.ReadLine();
            

            Vehiculo vehiculo = estacionamiento.BuscarVehiculoPorCodigo(codigo);
            if (vehiculo != null)
            {                           
                C.Cs(ConsoleColor.Yellow); Console.Write("⏰ Ingrese la hora de salida "); C.Cs(ConsoleColor.Red); Console.WriteLine("[FORMATO: [HH:MM] FORMATO: [24H]].");
                C.Cs(ConsoleColor.Yellow); Console.Write("--> ");
                C.Cs(ConsoleColor.Cyan); string? horaSalidaInput = Console.ReadLine();
                DateTime horaSalida;
                DateTime fechaActual = DateTime.Now;

                while (!DateTime.TryParseExact(horaSalidaInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out horaSalida))
                {
                    C.Cs(ConsoleColor.Red); Console.WriteLine("Formato inválido.");
                    C.Cs(ConsoleColor.Yellow); Console.Write("⏰ Ingrese la hora de salida "); C.Cs(ConsoleColor.Red); Console.WriteLine("[FORMATO: [HH:MM] FORMATO: [24H]].");
                    C.Cs(ConsoleColor.Yellow); Console.Write("--> ");
                    C.Cs(ConsoleColor.Cyan); horaSalidaInput = Console.ReadLine();
                }

                
                horaSalida = new DateTime(fechaActual.Year, fechaActual.Month, fechaActual.Day, horaSalida.Hour, horaSalida.Minute, 0);

                string? factura = registro.FacturarSalida(vehiculo, horaSalida);
                //Console.WriteLine($"\nFactura generada:\n{factura}");

                estacionamiento.Facturar(vehiculo, horaSalida);
                
                estacionamiento.SalirVehiculo(codigo);
                C.Cs(ConsoleColor.Yellow); Console.WriteLine($"\n Presione enter...");
                Console.ReadKey();
            }
            else
            {
                C.Cs(ConsoleColor.Red); Console.WriteLine("❌ Código no encontrado.");
                C.Cs(ConsoleColor.Yellow); Console.WriteLine($"\n Presione enter...");
                Console.ReadKey();
            }
        }


        static void MostrarFacturas()
        {
            Console.Clear();
            foreach (var factura in registro.Facturas)
            {
                C.Cs(ConsoleColor.White); Console.WriteLine("---📋📋📋📋📋---");
                C.Cs(ConsoleColor.Yellow); Console.WriteLine(factura);
            }
            C.Cs(ConsoleColor.Yellow); Console.WriteLine($"\n Presione enter...");
            Console.ReadKey();
        }


        static void MostrarVehiculosEstacionados()
        {
            Console.Clear();
            foreach (var vehiculo in estacionamiento.Vehiculos)
            {
                C.Cs(ConsoleColor.Yellow); Console.WriteLine($"✅ Código: {vehiculo.Codigo}, Matrícula: {vehiculo.Matricula}, Hora de Entrada: {vehiculo.HoraEntrada}");
            }
            C.Cs(ConsoleColor.Yellow); Console.WriteLine($"\n Presione enter...");
            Console.ReadKey();
        }

    }
}
