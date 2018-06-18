using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TINTORERIAbalam
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ingresoinsumo = new Form1();
            ingresoinsumo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IngresodeHilo ingrehilo = new IngresodeHilo();
            ingrehilo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IngresodeColorante color = new IngresodeColorante();
            color.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Regenmadejado registroenma = new Regenmadejado();
            registroenma.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProduccionMercerizado merce = new ProduccionMercerizado();
            merce.Show();
        }
    }
}
