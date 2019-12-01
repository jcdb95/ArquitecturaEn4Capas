using System.Runtime.Serialization;

namespace Arquitectura4Capas.Entidades
{
    [DataContract(Name = "bien")]
    public class Bien
    {
        private int _id, _idUsuario, _idTipo, _idJugador;
        private string _nombreJugador, _fecha;
        private double _precio;
        [DataMember]
        public int Id { get { return _id; } set { _id = value; } }
        [DataMember]
        public int IdTipo { get { return _idUsuario; } set { _idUsuario = value; } }
        [DataMember]
        public int IdJugador { get { return _idJugador; } set { _idJugador = value; } }
        [DataMember(Name = "nombre")]
        public string Nombre { get { return _nombreJugador; } set { _nombreJugador = value; } }
        [DataMember(Name = "precio")]
        public double Precio { get { return _precio; } set { _precio = value; } }
        [DataMember(Name = "fecha")]
        public string Fecha { get { return _fecha; } set { _fecha = value; } }

        public Bien(int Id, int IdTipo, int IdJugador, string Nombre, double Precio, string Fecha)
        {
            this.Id = Id;
            this.IdTipo = IdTipo;
            this.IdJugador = IdJugador;
            this.Nombre = Nombre;
            this.Precio = Precio;
            this.Fecha = Fecha;
        }
    }
}