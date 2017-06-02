using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComeBullet;

namespace POO_TI
{
    class Ranking
    {
        private int[] pontos = new int[10];
        private string[] nomePersonagem = new string[10];
        private BulletWorld bull;
        private Choice escolhe;

        public Ranking(BulletWorld bullet, Choice escolheu)
        {
            this.bull = bullet;
            this.escolhe = escolheu;
        }

        public void CarregaVetor()
        {
            if (bull.verifMorte() == true)
            {
                for (int i = 0; i < nomePersonagem.Length; i++)
                {
                    //  pontos[i] = bull.Pontuacao;
                    nomePersonagem[i] = escolhe.Name;
                }
            }
        }
    }
}
