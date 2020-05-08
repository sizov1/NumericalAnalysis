using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spline
{
    public partial class Form1 : Form
    {
        Info inf;
        int n;
        Spline spline;
        double x0, h; 

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormInfo fi = new FormInfo();
            fi.DisplayInfo(inf);
            fi.Show();
        }

        void SplineCoefficientTable()
        {
            for(int i = 0; i < n; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i.ToString();
                dataGridView1.Rows[i].Cells[1].Value = (x0 + i * h).ToString();
                dataGridView1.Rows[i].Cells[2].Value = (x0 + (i + 1) * h).ToString();
                dataGridView1.Rows[i].Cells[3].Value = spline.a[i].ToString();
                dataGridView1.Rows[i].Cells[4].Value = spline.b[i].ToString();
                dataGridView1.Rows[i].Cells[5].Value = spline.c[i].ToString();
                dataGridView1.Rows[i].Cells[6].Value = spline.d[i].ToString();
            }
        }

        void SplineValuesTable()
        {
            double nh = h / 3;
            for(int i = 0; i < 3 * n; i++)
            {
                double Fxk = spline.F(x0 + i * nh);
                double Sxk = spline.S(x0 + i * nh);
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = i.ToString();
                dataGridView2.Rows[i].Cells[1].Value = (x0 + i * nh).ToString();
                dataGridView2.Rows[i].Cells[2].Value = Fxk.ToString();
                dataGridView2.Rows[i].Cells[3].Value = Sxk.ToString();
                dataGridView2.Rows[i].Cells[4].Value = Math.Abs(Fxk - Sxk).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = System.Convert.ToInt32(entern.Text.ToString());
            if (comboBox1.SelectedIndex == 0)
            {
                spline = new Test(n);
                spline.ConsructSpline();
                x0 = spline.x0; h = spline.h;
            }

            SplineCoefficientTable();
            SplineValuesTable();
        }
    }
}
