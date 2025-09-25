using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASO1_T1
{
    internal class Nodo
    {
        private double sueldo;
        private Nodo siguiente;
        private Nodo anterior;

        public double Sueldo { get => sueldo; set => sueldo = value; }
        internal Nodo Siguiente { get => siguiente; set => siguiente = value; }
        internal Nodo Anterior { get => anterior; set => anterior = value; }
    }
}
