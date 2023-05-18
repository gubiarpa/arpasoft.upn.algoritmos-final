using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinal
{
    public class Dijkstra
    {
		// obtenemos el vertice con minima distancia
		int minDistance(int[] dist, bool[] ocupado)
		{

			// Inicializamos valores para minimo
			int min = Int32.MaxValue, min_index=-1;
			int V = dist.GetLength(0);

			for (int v = 0; v < V; v++)
				if (ocupado[v] == false && dist[v] <= min)
				{
					min = dist[v];
					min_index = v;
				}

			return min_index;
		}

		// Mostramos la ruta
		void printSolution(int[] dist, List<int> listaNodo)
		{
			int pos, V = dist.GetLength(0);
			Console.WriteLine("\nRUTA MINIMA");
			Console.WriteLine("Vertice \t Distancia al Origen");
			for (int i = 0; i < V; i++)
            {
				pos = listaNodo[i];
				Console.WriteLine("{0} \t\t {1}", pos + 1, dist[pos]);
			}
		}
		// mostramos Matriz de Adyacencia
		void printAdy(int[,] graph)
		{
			int V = graph.GetLength(0);
			Console.WriteLine("\nMATRIZ ADYACENCIA");

			Console.Write("\t");
			for (int j = 0; j < V; j++)
				Console.Write("{0}\t", j + 1);
			Console.WriteLine();
			Console.Write("\t");
			for (int j = 0; j < V; j++)
				Console.Write("---\t");
			Console.WriteLine();

			for (int i = 0; i < V; i++)
			{
				Console.Write("{0} |\t",i+1);
				for (int j = 0; j < V; j++)
                {
					Console.Write("{0}\t", graph[i,j]);
				}
				Console.WriteLine();
			}
		}

		//Algoritmo Dijkstra's del camino mas corto usando matriz de adyacencia
		public void dijkstra(int[,] graph, int src)
		{
			int V = graph.GetLength(0);
			int[] dist = new int[V];					// Distancias de cada nodo al origen
			List<int> listaNodo = new List<int>();		// Lista de nodos del recorrido

			bool[] ocupado = new bool[V];		// ocupado[i] lo usamos para marcar si nodo ya esta asignado 

			// Inicializamos las distancias 
			for (int i = 0; i < V; i++)
            {
				dist[i] = Int32.MaxValue;
				ocupado[i] = false;
			}

			// Distance para el vertice origen
			dist[src] = 0;

			// Camino minimo para todos los vertices
			for (int count = 0; count < V ; count++)
			{
				// obtenemos el vertice con minima distancia
				int u = minDistance(dist, ocupado);

				// Lo marcamos como vertice procesado
				ocupado[u] = true;
				listaNodo.Add(u);

				// Update dist value of the adjacent vertices of the picked vertex.
				for (int v = 0; v < V; v++)
                {
					// actualizamos las distancias para los vertices adyacentes
					if (!ocupado[v] && (graph[u,v]!=0) && dist[u] != Int32.MaxValue
												&& dist[u] + graph[u,v] < dist[v])
						dist[v] = dist[u] + graph[u,v];
				}
			}

			// Mostramos las distancias finales
			printAdy(graph);
			printSolution(dist, listaNodo);
		}
		public int proceso()
		{
			int[,] graph = {
						{ 0, 4, 2, 0, 0, 0},
						{ 4, 0, 1, 5, 0, 0},
						{ 2, 1, 0, 8,10, 0},
						{ 0, 5, 8, 0, 2, 6},
						{ 0, 0,10, 2, 0, 2},
						{ 0, 0, 0, 6, 2, 0}
			};

			dijkstra(graph, 0);			// Dijstra partiendo del nodo 1
			return 0;
		}

	}
}
