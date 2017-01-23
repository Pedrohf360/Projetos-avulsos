using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_01_20_Calculadora
{
    public partial class Form1 : Form
    {
        double total, ultimoNumero;
        string operador;

        private void Limpar()
        {
            total = 0;
            ultimoNumero = 0;
            operador = "+";
            tbResultado.Text = "0";
        }

        private void Calcular()
        {
            switch (operador)
            {
                case "+":
                    total += ultimoNumero;
                    break;

                case "-":
                    total -= ultimoNumero;
                    break;

                case "/":
                    total /= ultimoNumero;
                    break;

                case "X":
                    total *= ultimoNumero;
                    break;
            }

            ultimoNumero = 0;
            tbResultado.Text = total.ToString();
        }

        public Form1()
        {
            InitializeComponent();

            Limpar();
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void BtNumero(object sender, EventArgs e)
        {
            if (ultimoNumero == 0)
            {
                tbResultado.Text = (sender as Button).Text;
            }
            else
            {
                tbResultado.Text += (sender as Button).Text;
            }

            ultimoNumero = Convert.ToDouble(tbResultado.Text);
        }

        private void BtOperador(object sender, EventArgs e)
        {
            ultimoNumero = Convert.ToDouble(tbResultado.Text);

            Calcular();

            operador = (sender as Button).Text;
        }

        private void btIgual_Click(object sender, EventArgs e)
        {
            ultimoNumero = Convert.ToDouble(tbResultado.Text);

            Calcular();

            operador = "+";

            total = 0;
        }

        private void tbResultado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
