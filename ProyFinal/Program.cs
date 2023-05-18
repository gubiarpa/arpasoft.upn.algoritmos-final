using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinal
{
    class Program
    {
        public const int INF = 99999;
        static void Main(string[] args)
        {
            int opc;
            do
            {
                Console.WriteLine();
                Console.WriteLine("          PROYECTO FINAL                  ");
                Console.WriteLine("          ==============                  ");
                Console.WriteLine(" 1. Fuerza Bruta : Busqueda de cadenas    ");
                Console.WriteLine(" 2. Fuerza Bruta : Combinaciones de clave ");
                Console.WriteLine(" 3. Ordenamiento : Insercion              ");
                Console.WriteLine(" 4. Ordenamiento : Merge Sort             ");
                Console.WriteLine(" 5. Busqueda Binaria                      ");
                Console.WriteLine(" 6. Algoritmo Voraz : Dijkstra            ");
                Console.WriteLine(" 7. Divide y Conquista : Quicksort        ");
                Console.WriteLine(" 8. Backtracking : Salto de Caballo       ");
                Console.WriteLine(" 9. Prog. Dinamica : Mochila              ");
                Console.WriteLine("10. Prog. Dinamica : Floyd                ");
                Console.WriteLine(" 0. Salir                                 ");
                Console.Write("          Opc : ");
                opc = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (opc)
                {
                    case 1:
                        {
                            Console.WriteLine("BUSQUEDA DE CADENAS");
                            Fuerza obj = new Fuerza();
                            obj.buscar("Analisis de Algorimtos", "Algo");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("COMBINACIONES DE CLAVE");
                            Fuerza obj = new Fuerza();
                            obj.listarCombinaciones("jorge", 3);
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("ORDENAMIENTO POR INSERCION");
                            Console.WriteLine("Arreglo Original : ");
                            int[] data = { 20, 10, 63, 28, 18, 33, 7, 55 };
                            Ordenamiento obj = new Ordenamiento();
                            obj.listado(data);
                            obj.insercion(data);
                            Console.WriteLine("Arreglo Ordenado : ");
                            obj.listado(data);
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("ORDENAMIENTO MERGE SORT");
                            Console.WriteLine("Arreglo Original : ");
                            int[] data = { 20, 10, 63, 28, 18, 33, 7, 55 };
                            Ordenamiento obj = new Ordenamiento();
                            obj.listado(data);
                            obj.merge_sort(data, 0, data.Length - 1);
                            Console.WriteLine("Arreglo Ordenado : ");
                            obj.listado(data);
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("BUSQUEDA BINARIA");
                            int[] data = { 20, 10, 63, 28, 18, 33, 7, 55 };
                            Ordenamiento obj = new Ordenamiento();
                            obj.insercion(data);
                            Console.WriteLine("Arreglo Ordenado : ");
                            obj.listado(data);
                            Console.WriteLine("Busqueda Binaria");
                            Console.Write("Ingrese numero a buscar : ");
                            int numero = int.Parse(Console.ReadLine());
                            int pos = obj.BusquedaBinaria(numero, data, 0, data.Length - 1);
                            if (pos >= 0)
                                Console.WriteLine("Numero encontrado en la posicion " + (pos + 1));
                            else
                                Console.WriteLine("Numero no encontrado");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("DIJKSTRA");
                            Dijkstra obj = new Dijkstra();
                            obj.proceso();
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("ORDENAMIENTO QUICK SORT");
                            Console.WriteLine("Arreglo Original : ");
                            int[] data = { 20, 10, 63, 28, 18, 33, 7, 55 };
                            Ordenamiento obj = new Ordenamiento();
                            obj.listado(data);
                            obj.quick_sort(data, 0, data.Length - 1);
                            Console.WriteLine("Arreglo Ordenado : ");
                            obj.listado(data);
                            Console.ReadKey();
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("SALTO DEL CABALLO");
                            BackTracking obj = new BackTracking();
                            Console.Write("Dimension de tablero : ");
                            int N = int.Parse(Console.ReadLine());
                            Console.WriteLine("Celda inicial : ");
                            Console.Write("Fila  : ");
                            int fila = int.Parse(Console.ReadLine());
                            Console.Write("Col   : ");
                            int col = int.Parse(Console.ReadLine());
                            obj.procesar(N, fila - 1, col - 1);
                            obj.imprimirMatriz();
                            Console.ReadKey();
                        }
                        break;
                    case 9:
                        {
                            Console.WriteLine("PROBLEMA DE LA MOCHILA");
                            int capacidad = 50;
                            int[] pesos = { 10, 20, 30 };
                            int[] valores = { 60, 100, 120 };
                            int n = pesos.Length;
                            Dinamica obj = new Dinamica();
                            int resultado = obj.Mochila(capacidad, pesos, valores, n);
                            Console.WriteLine("Listado de pesos : ");
                            obj.listado(pesos);
                            Console.WriteLine("Listado de cantidades : ");
                            obj.listado(valores);
                            Console.WriteLine("El máximo valor que se puede obtener es : {0}", resultado);
                            Console.ReadKey();
                        }
                        break;
                    case 10:
                        {
                            Console.WriteLine("ALGORITMO DE FLOYD");
                            int n = 4;
                            int[,] grafo = {{   0,   5, INF,  10 },
                                            { INF,   0,   3, INF },
                                            { INF, INF,   0,   1 },
                                            { INF, INF, INF,   0 }};

                            Dinamica obj = new Dinamica();
                            Console.WriteLine("\nLa matriz original es: ");
                            obj.imprimirMatriz(grafo, n);
                            Console.WriteLine("\nLa matriz de distancias más cortas entre cada par de vértices es: ");
                            obj.Floyd(grafo, n);
                            Console.ReadKey();
                        }
                        break;
                }
            } while (opc != 0);

        }
    }
}
