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
    public partial class ProduccionMercerizado : Form
    {
        public ProduccionMercerizado()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<RegistroEnmadejado> regenmad = new List<RegistroEnmadejado>();
            List<EnmadejadoProducido> prodenma = new List<EnmadejadoProducido>();
            List<Hilo> listahilo = new List<Hilo>();

            string fileName2 = @"C:\Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\RegistroEnmadejado.txt";
            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream2);
            while (reader.Peek() > -1)
            {
                RegistroEnmadejado regtemp = new RegistroEnmadejado();
                regtemp.Tipodehilo = reader.ReadLine();
                regtemp.Cantidad = Convert.ToDecimal(reader.ReadLine());
                regtemp.Numerodemaquina = reader.ReadLine();
                regtemp.Fechaenmadejado = Convert.ToDateTime(reader.ReadLine());
                regenmad.Add(regtemp);
            }
            reader.Close();


            string fileName3 = @"C:\Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Hilo.txt";
            FileStream stream3 = new FileStream(fileName3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Hilo hilotemp = new Hilo();
                hilotemp.Tipodehilo = reader3.ReadLine();
                hilotemp.Proveedor = reader3.ReadLine();
                hilotemp.Cantidad = Convert.ToDecimal(reader3.ReadLine());
                listahilo.Add(hilotemp);
            }
            reader3.Close();


            

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = prodenma;
            dataGridView2.Refresh();

            for (int i = 0; i < prodenma.Count; i++)
            {
                comboBox1.Items.Add(prodenma[i].Nombre);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string fileName = @"C: \Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\RegistroMercerizado.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(textBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.WriteLine(comboBox1.Text);
            writer.WriteLine(textBox4.Text);
            writer.Close();
        }
    }
}
