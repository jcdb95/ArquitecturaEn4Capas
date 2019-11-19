using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura4Capas.Entidades
{
	public class Bitacora
	{
		public int codigoUsuario { get; set; }
		public string descripcion { get; set; }
		public int tipoConsulta { get; set; }

		public Bitacora(int usuario, string descripcion, TipoConsultaEnum consulta)
		{
			this.codigoUsuario = usuario;
			this.descripcion = descripcion;
			this.tipoConsulta = (int)consulta;
		}

	}
}
