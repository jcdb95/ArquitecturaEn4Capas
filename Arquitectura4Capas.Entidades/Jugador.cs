using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Arquitectura4Capas.Entidades
{
	[DataContract]
	public class Jugador
	{
		private string _nombre, _apellido;
		private double _fuerza, _angulo;
		private int _id;

		[DataMember]
		public int Id { get { return _id; } set { _id = value; } }

		[DataMember]
		public string Nombre { get { return _nombre; } set { _nombre = value; } }
		[DataMember]
		public string Apellido { get { return _apellido; } set { _apellido = value; } }
		[DataMember]
		public double Fuerza { get { return _fuerza; } set { _fuerza = value; } }
		[DataMember]
		public double Angulo { get { return _angulo; } set { _angulo = value; } }
		public double Distancia { get { return _angulo * Math.PI * _fuerza / 360; } }

		public Jugador(int id, string nombre, string apellido, double fuerza, double angulo)
		{
			_id = id;
			_nombre = nombre;
			_apellido = apellido;

			if (fuerza > 0)
			{
				_fuerza = fuerza;
			}
			else
			{
				throw new Exception("Ingrese un valor mayor a cero");
			}

			if (angulo >= 0 && angulo <= 180)
			{
				_angulo = angulo;
			}
			else
			{
				throw new Exception("El valor del angulo debe estar entre >= 0° y <= 180°");
			}
		}
	}
}
