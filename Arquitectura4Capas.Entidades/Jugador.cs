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
        private int _id, _idUsuario;
        private List<Bien> _bienes;

        [DataMember]
        public int Id { get { return _id; } set { _id = value; } }
        [DataMember]
        public int IdUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
        //[DataMember(Name = "nombre")] asi se castea un valor cuando lo queres igual que la base de datos
        [DataMember]
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        [DataMember]
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        [DataMember]
        public double Fuerza { get { return _fuerza; } set { _fuerza = value; } }
        [DataMember]
        public double Angulo { get { return _angulo; } set { _angulo = value; } }

        public List<Bien> Bienes { get { return _bienes; } set { _bienes = value; } }

        public Jugador(int id, int usuario, string nombre, string apellido, double fuerza, double ang)
        {
            _id = id;
            _idUsuario = usuario;
            _nombre = nombre;
            _apellido = apellido;
            if (fuerza > 0 && fuerza < 11)
            {
                _fuerza = fuerza;
            }
            else
            {
                throw new Exception("Ingresa un numero mayor a cero");
            }
            _angulo = ang;
        }

        public override string ToString()
        {
            return Nombre + " - " + Apellido;
        }
        public void ToStringWithId()
        {
            Console.WriteLine(Id + " - " + Nombre + " - " + Apellido);
        }
    }
}
