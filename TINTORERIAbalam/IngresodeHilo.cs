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
    public partial class IngresodeHilo : Form
    {
        public IngresodeHilo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Hilo> listahilo = new List<Hilo>();
            string fileName = @"C: \Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Hilo.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(textBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.WriteLine(textBox3.Text);
            writer.Close();

            string fileName2 = @"C:\Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Hilo.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream2);
            while (reader.Peek() > -1)
            {
                Hilo hilotemp = new Hilo();
                hilotemp.Tipodehilo = reader.ReadLine();
                hilotemp.Proveedor = reader.ReadLine();
                hilotemp.Cantidad = Convert.ToDecimal(reader.ReadLine());
                listahilo.Add(hilotemp);
            }
            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = listahilo;
            dataGridView1.Refresh();
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
        }
    }
}
