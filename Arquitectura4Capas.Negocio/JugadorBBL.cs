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
        private JugadorDAL mapperJugador = new JugadorDAL();
        public Jugador GetJugador(int id)
        {
            Jugador obj = mapperJugador.Get(id);
            return obj;
        }
    }
}
