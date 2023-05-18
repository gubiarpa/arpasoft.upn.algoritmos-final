using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinal
{
    public class Ordenamiento
    {

        public void listado(int[] data)
        {
            int N = data.Length;
            Console.Write("LISTADO : ");
            for (int i = 0; i < N; i++)
            {
                Console.Write("{0}\t", data[i]);
            }
            Console.WriteLine();
        }
        public void insercion(int[] data)
        {
            int N = data.Length;
            int aux;
            int i, j;
            for (i = 0; i < N; i++)
            {
                aux = data[i];
                j = i;
                while (j > 0 && data[j - 1] > aux)
                {
                    data[j] = data[j - 1];
                    j--;
                }
                data[j] = aux;
            }
        }
        void merge(int[] data, int izq, int med, int der)
        {

            int[] temp = new int[der-izq+1];
            int i, j, k;
            i = izq;
            j = med + 1;
            k = 0;

            while (i <= med && j <= der)
            {
                if (data[i] < data[j])
                    temp[k++] = data[i++];
                else
                    temp[k++] = data[j++];
            }
            while (i <= med)
            {
                temp[k++] = data[i++];
            }
            while (j <= der)
            {
                temp[k++] = data[j++];
            }
            for (i = izq, j = 0; i <= der; i++, j++)
            {
                data[i] = temp[j];
            }
        }

        public void merge_sort(int[] data, int izq, int der)
        {

            if (izq < der)
            {
                int med = (izq + der) / 2;
                merge_sort(data, izq, med);
                merge_sort(data, med + 1, der);
                merge(data, izq, med, der);
            }
        }
        public void quick_sort(int[] data, int primero, int ultimo)
        {
            int N = data.Length;
            int i, j, central, aux;
            float pivote;

            central = (primero + ultimo) / 2;
            pivote = data[central];
            i = primero;
            j = ultimo;
            do
            {
                while (data[i] < pivote)
                    i++;
                while (data[j] > pivote)
                    j--;
                if (i <= j)
                {
                    // intercambio
                    aux = data[i];
                    data[i] = data[j];
                    data[j] = aux;
                    //
                    i++;
                    j--;
                }
            } while (i <= j);
            //Ordenamos la sublista izquierda
            if (primero < j)
            {
                quick_sort(data, primero, j);
            }
            //Ordenamos la sublista derecha
            if (i < ultimo)
            {
                quick_sort(data, i, ultimo);
            }
        }

        public int BusquedaBinaria(int busca, int[] data, int izq, int der)
        {
            int res = -1;
            int medio = (izq + der) / 2;
            if (busca == data[medio])
                res = medio;
            else
            {
                if (izq > der)
                    res = -1;
                else
                {
                    if (busca < data[medio])
                        res = BusquedaBinaria(busca, data, izq, medio - 1);
                    else
                        res = BusquedaBinaria(busca, data, medio + 1, der);
                }
            }
            return res;
        }

    }
}
