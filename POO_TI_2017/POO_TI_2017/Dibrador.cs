using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO_TI
{
    class Dibrador : Personagem
    {

        public Dibrador(BulletWorld b)
            : base(b)
        {
            setFigura(POO_TI_2017.Properties.Resources.dibrador0);
            setDirecao(3); // Esquerda. 
            setVelocidade(3);
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
                // Indo p/ esquerda (1 = seta p/ esquerda: esquerda desce; 2 = seta p/ cima: esquerda sobe).
                case 1:
                    setFigura(POO_TI_2017.Properties.Resources.dibrador1);
                    break;

                case 2:
                    setFigura(POO_TI_2017.Properties.Resources.dibrador1);
                    break;
                // Indo p/ direita (3 = seta p/ direita: direita sobe; 4 = seta p/ baixo: direita desce).
                case 3:
                    setFigura(POO_TI_2017.Properties.Resources.dibrador0);
                    break;

                case 4:
                    setFigura(POO_TI_2017.Properties.Resources.dibrador0);
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
                // Indo p/ esquerda (1 = seta p/ esquerda: esquerda desce; 2 = seta p/ cima: esquerda sobe).
                case 1:
                    setPos(posX - velocidade, posY + velocidade);
                    break;

                case 2:
                    setPos(posX - velocidade, posY - velocidade);
                    break;
                // Indo p/ direita (3 = seta p/ direita: direita sobe; 4 = seta p/ baixo: direita desce).
                case 3:
                    setPos(posX + velocidade, posY - velocidade);
                    break;

                case 4:
                    setPos(posX + velocidade, posY + velocidade);
                    break;
            }
        }
    }
}
