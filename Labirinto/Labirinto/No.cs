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

    public class tupleComparer : IEqualityComparer<No>
    {
        public bool Equals(No no1, No no2 )
        {
            //if (tup1 == null && tup2 == null) { return true; }
            //if (tup1 == null | tup2 == null) { return false; }
            if (no1.posicao.Item1 == no2.posicao.Item1 && no1.posicao.Item2 == no2.posicao.Item2) { return true; }
            return false;
        }
        public int GetHashCode(No no)
        {
            string code = no.posicao.Item1 + "," + no.posicao.Item2;
            return code.GetHashCode();
        }
    }
}
