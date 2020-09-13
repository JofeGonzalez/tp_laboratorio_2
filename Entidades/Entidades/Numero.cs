using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public string setNumero { set { numero = ValidarNumero(value); } }

        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            this.numero = ValidarNumero(strNumero);
        }

        private double ValidarNumero(string strNumero)
        {
            if (!(double.TryParse(strNumero, out numero)))
            {
                numero = 0;
            }
            return numero;
        }

        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            char[] array = binario.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != '0' && array[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        public static string BinarioDecimal(string binario)
        {
            string numeroDecimal = "Valor Inválido";
            if (EsBinario(binario))
            {
                numeroDecimal = Convert.ToInt32(binario, 2).ToString();
            }
            return numeroDecimal;
        }

        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor Inválido";
            if (numero > 0)
            {
                String cadena = "";
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    numero = (int)(numero / 2);
                    retorno = cadena;
                }
            }
            else
            {
                if (numero == 0)
                {
                    retorno = "0";
                }
                else
                {
                    return retorno;
                }
            }
            return retorno;
        }

        public static string DecimalBinario(string numero)
        {
            double resultado;
            string retorno = "Numero Invalido";
            if (double.TryParse(numero, out resultado))
            {
                retorno = DecimalBinario(resultado);
            }
            return retorno;
        }
        public static double operator +(Numero numero1, Numero numero2)
        {
            return numero1.numero + numero2.numero;
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            return numero1.numero - numero2.numero;
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            return numero1.numero * numero2.numero;
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            if (numero2.numero == 0)
                return double.MinValue;
            else
                return numero1.numero / numero2.numero;

        }
    }
}
