using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido
        {
            get { return apellido; }
            set { this.apellido = ValidarNombreApellido(value); }
        }
        public int DNI
        {
            get { return dni; }
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        public ENacionalidad Nacionalidad
        {
            get { return nacionalidad; }
            set { this.nacionalidad = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = ValidarNombreApellido(value); }
        }
        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.nacionalidad, value); }
        }
        public Persona()
        {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.dni = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Datos de la persona:");
            sb.AppendFormat("Nombre: {0}", Nombre);
            sb.AppendFormat("Apellido: {0}", Apellido);
            sb.AppendFormat("Dni: {0}", DNI);
            sb.AppendFormat("Nacionalidad: {0}", Nacionalidad);

            return sb.ToString();
        }
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 && dato > 99999999)
            {
                throw //dniinvalido
            }
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 0 && dato < 90000000)
                    {
                        return dato;
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato > 89999999 && dato < 100000000)
                    {
                        return dato;
                    }
                    break;
            }
            throw //nacionalidadinvalida
        }
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!int.TryParse(dato, out int dni))
            {
                throw new //dniinvalido
            }
            else
            {
                return ValidarDni(nacionalidad, dni);
            }
        }
        private static string ValidarNombreApellido(string dato)
        {
            foreach (char item in dato)
            {
                if (!(char.IsLetter(item)) || char.IsWhiteSpace(item))
                {
                    return null;
                }
            }
            return dato;
        }
    }
}
