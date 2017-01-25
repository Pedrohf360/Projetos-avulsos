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
        Rosto robo1 = new Rosto();

        public Form1()
        {
            InitializeComponent();
        }

        private void btFeliz_Click(object sender, EventArgs e)
        {
            robo1.Feliz();
        }

        private void btTriste_Click(object sender, EventArgs e)
        {
            robo1.Triste();
        }

        private void btDesconfiado_Click(object sender, EventArgs e)
        {

              //  robo1.Desconfiar();
        }

    }
}
