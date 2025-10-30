using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABB3
{
    internal class Arbol
    {
        public Nodo insertar(Nodo actual, int num)
        {
            Nodo nuevo = new Nodo(num);
            if (actual == null) return nuevo;
            if (num < actual.numero)
                actual.izquierda = insertar(actual.izquierda, num);
            else if (num > actual.numero)
                actual.derecha = insertar(actual.derecha, num);
            else MessageBox.Show("No duplicados");
            return actual;
        }

        public void mostrar(Nodo actual, TreeView t, TreeNode tallo)
        {
            if (actual != null)
            {
                TreeNode raiz = new TreeNode(actual.numero.ToString());
                if (tallo == null) t.Nodes.Add(raiz);
                else tallo.Nodes.Add(raiz);

                mostrar(actual.izquierda, t, raiz);
                mostrar(actual.derecha, t, raiz);
            }
        }

        public int minimo(Nodo actual)
        {
            while (actual.izquierda != null)
                actual = actual.izquierda;
            return actual.numero;
        }

        public int maximo(Nodo actual)
        {
            while (actual.derecha != null)
                actual = actual.derecha;
            return actual.numero;
        }

        public int SumaHojas(Nodo actual)
        {
            if(actual == null) return 0;
            if(actual.derecha == null && actual.izquierda==null)
                return actual.numero;

            return SumaHojas(actual.izquierda) + SumaHojas(actual.derecha);
        }

        public int VerificarBalanceo(Nodo actual)
        {
            if (actual == null) return 0;

            int alturaIzq = VerificarBalanceo(actual.izquierda);
            int alturaDer = VerificarBalanceo(actual.derecha);

            if (alturaIzq < 0) return -1; //no esta balanceado
            if (alturaDer < 0) return -1; //no esta balanceado

            if (Math.Abs(alturaIzq-alturaDer) > 1) return -1;

            return Math.Max(alturaDer, alturaIzq) + 1;
        }
    }
}
