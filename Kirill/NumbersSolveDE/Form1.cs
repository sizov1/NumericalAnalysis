using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NumbersSolveDE
{
    public partial class Form1 : Form
    {

        const double eqdiff = 1e-15;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 q = new Form2();
            q.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double u0 = System.Convert.ToDouble(su0.Text);
            double xmax = System.Convert.ToDouble(sxmax.Text);
            double h = System.Convert.ToDouble(sh.Text);
            int N = System.Convert.ToInt32(sN.Text);
            if (radioButton1.Checked) {
                CalcWithoutControl(u0, xmax, N, h);
            } else {
              //  CalcWithControl(u0, xmax, N, h);
            }
        }

        double f(double x, double v) { return (-5.0 / 2.0) * v; }

        double twon(int n) { return (double)(2 << (n - 1)); }

        double get_next_value(double x, double v, double h)
        {
            double k1 = f(x, v);
            double k2 = f(x + h / 2, v + k1 * (h / 2));
            double k3 = f(x + h / 2, v + k2 * (h / 2));
            double k4 = f(x + h, v + h * k3);
            return v + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
        }

        void CalcWithoutControl(double u0, double xmax, int N,double h)
        {
            ZedGraph.PointPairList f1_list = new ZedGraph.PointPairList();
            ZedGraph.PointPairList f2_list = new ZedGraph.PointPairList();

            dataGridView1.Rows.Clear();
            // добавляем начальную точку на график
            f1_list.Add(0, u0);

            int i = 0;
            double v = u0;
            List<List<double>> table = new List<List<double>>();

            for (double x = 0.0; x < xmax && i < N; x += h)
            {

                // вычисляем следующие значение численной траектории
                v = get_next_value(x, v, h);

                // вычисляем значение численной траектории с помощью двойного счета с половинным шагом
                double v2 = get_next_value(x, v, h / 2.0);
                v2 = get_next_value(x + h / 2.0, v2, h / 2.0);

                // считаем ОЛП
                double sp = twon(4);
                double lte = ((v2 - v) / (sp - 1.0)) * sp;

                // вычисляем значение точного решения
                double u = u0 * Math.Exp( (-5.0/2.0) * (x + h) );

                // добавляем точки точного и численного решения на график 
                f1_list.Add(x + h, v);
                f2_list.Add(x + h, u);

                List<double> tablerow = new List<double>(10);
                tablerow.Add(x + h); tablerow.Add(v); tablerow.Add(v2);
                tablerow.Add(v - v2); tablerow.Add(lte); tablerow.Add(h);
                tablerow.Add(0); tablerow.Add(0); tablerow.Add(u);
                tablerow.Add(Math.Abs(u - v));
                table.Add(tablerow);

                i++;
            }

            ZedGraph.GraphPane panel = zedGraph.GraphPane;
            panel.CurveList.Clear();
            ZedGraph.LineItem Curve1 = panel.AddCurve("num", f1_list, Color.FromName("Red"), ZedGraph.SymbolType.None);
            ZedGraph.LineItem Curve2 = panel.AddCurve("exact", f2_list, Color.FromName("Blue"), ZedGraph.SymbolType.None);

            panel.XAxis.Min = -0.1;
            panel.XAxis.Max = xmax + 0.1;
            panel.YAxis.Min = -1;

            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }
    }

    
}