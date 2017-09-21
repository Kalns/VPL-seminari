using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JavaToDash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            int sk_int = Int32.Parse(textBox1.Text);
            int izvele = Int32.Parse(textBox2.Text);

            switch (izvele)
            {
                case 1:
                    label4.Text="kvadrats = " + sk_int * sk_int;
                    break;
                case 2:
                    label4.Text=((sk_int >= 0) ? ("kvadratsakne = " + Math.Sqrt((double)sk_int)) : ("kvadratsanke neeksiste!"));
                    break;
                case 3:
                    label4.Text=((sk_int > 0) ? ("log = " + Math.Log((double)sk_int)) : ("log neeksiste!"));
                    break;
                case 4:
                    int fac = 1;
                    for (int i = 1; i <= sk_int; i++)
                    {
                        fac *= i;
                    }
                    label4.Text=((sk_int >= 0) ? ("faktorials = " + fac) : ("faktorials neeksiste?!?"));
                    break;

                default:
                    label4.Text="Nav sadas darbibas";
                    break;

            }
        }
    }
}
