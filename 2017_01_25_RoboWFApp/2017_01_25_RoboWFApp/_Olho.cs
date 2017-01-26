using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_01_25_RoboWFApp
{
    class Olho
    {
        public string cor { get; set; }
        public string estado { get; set; }

        public void AbrirOlho()
        {
            estado = "O";
        }

        public void FecharOlho()
        {
            estado = "---"; 
        }

        public void PiscarOlho()
        {
            AbrirOlho();
            FecharOlho();
        }

        public Olho()
        {
            estado = "__";
            cor = "Castanho";
        }
    }
}
