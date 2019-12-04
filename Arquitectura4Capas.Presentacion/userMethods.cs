using System;
using System.Collections.Generic;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Negocio;

namespace Arquitectura4Capas.Presentacion
{
    public static class userMethods
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
        public static string listOpciones(Boolean isBienes)
        {
            Console.WriteLine("De estas opciones:");
            if (!isBienes)
            {
                foreach (TipoConsultaEnum e in Enum.GetValues(typeof(TipoConsultaEnum)))
                {
                    Console.WriteLine("{1} - {0}", e, (int)e);
                }
            }
            else
            {
                foreach (TipoConsultaBienes e in Enum.GetValues(typeof(TipoConsultaBienes)))
                {
                    Console.WriteLine("{1} - {0}", e, (int)e);
                }
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
                    listJugadores(u, true, false, false);

                    break;
                case "2":
                    Console.WriteLine("Elegiste crear un jugador");
                    createJugador(u);
                    returnOpciones(listOpciones(false), u);
                    break;
                case "3":
                    Console.WriteLine("Elegiste eliminar un jugador");
                    deleteJugador(u);
                    break;
                case "4":
                    Console.WriteLine("Elegiste trabajar con bienes");
                    bienesMethods.returnOpciones(listOpciones(true), u);
                    break;
                case "5":
                    Console.WriteLine("Elegiste eliminar bienes");
                    bienesMethods.returnOpciones(listOpciones(true), u);
                    break;
                case "0":
                    Console.WriteLine("Hasta luego!");
                    Environment.Exit(0);
                    bienesMethods.returnOpciones(listOpciones(true), u);
                    break;
                default:
                    Console.WriteLine("Mmm opcion incorrecta, vamos de nuevo");
                    listOpciones(false);
                    break;
            }
        }

        // Funcion que lista a los jugadores
        public static void listJugadores(Usuario u, Boolean justShowing, Boolean forBienes, Boolean deletingPlayers)
        {
            JugadorBLL servicioJugador = new JugadorBLL();
            List<Jugador> lst = servicioJugador.GetJugador(u.Codigo);
            foreach (var jugador in lst)
            {
                if (justShowing)
                {
                    Console.WriteLine(jugador.ToString());
                }
                else if (!justShowing)
                {
                    jugador.ToStringWithId();
                }
            }
            if (!forBienes && !deletingPlayers) checkIfContinue(u);
            // checkIfContinue(u);
        }

        public static void checkIfContinue(Usuario u)
        {
            Console.WriteLine("Seguimos? (y/n)");
            string answer = Console.ReadLine().ToUpper();
            if (answer == "Y" || answer == "YES" || answer == "SI")
            {
                returnOpciones(listOpciones(false), u);
            }
            else
            {
                Console.WriteLine("Hasta luego!");
                Environment.Exit(0);
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
            Console.WriteLine("Angulo (entre 0 y 90):");
            string anguloJugador = Console.ReadLine();
            try
            {
                Jugador jugadorNuevo = new Jugador(1, u.Codigo, nombreJugador, apellidoJugador, Int32.Parse(fuerzaJugador), Int32.Parse(anguloJugador));
                string rtaServer = servicioJugador.SendJugador(jugadorNuevo);
                if (rtaServer == "\"OK\"")
                {
                    servicioBitacora.enviarPost(new Bitacora(u.Codigo, "Se creo un jugador", TipoConsultaEnum.Crear_jugador));
                    Console.WriteLine("Jugador creado con exito! Con que seguimos?");
                    checkIfContinue(u);
                }
                else
                {
                    Console.WriteLine("Ups! Hubo un error del server:" + rtaServer);
                    createJugador(u);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Hubo un error en el server:" + e.ToString());
            }
        }

        // Funcion que toma los datos para eliminar un jugador
        public static void deleteJugador(Usuario u)
        {
            JugadorBLL servicioJugador = new JugadorBLL();
            BitacoraBBL servicioBitacora = new BitacoraBBL();
            Console.WriteLine("Que jugador te gustaria eliminar? (ingresa solo el id)");
            listJugadores(u, false, false, true);
            Console.WriteLine("ID:");
            string idJugadorToDelete = Console.ReadLine();
            try
            {
                string rtaServer = servicioJugador.DeleteJugador(u.Codigo.ToString(), idJugadorToDelete);
                if (rtaServer == "\"OK\"")
                {
                    servicioBitacora.enviarPost(new Bitacora(u.Codigo, "Se elimino un jugador", TipoConsultaEnum.Eliminar_jugador));
                    Console.WriteLine("Jugador eliminado con exito!");
                    checkIfContinue(u);
                }
                else
                {
                    Console.WriteLine("Ups! Hubo un error del server:" + rtaServer);
                    deleteJugador(u);
                }
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Hubo un error en el server:" + e.ToString());
                checkIfContinue(u);

            }
        }


    }
}