using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_01_25_RoboWFApp
{
    class Rosto
    {
        public Olho olhoDireito { get; set; }
        public Olho olhoEsquerdo { get; set; }

        public string estado { get; set; }

        public void Feliz()
        {
            estado = "(________)";

            olhoDireito.AbrirOlho();
            olhoEsquerdo.AbrirOlho();
        }

        public void Triste()
        {
            olhoEsquerdo.FecharOlho();
            olhoDireito.FecharOlho();
            estado = " ----- ";
        }

        public void Desconfiar()
        {
            olhoDireito.FecharOlho();
            olhoEsquerdo.AbrirOlho();
            estado = "~-~-~-~";
        }

        public Rosto()
        {
            olhoDireito = new Olho();
            olhoEsquerdo = new Olho();

            Feliz();
        }
    }
}
