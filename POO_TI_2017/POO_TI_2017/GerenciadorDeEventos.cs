using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_TI
{
    class GerenciadorDeEventos
    {
        protected Evento[] eventosPendentes;
        protected BulletWorld jogo;
        public GerenciadorDeEventos(Evento[] e, BulletWorld game)
        {
            this.eventosPendentes = e;
            this.jogo = game;
        }

        public void ProcessarEventos()
        {
            /*tabela de eventos: 
            código - Descrição
            1 - GerarBulletAzul
            2 - GerarBulletVerde
            3 - GerarBulletPurpura
            4 - GerarBulletVermelho
            5 - GerarBulletAmarelo
            6 - ComerBulletVerde
            7 - AumentarVelocidade
            8 - DiminuirVelocidade
            9 - Teleporte
            10 - EmbaralharBullets
            */

            for (int i = 0; i < eventosPendentes.Length; i++)
            {
                ComeBullet.Bullet novaBullet;
                switch (eventosPendentes[i].getCodigo())
                {
                    case 1: // 1 - GerarBulletAzul
                        novaBullet = new BulletAzul(jogo.aleat.Next(0,jogo.Width), jogo.aleat.Next(0,jogo.Height), jogo, ComeBullet.Properties.Resources.blueBullet, 3); 
                        jogo.objetos.inserirFinal(novaBullet);
                        break;
                    case 2: // 2 - GerarBulletVerde
                        novaBullet = new BulletVerde(jogo.aleat.Next(0,jogo.Width), jogo.aleat.Next(0,jogo.Height), jogo, ComeBullet.Properties.Resources.greenBullet, 1);
                        jogo.objetos.inserirFinal(novaBullet);
                        jogo.countBltVerde++;
                        break;
                    case 3: // 3 - GerarBulletPurpura
                        novaBullet = new BulletPurpura(jogo.aleat.Next(0,jogo.Width), jogo.aleat.Next(0,jogo.Height), jogo, ComeBullet.Properties.Resources.purpleBullet, 4);
                        jogo.objetos.inserirFinal(novaBullet);
                        break;
                    case 4: //GerarBulletVermelho
                        novaBullet = new BulletVermelho(jogo.aleat.Next(0,jogo.Width), jogo.aleat.Next(0,jogo.Height), jogo, ComeBullet.Properties.Resources.redBullet, 5);
                        jogo.objetos.inserirFinal(novaBullet);
                        break;
                    case 5: //GerarBulletAmarelo
                        novaBullet = new BulletAmarelo(jogo.aleat.Next(0,jogo.Width), jogo.aleat.Next(0,jogo.Height), jogo, ComeBullet.Properties.Resources.yellowBullet, 10);
                        jogo.objetos.inserirFinal(novaBullet);
                        break;
                    case 6:
                        jogo.countBltVerde--;
                        jogo.atualizaPlacar(1);
                        break;
                    case 7: // AumentarVelocidade
                        jogo.goPersonagem.setVelocidade(jogo.goPersonagem.getVelocidade() * 2);
                        break;
                    case 8: // DiminuirVelocidade
                        jogo.goPersonagem.setVelocidade(jogo.goPersonagem.getVelocidade() / 2);
                        break;
                    case 9: // Teleporte 
                        jogo.goPersonagem.teleporte();
                        break;
                    case 10:
                        jogo.objetos.redistribuir();
                        break;
                }
            }
        }
    }
}
