using System;
using System.Collections.Generic;

namespace AgendaTurnos
{
    class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Turno { get; set; }
        public string Especialidad { get; set; }
        public string Hora { get; set; }

        public Paciente(int id, string nombre, string cedula, string turno, string especialidad, string hora)
        {
            Id = id;
            Nombre = nombre;
            Cedula = cedula;
            Turno = turno;
            Especialidad = especialidad;
            Hora = hora;
        }

        public override string ToString()
        {
            return $"{Turno} | {Nombre} | {Cedula} | {Especialidad} | {Hora}";
        }
    }

    class Agenda
    {
        private List<Paciente> listaPacientes;

        public Agenda()
        {
            listaPacientes = new List<Paciente>();
        }

        public void AgregarTurno(Paciente paciente)
        {
            listaPacientes.Add(paciente);
            Console.WriteLine("✅ Turno agregado correctamente.");
        }

        public void MostrarTurnos()
        {
            Console.WriteLine("\n📋 Lista de Turnos:");
            if (listaPacientes.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
                return;
            }
            foreach (var paciente in listaPacientes)
            {
                Console.WriteLine(paciente);
            }
        }

        public void BuscarPorCedula(string cedula)
        {
            var paciente = listaPacientes.Find(p => p.Cedula == cedula);
            if (paciente != null)
            {
                Console.WriteLine("\n🔍 Paciente encontrado:");
                Console.WriteLine(paciente);
            }
            else
            {
                Console.WriteLine("❌ Paciente no encontrado.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            int opcion;
            do
            {
                Console.WriteLine("\n--- Menú de Turnos de Pacientes ---");
                Console.WriteLine("1. Agendar nuevo turno");
                Console.WriteLine("2. Ver todos los turnos");
                Console.WriteLine("3. Buscar paciente por cédula");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        Console.Write("ID del paciente: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nombre completo: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Cédula: ");
                        string cedula = Console.ReadLine();
                        Console.Write("Turno (ej: T01): ");
                        string turno = Console.ReadLine();
                        Console.Write("Especialidad: ");
                        string especialidad = Console.ReadLine();
                        Console.Write("Hora (ej: 09:30): ");
                        string hora = Console.ReadLine();
                        agenda.AgregarTurno(new Paciente(id, nombre, cedula, turno, especialidad, hora));
                        break;
                    case 2:
                        agenda.MostrarTurnos();
                        break;
                    case 3:
                        Console.Write("Ingrese cédula a buscar: ");
                        string buscarCedula = Console.ReadLine();
                        agenda.BuscarPorCedula(buscarCedula);
                        break;
                    case 4:
                        Console.WriteLine("👋 Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción no válida.");
                        break;
                }
            } while (opcion != 4);
        }
    }
}

