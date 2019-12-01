using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Negocio;
using Arquitectura4Capas.Entidades;

namespace Arquitectura4Capas.Presentacion
{
    class Program
    {


        static void Main(string[] args)
        {
            Usuario user = userMethods.iniciarUsuario();
            string opcionElegida = userMethods.listOpciones(false);
            userMethods.returnOpciones(opcionElegida, user);
            Console.ReadKey();
        }
    }
}
