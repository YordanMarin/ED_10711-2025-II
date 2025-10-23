using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Nodo raiz;
        Arbol a = new Arbol();
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textNumero.Text, @"^\d{4}.\d+$"))
            {
                if (double.TryParse(textNumero.Text, out double num) & num > 0)
                {
                    if (raiz == null) raiz = a.insertar(null, num);
                    else a.insertar(raiz, num);

                    treeView1.Nodes.Clear();
                    a.mostrar(raiz, treeView1, null);
                    treeView1.ExpandAll();
                    textNumero.Clear();
                }
                else MessageBox.Show("Solo se permiten números mayores a 0");
            }
            else 
                MessageBox.Show("Solo se permiten a enteros y almenos 1 decimal");
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            textPost.Clear();
            a.post(raiz, textPost);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textNumero.Text, out double num) & num > 0)
            {
                if (a.buscar(raiz, num) != null)
                    MessageBox.Show($"El número {num} so existe");
                else 
                    MessageBox.Show($"El número {num} no existe");
            }
            else MessageBox.Show("Solo se permiten números mayores a 0");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textNumero.Text, out double num) & num > 0)
            {
                if (a.buscar(raiz, num) != null)
                {
                    raiz = a.eliminar(raiz, num);
                    treeView1.Nodes.Clear();
                    a.mostrar(raiz, treeView1, null);
                    treeView1.ExpandAll();
                    textNumero.Clear();
                }
                else
                    MessageBox.Show($"El número {num} no existe");
            }
            else MessageBox.Show("Solo se permiten números mayores a 0");
        }
    }
}
