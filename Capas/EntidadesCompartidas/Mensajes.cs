using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EntidadesCompartidas
{
    public abstract class Mensajes
    {
        //atributos
        private int numInt;
        private DateTime fechaHora;
        private string asunto;
        private string texto;

        //atributo de asoc.
        Usuarios cedulaE;
        Usuarios cedulaR;

        //propiedades
        public int NumInt
        {
            get { return numInt; }
            set { numInt = value; }
        }
        public DateTime Fechahora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }
        public string Asunto
        {
            get { return asunto; }
            set
            {
                if (value.Trim().Length > 50 || value.Trim().Length <= 0)
                    throw new Exception("Se permite un máximo de 50 caracteres");
                else
                    asunto = value;
            }
        }
        public string Texto
        {
            get { return texto; }
            set
            {
                if (value.Trim().Length > 200 || value.Trim().Length <= 0)
                    throw new Exception("Se permite un máximo de 200 caracteres");
                else
                    texto = value;
            }
        }
        public Usuarios CedulaE
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse la cédula del usuario que envía");
                else
                    cedulaE = value;
            }
            get { return cedulaE; }
        }
        public Usuarios CedulaR
        {
            set
            {
                if (value == null)
                    throw new Exception("Debe saberse el nombre del usuario que recibe.");
                else
                    cedulaR = value;
            }
            get { return cedulaR; }
        }

        //constructor
        public Mensajes(string pAsunto, string pTexto, Usuarios pCedulaE, Usuarios pCedulaR, int pNumInt, DateTime pFechaHora)
        {
            Asunto = pAsunto;
            Texto = pTexto;
            CedulaE = pCedulaE;
            CedulaR = pCedulaR;
            NumInt = pNumInt;
            Fechahora = pFechaHora;
        }

        //operaciones
        public override string ToString()
        {
            return ("Cedula de usuario que envía: " + CedulaE + "Cedula de usuario que recibe: " + CedulaR + "Fecha y Hora " + Fechahora.ToShortDateString() + "- " + Fechahora.ToShortTimeString() + "Asunto " + Asunto + "Texto: " + Texto);
        }

    }
}


