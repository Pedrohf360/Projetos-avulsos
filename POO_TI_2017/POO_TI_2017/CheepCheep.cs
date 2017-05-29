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

        }
        
        /// <summary>
        /// Determina a direção que o personagem irá seguir (horizontal ou vertical) após o usuário pressionar alguma tecla.
        /// </summary>
        /// <param name="dir">1: Esquerda; 2: Cima; 3: Direita; 4: Baixo.</param>
        public override void setDirecao(int dir)
        {
            switch (dir)
            {
                case 1:
                    this.setFigura(ComeBullet.Properties.Resources.cheepcheep0);
                    break;

                case 2:
                    this.setFigura(ComeBullet.Properties.Resources.cheepcheep3);
                    break;

                case 3:
                    this.setFigura(ComeBullet.Properties.Resources.cheepcheep1);
                    break;

                case 4:
                    this.setFigura(ComeBullet.Properties.Resources.cheepcheep2);
                    break;
            }
        }
    }
}
