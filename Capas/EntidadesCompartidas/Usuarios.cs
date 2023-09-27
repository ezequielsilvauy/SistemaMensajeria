using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuarios
    {
        //atributos
        private int cedula;
        private string nombre;
        private string nomUsuario;


        //propiedades
        public int Cedula
        {
            get { return cedula; }
            set
            {
                if (value < 10000000 || value >= 100000000)
                {
                    throw new Exception("El número de cédula debe contener 8 caracteres numéricos");
                }
                cedula = value;
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim().Length > 30 || value.Trim().Length <= 0)
                    throw new Exception("Es un campo obligatorio y se permite un máximo de 30 caracteres");
                else
                    nombre = value;
            }
        }
        public string NomUsuario
        {
            get { return nomUsuario; }
            set
            {
                if (value.Trim().Length > 15 || value.Trim().Length <= 0)
                    throw new Exception("Es un campo obligatorio y se permite un máximo de 15 caracteres");
                else
                    nomUsuario = value;
            }
        }

        //constructores
        public Usuarios(int pCedula, string pNombre, string pNomUsuario)
        {
            Cedula = pCedula;
            Nombre = pNombre;
            NomUsuario = pNomUsuario;
        }


        //operaciones
        public override string ToString()
        {
            return ("Cedula: " + cedula + "Nombre: " + nombre + "Nombre de Usuario: " + nomUsuario);
        }
    }
}
