using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;

namespace Arquitectura4Capas.Datos
{
	public class JugadorDAL
	{

		public Jugador Get(int id)
		{
			string id_string = id.ToString();
			string resultado = WebApiHelper.Get("http://uba-cai.azurewebsites.net/api/Usuarios/" + id_string);
			Jugador j = MapearObjeto(resultado);
			return j;
		}

		private Jugador MapearObjeto(string json)
		{
			MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(json));
			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Jugador));
			Jugador lst = (Jugador)ser.ReadObject(stream1);
			return lst;
		}

	}
}
