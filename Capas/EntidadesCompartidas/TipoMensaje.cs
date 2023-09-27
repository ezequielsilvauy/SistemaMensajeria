using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class TipoMensaje
    {
        //atributos
        private string CodigoInterno;
        private string NombreTipo;

        //propiedades
        public string codigoInterno
        {
            get { return CodigoInterno; }
            set
            {
                if (value.Trim().Length != 3)
                    throw new Exception("El codigo interno debe contener 3 letras");
                else
                    CodigoInterno = value;
            }
        }

        public string nombreTipo
        {
            get { return NombreTipo; }
            set
            {
                if (value.Trim().Length > 15 || value.Trim().Length == 0)
                    throw new Exception("Se permite un máximo de 15 caracteres y el nombre es un campo obligatorio");
                NombreTipo = value;
            }
        }

        //constructores
        public TipoMensaje(string pCodigoInterno, string pNombreTipo)
        {
            codigoInterno = pCodigoInterno;
            nombreTipo = pNombreTipo;
        }

        //operaciones
        public override string ToString()
        {
            return ("Codigo interno: " + codigoInterno + "Nombre: " + nombreTipo);
        }
    }
}
