using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonteKarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            int bHeight = 200, bWidth = 200;
            Bitmap bmp = new Bitmap(bWidth, bHeight);
            Graphics graph = this.panel1.CreateGraphics();
                       
            Random rnd = new Random();
            double x, y;
            int circlePts = 0, totalPts = 0;

            if (int.Parse(textBox1.Text) >= 1)
            {
                for (int i = 0; i < int.Parse(textBox1.Text); i++)
                {
                    x = rnd.NextDouble();
                    y = rnd.NextDouble();
                    Color ptColor = Color.Red;
                    if (Math.Pow(x, 2) + Math.Pow(y, 2) <= 1)
                    {
                        circlePts++;
                        ptColor = Color.Purple;
                    }


                    int imX = (int)Math.Floor(x * (bWidth - 1) * 1.0) + 1;
                    int imY = (int)Math.Floor(y * (bHeight - 1) * 1.0) + 1;
                    bmp.SetPixel(imX, imY, ptColor);


                    totalPts++;
                }

                double piApprox = 4.0 * (double)circlePts / (double)(totalPts);
                labelResult.Text = piApprox.ToString();

                graph.DrawImage(bmp, new Point(0,0));
            }
                            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            labelResult.Text = "";
          
        }
    }
}
