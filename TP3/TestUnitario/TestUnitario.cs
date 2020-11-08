using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;
using Archivos;
namespace TestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            Alumno alumno = new Alumno(1, "Pedro", "Perez", "13579864", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno1 = new Alumno(1, "Domingo", "Gonzalez", "95806218", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Universidad universidad = new Universidad();
            universidad += alumno;
            universidad += alumno1;

            Assert.AreEqual(alumno, alumno1);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoException()
        {
            Alumno alumno = new Alumno(1, "Domingo", "Gonzalez", "Aleluya", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
        }

        [TestMethod]
        public void TestCantidadDeAlumnos()
        {
            Universidad universidad = new Universidad();
            Alumno alumno1 = new Alumno(9, "Juan", "Colmenarez", "19372846", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            Alumno alumno2 = new Alumno(10, "Simon", "Bolivar", "97643125", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);

            universidad += alumno1;
            universidad += alumno2;

            Assert.AreEqual(2, universidad.Alumnos.Count);
        }
    }
}
