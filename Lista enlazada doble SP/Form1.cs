using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista_enlazada_doble_SP
{
    public partial class Form1 : Form
    {
        Lista l = new Lista();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre!");
            }
            else
            {
                if(byte.TryParse(textEdad.Text, out byte edad) && edad <=164)
                {
                    listView1.Items.Clear();
                    l.insertar(textNombre.Text.Trim(), edad);
                    l.mostrar(listView1);
                    textNombre.Clear();
                    textEdad.Clear();
                }
                else
                {
                    MessageBox.Show("Ingrese una edad válida!");
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("Ingrese un nombre a buscar!");
            }
            else
            {
                Nodo encontrar = l.buscar(textNombre.Text.Trim());

                if(encontrar != null)
                {
                    MessageBox.Show($"Nombre: {encontrar.Nombre}\nEdad: {encontrar.Edad}");
                }
                else
                {
                    MessageBox.Show($"El nombre {textNombre.Text} no se encuentra en la lista");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                string nom = listView1.SelectedItems[0].Text;
                if (string.IsNullOrWhiteSpace(textNombre.Text))
                {
                    MessageBox.Show("Ingrese un nombre a buscar!");
                }
                else
                {
                    if (byte.TryParse(textEdad.Text, out byte edad) && edad <= 164)
                    {
                        l.modificar(nom, textNombre.Text, byte.Parse(textEdad.Text));
                        listView1.Items.Clear();
                        l.mostrar(listView1);
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una edad válida!");
                    }
                }     
            }
            else
            {
                MessageBox.Show("Seleccione un nombre de la lista!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string nom = listView1.SelectedItems[0].Text;

                l.eliminar(nom);
                listView1.Items.Clear();
                l.mostrar(listView1);
                textNombre.Clear();
                textEdad.Clear();
            }
            else
            {
                MessageBox.Show("Seleccione un nombre de la lista!");
            }
        }
    }
}
