using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Negocio;

namespace Arquitectura4Capas.Presentacion
{
    class Program
    {


        static void Main(string[] args)
        {

            JugadorBLL servicio = new JugadorBLL();
            BienBBL servicioBien = new BienBBL();
            // TODO: Agregar inputs para completar jugadores en consola
            // TODO: La idea es hacer algo web con vue
            // Jugador nuevoJugador = new Jugador(4, 883083, "Roberto", "Baggio", 7, 9);
            // servicio.SendJugador(nuevoJugador);
            List<Jugador> lst = servicio.GetJugador(883083);
            foreach (var item in lst)
            {
                Console.WriteLine(item.Nombre + " " + item.Apellido);
                foreach (var item2 in servicioBien.getAllBienes(item))
                {
                    Console.WriteLine(item2.Fecha);
                }
                // servicioBien.EnviarBien(new Bien(1, 1, item.Id, "Casa", 25000.00, "12/12/2019"));
                break;
            }


        }
    }
}
