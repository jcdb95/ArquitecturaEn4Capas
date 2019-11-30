using System.IO;
using System;
using System.Runtime.Serialization.Json;
using System.Text;
using Arquitectura4Capas.Entidades;
using System.Collections.Specialized;
using System.Collections.Generic;


namespace Arquitectura4Capas.Datos
{
    public class JugadorDAL
    {

        public List<Jugador> GetJugadores(int idUsuario)
        {
            try
            {
                string json2 = WebApiHelper.Get("http://uba-cai.azurewebsites.net/api/jugador/" + idUsuario.ToString()); // trae un texto en formato json de una web
                List<Jugador> resultado = MapObj(json2);
                return resultado;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private List<Jugador> MapObj(string json)
        {
            try
            {
                MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(json));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Jugador>));
                List<Jugador> lst = (List<Jugador>)ser.ReadObject(stream1);
                return lst;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string AddJugador(Jugador jugador)
        {
            try
            {
                NameValueCollection parametros = mapping(jugador);
                string result = WebApiHelper.Post("http://uba-cai.azurewebsites.net/api/jugador/" + jugador.IdUsuario.ToString(), parametros);
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public string Delete(string registro, string idJugador)
        {
            try
            {
                return WebApiHelper.Get("http://uba-cai.azurewebsites.net/api/Jugador/Delete?codigo=" + idJugador.ToString() + "&registro=" + registro);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        private NameValueCollection mapping(Jugador jugador)
        {
            NameValueCollection valores = new NameValueCollection();
            valores["Id"] = jugador.Id.ToString();
            valores["IdUsuario"] = jugador.IdUsuario.ToString();
            valores["Nombre"] = jugador.Nombre;
            valores["Apellido"] = jugador.Apellido;
            valores["Fuerza"] = jugador.Fuerza.ToString();
            valores["Angulo"] = jugador.Angulo.ToString();
            return valores;
        }

    }
}
