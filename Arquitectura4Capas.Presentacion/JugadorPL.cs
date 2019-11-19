using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Negocio;

namespace Arquitectura4Capas.Presentacion
{
	class Program
	{


		static void Main(string[] args)
		{
			/*
            string nombre = string.Empty, apellido = string.Empty;
            double fuerza, angulo;

            Console.WriteLine("Por favor ingrese su nombre:");
            nombre = Console.ReadLine();

            Console.WriteLine("Por favor ingrese su apellido:");
            apellido = Console.ReadLine();

            Console.WriteLine("Por favor ingrese su fuerza:");
            fuerza = double.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingrese un ángulo:");
            angulo = double.Parse(Console.ReadLine());

            Jugador j = new Jugador(nombre, apellido, fuerza, angulo);

            Console.WriteLine("La distancia de tiro del jugador: " + j.Nombre + ", " + j.Apellido + " es " + j.Distancia.ToString() + " metros.");

            double suma = Calculadora.Suma(j.Angulo, j.Fuerza);

            // traer de servicio

            Console.WriteLine("ingrese el id de jugador a traer: ");
            int id = int.Parse(Console.ReadLine());
            */
			JugadorBLL servicio = new JugadorBLL();



			Jugador j2 = servicio.Get(883083);

			Console.WriteLine("El jugador obtenido es: " + j2.Nombre);
			Console.ReadKey();
		}
	}
}
