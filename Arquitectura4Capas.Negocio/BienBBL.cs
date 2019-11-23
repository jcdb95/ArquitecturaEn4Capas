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

        public List<Bien> getAllBienes(Jugador j)
        {
            List<Bien> lista = mapper.getBienesByID(j.Id);
            j.Bienes = lista;
            return lista;
        }

        public string EnviarBien(Bien bien)
        {
            string result;
            result = mapper.EnviarBien(bien);
            return result;
        }
    }
}