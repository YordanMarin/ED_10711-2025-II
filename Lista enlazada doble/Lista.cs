using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista_enlazada_doble
{
    internal class Lista
    {
        Nodo primero = null;
        Nodo ultimo = null;

        public void insertar(int num)
        {
            Nodo nuevo = new Nodo();
            nuevo.Numero = num;

            if(primero == null)
            {
                primero = nuevo;
                nuevo.Siguiente = null;
                nuevo.Anterior = null;
                ultimo = nuevo;
            }
            else
            {
                ultimo.Siguiente = nuevo;
                nuevo.Siguiente = null;
                nuevo.Anterior = ultimo;
                ultimo = nuevo;
            }
        }

        public void mostrar(ListBox list)
        {
            Nodo actual = primero;

            while( actual != null)
            {
                list.Items.Add(actual.Numero);
                actual = actual.Siguiente;
            }
        }

        public void eliminar(int num)
        {
            Nodo actual = primero;

            while( actual != null)
            {
                if( actual.Numero == num)
                {
                    if(actual == primero)
                    {
                        primero = primero.Siguiente;
                        primero.Anterior = null;
                    }else if(actual == ultimo)
                    {
                        ultimo = ultimo.Anterior;
                        ultimo.Siguiente = null;
                    }
                    else
                    {
                        actual.Anterior.Siguiente = actual.Siguiente;
                        actual.Siguiente.Anterior = actual.Anterior;
                    }
                    return;
                }
                actual = actual.Siguiente;
            }
        }
    }
}
