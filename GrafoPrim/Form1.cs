using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafoPrim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Grafo g;
        private void btnVertices_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textVert.Text, out int vert) && vert > 0)
            {
                g = new Grafo(vert);
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                richTextBox1.Clear();
            }
            else MessageBox.Show("Ingrese un vertice válido");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (g != null)
            {
                int o = int.Parse(textOrigen.Text);
                int d = int.Parse(textDestino.Text);
                int c = int.Parse(textCosto.Text);

                g.insertarArista(o, d, c);
                g.imprimirArista(listBox1, o, d, c);
                textOrigen.Clear();
                textDestino.Clear();
                textCosto.Clear();
            }
            else MessageBox.Show("Define primero la cantidad de vértices");
        }

        private void btnMatriz_Click(object sender, EventArgs e)
        {
            if (g != null)
            {
                richTextBox1.Clear();
                g.imprimirMatriz(richTextBox1);
            }
            else MessageBox.Show("Define primero la cantidad de vértices");
        }

        private void btnprim_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            g.Prim(listBox2);
        }
    }
}
