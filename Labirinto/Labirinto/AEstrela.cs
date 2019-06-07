using System;
using System.Collections.Generic;
using System.Text;

namespace Labirinto
{
    public class AEstrela
    {
        public static (int, int)[] nosAdjacentes =
        {
            (0, -1), (0, 1), (-1, 0), (1, 0), (-1, -1), (-1, 1), (1, -1), (1, 1)
        };

        public static List<(int, int)> Resolver(int[,] labirinto, (int, int) inicio, (int, int) fim)
        {
            No inicial = new No(null, inicio);
            No final = new No(null, fim);

            List<No> lista_aberta = new List<No>();
            HashSet<No> lista_fechada = new HashSet<No>();

            lista_aberta.Add(inicial);

            while(lista_aberta.Count > 0)
            {

                //nó atual
                No noAtual = lista_aberta[0];
                int indiceAtual = 0;
                
                //se nos nós da lista aberta existir algum com um fator menor do que o nosso nó atual, começar por ele, pois tem "mais chance" de ser o melhor caminho.
                for (int i = 0; i < lista_aberta.Count; i++)
                    if (lista_aberta[i].f < noAtual.f)
                    {
                        noAtual = lista_aberta[i];
                        indiceAtual = i;
                    }

                lista_aberta.RemoveAt(indiceAtual);
                lista_fechada.Add(noAtual);

                //cheguei no canto que queria
                if (noAtual.Equals(final))
                {
                    List<(int, int)> caminho = new List<(int, int)>();
                    No atual = noAtual;
                    while (atual != null)
                    {
                        caminho.Add(atual.posicao);
                        atual = atual.pai;
                    }
                    caminho.Reverse();
                    return caminho;
                }

                List<No> filhos = new List<No>();

                foreach ((int, int) adjacente in nosAdjacentes)
                {
                    (int, int) posicaoDoNo = (noAtual.posicao.Item1 + adjacente.Item1, noAtual.posicao.Item2 + adjacente.Item2);
                    //se o nó adjcante estiver fora dos limites da matriz
                    if (posicaoDoNo.Item1 > (labirinto.GetLength(0) - 1) || posicaoDoNo.Item1 < 0 || posicaoDoNo.Item2 > (labirinto.GetLength(1) - 1) || posicaoDoNo.Item2 < 0)
                        continue;
                    //se existir um obstáculo no nó adjacente
                    if (labirinto[posicaoDoNo.Item1, posicaoDoNo.Item2] != 0)
                        continue;

                    No novoNo = new No(noAtual, posicaoDoNo);

                    filhos.Add(novoNo);
                }

                foreach (No filho in filhos)
                {
                    //filho já foi visitado
                    if (lista_fechada.Contains(filho))
                        continue;

                    //criar o valor f, g e h

                    //quantidade de passos até chegar aqui
                    filho.g = noAtual.g + 1;
                    //distância euclidiana entre o ponto atual e o ponto que eu quero chegar
                    filho.h = (int)Math.Pow((filho.posicao.Item1 - final.posicao.Item1), 2) + (int)Math.Pow((filho.posicao.Item2 - final.posicao.Item2), 2);
                    //soma da quantidade de passos dadas mais a distância
                    filho.f = filho.g + filho.h;

                    //filho já está na lista de nós a visitar
                    foreach (No filho_aberto in lista_aberta)
                        if (filho.Equals(filho_aberto))
                            continue;

                    lista_aberta.Add(filho);
                }
            }

            return new List<(int, int)>();
        }
    }
}
