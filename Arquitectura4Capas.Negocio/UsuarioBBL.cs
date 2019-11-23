using System;
using System.Collections.Generic;
using System.Text;
using Arquitectura4Capas.Entidades;
using Arquitectura4Capas.Datos;

namespace Arquitectura4Capas.Negocio
{
    public class UsuarioBBL
    {
        UsuarioDAL mapper = new UsuarioDAL();

        public Usuario getUserByID(int id)
        {
            // Usuario u = new Usuario();
            return mapper.getUsuarioByID(id);
        }
    }
}