using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TINTORERIAbalam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Insumo> insu = new List<Insumo>();

            string fileName = @"C: \Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Insumos.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(textBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.WriteLine(comboBox1.Text);
            writer.WriteLine(textBox4.Text);
            writer.Close();

            string fileName2 = @"C:\Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Insumos.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream2);
            while (reader.Peek() > -1)
            {
                Insumo insutemp = new Insumo();
                insutemp.Nombreproducto = reader.ReadLine();
                insutemp.Cantidad = Convert.ToDecimal(reader.ReadLine());
                insutemp.Proveedor = reader.ReadLine();
                insutemp.Descripcion = reader.ReadLine();
                insu.Add(insutemp);
            }
            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = insu;
            dataGridView1.Refresh();
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox4.Text = " ";
        }
    }
}
