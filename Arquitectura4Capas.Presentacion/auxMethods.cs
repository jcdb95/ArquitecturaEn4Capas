using System;
using System.Collections.Generic;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Negocio;

namespace Arquitectura4Capas.Presentacion
{
    public static class auxMethods
    {
        // Inicio al usuario con el que voy a listar, crear o eliminar jugadores
        public static Usuario iniciarUsuario()
        {
            Console.WriteLine("Hola! ingresa tu numero de registro:");

            string idUsuarioString = Console.ReadLine();
            int idUsuario;
            UsuarioBBL serivicioUsuario = new UsuarioBBL();
            while (!int.TryParse(idUsuarioString, out idUsuario))
            {
                Console.WriteLine("El numero ingresado no es correcto! Ingresalo de nuevo:");
                idUsuarioString = Console.ReadLine();
            }
            Usuario nuevoUsuario = serivicioUsuario.getUserByID(idUsuario);
            Console.WriteLine("Hola {0}!", nuevoUsuario.Nombre);
            return nuevoUsuario;
        }

        // listado de las opciones principales
        public static string listOpciones()
        {
            Console.WriteLine("De estas opciones:");
            foreach (TipoConsultaEnum e in Enum.GetValues(typeof(TipoConsultaEnum)))
            {
                Console.WriteLine("{1} - {0}", e, (int)e);
            }
            Console.WriteLine("Que te gustaria hacer? (ingresa solo el numero de la opcion)");
            string opcionSeleccionada = Console.ReadLine();
            while (string.IsNullOrEmpty(opcionSeleccionada))
            {
                Console.WriteLine("Selecciona una opcion valida! Vamos de nuevo:");
                opcionSeleccionada = Console.ReadLine();
            }
            return opcionSeleccionada;

        }


        // Segun la opcion elegida hago distintas cosas
        public static void returnOpciones(string opc, Usuario u)
        {
            switch (opc)
            {
                case "1":
                    Console.WriteLine("Elegiste listar jugadores");
                    listJugadores(u, true);
                    break;
                case "2":
                    Console.WriteLine("Elegiste crear un jugador");
                    createJugador(u);
                    break;
                case "3":
                    Console.WriteLine("Elegiste eliminar un jugador");
                    deleteJugador(u);
                    break;
                default:
                    Console.WriteLine("Mmm opcion incorrecta, vamos de nuevo");
                    listOpciones();
                    break;
            }
        }

        // Funcion que lista a los jugadores
        public static void listJugadores(Usuario u, Boolean justShowing)
        {
            JugadorBLL servicioJugador = new JugadorBLL();
            List<Jugador> lst = servicioJugador.GetJugador(u.Codigo);
            foreach (var jugador in lst)
            {
                if (justShowing)
                {
                    Console.WriteLine("Nombre: {0} - Apellido: {1}", jugador.Nombre, jugador.Apellido);
                }
                else if (!justShowing)
                {
                    Console.WriteLine("ID:{0} - Nombre: {1} - Apellido: {2}", jugador.Id, jugador.Nombre, jugador.Apellido);
                }
            }
        }

        // Funcion que crea a los jugadores
        public static void createJugador(Usuario u)
        {
            JugadorBLL servicioJugador = new JugadorBLL();
            BitacoraBBL servicioBitacora = new BitacoraBBL();
            Console.WriteLine("Completa los campos para crear un jugador: \n");
            Console.WriteLine("Nombre:");
            string nombreJugador = Console.ReadLine();
            Console.WriteLine("Apellido:");
            string apellidoJugador = Console.ReadLine();
            Console.WriteLine("Fuerza (entre 1 y 10):");
            string fuerzaJugador = Console.ReadLine();
            Console.WriteLine("Angulo:");
            string anguloJugador = Console.ReadLine();
            try
            {
                Jugador jugadorNuevo = new Jugador(1, u.Codigo, nombreJugador, apellidoJugador, Int32.Parse(fuerzaJugador), Int32.Parse(anguloJugador));
                servicioBitacora.enviarPost(new Bitacora(u.Codigo, "Se creo un jugador", TipoConsultaEnum.Crear_jugador));
                string rtaServer = servicioJugador.SendJugador(jugadorNuevo);
                if (rtaServer == "\"OK\"")
                {
                    Console.WriteLine("Jugador creado con exito! Con que seguimos?");
                    listOpciones();
                }
                else
                {
                    Console.WriteLine("Ups! Hubo un error del server:" + rtaServer);
                    createJugador(u);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // Funcion que toma los datos para eliminar un jugador
        public static void deleteJugador(Usuario u)
        {
            JugadorBLL servicioJugador = new JugadorBLL();
            BitacoraBBL servicioBitacora = new BitacoraBBL();
            Console.WriteLine("Que jugador te gustaria eliminar? (ingresa solo el id)");
            listJugadores(u, false);
            Console.WriteLine("ID:");
            string idJugadorToDelete = Console.ReadLine();
            try
            {
                servicioBitacora.enviarPost(new Bitacora(u.Codigo, "Se creo un jugador", TipoConsultaEnum.Crear_jugador));
                string rtaServer = servicioJugador.DeleteJugador(u.Codigo.ToString(), idJugadorToDelete);
                Console.WriteLine(rtaServer);
                if (rtaServer == "\"OK\"")
                {
                    Console.WriteLine("Jugador eliminado con exito!");
                }
                else
                {
                    Console.WriteLine("Ups! Hubo un error del server:" + rtaServer);
                    deleteJugador(u);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }


    }
}