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
    public partial class IngresodeColorante : Form
    {
        public IngresodeColorante()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Colorante> color = new List<Colorante>();
            
            string fileName = @"C: \Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Colorantes.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(textBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.Close();

            string fileName2 = @"C:\Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Colorantes.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream2);
            while (reader.Peek() > -1)
            {
                Colorante colotemp = new Colorante();
                colotemp.Nombre = reader.ReadLine();
                colotemp.Cantidad = Convert.ToDecimal(reader.ReadLine());
                color.Add(colotemp);
            }
            reader.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = color;
            dataGridView1.Refresh();
            textBox1.Text = " ";
            textBox2.Text = " ";
         
        }
    }
}
