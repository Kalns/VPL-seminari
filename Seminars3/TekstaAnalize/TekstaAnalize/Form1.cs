using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TekstaAnalize
{
    public partial class Form1 : Form
    {
        double[] visiBurtiVekt = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        double[] lielieBurtiVekt = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }

        void fileRead(String path)
        {
            string readText = System.IO.File.ReadAllText(path);

            foreach (char iCh in readText)
            {
                if (char.IsLetter(iCh))
                {
                    visiBurtiVekt[(int)Char.ToLower(iCh) - 97]++;
                    if (Char.IsUpper(iCh))
                    {
                        lielieBurtiVekt[(int)(iCh - 65)]++;
                    }
                }
            }
            refreshChart();

        }

        void refreshChart()
        {
            chart1.Series["Visi burti"].Points.Clear();
            for (int i=0; i<visiBurtiVekt.Length; i++)
            {
                chart1.Series["Visi burti"].Points.AddXY(((char)(i + 97)).ToString(), visiBurtiVekt[i]);
            }

            chart1.Series["Lielie burti"].Points.Clear();
            for (int i = 0; i < lielieBurtiVekt.Length; i++)
            {
                chart1.Series["Lielie burti"].Points.AddXY(((char)(i + 65)).ToString(), lielieBurtiVekt[i]);
            }
        }

        void clearHistory()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                String path = ofd.InitialDirectory + ofd.FileName;
                fileRead(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearHistory();
        }


    }
}
