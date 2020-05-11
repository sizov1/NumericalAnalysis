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
            double nh = h / 4;
            for(int i = 0; i < 4 * n; i++)
            {
                double xk = x0 + i * nh;
                double Fxk = spline.F(xk);
                double Sxk = spline.S(xk);
                double dFxk = spline.dF(xk);
                double dSxk = spline.dS(xk);
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells[0].Value = i.ToString();
                dataGridView2.Rows[i].Cells[1].Value = xk.ToString();
                dataGridView2.Rows[i].Cells[2].Value = Fxk.ToString();
                dataGridView2.Rows[i].Cells[3].Value = Sxk.ToString();
                dataGridView2.Rows[i].Cells[4].Value = Math.Abs(Fxk - Sxk).ToString("E");
                dataGridView2.Rows[i].Cells[5].Value = dFxk.ToString();
                dataGridView2.Rows[i].Cells[6].Value = dSxk.ToString();
                dataGridView2.Rows[i].Cells[7].Value = Math.Abs(dFxk - dSxk).ToString("E");
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
