using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_Binario_Busqueda
{
    internal class arbol
    {
        public Nodo insertar(Nodo actual, int num)
        {
            Nodo nuevo = new Nodo(num);

            if (actual == null) return nuevo;
            if (num < actual.numero)
                actual.izquierda = insertar(actual.izquierda, num);
            else if (num > actual.numero)
                actual.derecha = insertar(actual.derecha, num);
            else MessageBox.Show("No se permiten duplicados");
            return actual;
        }

        public void preorden(Nodo actual, TextBox t)
        {
            if(actual != null)
            {
                t.Text += actual.numero.ToString() +" ";//R
                preorden(actual.izquierda, t); //I
                preorden(actual.derecha, t); //D
            }
        }

        public void inorden(Nodo actual, TextBox t)
        {
            if (actual != null)
            {
                inorden(actual.izquierda, t); //I
                t.Text += actual.numero.ToString() + " ";//R
                inorden(actual.derecha, t); //D
            }
        }

        public void postorden(Nodo actual, TextBox t)
        {
            if (actual != null)
            {
                postorden(actual.izquierda, t); //I
                postorden(actual.derecha, t); //D
                t.Text += actual.numero.ToString() + " ";//R
            }
        }

        public void mostrar(Nodo actual, TreeView t, TreeNode tallo)
        {
            if (actual != null)
            {
                TreeNode raiz = new TreeNode(actual.numero.ToString());//R
                if(tallo == null) t.Nodes.Add(raiz);
                else tallo.Nodes.Add(raiz);

                mostrar(actual.izquierda, t,raiz); //I
                mostrar(actual.derecha, t, raiz); //D
            }
        }
    }
}
