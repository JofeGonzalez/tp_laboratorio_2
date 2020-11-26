using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using ClasesAbstractas;

namespace ClasesInstanciables
{
    public static class Sql
    {
        static SqlConnection cnx;
        /// <summary>
        /// Conexion con la base de Datos
        /// </summary>
        static Sql()
        {
            cnx = new SqlConnection("server=DESKTOP-OG6OM47\\SQLEXPRESS; database=BD2Parcial; integrated security = true");
        }
        /// <Obtiene la Lista de Productos desde la base de datos>
        /// <returns> Retorna la Lista Obtenida </returns>
        public static List<Producto> GetProductos()
        {
            try
            {
                List<Producto> productos = new List<Producto>();
                SqlCommand comando = new SqlCommand("Select * from Producto", cnx);
                if (cnx.State != ConnectionState.Open)
                {
                    cnx.Open();
                }
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    productos.Add(new Producto(int.Parse(datos["IdProductos"].ToString()), (datos["NombreProducto"]).ToString()));
                }
                return productos;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }
        /// <Obtiene la Lista de Clientes desde la base de datos>
        /// <returns> Retorna la Lista Obtenida </returns>
        public static List<Cliente> GetClientes()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                SqlCommand comando = new SqlCommand("Select * from Clientes", cnx);
                if (cnx.State != ConnectionState.Open)
                {
                    cnx.Open();
                }
                SqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    clientes.Add(new Cliente((datos["NombreCliente"].ToString()), int.Parse(datos["DniCliente"].ToString()), (int.Parse(datos["IdCliente"].ToString())), datos["DireccionCliente"].ToString()));
                }
                return clientes;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }
        /// <summary>
        /// Agrega una venta a la base de Datos
        /// </summary>
        /// <param name="idProducto"> id de Producto a agregar en la venta</param>
        /// <param name="idCliente"> id del cliente que realiza la compra </param>
        /// <param name="modoEntrega"> modo de entrega seleccionado para la venta </param>
        public static void AgregarVenta(int idProducto, int idCliente, modoEntrega modoEntrega)
        {
            try
            {
                string query = "insert into Ventas (idProducto, idCliente, modoEntrega) values (@idProducto, @idCliente, @modoEntrega)";
                cnx.Open();
                SqlCommand comando = new SqlCommand(query, cnx);
                comando.Parameters.AddWithValue("@idProducto", idProducto);
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                comando.Parameters.AddWithValue("@modoEntrega", modoEntrega);
                comando.ExecuteNonQuery();
                if (modoEntrega.ToString() == "delivery")
                {
                    Cliente cliente = GetDatosCliente(idCliente);
                    GuardarPedidoDelivery(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }
        /// <summary>
        /// Obtiene el id del cliente a través de su nombre
        /// </summary>
        /// <param name="cliente"> Nombre del cliente a ser buscado </param>
        /// <returns> retorna el id del cliente </returns>
        public static int GetIdCliente(string cliente)
        {
            try
            {
                SqlCommand comandoCliente = new SqlCommand($"Select idCliente from Clientes where NombreCliente = '{cliente}'", cnx);
                if (cnx.State != ConnectionState.Open)
                {
                    cnx.Open();
                }
                SqlDataReader idCliente = comandoCliente.ExecuteReader();
                while (idCliente.Read())
                {
                    return int.Parse(idCliente["idCliente"].ToString());
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }

        }
        /// <summary>
        /// Obtiene los datos del cliente a través de su id
        /// </summary>
        /// <param name="id"> Id del cliente a ser buscado </param>
        /// <returns> Retorna el cliente obtenido en la busqueda </returns>
        public static Cliente GetDatosCliente(int id)
        {
            try
            {
                Cliente cliente = new Cliente();
                SqlCommand comandoCliente = new SqlCommand($"select * from Clientes where IdCliente = '{id}'", cnx);
                if (cnx.State != ConnectionState.Open)
                {
                    cnx.Open();
                }
                SqlDataReader datosCliente = comandoCliente.ExecuteReader();
                while (datosCliente.Read())
                {
                    cliente = new Cliente((datosCliente["NombreCliente"].ToString()), int.Parse(datosCliente["DniCliente"].ToString()), (int.Parse(datosCliente["IdCliente"].ToString())), datosCliente["DireccionCliente"].ToString());
                }
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }
        }
        /// <summary>
        /// Obtiene el id del prodcuto a través de su nombre
        /// </summary>
        /// <param name="cliente"> Nombre del prodcuto a ser buscado </param>
        /// <returns> retorna el id del producto </returns>
        public static int GetIdProducto(string producto)
        {
            try
            {
                SqlCommand comandoProducto = new SqlCommand($"Select idProductos from Producto where NombreProducto = '{producto}'", cnx);
                if (cnx.State != ConnectionState.Open)
                {
                    cnx.Open();
                }
                SqlDataReader idProducto = comandoProducto.ExecuteReader();
                while (idProducto.Read())
                {
                    return int.Parse(idProducto["idProductos"].ToString());
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cnx.Close();
            }

        }
        /// <summary>
        /// Agrega un cliente a la base de datos
        /// </summary>
        /// <param name="nombre"> Nombre del cliente a agregar </param>
        /// <param name="dni"> Dni del cliente a agregar </param>
        /// <param name="direccion"> Direccion del cliente a agregar </param>
        public static void AgregarCliente(string nombre, int dni, string direccion)
        {
            string query = "insert into Clientes (NombreCliente, DniCliente, DireccionCliente) values (@nombre, @dni, @direccion)";
            cnx.Open();
            SqlCommand comando = new SqlCommand(query, cnx);
            comando.Parameters.AddWithValue("@nombre", Persona.ValidarNombreApellido(nombre));
            comando.Parameters.AddWithValue("@dni", Persona.ValidarDni(dni));
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.ExecuteNonQuery();
            cnx.Close();
        }
        /// <summary>
        /// Agrega un producto a la base de datos
        /// </summary>
        /// <param name="nombre"> Nombre del producto a agregar </param>
        public static void AgregarProductos(string nombre)
        {
            string query = "insert into Producto (NombreProducto) values (@nombre)";
            cnx.Open();
            SqlCommand comando = new SqlCommand(query, cnx);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.ExecuteNonQuery();
            cnx.Close();
        }
        /// <summary>
        /// Permite modificar el nombre de un producto en la base de datos
        /// </summary>
        /// <param name="nombre"> Nombre a modificar </param>
        /// <param name="idProducto"> Id del producto a modificar </param>
        public static void ModificarProductos(string nombre, int idProducto)
        {
            string query = "update Producto set NombreProducto = @nombre where idProductos = @id";
            cnx.Open();
            SqlCommand comando = new SqlCommand(query, cnx);
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@id", idProducto);
            comando.ExecuteNonQuery();
            cnx.Close();
        }
        /// <summary>
        /// Permite modificar los datos de un cliente
        /// </summary>
        /// <param name="nombre"> Nombre del cliente que puede ser modificado en </param>
        /// <param name="dni"> Dni del cliente que puede ser modificado </param>
        /// <param name="direccion"> Direccion del cliente que puede ser modificado </param>
        /// <param name="idCliente"> Id del cliente que sera modificado </param>
        public static void ModificarCliente(string nombre, int dni, string direccion, int idCliente)
        {
            string query = "update Clientes set NombreCliente = @nombre, DniCliente = @dni, DireccionCliente = @direccion where idCliente=@id";
            cnx.Open();
            SqlCommand comando = new SqlCommand(query, cnx);
            comando.Parameters.AddWithValue("@nombre", Persona.ValidarNombreApellido(nombre));
            comando.Parameters.AddWithValue("@dni", Persona.ValidarDni(dni));
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@id", idCliente);
            comando.ExecuteNonQuery();
            cnx.Close();
        }
        /// <summary>
        /// Permite eliminar un producto de la base de datos
        /// </summary>
        /// <param name="id"> Id del producto que sera eliminado </param>
        public static void EliminarProducto(int id)
        {
            string query = "delete from Producto where idProductos = @id";
            cnx.Open();
            SqlCommand comando = new SqlCommand(query, cnx);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            cnx.Close();
        }
        /// <summary>
        /// Permite eliminar un cliente de la base de datos
        /// </summary>
        /// <param name="id"> Id del cliente que sera eliminado </param>
        public static void EliminarCliente(int id)
        {
            string query = "delete from Clientes where idCliente = @id";
            cnx.Open();
            SqlCommand comando = new SqlCommand(query, cnx);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            cnx.Close();
        }
        /// <summary>
        /// Lee los pedidos precargados en un archivo XML
        /// </summary>
        /// <returns> Retorna una lista de ventas </returns>
        public static List<Venta> LeerPedidosXml()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\xml.xml";
            Xml<List<Venta>> xml = new Xml<List<Venta>>();
            List<Venta> ventas = new List<Venta>();
            xml.Leer(path, out ventas);
            return ventas;
        }
        /// <summary>
        /// Guarda los pedidos que tienen modo de entrega delivery
        /// </summary>
        /// <param name="cliente"> Nombre del cliente que pidio por delivery </param>
        public static void GuardarPedidoDelivery(Cliente cliente)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\deliverys.txt";
            string venta = $"{cliente.Nombre} , {cliente.DNI} , {cliente.DireccionCliente}";
            Texto texto = new Texto();
            texto.Guardar(path, venta);
        }
        /// <summary>
        /// Guarda los pedidos que no llegan a ser finalizados durante el proceso
        /// </summary>
        /// <param name="ventas"> Recibe la lista de ventas que no paso a finalizados </param>
        public static void GuardarPedidosXml(List<Venta> ventas)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\PedidosFaltantes.xml";
            Xml<List<Venta>> venta = new Xml<List<Venta>>();
            venta.Guardar(path, ventas);
        }
    }
}