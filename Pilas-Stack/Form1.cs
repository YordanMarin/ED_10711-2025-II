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

namespace Pilas_Stack
{
    public partial class Form1 : Form
    {
        Pila p = new Pila();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnApilar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textNombre.Text))
            {
                if(Regex.IsMatch(textNombre.Text, @"^[a-zA-Z]+$"))
                {
                    listBox1.Items.Clear();
                    p.Push(textNombre.Text.Trim());
                    p.mostrar(listBox1);
                    textNombre.Clear();
                }
                else
                {
                    MessageBox.Show("Solo se permiten texto");
                }
            }
            else
                MessageBox.Show("Ingrese un nombre!");
        }

        private void btnDesapilar_Click(object sender, EventArgs e)
        {
            string nom = p.Pop();

            if(nom != null)
            {
                MessageBox.Show($"{nom} ah sido desapilado correctamente");
                listBox1.Items.Clear();
                p.mostrar(listBox1);
            }
            else
            {
                MessageBox.Show("Pila vacía!");
            }
        }

        private void btnVistazo_Click(object sender, EventArgs e)
        {
            string nom = p.Peek();

            if (nom != null)
            {
                MessageBox.Show($"Cima: {nom}");
            }
            else
            {
                MessageBox.Show("Pila vacía!");
            }
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cantidad: " + p.Count());
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            p.Clear();
            listBox1.Items.Clear();
            MessageBox.Show("Pila se limpio correctamente");
        }
    }
}
