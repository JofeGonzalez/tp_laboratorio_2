using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora: Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Boton Operar
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedItem == null)
            {
                this.comboBox1.SelectedItem = "+";
            }
            this.textBox3.Text = (Operar(this.textBox1.Text, this.textBox2.Text, this.comboBox1.SelectedItem.ToString()).ToString()); 

        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            Numero numeroU = new Numero(numero1);
            Numero numeroD = new Numero(numero2);
            resultado = Calculadora.Operar(numeroU, numeroD, operador);
            return resultado;
        }
        //Boton Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.textBox1.Clear();
            this.comboBox1.Text = "+";
            this.textBox2.Clear();
            this.textBox3.Clear();
        }
        //Boton Cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Boton Convertir a Binario
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = Numero.DecimalBinario(this.textBox3.Text.ToString());
        }
        //Boton Convertir a Decimal
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = Numero.BinarioDecimal(this.textBox3.Text.ToString());
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
