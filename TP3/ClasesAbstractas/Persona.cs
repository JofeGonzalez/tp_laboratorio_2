﻿using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
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
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}"));
            sb.AppendLine(string.Format($"NACIONALIDAD: {this.Nacionalidad}"));
            return sb.ToString();
        }
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException();
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
            throw new NacionalidadInvalidaException();
        }
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!int.TryParse(dato, out int dni))
            {
                throw new DniInvalidoException();
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
