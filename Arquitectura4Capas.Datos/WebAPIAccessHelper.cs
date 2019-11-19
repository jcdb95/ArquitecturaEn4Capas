using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura4Capas.Datos
{
    public static class WebApiHelper
    {
        static WebClient client;
        static string rutaBase;

        static WebApiHelper()
        {
            client = new WebClient();
        }

        public static string Get(string url)
        {
            var responseString = client.DownloadString(url);
            return responseString;
        }

        public static string Post(string url, NameValueCollection parametros)
        {
            string uri = url;
            var response = client.UploadValues(uri, parametros);
            var responseString = Encoding.Default.GetString(response);
            return responseString;
        }
    }
}
