﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        public Universitario()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        public override bool Equals(object obj)
        {
            if(obj is Universitario)
            {
                if(this.legajo == ((Universitario)obj).legajo || this.DNI == ((Universitario)obj).DNI){
                    return true;
                }
            }
            return false;
        }
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{base.ToString()}");
            sb.AppendFormat("LEGAJO NMUMERO: {0}", this.legajo);
            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }

}
