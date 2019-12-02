using System;
using Arquitectura4Capas.Negocio;
using Arquitectura4Capas.Entidades;

namespace Arquitectura4Capas.Presentacion
{
	class Program
	{


		static void Main(string[] args)
		{
			Usuario user = userMethods.iniciarUsuario();
			string opcionElegida = userMethods.listOpciones(false);
			userMethods.returnOpciones(opcionElegida, user);
			Console.ReadKey();
		}
	}
}
