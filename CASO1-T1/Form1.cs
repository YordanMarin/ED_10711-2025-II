using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASO1_T1
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
            string sueldo = textSueldo.Text.Trim();

            if (sueldo.Contains("."))
            {
                string[] partes = sueldo.Split('.');

                if (partes[0].Length == 5)
                {
                    if (partes[1].Length > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(sueldo))
                        {
                            if (double.TryParse(sueldo, out double s))
                            {
                                if (s > 0)
                                {
                                    if (l.insertar(s))
                                    {
                                        listBox1.Items.Clear();
                                        l.mostrar(listBox1);
                                        textSueldo.Clear();
                                    }
                                    else MessageBox.Show("No se permiten duplicados!");
                                }
                                else MessageBox.Show("No se permiten negativos!");
                            }
                            else MessageBox.Show("Ingrese un número válido!");
                        }
                        else MessageBox.Show("Ingrese sueldo por favor!");
                    }
                    else MessageBox.Show("Debe de tener almenos 1 decimal");
                    
                }
                else MessageBox.Show("Tiene que ser 5 enteros");

                
            }
            else MessageBox.Show("Debe de ingresar el punto decimal!");
        }
    }
}
