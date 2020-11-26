using ClasesInstanciables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormProyect
{
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
            this.Load += Mostrar;
            this.AgregarBtn.Click += Mostrar;
            this.ModificarBtn.Click += Mostrar;
            this.EliminarBtn.Click += Mostrar;
        }
        private void Mostrar(object sender, EventArgs e)
        {
            List<Producto> productos = Sql.GetProductos();
            DGVProductos.DataSource = productos;
        }

        private void AgregarBtn_Click(object sender, EventArgs e)
        {
            Sql.AgregarProductos(NombreProductoTxt.Text);
            MessageBox.Show("Insertado.");
        }

        private void ModificarBtn_Click(object sender, EventArgs e)
        {
            Sql.ModificarProductos(NombreProductoTxt.Text, int.Parse(IdProductoTxt.Text));
            MessageBox.Show("Modificado.");
        }

        private void EliminarBtn_Click(object sender, EventArgs e)
        {
            Sql.EliminarProducto(int.Parse(IdProductoTxt.Text));
            MessageBox.Show("Eliminado.");
        }
    }
}
