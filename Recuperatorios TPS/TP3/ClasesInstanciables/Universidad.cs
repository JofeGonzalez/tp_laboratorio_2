using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return jornada; }
            set { this.jornada = value; }
        }
        public Jornada this[int i]
        {
            get { return jornada[i]; }
            set { this.jornada[i] = value; }
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> srl = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            return srl.Guardar(path, uni);
        }
        public static Universidad Leer()
        {
            Xml<Universidad> dsrl = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml";
            Universidad rtrn;
            dsrl.Leer(path, out rtrn);
            return rtrn;
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach(Jornada jorn in uni.jornada)
            {
                sb.Append(jorn.ToString());
            }
            return sb.ToString();
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Profesor operator !=(Universidad u, EClases clases)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor != clases)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        public static Universidad operator +(Universidad g, EClases clases)
        {
            Jornada jornada = new Jornada(clases, g == clases);
            foreach (Alumno alumno in g.alumnos)
            {
                if (alumno == clases)
                    jornada.Alumnos.Add(alumno);
            }
            g.jornada.Add(jornada);
            return g;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
                throw new AlumnoRepetidoException();
            u.alumnos.Add(a);
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.profesores.Add(i);
            return u;
        }
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach(Alumno alum in g.Alumnos)
            {
                if(alum == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor prof in g.profesores)
            {
                if (prof == i)
                    return true;
            }
            return false;
        }
        public static Profesor operator ==(Universidad u, EClases clases)
        {
            foreach (Profesor profesor in u.profesores)
            {
                if (profesor == clases)
                    return profesor;
            }
            throw new SinProfesorException();
        }
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>(); 
        }
    }
}
