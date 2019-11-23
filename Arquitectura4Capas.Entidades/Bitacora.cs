using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura4Capas.Entidades
{
    public class Bitacora
    {
        private int _codigoUsuario, _tipoConsulta;
        private string _descripcion;
        public int CodigoUsuario { get { return _codigoUsuario; } set { _codigoUsuario = value; } }
        public int TipoConsulta { get { return _tipoConsulta; } set { _tipoConsulta = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public Bitacora(int usuario, string descripcion, TipoConsultaEnum consulta)
        {
            this._codigoUsuario = usuario;
            this._descripcion = descripcion;
            this._tipoConsulta = (int)consulta;
        }

    }
}
