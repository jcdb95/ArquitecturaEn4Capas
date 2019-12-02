using System;
using System.Collections.Generic;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Negocio;

namespace Arquitectura4Capas.Presentacion
{
	public static class bienesMethods
	{
		public static void returnOpciones(string opcionElegida, Usuario u)
		{
			switch (opcionElegida)
			{
				case "1":
					Console.WriteLine("Los bienes de que jugador te gustaria mostrar? (Elegi solo el ID)");
					userMethods.listJugadores(u, false);
					string idElegido = Console.ReadLine();
					listBienes(idElegido);
					break;
				case "2":
					Console.WriteLine("A que jugador le cargamos bienes?");
					userMethods.listJugadores(u, false);
					string idElegidoParaBienes = Console.ReadLine();
					AgregarBien(idElegidoParaBienes, u);
					break;
				default:
					Console.WriteLine("Tu opcion elegida fue incorrecta! Vamos de nuevo");
					userMethods.listOpciones(false);
					break;
			}
		}

		public static void listBienes(string id)
		{
			BienBBL servicioBienes = new BienBBL();
			JugadorBLL servicioJugador = new JugadorBLL();
			// Aca voy a buscar ese jugador 
			List<Bien> lst = servicioBienes.getAllBienes(Int32.Parse(id));
			Console.WriteLine("Los bienes del jugador " + id + " son:");
			foreach (var item in lst)
			{
				Console.WriteLine("- " + item.Nombre + " - $" + item.Precio.ToString());
			}
			Console.WriteLine("\n");
			Console.WriteLine("Esos fueron los vienes del jugador con que seguimos?");
			userMethods.listOpciones(false);
		}

		public static void AgregarBien(string idElegido, Usuario u)
		{
			Console.WriteLine("Que le vamos a cargar? (Casa, auto, yate, etc)");
			string bien = Console.ReadLine();
			Console.WriteLine("Que precio tiene?");
			string precio = Console.ReadLine();
			int precioInt, idElegidoInt;
			try
			{
				if (
					bien != null &&
					precio != null &&
					Int32.TryParse(precio, out precioInt) &&
					Int32.TryParse(idElegido, out idElegidoInt))
				{
					Bien nuevoBien = new Bien(1, devolverTipo(bien), Int32.Parse(idElegido), bien, Int32.Parse(precio), DateTime.Now.ToString("dd/mm/yyyy"));
					BienBBL servicioBien = new BienBBL();
					BitacoraBBL servicioBitacora = new BitacoraBBL();
					string rtaServer = servicioBien.EnviarBien(nuevoBien);
					if (rtaServer == "\"OK\"")
					{
						servicioBitacora.enviarPost(new Bitacora(u.Codigo, "Se creo un bien al jugador: " + idElegido, TipoConsultaEnum.Crear_jugador));
						userMethods.listOpciones(false);
					}
					else
					{
						Console.WriteLine("Ups! Hubo un error del server:" + rtaServer);
						AgregarBien(idElegido, u);
					}

				}
				else
				{
					Console.WriteLine("Ups cargaste mal algun dato, vamos de nuevo!");
					AgregarBien(idElegido, u);
				}
			}
			catch (System.Exception)
			{
				throw;
			}

		}

		public static int devolverTipo(string bienACargar)
		{
			if (
				bienACargar.ToUpper().IndexOf("CASA") != -1 ||
				bienACargar.ToUpper().IndexOf("MANSION") != -1 ||
				bienACargar.ToUpper().IndexOf("DEPARTAMENTO") != -1)
			{
				return (int)TipoAltaBienEnum.Casa;

			}
			else if (
				bienACargar.ToUpper().IndexOf("AUTO") != -1 ||
				bienACargar.ToUpper().IndexOf("CAMIONETA") != -1 ||
				bienACargar.ToUpper().IndexOf("MOTO") != -1
			)
			{
				return (int)TipoAltaBienEnum.Auto;

			}
			else
			{
				return (int)TipoAltaBienEnum.Otros;

			}
		}
	}
}