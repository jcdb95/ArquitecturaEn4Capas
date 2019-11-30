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
            Usuario user = auxMethods.iniciarUsuario();
            string opcionElegida = auxMethods.listOpciones();
            auxMethods.returnOpciones(opcionElegida, user);
            Console.ReadKey();
        }
    }
}
