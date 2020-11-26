using System;
using Archivos;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoException()
        {
            Cliente cliente = new Cliente("Jofe", "HolaMundo", 25, "La Luna");
        }
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void ArchivosException()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\hola.txt";
            Texto text = new Texto();
            string datos;
            text.Leer(path, out datos);
        }
    }
}
