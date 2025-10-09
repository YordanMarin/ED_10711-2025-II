using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_binario
{
    public partial class Form1 : Form
    {
        arbol a = new arbol();
        Nodo raiz;
        Nodo selec;
        public Form1()
        {
            InitializeComponent();
            radioIzquierda.Checked = true;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            raiz = a.insertar(null, int.Parse(textNumero.Text));
            a.mostrar(raiz, treeView1, null);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
             selec = (Nodo)e.Node.Tag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selec != null)
            {
                if (radioIzquierda.Checked == true)
                    selec.izquierda = a.insertar(selec.izquierda, int.Parse(textNumero.Text));
                if (radioDerecha.Checked == true)
                    selec.derecha = a.insertar(selec.derecha, int.Parse(textNumero.Text));

                treeView1.Nodes.Clear();
                a.mostrar(raiz, treeView1, null);
                treeView1.ExpandAll();
                textNumero.Clear();
            }
            else MessageBox.Show("Seleccione un nodo!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Altura: " + a.altura(raiz));
        }
    }
}
