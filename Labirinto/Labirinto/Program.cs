using System;
using System.Collections.Generic;

namespace Labirinto
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] labirinto = {
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            (int, int) inicio = (0, 0);
            (int, int) fim = (7, 6);

            List<(int, int)> caminho = AEstrela.Resolver(labirinto, inicio, fim);

            foreach(var tuple in caminho)
            {
                Console.Write(tuple);
                if (!tuple.Equals(fim))
                    Console.Write("->");
            }
            if(caminho.Count < 1)
                Console.WriteLine("Não existe um caminho para chegar no ponto desejado.");

            Console.ReadKey();
        }
    }
}
