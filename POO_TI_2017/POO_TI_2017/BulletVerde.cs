using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 

namespace POO_TI
{
    public class BulletVerde : Bullet
    {
        private Evento[] evento = new Evento[1];
        public BulletVerde(int posX, int posY, BulletWorld f, System.Drawing.Image fig, int p)
            : base(posX, posY, f, fig, p)
        { }
        public override Evento[] gerarEventos()
        {
            evento[0] = new Evento(6, "ComerBulletVerde");
            return evento;
        }
    }
}
