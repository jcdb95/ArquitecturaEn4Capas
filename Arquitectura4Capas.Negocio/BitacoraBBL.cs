using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Datos;

namespace Arquitectura4Capas.Negocio
{
    public class BitacoraBBL
    {
        BitacoraMapper mapperBitacora = new BitacoraMapper();

        public string enviarPost(Bitacora bitacoraAEnviar)
        {
            string pepe = mapperBitacora.EnviarLog(bitacoraAEnviar);
            return pepe;
        }
    }
}