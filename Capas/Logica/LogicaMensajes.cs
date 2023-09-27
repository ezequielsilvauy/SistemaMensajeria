using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaMensajes
    {
        public static void Alta(Mensajes unM)
        {
            if (unM is Privado)
                PersistenciaPrivado.Alta((Privado)unM);
            else if (unM is Comun)
                PersistenciaComun.Alta((Comun)unM);
        }

        public static List<EntidadesCompartidas.Mensajes> ListarEnviados(Usuarios pCedulaE)
        {
            List<Mensajes> oLista = new List<Mensajes>();

            oLista.AddRange(PersistenciaPrivado.ListarEnviados(pCedulaE));

            return (oLista);
        }

        public static List<EntidadesCompartidas.Mensajes> ListarRecibidos(Usuarios pCedulaR)
        {
            List<Mensajes> oLista = new List<Mensajes>();

            oLista.AddRange(PersistenciaPrivado.ListarRecibidos(pCedulaR));

            return (oLista);
        }

        public static List<EntidadesCompartidas.Mensajes> ListarExT(Usuarios pCedulaE, TipoMensaje pTipoMensaje)
        {
            List<Mensajes> oLista = new List<Mensajes>();

            oLista.AddRange(PersistenciaComun.ListarEnviadosxTipo(pCedulaE, pTipoMensaje));

            return (oLista);
        }

        public static List<EntidadesCompartidas.Mensajes> ListarRxT(Usuarios pCedulaR, TipoMensaje pTipoMensaje)
        {
            List<Mensajes> oLista = new List<Mensajes>();

            oLista.AddRange(PersistenciaComun.ListarRecibidosxTipo(pCedulaR, pTipoMensaje));

            return (oLista);
        }
    }
}
