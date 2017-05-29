using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using ComeBullet;


namespace POO_TI
{
    public partial class BulletWorld : Form
    {
        Stopwatch tempoJogo;
        Random aleat = new Random(DateTime.Now.Millisecond);

       public Lista objetos = new Lista();
       
        int escolha;

        #region baseCode

        public BulletWorld(int i)
        {
            InitializeComponent();
            escolha = i;
        }

        private void Init()
        {
            objetos.limpaLista();
            
            //////////////////////////////
            ///
            /// Ações para iniciar o jogo
            ///
            /////////////////////////////
            
            timer1.Enabled = timer2.Enabled = timer3.Enabled = true;
            tempoJogo = new Stopwatch();
            tempoJogo.Start();
        }

        
        #endregion

                
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            char tecla = e.KeyChar;  //captura a tecla apertada na janela do jogo

                ////////////////
                ///
                ///  realizar aqui o tratamento de teclado
                /// 
                ////////////////
            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //////////////////
            ///
            /// timer (motor) principal do jogo. realizar ações de atualização aqui
            ///
            //////////////////
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
                ////////////
                ///
                /// caso deseje usar um timer secundário...
                ///
                ////////////
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //inicia um novo jogo assim que a janela é mostrada
            Init();
        }

        
        private void timer3_Tick_1(object sender, EventArgs e)
        {
            //código para atualizar o tempo de jogo e mostrar no mundo de bullets
            timeLabel.Text = tempoJogo.Elapsed.ToString(@"mm\:ss\.ff");
        }

        private void BulletWorld_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                
            }
        }
    }
}
