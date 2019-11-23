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
            string json2 = WebApiHelper.Get("http://uba-cai.azurewebsites.net/api/Bienes/" + codigoJugador.ToString());
            List<Bien> resultado = MapObj(json2);
            return resultado;
        }
        private List<Bien> MapObj(string json)
        {
            MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Bien>));
            List<Bien> lst = (List<Bien>)ser.ReadObject(stream1);
            return lst;
        }

        public string EnviarBien(Bien bien)
        {
            NameValueCollection parametros = MappearADiccionario(bien);

            string result = WebApiHelper.Post("bienes/" + bien.IdJugador.ToString(), parametros);

            return result;
        }

        private NameValueCollection MappearADiccionario(Bien bien)
        {
            NameValueCollection valores = new NameValueCollection();
            valores["Id"] = bien.Id.ToString();
            valores["IdTipo"] = bien.IdTipo.ToString();
            valores["IdJugador"] = bien.IdJugador.ToString();
            valores["Nombre"] = bien.Nombre;
            valores["Precio"] = bien.Precio.ToString();
            valores["Fecha"] = bien.Fecha.ToString();
            return valores;
        }
    }
}