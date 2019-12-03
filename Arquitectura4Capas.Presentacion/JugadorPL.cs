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
			userMethods.returnOpciones(userMethods.listOpciones(false), user);
			Console.ReadKey();
		}
	}
}
