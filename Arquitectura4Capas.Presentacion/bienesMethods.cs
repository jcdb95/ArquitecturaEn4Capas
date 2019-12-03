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
					listBienes(idElegido, false, u);
					break;
				case "2":
					Console.WriteLine("A que jugador le cargamos bienes? Ingresa solo el ID");
					userMethods.listJugadores(u, false);
					string idElegidoParaBienes = Console.ReadLine();
					AgregarBien(idElegidoParaBienes, u);
					break;
				case "3":
					Console.WriteLine("A que jugador le borramos bienes? Ingresa solo el ID");
					userMethods.listJugadores(u, false);
					string idElegidoParaEliminarleBienes = Console.ReadLine();
					DeleteBien(idElegidoParaEliminarleBienes, u);
					break;
				default:
					Console.WriteLine("Tu opcion elegida fue incorrecta! Vamos de nuevo");
					userMethods.listOpciones(false);
					break;
			}
		}

		public static void listBienes(string id, Boolean justShowing, Usuario u)
		{
			BienBBL servicioBienes = new BienBBL();
			JugadorBLL servicioJugador = new JugadorBLL();
			// Aca voy a buscar ese jugador 
			Console.WriteLine(servicioBienes.getAllBienes(Int32.Parse(id)).Capacity);
			List<Bien> lst = servicioBienes.getAllBienes(Int32.Parse(id));
			Console.WriteLine("Los bienes del jugador " + id + " son:");
			if (lst.Capacity > 0 && !justShowing)
			{
				foreach (var item in lst)
				{
					Console.WriteLine("- " + item.Id + " - " + item.Nombre + " - $" + item.Precio.ToString());
				}
				Console.WriteLine("\n");
				Console.WriteLine("Esos fueron los Bienes del jugador con que seguimos?");
				userMethods.listOpciones(false);
				userMethods.returnOpciones(userMethods.listOpciones(false), u);
			}
			else if (lst.Capacity > 0 && justShowing)
			{
				foreach (var item in lst)
				{
					Console.WriteLine("- " + item.Id + " - " + item.Nombre + " - $" + item.Precio.ToString());
				}
				userMethods.returnOpciones(userMethods.listOpciones(false), u);

			}
			else
			{
				Console.WriteLine("\n");
				Console.WriteLine("MM parece que el jugador no tiene bienes ¯|_(ツ)_|¯ ");
				userMethods.returnOpciones(userMethods.listOpciones(false), u);

			}
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
					string rtaServer = servicioBien.EnviarBien(nuevoBien);
					if (rtaServer == "\"OK\"")
					{
						BitacoraBBL servicioBitacora = new BitacoraBBL();
						servicioBitacora.enviarPost(new Bitacora(u.Codigo, "Se creo un bien al jugador: " + idElegido, TipoConsultaEnum.Crear_jugador));
						Console.WriteLine("Se creo el bien: " + bien + " por: $" + precio + " - Con exito!");
						userMethods.returnOpciones(userMethods.listOpciones(false), u);
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
			catch (System.Exception e)
			{
				Console.WriteLine("Hubo un error en el server:" + e.ToString());
			}

		}

		public static void DeleteBien(string idJugador, Usuario u)
		{
			Console.WriteLine("Okey, vamos a eliminar algunos bienes!");
			Console.WriteLine("De estos bienes cual eliminamos? Ingresa solo el ID:");
			listBienes(idJugador, true, u);
			Console.WriteLine("\n");
			Console.WriteLine("ID:");
			string idBien = Console.ReadLine();

			try
			{
				BienBBL servicioBien = new BienBBL();
				string rtaServer = servicioBien.DeleteBien(idBien, u.Codigo.ToString(), idJugador);
				if (rtaServer == "\"OK\"")
				{
					BitacoraBBL servicioBitacora = new BitacoraBBL();
					servicioBitacora.enviarPost(new Bitacora(u.Codigo, "Se elimino el bien: " + idBien, TipoConsultaEnum.Trabajar_con_bienes));
					Console.WriteLine("El bien " + idBien + " Se elimino con exito!");
					userMethods.returnOpciones(userMethods.listOpciones(false), u);

				}
				else
				{
					Console.WriteLine("Ups! Hubo un error del server:" + rtaServer);
					DeleteBien(idJugador, u);
				}

			}
			catch (System.Exception e)
			{
				Console.WriteLine("Hubo un error:" + e.ToString());
				userMethods.returnOpciones(userMethods.listOpciones(false), u);
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