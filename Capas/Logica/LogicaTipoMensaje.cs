using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaTipoMensaje
    {
        public static TipoMensaje Buscar(string pCodigoInterno)
        {
            return (PersistenciaTipoMensaje.Buscar(pCodigoInterno));
        }

        public static void Modificar(TipoMensaje unT)
        {
            PersistenciaTipoMensaje.Modificar(unT);
        }

        public static void Eliminar(TipoMensaje unT)
        {
            PersistenciaTipoMensaje.Eliminar(unT);
        }

        public static void Alta(TipoMensaje unT)
        {
            PersistenciaTipoMensaje.Alta(unT);
        }

        public static List<TipoMensaje> ListarTipoMensaje(string codigoInterno)
        {
            return (PersistenciaTipoMensaje.ListarTipoMensaje(codigoInterno));
        }
    }
}
