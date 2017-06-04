using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace POO_TI
{
    public partial class BulletWorld : Form
    {
        Stopwatch tempoJogo;
        public Random aleat = new Random(DateTime.Now.Millisecond);
        GerenciadorDeEventos GerenteEvento;
        public ComeBullet.Lista objetos = new ComeBullet.Lista();
        public Bullet novaBullet;
        public int countBltVerde;
        int escolha;
        int pontuacao;
        //static string caminhoRanking = ".../bin/";
        public Personagem goPersonagem;

        public BulletWorld(int i)
        {
            InitializeComponent();
            escolha = i;
        }

        private void iniciarJogo()// antigo init
        {
            try
            {
                objetos.limpaLista();
                for (int i = 0; i <= 4; i++)
                {
                    novaBullet = new BulletVerde(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.greenBullet, 1);
                    objetos.inserirFinal(novaBullet);
                }
                countBltVerde = 5;
                novaBullet = new BulletVermelho(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.redBullet, 5);
                objetos.inserirFinal(novaBullet);
                switch (escolha)
                {
                    case 1: //cheep
                        goPersonagem = new CheepCheep(this);
                        break;
                    case 2://bill
                        goPersonagem = new BulletBill(this);
                        break;
                    case 3://blooper
                        goPersonagem = new CrazyBlooper(this);
                        break;
                    case 4: //mario
                        goPersonagem = new LeftMario(this);
                        break;
                    case 5: //dibrador
                        goPersonagem = new Dibrador(this);
                        break;
                    case 6:
                        goPersonagem = new Bender(this);
                        break;
                        
                }
                timer2.Interval = 5000;
                timer1.Interval = 30;
                timer1.Enabled = timer2.Enabled = timer3.Enabled = true;
                tempoJogo = new Stopwatch();
                tempoJogo.Start();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception exGeral)
            {
                MessageBox.Show(exGeral.Message);
            }
        }

        //static void leArquivo()
        //{
        //    using (StreamReader arqLido = new StreamReader(@caminhoRanking, ASCIIEncoding.ASCII))
        //    {
        //        string[] LinhaArq = File.ReadAllLines(@caminhoRanking + "ranking.txt");
        //        string[] aux = new string[LinhaArq.Length];
        //        for (int l = 0; l >= LinhaArq.Length; l++)
        //        {

        //        }
        //        arqLido.Close();
        //    }
        //}
        private void paraTimers()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
        }
        private void ligaTimers()
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }
        private static void PauseCronometro(Stopwatch t) //Controla Pause do Jogo
        {
            try
            {
                if (t.IsRunning)
                {
                    t.Stop();
                }
                else
                {
                    t.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public bool verifVitoria()
        {
            try
            {
                if (this.countBltVerde == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (InvalidOperationException)
            {
                return false;
                throw new InvalidOperationException("Erro ao verificar conclusão do jogo!"); ;
            }
            catch (NullReferenceException)
            {
                return false;
                throw new NullReferenceException("Algo está  vazio - verifVitoria!"); ;
            }
            catch (Exception)
            {
                return false;
                throw new Exception("Erro - verifVitoria!"); ;
            }
        }
        public bool verifMorte()
        {
            try
            {
                if (this.goPersonagem.verifLimites())
                {
                    return true;
                }
                return false;
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Erro ao verificar limites do personagem");
            }
        }
        public void atualizaPlacar(int valor)
        {
            pontuacao += valor;
        }
        public void timeBullets()
        {
            try
            {
                if (goPersonagem is CrazyBlooper)
                {
                    goPersonagem.setDirecao(aleat.Next(1, 5));
                }
                novaBullet = new BulletVerde(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.greenBullet, 1);
                objetos.inserirFinal(novaBullet);
                countBltVerde++;
                int aux = aleat.Next(1, 6);
                switch (aux)
                {
                    case 1:
                        novaBullet = new BulletVerde(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.greenBullet, 1);
                        countBltVerde++;
                        break;
                    case 2:
                        novaBullet = new BulletVermelho(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.redBullet, 5);
                        break;
                    case 3:
                        novaBullet = new BulletPurpura(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.purpleBullet, 4);
                        break;
                    case 4:
                        novaBullet = new BulletAzul(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.blueBullet, 3);
                        break;
                    case 5:
                        novaBullet = new BulletAmarelo(aleat.Next(0, this.Width), aleat.Next(0, this.Height), this, ComeBullet.Properties.Resources.yellowBullet, 10);
                        break;
                }
                objetos.inserirFinal(novaBullet);
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Algo está vazio - timeBullets()!!");
            }
            catch (Exception)
            {
                throw new Exception("Algo está errado - timeBullets()!!");
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                string tecla = e.KeyValue.ToString();
                switch (tecla)
                {
                    case "37": //esquerda
                        goPersonagem.setDirecao(1);
                        break;
                    case "38": //cima
                        goPersonagem.setDirecao(2);
                        break;
                    case "39": //direita
                        goPersonagem.setDirecao(3);
                        break;
                    case "40": //baixo
                        goPersonagem.setDirecao(4);
                        break;
                    case "27": // esc   
                        paraTimers();
                        DialogResult dr = MessageBox.Show("Deseja Fechar o Jogo?", "           JOGO PAUSADO", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            this.Close();
                        }
                        else
                        {
                            ligaTimers();
                        }
                        break;
                    case "32": // espaço - pausa 
                        paraTimers();
                        DialogResult dr2 = MessageBox.Show("   JOGO PAUSADO", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr2 == DialogResult.OK)
                        {
                            ligaTimers();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                PauseCronometro(tempoJogo);
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.goPersonagem.mover();
                ComeBullet.GameObject aux = objetos.testeColisao(this.goPersonagem);
                if (aux != null)
                {
                    objetos.retirar(aux);
                    aux.apagar();
                    novaBullet = (Bullet)aux;
                    atualizaPlacar(novaBullet.pontos);
                    GerenteEvento = new GerenciadorDeEventos(novaBullet.gerarEventos(), this);
                    GerenteEvento.ProcessarEventos();
                }

                if (verifMorte())
                {
                    PauseCronometro(tempoJogo);
                    paraTimers();
                    MessageBox.Show("       GAME OVER !!! Pontuação: " + this.pontuacao, "   JÁ ?!?! ");
                    this.Close();
                }
                if (verifVitoria())
                {
                    PauseCronometro(tempoJogo);
                    paraTimers();
                    MessageBox.Show(" GAME OVER !!!", "   ACABOUUUUUUUUUUUUUUUUU ");
                    this.Close();
                }
            }
            catch (NullReferenceException)
            {

                throw new NullReferenceException("Algo está vazio!! - timer1_Tick()");
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                timeBullets();
            }
            catch (Exception)
            {
                throw new Exception("Erro - timer2!");
            }

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
            iniciarJogo();
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            //código para atualizar o tempo de jogo e mostrar no mundo de bullets
            timeLabel.Text = tempoJogo.Elapsed.ToString(@"mm\:ss\.ff");
        }
    }
}
