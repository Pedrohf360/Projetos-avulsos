using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO_TI
{
    public abstract class Bullet : ComeBullet.Bullet
    {
        protected int pontos;
        public Bullet(int posX, int posY, BulletWorld f, System.Drawing.Image fig, int p)
            : base(posX, posY, f, fig, p)
        {
            this.pontos = p;
        }
        public abstract Evento[] gerarEventos();
    }
}

