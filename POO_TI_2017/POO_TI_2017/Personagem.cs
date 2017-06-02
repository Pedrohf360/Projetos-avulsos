using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComeBullet;


namespace POO_TI
{
    public abstract class Personagem : GameObject
    {
        protected static Random aleatorio = new Random();

        protected int direcao; // 1: Esquerda; 2: Cima; 3: Direita; 4: Baixo.
        protected int velocidade;
        protected BulletWorld formWorld;

        public Personagem(BulletWorld b)
        {
            setPos(600, 300);
            this.velocidade = 2; 
            this.setBox(b);
            this.formWorld = b;
        }

        public void setVelocidade(int vel)
        {
            if (vel > 0 && vel < 10)
            {
                this.velocidade = vel;
            }
            else if(vel <= 0)
            {
                this.velocidade = 1;
            }
        }

        /// <summary>
        /// Retorna "true" se o personagem ultrapassar um limite horizontal ou vertical. Retorna "false" se não.
        /// </summary>
        /// <returns></returns>
        public bool verifLimites()
        {
            if (getX() < 0 || getX() > formWorld.Size.Width ||
                getY() < 0 || getY() > formWorld.Size.Height)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Teleporta o personagem para uma posição randômica. Utiliza o método "setPos", movendo o personagem para alguma posição que mantenha uma distância de 50 pixels da borda.
        /// </summary>
        public void teleporte()
        {
            setPos(formWorld.aleat.Next(0,formWorld.Width), formWorld.aleat.Next(0,formWorld.Height));
            //this.posX =  formWorld.aleat.Next();
            //this.posY = formWorld.aleat.Next();
        }

        public abstract void setDirecao(int dir);

        public abstract void mover();

        public int getVelocidade()
        {
            return velocidade;
        }
    }
}
