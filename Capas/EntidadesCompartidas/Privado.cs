using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Privado : Mensajes
    {
        //atributos
        private DateTime fechaCad;

        //propiedades
        public DateTime FechaCad
        {
            get { return fechaCad; }
            set
            {
                if (value < DateTime.Now)
                    throw new Exception("No se permite la fecha de caducidad introducida.");
                else
                    fechaCad = value;
            }
        }


        //constructor
        public Privado(string pAsunto, string pTexto, Usuarios pCedulaE, Usuarios pCedulaR, DateTime pFechaCad, int pNumInt, DateTime pFechaHora)
            : base(pAsunto, pTexto, pCedulaE, pCedulaR, pNumInt, pFechaHora)
        {
            FechaCad = pFechaCad;
        }

        //operaciones
        public override string ToString()
        {
            return ("Fecha de Caducidad: " + FechaCad) + base.ToString();
        }
    }
}
