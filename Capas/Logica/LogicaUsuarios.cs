using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuarios
    {
        public static void Alta(Usuarios unU)
        {
            PersistenciaUsuarios.Alta(unU);
        }

        public static void Modificar(Usuarios unU)
        {
            PersistenciaUsuarios.Modificar(unU);
        }

        public static void Eliminar(Usuarios unU)
        {
            PersistenciaUsuarios.Eliminar(unU);
        }

        public static Usuarios Buscar(int pCedula)
        {
            return (PersistenciaUsuarios.Buscar(pCedula));
        }

        public static List<Usuarios> ListarUsuarios()
        {
            return (PersistenciaUsuarios.ListarUsuarios());
        }
    }
}
