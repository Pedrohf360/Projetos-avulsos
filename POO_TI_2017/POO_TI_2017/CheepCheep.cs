using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace POO_TI
{

    class CheepCheep : Personagem
    {
        public CheepCheep()
        {
            setFigura(ComeBullet.Properties.Resources.cheepcheep0);
            direcao = 1; // Esquerda.
        }
        
        /// <summary>
        /// Determina a direção que o personagem irá seguir (horizontal ou vertical) após o usuário pressionar alguma tecla. Atualiza o valor da variável "direcao" que irá influenciar no método mover().
        /// </summary>
        /// <param name="dir">1: Esquerda; 2: Cima; 3: Direita; 4: Baixo.</param>
        public override void setDirecao(int dir)
        {
            direcao = dir;

            switch (dir)
            {
                case 1:
                    setFigura(ComeBullet.Properties.Resources.cheepcheep0);
                    break;

                case 2:
                    setFigura(ComeBullet.Properties.Resources.cheepcheep3);
                    break;

                case 3:
                    setFigura(ComeBullet.Properties.Resources.cheepcheep1);
                    break;

                case 4:
                    setFigura(ComeBullet.Properties.Resources.cheepcheep2);
                    break;
            }
        }

        /// <summary>
        /// Utiliza o valor passado para o método setDirecao().
        /// 1: Esquerda; 2: Cima; 3: Direita; 4: Baixo.
        /// </summary>
        public override void mover()
        {
            switch (direcao)
            {
                case 1:
                    setPos(posX-velocidade, posY);
                    break;

                case 2:
                    setPos(posX, posY-velocidade);
                    break;

                case 3:
                    setPos(posX+velocidade, posY);
                    break;

                case 4:
                    setPos(posX, posY+velocidade);
                    break;
            }
        }
    }
}
