using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arquitectura4Capas.Entidades;


namespace Arquitectura4Capas.Datos
{
    public class BitacoraMapper
    {
        public string EnviarLog(Bitacora bitacora)
        {
            try
            {
                NameValueCollection parametros = MappearADiccionario(bitacora);
                string result = WebApiHelper.Post("http://uba-cai.azurewebsites.net/api/Bitacora", parametros);
                return result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private NameValueCollection MappearADiccionario(Bitacora bitacora)
        {
            NameValueCollection valores = new NameValueCollection();
            valores["id"] = bitacora.CodigoUsuario.ToString();
            valores["descripcion"] = bitacora.Descripcion;
            valores["criticidad"] = bitacora.TipoConsulta.ToString();
            return valores;
        }
    }
}
