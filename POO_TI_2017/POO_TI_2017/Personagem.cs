using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComeBullet;


namespace POO_TI
{
    public abstract class Personagem : GameObject
    {
        static Random r = new Random();

        protected int direcao; // 1: Esquerda; 2: Cima; 3: Direita; 4: Baixo.
        protected int velocidade;
        BulletWorld formWorld;

        public Personagem()
        {
            setPos(600, 300);
            this.velocidade = 2;

        }

        public void setVelocidade(int vel)
        {
            if (this.velocidade > 0 || this.velocidade < 10)
                this.velocidade = vel;
        }

        /// <summary>
        /// Retorna "true" se o personagem ultrapassar um limite horizontal ou vertical. Retorna "false" se não.
        /// </summary>
        /// <returns></returns>
        public Boolean verifLimites()
        {
            if (getX() < 0 || getX() > formWorld.Size.Width ||
                getY() < 0 || getY() > formWorld.Size.Height)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        public abstract void setDirecao(int dir);

        public void teleporte()
        {
            setPos(r.Next(50, formWorld.Size.Width - 50), r.Next(50, formWorld.Size.Height - 50));
        }

        public abstract void mover();
    }
}
