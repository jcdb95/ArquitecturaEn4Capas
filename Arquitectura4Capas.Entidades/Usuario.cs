using System.Runtime.Serialization;

namespace Arquitectura4Capas.Entidades
{
    [DataContract(Name = "User")]
    public class Usuario
    {

        protected int _codigo;
        protected string _nombre;
        protected string _nombreUsuario;
        protected string _email;
        protected string _password;

        [DataMember(Name = "id")]
        public int Codigo { get { return _codigo; } set { _codigo = value; } }

        [DataMember(Name = "name")]
        public string Nombre { get { return _nombre; } set { _nombre = value; } }

        [DataMember(Name = "username")]
        public string NombreUsuario { get { return _nombreUsuario; } set { _nombreUsuario = value; } }

        [DataMember(Name = "email")]
        public string Email { get { return _email; } set { _email = value; } }

        [DataMember(Name = "phone")]
        public string Password { get { return _password; } set { _password = value; } }
    }
}