using System;
using System.Collections.Generic;
using System.Text;

namespace Labirinto
{
    public class No
    {
        public int g, h, f;
        public No pai;
        public (int, int) posicao;

        public No(No pai, (int, int) posicao)
        {
            this.pai = pai;
            this.posicao = posicao;

            this.g = this.h = this.f = 0;
        }

        public bool Equals(No outro)
        {
            return this.posicao == outro.posicao;
        }
    }
}
