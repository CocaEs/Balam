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
    public partial class Regenmadejado : Form
    {
        public Regenmadejado()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Hilo> listahilo = new List<Hilo>();
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
            for (int i = 0; i < listahilo.Count; i++)
            {
                comboBox1.Items.Add(listahilo[i].Tipodehilo);
            }     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<RegistroEnmadejado> enmadejado = new List<RegistroEnmadejado>();
            List<Hilo> listahilo = new List<Hilo>();
            List<EnmadejadoProducido> enmabodega = new List<EnmadejadoProducido>();

            string fileName = @"C: \Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\RegistroEnmadejado.txt";
            FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(comboBox1.Text);
            writer.WriteLine(textBox2.Text);
            writer.WriteLine(textBox3.Text);
            writer.WriteLine(DateTime.Now);
            writer.Close();


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
                enmadejado.Add(regtemp);
            }
            reader.Close();

            string fileName3 = @"C:\Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Hilo.txt";
            FileStream stream3 = new FileStream(fileName3, FileMode.Open, FileAccess.Read);
            StreamReader reader3 = new StreamReader(stream3);
            while (reader3.Peek() > -1)
            {
                Hilo hilotempo = new Hilo();
                hilotempo.Tipodehilo = reader3.ReadLine();
                hilotempo.Proveedor = reader3.ReadLine();
                hilotempo.Cantidad = Convert.ToDecimal(reader3.ReadLine());
                listahilo.Add(hilotempo);
            }
            reader3.Close();

            for (int i = 0; i < listahilo.Count; i++)
            {
                if(comboBox1.Text == listahilo[i].Tipodehilo)
                {
                    listahilo[i].Cantidad = listahilo[i].Cantidad - Convert.ToDecimal(textBox2.Text);
                }
            }


            string fileName5 = @"C: \Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\Hilo.txt";
            FileStream stream5 = new FileStream(fileName5, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer5 = new StreamWriter(stream5);
            for (int i = 0; i < listahilo.Count; i++)
            {
                writer5.WriteLine(listahilo[i].Tipodehilo);
                writer5.WriteLine(listahilo[i].Proveedor);
                writer5.WriteLine(listahilo[i].Cantidad);
            }
            writer5.Close();

            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = enmadejado;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = listahilo;
            dataGridView2.Refresh();

            //asigna a una lista los nombres de los hilos y el enmadejado
            for (int i = 0; i < listahilo.Count; i++)
            {
                EnmadejadoProducido enmatemp = new EnmadejadoProducido();
                enmatemp.Nombre = listahilo[i].Tipodehilo;
                enmatemp.Cantidad = 0;
                enmabodega.Add(enmatemp);
            }

            string fileName6 = @"C: \Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\EnmadejadoBodega.txt";
            FileStream stream6 = new FileStream(fileName6, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer6 = new StreamWriter(stream6);
            for (int i = 0; i < enmabodega.Count; i++)
            {
                writer6.WriteLine(enmabodega[i].Nombre);
                writer6.WriteLine(enmabodega[i].Cantidad);
            }
            writer6.Close();


            string fileName4 = @"C:\Users\EsOsc\source\repos\TINTORERIAbalam\TINTORERIAbalam\bin\Debug\EnmadejadoBodega.txt";
            FileStream stream4 = new FileStream(fileName4, FileMode.Open, FileAccess.Read);
            StreamReader reader4 = new StreamReader(stream4);
            while (reader4.Peek() > -1)
            {
                EnmadejadoProducido prodtemp = new EnmadejadoProducido();
                prodtemp.Nombre = reader4.ReadLine();
                prodtemp.Cantidad = Convert.ToDecimal(reader4.ReadLine());
            }
            reader4.Close();

            //sumatoria de todo el enmadejado producido

            for (int i = 0; i < regenmad.Count; i++)
            {
                for (int j = 0; j < prodenma.Count; j++)
                {
                    if (regenmad[i].Tipodehilo == prodenma[j].Nombre)
                    {
                        prodenma[j].Cantidad = prodenma[j].Cantidad + regenmad[i].Cantidad;
                    }
                }
            }
        }

       
    }
}
