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
        BienesMapper mapperBienes = new BienesMapper();
        // Get de jugador
        public List<Jugador> GetJugador(int id)
        {
            List<Jugador> lst = mapperJugador.GetJugadores(id);
            foreach (var jugador in lst)
            {
                jugador.Bienes = mapperBienes.getBienesByID(jugador.Id);
            }
            return lst;
        }
        //Post de jugador
        public string SendJugador(Jugador j)
        {
            return mapperJugador.AddJugador(j);
        }
        // Delete de
        public string DeleteJugador(string idUsuario, string id)
        {
            return mapperJugador.Delete(idUsuario, id);
        }

    }
}
