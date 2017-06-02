using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace POO_TI
{
    public class BulletVermelho : Bullet
    {
        private Evento[] evento = new Evento[4];

        public BulletVermelho(int posX, int posY, BulletWorld f, System.Drawing.Image fig, int p)
            : base(posX, posY, f, fig, p)
        { }

        public override Evento[] gerarEventos()
        {
            evento[0] = new Evento(2, "GerarBulletVerde");
            evento[1] = new Evento(2, "GerarBulletVerde");
            evento[2] = new Evento(2, "GerarBulletVerde");
            evento[3] = new Evento(7, "AumentarVelocidade");
            return evento;
        }
    }
}
