using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_25_05_TI_POO_Personagem
{
    public abstract class Personagem
    {
        protected int velocidade;
        protected Boolean ultrapassaLimite;


        /// <summary>
        /// Determina a velocidade do personagem
        /// </summary>
        /// <param name="velocidade">Valor da velocidade.</param>
        public void SetVelocidade
        {
            set { this. = value;}
        }
        

        public bool VerifLimites()
        {

        }

        public void SetDirecao
        {
            set {this. = value;}
        }

        public void Teleporte()
        {

        }

        public void Mover()
        {

        }
    }
}
