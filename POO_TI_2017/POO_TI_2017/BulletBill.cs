using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO_TI
{
    class BulletBill : Personagem
    {
        public BulletBill()
        {
        }

        /// <summary>
        /// Determina a direção que o personagem irá seguir (horizontal ou vertical) após o usuário pressionar alguma tecla.
        /// </summary>
        /// <param name="dir">1: Esquerda; 2: Cima; 3: Direita; 4: Baixo.</param>
        public override void setDirecao(int dir)
        {
            //if (dir == 1)
            //setPos(direcao[dir])
        }
    }
}
