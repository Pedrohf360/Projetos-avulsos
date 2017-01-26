using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2017_01_25_RoboWFApp
{
    public partial class Form1 : Form
    {
        Rosto meuRosto;

        public Form1()
        {
            InitializeComponent();

            meuRosto = new Rosto();

            meuRosto.Feliz(); // Realmente precisa? (No construtor já tem Feliz());
        }

        public void Ajustar()
        {
            btOlhoDireito.Text = meuRosto.olhoDireito.estado;
            btOlhoEsquerdo.Text = meuRosto.olhoEsquerdo.estado;
            btBoca.Text = meuRosto.estado;
        }

        private void btFeliz_Click(object sender, EventArgs e)
        {
            meuRosto.Feliz();

            Ajustar();
        }

        private void btTriste_Click(object sender, EventArgs e)
        {
            meuRosto.Triste();

            Ajustar();   
        }

        private void btDesconfiado_Click(object sender, EventArgs e)
        {
            meuRosto.Desconfiar();

            Ajustar();
        }

    }
}
