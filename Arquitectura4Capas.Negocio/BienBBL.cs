using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Datos;

namespace Arquitectura4Capas.Negocio
{
    public class BienBBL
    {
        BienesMapper mapper = new BienesMapper();

        public List<Bien> getAllBienes(int idJugador)
        {
            return mapper.getBienesByID(idJugador);
        }

        public string EnviarBien(Bien bien)
        {
            string result;
            result = mapper.EnviarBien(bien);
            return result;
        }
    }
}