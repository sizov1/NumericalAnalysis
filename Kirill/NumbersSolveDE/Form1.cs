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
        const int number_rows = 1000; // количество строк в таблице
        OutputData calcInfo = new OutputData();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 q = new Form2();
            q.InitInfo(calcInfo);
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
                CalcWithControl(u0, xmax, N, h);
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

            // добавляем начальную точку на график
            f1_list.Add(0, u0);

            
            double v = u0;
            List<List<double>> table = new List<List<double>>();
            List<double> lteList = new List<double>();
            List<double> gteList = new List<double>();

            int i = 0; double x = 0.0;
            for (x = 0.0; x < xmax && i < N;)
            {
                // вычисляем следующие значение численной траектории
                v = get_next_value(x, v, h);

                // вычисляем значение численной траектории с помощью двойного счета с половинным шагом
                double v2 = get_next_value(x, v, h / 2.0);
                v2 = get_next_value(x + (h / 2.0), v2, h / 2.0);
                x += h;

                // считаем ОЛП
                double twop = twon(4);
                double lte = ((v2 - v) / (twop - 1.0)) * twop;
                lteList.Add(lte);

                // вычисляем значение точного решения
                double u = u0 * Math.Exp((-5.0 / 2.0) * x);
                gteList.Add(Math.Abs(u - v));

                // добавляем точки точного и численного решения на график 
                f1_list.Add(x, v);
                f2_list.Add(x, u);

                List<double> tablerow = new List<double> { x, v, v2, v - v2, lte, h, 0, 0, u, Math.Abs(u - v) };
                table.Add(tablerow);

                i++;
            }

            // строим графики численного и точного решения 
            zedGraph.GraphPane.CurveList.Clear();
            Draw(ref f1_list, "num", Color.FromName("Blue"), xmax);
            Draw(ref f2_list, "exact", Color.FromName("Red"), xmax);

            // заполняем таблицу 
            InitTable(ref table, i / 5, 10);

            double maxGte = gteList.Max();
            calcInfo.InitData(i, xmax - x, lteList.Max(), 0, 0, h, 0, h, 0, maxGte, table[gteList.IndexOf(maxGte)][0]);
        }

        void CalcWithControl(double u0, double xmax, int N, double h)
        {
            ZedGraph.PointPairList f1_list = new ZedGraph.PointPairList();
            ZedGraph.PointPairList f2_list = new ZedGraph.PointPairList();

            f1_list.Add(0, u0);

            int i = 0, C1 = 0, C2 = 0;
            double x, v = u0, vpre = v, eps = System.Convert.ToDouble(seps.Text);
            List<List<double>> table = new List<List<double>>();
            List<double> lteList = new List<double>();
            List<double> gteList = new List<double>();

            for (x = 0.0; x < xmax && i < N;)
            {
                v = get_next_value(x, vpre, h);
                double v2 = get_next_value(x, v, h / 2.0);
                v2 = get_next_value(x + (h / 2.0), v2, h / 2.0);
                x += h;
                double S = ((v2 - v) / (twon(4) - 1.0));
                double lte = S * twon(4);
                lteList.Add(lte);

                if (Math.Abs(S) > eps) {
                    x -= h;
                    h /= 2;
                    C1++;
                    continue;
                } else if (Math.Abs(S) < (eps / twon(5))) {
                    vpre = v;
                    h *= 2;
                    C2++;
                } else {
                    vpre = v;
                }

                double u = u0 * Math.Exp((-5.0 / 2.0) * x);
                gteList.Add(Math.Abs(u - v));

                f1_list.Add(x, v);
                f2_list.Add(x, u);

                List<double> tablerow = new List<double>(10){ x, v, v2, v - v2, lte, h, C1, C2, u, Math.Abs(u - v)};
                table.Add(tablerow);

                i++;
            }

            zedGraph.GraphPane.CurveList.Clear();
            Draw(ref f1_list, "num", Color.FromName("Blue"), xmax);
            Draw(ref f2_list, "exact", Color.FromName("Red"), xmax);

            InitTable(ref table, i / 5, 10);

            double maxGte = gteList.Max();
            calcInfo.InitData(i, xmax - x, lteList.Max(), 0, 0, h, 0, h, 0, maxGte, table[gteList.IndexOf(maxGte)][0]);
        }

        void Draw(ref ZedGraph.PointPairList f_list, string name, Color clr, double xmax = 1.0)  // построение графиков
        {
            ZedGraph.GraphPane panel = zedGraph.GraphPane;
            ZedGraph.LineItem Curve = panel.AddCurve(name, f_list, clr, ZedGraph.SymbolType.None);
            panel.XAxis.Min = -0.1;
            panel.XAxis.Max = xmax + 0.1;
            panel.YAxis.Min = -1;
            zedGraph.AxisChange();
            zedGraph.Invalidate();
        }

        void InitTable(ref List<List<double>> data, int number_rows, int number_columns)  // функция заполняет таблицу 
        {
            dataGridView1.Rows.Clear();
            for (int j = 0; j < number_rows; j++)
            {
                dataGridView1.Rows.Add();
                for (int k = 0; k < number_columns; k++)
                {
                    dataGridView1.Rows[j].Cells[k].Value = data[j][k];
                }
            }
        }

    }

    
}