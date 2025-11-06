using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafoAdyacencia
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

        public void insertarArista(int o, int d)
        {
            matriz[o,d] = 1;
            //matriz[d,o] = 1; si el grafo es no dirigido
        }
        public void imprimirArista(ListBox list, int o, int d)
        {
            list.Items.Add($"{o} | {d}");
        }

        public void imprimirMatriz(RichTextBox rich)
        {
            for(int i = 0;i < vertices; i++)
            {
                for (int j = 0;j < vertices; j++)
                {
                    rich.Text += matriz[i, j]+"\t";
                }
                rich.Text += "\n";
            }
        }

        public void amplitud(TextBox text)
        {
            int inicio = 0;
            bool[] visitado = new bool[vertices];
            Queue<int> cola = new Queue<int>();

            visitado[inicio] = true;
            cola.Enqueue(inicio);

            while(cola.Count() != 0)
            {
                int actual = cola.Dequeue();
                text.Text += actual + " ";

                for(int i = inicio;i < vertices; i++)
                {
                    if (matriz[actual,i] ==1 && !visitado[i])
                    {
                        visitado[i] = true;
                        cola.Enqueue(i);
                    }
                }
            }
        }

        public void profundidad(TextBox text)
        {
            int inicio = 0;
            bool[] visitado = new bool[vertices];
            Stack<int> pila = new Stack<int>();

            visitado[inicio] = true;
            pila.Push(inicio);

            while (pila.Count() != 0)
            {
                int actual = pila.Pop();
                text.Text += actual + " ";

                for (int i = vertices-1; i >=inicio; i--)
                {
                    if (matriz[actual, i] == 1 && !visitado[i])
                    {
                        visitado[i] = true;
                        pila.Push(i);
                    }
                }
            }
        }
    }
}
