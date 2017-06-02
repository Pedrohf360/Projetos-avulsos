using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO_TI
{
    class LeftMario : Personagem
    {
        public LeftMario(BulletWorld b)
            : base(b)
        {
            setFigura(ComeBullet.Properties.Resources.Leftmario3);
            direcao = 4 ; // Esquerda.
            setDirecao(4);
            setVelocidade(5);
        }

        /// <summary>
        ///
        /// </summary
        public override void setDirecao(int d)
        { 
            switch (direcao)
            {
                case 1:
                    setFigura(ComeBullet.Properties.Resources.Leftmario2);
                    break; 
                case 2:
                    setFigura(ComeBullet.Properties.Resources.Leftmario3);
                    break;

                case 3:
                    setFigura(ComeBullet.Properties.Resources.Leftmario0);
                    break;

                case 4:
                    setFigura(ComeBullet.Properties.Resources.Leftmario1);
                    break;
            }

            direcao--;
            if (direcao == 0)
            {
                direcao = 4 ;
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
                    setPos(posX - velocidade, getY());
                    break;

                case 2:
                    setPos(getX(), posY - velocidade);
                    break;

                case 3:
                    setPos(posX + velocidade, getY());
                    break;

                case 4:
                    setPos(getX(), posY + velocidade);
                    break;
            }
        }
    }
}
