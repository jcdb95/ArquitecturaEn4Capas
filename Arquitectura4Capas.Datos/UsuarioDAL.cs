using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Arquitectura4Capas.Entidades;

namespace Arquitectura4Capas.Datos
{
    public class UsuarioDAL
    {
        public Usuario getUsuarioByID(int codigo)
        {
            string json2 = WebApiHelper.Get("http://uba-cai.azurewebsites.net/api/usuarios/" + codigo.ToString());
            return MapObj(json2);
        }

        private Usuario MapObj(string json)
        {
            MemoryStream stream1 = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Usuario));
            return (Usuario)ser.ReadObject(stream1);
        }
    }
}