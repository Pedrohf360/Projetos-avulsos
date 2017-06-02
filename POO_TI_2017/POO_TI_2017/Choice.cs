using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POO_TI
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            BulletWorld jogo = null;
            new BulletWorld(4);

            if (radioButton1.Checked)
            {
                jogo = new BulletWorld(1);
            }
            else if (radioButton2.Checked)
            {
                jogo = new BulletWorld(2);
            }
            else if (radioButton3.Checked)
            {
                jogo = new BulletWorld(3);
            }
            else if (radioButton4.Checked)
            {
                jogo = new BulletWorld(4);
            }
            else if (radioButton5.Checked)
            {
                jogo = new BulletWorld(5);
            }
            else if (radioButton6.Checked)
            {
                jogo = new BulletWorld(6);
            }

            jogo.Show();
        }

        private void Choice_Load(object sender, EventArgs e)
        {

        }
    }
}
