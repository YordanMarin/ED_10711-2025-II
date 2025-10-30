using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABB3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Arbol a = new Arbol();
        Nodo raiz;
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textNumero.Text, out int num) && num >= 0)
            {
                if (raiz == null) raiz = a.insertar(null, num);
                else a.insertar(raiz, num);

                treeView1.Nodes.Clear();
                a.mostrar(raiz, treeView1, null);
                treeView1.ExpandAll();
                textNumero.Clear();
            }
            else MessageBox.Show("Solo se permiten números positivos");
        }

        private void btnMinimo_Click(object sender, EventArgs e)
        {
            if (raiz == null) MessageBox.Show("Árbol vacio.");
            else MessageBox.Show("Mínimo: " + a.minimo(raiz));
        }

        private void btnMaximo_Click(object sender, EventArgs e)
        {
            if (raiz == null) MessageBox.Show("Árbol vacio.");
            else MessageBox.Show("Máximo: " + a.maximo(raiz));
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            if (raiz == null) MessageBox.Show("Árbol vacio.");
            else MessageBox.Show("Suma de hojas: " + a.SumaHojas(raiz));
        }

        private void btnBalanceo_Click(object sender, EventArgs e)
        {
            if (raiz == null) MessageBox.Show("Árbol vacio.");
            else
            {
                if(a.VerificarBalanceo(raiz) != -1)
                    MessageBox.Show("Árbol balanceado.");
                else MessageBox.Show("Árbol no balanceado.");
            }
        }
    }
}
