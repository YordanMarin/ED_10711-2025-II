using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafoDijsktra
{
    internal class Grafo
    {
        int[,] matriz;
        int vertices;

        public Grafo(int vertices)
        {
            this.vertices = vertices;
            matriz = new int[vertices,vertices];
        }

        public void imprimirMatriz(RichTextBox rich)
        {
            for (int i = 0; i < vertices; i++)
            {
                for(int j = 0; j < vertices; j++)
                {
                    rich.Text += matriz[i, j] + "\t";
                }
                rich.Text += "\n";
            }
        }

        public void insertarArista(int o, int d, int c)
        {
            matriz[o,d] = c;
            //matriz[d,o] = c; //si es no dirigido
        }

        public void imprimirArista(ListBox list, int o, int d, int c)
        {
            list.Items.Add($"{o} | {d} | {c}");
        }

        public void Dijsktra(ListBox list)
        {
            int origen = 0;
            int[] distancias = new int[vertices];
            bool[] visitados = new bool[vertices];

            for(int i = 0;i < vertices; i++)
            {
                distancias[i] = int.MaxValue;
                visitados[i] = false;
            }
            distancias[origen] = 0;

            for(int i = 0;i < vertices-1; i++)
            {
                int actual = minDistancia(distancias, visitados);
                visitados[actual] = true;

                for( int j = 0;j < vertices; j++)
                {
                    if (!visitados[j] && matriz[actual,j] != 0 && distancias[actual] != int.MaxValue && distancias[actual] + matriz[actual,j] < distancias[j])
                    {
                        distancias[j] = distancias[actual] + matriz[actual, j];
                    }
                }
            }
            //IMPRIMIENTO RUTAS MÍNIMAS
            list.Items.Add("Origen\tDestino\tDistancia mínima");
            for (int i = 0; i < vertices; i++)
            {
                if (distancias[i] == int.MaxValue)
                    list.Items.Add($"{origen}\t{i}\tIdeterminado");
                else list.Items.Add($"{origen}\t{i}\t{distancias[i]}");
            }
        }

        public int minDistancia(int[] distancias, bool[] visitados)
        {
            int min = int.MaxValue;
            int index = -1;

            for(int i = 0; i < vertices; i++)
            {
                if(!visitados[i] && distancias[i] <= min)
                {
                    min = distancias[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
