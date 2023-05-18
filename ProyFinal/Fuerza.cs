using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyFinal
{
    public class Fuerza
    {
		public int buscar(String cadena, String busca)
		{
			int pos = ubicarEnCadena(cadena, busca);
			if (pos >= 0)
				Console.WriteLine("Se encontro cadena '{0}'en texto '{1}' en la posicion {2}", busca, cadena, pos + 1);
			else
				Console.WriteLine("No se encontro cadena '{0}'en texto '{1}'", busca, cadena);

			int cont = contarVocales(cadena);
			Console.WriteLine("Se encontraron {0} vocales en texto '{1}'", cont, cadena);

			return 0;
		}

		int ubicarEnCadena(string cadena, string buscar)
		{
			int i, j;
			int n = cadena.Length;
			int m = buscar.Length;

			// busqueda caracteres por fuerza bruta
			for (i = 0; i <= n - m; i++)
			{
				j = 0;
				while (j < m && buscar[j] == cadena[i + j])
				{
					j++;
				}
				if (j == m)
					return i;
			}
			return -1;
		}
		int contarVocales(string cadena)
		{
			int i, cont = 0;
			int n = cadena.Length;
			char car;

			cadena = cadena.ToLower();
			for (i = 0; i < n; i++)
			{
				car = cadena[i];
				if (car == 'a' || car == 'e' || car == 'i' || car == 'o' || car == 'u')
					cont++;
			}
			return cont; ;
		}

		List<String> obtenerCombinaciones(String texto, int k)
        {
			List<string> resultados = new List<string>();
			int i,pos;
			int N = texto.Length;

			// inicializamos
			for (pos = 0; pos < N; pos++)
				resultados.Add(texto.Substring(pos,1));

			for (i = 2; i <= k; i++)
				resultados = concatenar(resultados, texto);

			return resultados;

		}
		private List<string> concatenar(List<string> lista, String texto)
		{
			List<string> resultados = new List<string>();
			String aux;
			int i,j;
			int N = texto.Length;
			for (i = 0; i < lista.Count; i++)
			{
				for (j = 0; j < N; j++)
                {
					aux = texto.Substring(j, 1);
					if (lista[i].IndexOf(aux) < 0)			// no se encuentra
                    {
						resultados.Add(lista[i] + aux);
					}
				}
			}
			return resultados;
		}
		public int listarCombinaciones(String texto, int k)
		{
			List<string> resultado =  obtenerCombinaciones(texto, k);
			Console.WriteLine("Combinaciones de longitud {0} para texto '{1}' :", k,texto);
			foreach (String valor in resultado)
            {
				Console.WriteLine(valor);
			}

			return 0;
		}
	}
}
