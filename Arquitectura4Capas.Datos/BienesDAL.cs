using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;

namespace Arquitectura4Capas.Datos
{
	public class BienesMapper
	{
		public List<Bien> getBienesByID(int codigoJugador)
		{
			try
			{
				string json2 = WebApiHelper.Get("http://uba-cai.azurewebsites.net/api/Bienes/" + codigoJugador.ToString());
				List<Bien> resultado = MapObj(json2);
				return resultado;
			}
			catch (System.Exception)
			{
				throw;
			}
		}
		private List<Bien> MapObj(string json)
		{
			try
			{
				MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(json));
				DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Bien>));
				List<Bien> lst = (List<Bien>)ser.ReadObject(stream1);
				return lst;
			}
			catch (System.Exception)
			{
				throw;
			}
		}

		public string EnviarBien(Bien bien)
		{
			try
			{
				NameValueCollection parametros = MappearADiccionario(bien);
				string result = WebApiHelper.Post("http://uba-cai.azurewebsites.net/api/bienes/" + bien.IdJugador.ToString(), parametros);
				return result;
			}
			catch (System.Exception)
			{

				throw;
			}
		}
		public string Delete(string idBien, string registro, string idJugador)
		{
			try
			{
				return WebApiHelper.Get("http://uba-cai.azurewebsites.net/api/Bienes/Delete?id=" + idBien.ToString() + "&idJugador=" + idJugador.ToString() + "&IdUsuario=" + registro.ToString());
			}
			catch (System.Exception)
			{

				throw;
			}
		}

		private NameValueCollection MappearADiccionario(Bien bien)
		{
			NameValueCollection valores = new NameValueCollection();
			valores["Id"] = bien.Id.ToString();
			valores["IdTipo"] = bien.IdTipo.ToString();
			valores["IdJugador"] = bien.IdJugador.ToString();
			valores["nombre"] = bien.Nombre;
			valores["precio"] = bien.Precio.ToString();
			valores["fecha"] = bien.Fecha.ToString();
			return valores;
		}
	}
}