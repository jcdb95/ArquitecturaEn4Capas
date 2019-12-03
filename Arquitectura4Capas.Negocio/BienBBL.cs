using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Datos;

namespace Arquitectura4Capas.Negocio
{
	public class BienBBL
	{
		BienesMapper mapperBienes = new BienesMapper();

		public List<Bien> getAllBienes(int idJugador)
		{
			return mapperBienes.getBienesByID(idJugador);
		}

		public string EnviarBien(Bien bien)
		{
			string result;
			result = mapperBienes.EnviarBien(bien);
			return result;
		}

		public string DeleteBien(string idBien, string idUsuario, string idJugador)
		{
			return mapperBienes.Delete(idBien, idUsuario, idJugador);
		}
	}
}