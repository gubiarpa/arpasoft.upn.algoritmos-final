using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinal
{
    public class Dinamica
    {
        public const int INF = 99999;

        public int Mochila(int capacidad, int[] pesos, int[] valores, int n)
        {
            int[,] tabla = new int[n + 1, capacidad + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= capacidad; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        tabla[i, j] = 0;
                    }
                    else if (pesos[i - 1] <= j)
                    {
                        tabla[i, j] = Math.Max(valores[i - 1] + tabla[i - 1, j - pesos[i - 1]], tabla[i - 1, j]);
                    }
                    else
                    {
                        tabla[i, j] = tabla[i - 1, j];
                    }
                }
            }

            return tabla[n, capacidad];
        }

        public void listado(int[] data)
        {
            int N = data.Length;
            for (int i = 0; i < N; i++)
            {
                Console.Write("{0}\t", data[i]);
            }
            Console.WriteLine();
        }

        public void Floyd(int[,] grafo, int n)
        {
            int[,] distancia = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    distancia[i, j] = grafo[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (distancia[j, i] + distancia[i, k] < distancia[j, k])
                        {
                            distancia[j, k] = distancia[j, i] + distancia[i, k];
                        }
                    }
                }
            }
            imprimirMatriz(distancia, n);
        }

        public void imprimirMatriz(int[,] distancia, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (distancia[i, j] == INF)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write(distancia[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
