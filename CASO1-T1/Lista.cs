﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASO1_T1
{
    internal class Lista
    {
        Nodo primero = null;
        Nodo ultimo = null;

        public bool insertar(double s)
        {
            Nodo nuevo = new Nodo();
            nuevo.Sueldo = s;

            if(buscar(s) == false)
            {
                if (primero == null)
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
                return true;
            }
            return false;
        }

        public bool buscar(double s)
        {
            Nodo actual = primero;
            while(actual != null)
            {
                if(actual.Sueldo == s)
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public void mostrar(ListBox list)
        {
            Nodo actual = primero;
            while(actual != null)
            {
                list.Items.Add(actual.Sueldo);
                actual = actual.Siguiente;
            }
        }
    }
}
