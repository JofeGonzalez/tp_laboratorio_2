using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        public List<Alumno> Alumnos
        {
            get { return alumnos; }
            set { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return clase; }
            set { this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return instructor; }
            set { this.instructor = value; }
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto arch = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            return arch.Guardar(path, jornada.ToString());
        }
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        public static string Leer()
        {
            Texto arch = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory + "Texto.txt";
            arch.Leer(path, out string datos);
            return datos;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.alumnos.Add(a);
            return j;
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Universitario alumno in j.alumnos)
            {
                if (alumno.Equals(a))
                    return true;
            }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format($"CLASE DE {this.clase.ToString()} POR {this.instructor}"));
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in alumnos)
            {
                sb.Append(string.Format(alumno.ToString()));
            }
            sb.AppendLine("<------------------------------------------------------------->");
            return sb.ToString();
        }
    }
}
