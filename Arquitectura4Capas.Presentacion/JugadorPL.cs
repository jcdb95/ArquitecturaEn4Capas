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
            BitacoraBBL bitacora = new BitacoraBBL();


            // Jugador j2 = servicio.GetJugador(883083);
            // Console.WriteLine("El jugador obtenido es: " + j2.Nombre);
            Bitacora log = new Bitacora(883083, "Testing post method again v2", TipoConsultaEnum.CONSULTA_USUARIO);
            string resultPost = bitacora.enviarPost(log);
            Console.WriteLine(resultPost);
            Console.ReadKey();
        }
    }
}
