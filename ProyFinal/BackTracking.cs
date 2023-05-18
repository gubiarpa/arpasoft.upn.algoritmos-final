using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinal
{
    public class BackTracking
    {
        public int N;
        public int fini, cini;
        private int[,] matriz;
        private int[,] delta = { { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 } };

        public void procesar(int n, int fini, int cini)
        {
            this.N = n;
            if (N > 0)
            {
                Inicializar();
                bool exito;
                matriz[fini, cini] = 1;
                SaltoCaballo(2, fini, cini, out exito);       // inicia en pieza 2
                if (exito)
                    Console.WriteLine("\nSOLUCION ENCONTRADA");
                else
                    Console.WriteLine("\nSOLUCION NO ENCONTRADA");

            }
        }
        
        private void Inicializar()
        {
            matriz = new int[N, N];
            for (int f = 0; f < N; f++)
                for (int c = 0; c < N; c++)
                    matriz[f, c] = 0;
        }

        private void SaltoCaballo(int i, int x, int y, out bool exito)
        {
            int deltaX, deltaY;
            exito = false;

            int NK = delta.GetLength(0);          // nro de posiciones
            for (int k = 0; k < NK; k++)      // 8 posibles movimientos
            {
                deltaX = x + delta[k, 0];
                deltaY = y + delta[k, 1];
                //Determina si nuevas coordenadas son aceptables
                if ((deltaX >= 0) && (deltaX < N) && (deltaY >= 0) && (deltaY < N) && (matriz[deltaX, deltaY] == 0))
                {
                    //Anota movimiento
                    matriz[deltaX, deltaY] = i;

                    if (i < N * N) // Si no se ha rellenado el tablero
                    {
                        SaltoCaballo(i + 1, deltaX, deltaY, out exito);
                        if (!exito)
                        {
                            matriz[deltaX, deltaY] = 0;        // no se alcanzo la solución, se borra anotación
                        }
                    }
                    else
                    {
                        exito = true;       //Caballo ha cubierto el tablero
                    }
                }
                if (exito)
                    break;
            }
        }
        
        public void imprimirMatriz()
        {
            Console.WriteLine("\nTablero");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
