using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO_TI
{
    public class BulletAmarelo : Bullet
    {
        private Evento[] evento = new Evento[2];

        public BulletAmarelo(int posX, int posY, BulletWorld f, System.Drawing.Image fig, int p)
            : base(posX, posY, f, fig, p)
        { }
        public override Evento[] gerarEventos()
        {
            evento[0] = new Evento(8, "DiminuirVelocidade");
            evento[1] = new Evento(2, "GerarBulletVerde");
            return evento;
        }
    }
}
