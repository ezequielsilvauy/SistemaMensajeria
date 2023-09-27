using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Comun : Mensajes
    {
        //atributo asoc
        TipoMensaje TipoMensaje;

        //propiedades
        public TipoMensaje tipoMensaje
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse el tipo de mensaje");
                else
                    TipoMensaje = value;
            }
            get { return TipoMensaje; }
        }

        //constructor
        public Comun(string pAsunto, string pTexto, Usuarios pCedulaE, Usuarios pCedulaR, int pNumInt, DateTime pFechaHora, TipoMensaje pTipoMensaje)
            : base(pAsunto, pTexto, pCedulaE, pCedulaR, pNumInt, pFechaHora)
        {
            tipoMensaje = pTipoMensaje;
        }

        //operaciones
        public override string ToString()
        {
            return base.ToString() + "Tipo de mensaje: " + tipoMensaje;
        }
    }
}
