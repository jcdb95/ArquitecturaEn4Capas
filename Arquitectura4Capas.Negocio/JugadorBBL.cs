using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Datos;


namespace Arquitectura4Capas.Negocio
{
    public class JugadorBLL
    {
        JugadorDAL mapperJugador = new JugadorDAL();
        // Get de jugador
        public List<Jugador> GetJugador(int id)
        {
            List<Jugador> lst = mapperJugador.GetJugadores(id);
            return lst;
        }
        //Post de jugador
        public string SendJugador(Jugador j)
        {
            Console.WriteLine("Fue llamada la funcion SendJugador en Capa de Negocio");
            return mapperJugador.AddJugador(j);
        }
        // Delete de
        public void DeleteJugador(string idUsuario, string id)
        {
            mapperJugador.Delete(idUsuario, id);
        }
    }
}
