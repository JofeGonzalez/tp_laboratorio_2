using ClasesInstanciables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Test
    {
        static void Main(string[] args)
        {
            //Agrego 2 productos
            Sql.AgregarProductos("SandwichDePollo");
            Console.WriteLine("Producto Agregado.");
            Sql.AgregarProductos("SandwichDeCarne");
            Console.WriteLine("Producto Agregado.");
            //Agrego 2 Clientes
            Sql.AgregarCliente("Diego", 45789562, "El cielo");
            Console.WriteLine("Cliente Agregado.");
            Sql.AgregarCliente("Lionel", 97414257, "La Tierra");
            Console.WriteLine("Cliente Agregado.");
            //Obtengo Lista de Productos
            List<Producto> productos = Sql.GetProductos();
            //Obtengo Lista Clientes
            List<Cliente> clientes = Sql.GetClientes();
            //Leo ventas de un archivo XML
            List<Venta> ventas = Sql.LeerPedidosXml();
            //Agrego una venta
            Sql.AgregarVenta(2, 5, modoEntrega.delivery);
            Console.WriteLine("Venta Agregada.");
            //Muestro listas por pantalla
            Console.WriteLine("IdProducto     NombreProducto");
            foreach (Producto pr in productos)
            {
                Console.WriteLine($"   {pr.IdProducto}           {pr.NombreProducto}");
            }
            Console.WriteLine("IdCliente   NombreCliente   DniCliente   DireccionCliente");
            foreach (Cliente cl in clientes)
            {
                Console.WriteLine($"   {cl.IdCliente}           {cl.Nombre}        {cl.DNI}        {cl.DireccionCliente}");
            }
            Console.WriteLine("IdProducto   IdCliente   ModoEntrega");
            foreach (Venta vn in ventas)
            {
                Console.WriteLine($"   {vn.IdProducto}           {vn.IdCliente}        {vn.ModoEntrega}");
            }
            //Obtengo id de los productos agregados
            int idProductoAgregado1 = Sql.GetIdProducto("SandwichDePollo");
            int idProductoAgregado2 = Sql.GetIdProducto("SandwichDeCarne");
            //Obtengo id de los clientes agregados
            int idClienteAgregado1 = Sql.GetIdCliente("Diego");
            int idClienteAgregado2 = Sql.GetIdCliente("Lionel");
            //Elimino datos agregados en la prueba
            Sql.EliminarCliente(idClienteAgregado1);
            Console.WriteLine("Cliente Eliminado");
            Sql.EliminarCliente(idClienteAgregado2);
            Console.WriteLine("Cliente Eliminado");
            Sql.EliminarProducto(idProductoAgregado1);
            Console.WriteLine("Producto Eliminado");
            Sql.EliminarProducto(idProductoAgregado2);
            Console.WriteLine("Producto Eliminado");
            Console.ReadKey();
        }
    }
}
