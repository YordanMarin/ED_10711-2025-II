using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol_Binario_Busqueda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        arbol a = new arbol();
        Nodo raiz;
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (raiz == null)
                    raiz = a.insertar(null, int.Parse(textNumero.Text));
                else
                    a.insertar(raiz, int.Parse(textNumero.Text));

                textNumero.Clear();
                treeView1.Nodes.Clear();
                a.mostrar(raiz, treeView1, null);
                treeView1.ExpandAll();
            }
            catch (Exception) {
                MessageBox.Show("Solo permiten números enteros validos");
            }
            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            textpre.Clear();
            textin.Clear();
            textpost.Clear();

            a.preorden(raiz, textpre);
            a.inorden(raiz, textin);
            a.postorden(raiz, textpost);
        }
    }
}
