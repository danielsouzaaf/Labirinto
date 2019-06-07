using System;
using System.Collections.Generic;
using System.Text;

namespace Labirinto
{
    public class No
    {
        public int g, h, f;
        public No pai;
        public Tuple<int, int> posicao;

        public No(No pai=null, Tuple<int, int> posicao=null)
        {
            this.pai = pai;
            this.posicao = posicao;

            this.g = this.h = this.f = 0;
        }

        public bool equals(No outro)
        {
            return this.posicao == outro.posicao;
        }
    }
}
