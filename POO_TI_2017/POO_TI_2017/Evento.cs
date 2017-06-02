using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_TI
{
    public class Evento
    {
        protected int codigo;
        protected string descricao;

        public Evento(int cod, string desc)
        {
            this.codigo = cod;
            this.descricao = desc;

        }
        public int getCodigo()
        {
            return codigo;
        }
        public void setCodigo(int cod)
        {
            codigo = cod;
        }

        public string getDescricao()
        {
            return descricao;
        }
        public void setDescricao(string dsc)
        {
            descricao = dsc;
        }
    }
}
