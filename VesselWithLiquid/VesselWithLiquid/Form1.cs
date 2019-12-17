using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VesselWithLiquid
{
    public partial class Form1 : Form
    {
        List<List<double>> data = new List<List<double>>();
        OutputData calcInfo = new OutputData();
        double xmax, alpha, sigma, constCoeff;
        const double g = 1.0;
        int nRows, countCurves = 0;

        List<Color> colors = new List<Color>();


        public Form1()
        {
            InitializeComponent();
            graph.GraphPane.XAxis.Title = "Время";
            graph.GraphPane.YAxis.Title = "Высота жидкости";
            graph.GraphPane.Title = "График решения уравнения";
            colors.Add(Color.FromName("Blue")); colors.Add(Color.FromName("BlueViolet"));
            colors.Add(Color.FromName("Red")); colors.Add(Color.FromName("DarkRed"));
            colors.Add(Color.FromName("Green")); colors.Add(Color.FromName("Violet"));
            colors.Add(Color.FromName("Thistle")); colors.Add(Color.FromName("Tomato"));
            colors.Add(Color.FromName("Salmon")); colors.Add(Color.FromName("Sienna"));
            colors.Add(Color.FromName("Yellow")); colors.Add(Color.FromName("Wheat"));
            colors.Add(Color.FromName("RoyalBlue")); colors.Add(Color.FromName("SaddleBrown"));
            colors.Add(Color.FromName("Pink")); colors.Add(Color.FromName("Moccasin"));
            colors.Add(Color.FromName("Lime")); colors.Add(Color.FromName("MediumBlue"));
            colors.Add(Color.FromName("DarkTurquoise")); colors.Add(Color.FromName("DarkViolet"));
            colors.Add(Color.FromName("Chocolate")); colors.Add(Color.FromName("CadetBlue"));
            colors.Add(Color.FromName("Coral")); colors.Add(Color.FromName("Crimson"));
            colors.Add(Color.FromName("Brown")); colors.Add(Color.FromName("Aquamarine"));
            colors.Add(Color.FromName("Azure")); colors.Add(Color.FromName("YellowGreen"));
            colors.Add(Color.FromName("Black")); colors.Add(Color.FromName("PapayaWhip"));
        }

        void InitConstCoeff()
        {
            double den = Math.PI * (Math.Tan(alpha / 2.0)) * (Math.Tan(alpha / 2.0));
            double num = sigma * Math.Sqrt(2.0 * g);
            constCoeff = num / den;
        }

        double ExactSolve(double x, double u0) { return Math.Pow( (-1.5 * constCoeff * x + Math.Pow(u0, 5.0/2.0) ), 2.0 / 5.0); }
          

        private void Button2_Click(object sender, EventArgs e)
        {
            FInfo q = new FInfo();
            q.Show();
        }

        private double twon(int n) { return (2 << (n + 1)); }

        private void Button1_Click(object sender, EventArgs e)
        {
            double u0 = System.Convert.ToDouble(su0.Text);
            double h = System.Convert.ToDouble(sh.Text);
            int N = System.Convert.ToInt32(sN.Text);
            alpha = System.Convert.ToDouble(salpha.Text);
            sigma = System.Convert.ToDouble(ssigma.Text);
            InitConstCoeff();
            Solve(u0, h, N);
        }

        double f(double x, double u) { return -0.6*constCoeff / (Math.Pow(u, 3.0/2.0)); }

        double GetNextValue(double x, double v, double h)
        {
            double k1 = f(x, v);
            double k2 = f(x + h / 2.0, v + k1 * (h / 2.0));
            double k3 = f(x + h / 2.0, v + k2 * (h / 2.0));
            double k4 = f(x + h, v + h * k3);
            return v + (h / 6.0) * (k1 + 2.0 * k2 + 2.0 * k3 + k4);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            graph.GraphPane.CurveList.Clear();
            countCurves = 0;
            graph.AxisChange();
            graph.Invalidate();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            FAnalysis analysForm = new FAnalysis();
            analysForm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FTable tableForm = new FTable();
            tableForm.InitTable(ref data, nRows / 5, 10);
            tableForm.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            FInfoSolve infForm = new FInfoSolve();
            infForm.InitInfo(calcInfo);
            infForm.Show();
        }

        void Solve(double u0, double h, double N)
        {
            data = new List<List<double>>();
            ZedGraph.PointPairList f1_list = new ZedGraph.PointPairList();
            ZedGraph.PointPairList f2_list = new ZedGraph.PointPairList();

            int i = 0, C1 = 0, C2 = 0;
            double x, v2, S, lte, u, v = u0, vprev = v;
            double eps = System.Convert.ToDouble(seps.Text);
            double b = System.Convert.ToDouble(sb.Text);
            xmax = System.Convert.ToDouble(sxmax.Text);

            List<double> lteList = new List<double>();
            List<double> gteList = new List<double>();
            List<double> hList = new List<double>();
            List<double> xList = new List<double>();

            for (x = 0.0; Math.Abs(x - xmax) > b && i < N;)
            {
                v = GetNextValue(x, vprev, h);
                vprev = v;
                v2 = GetNextValue(x, vprev, h / 2.0);
                v2 = GetNextValue(x + (h / 2.0), v2, h / 2.0);
                x += h;
                S = (v2 - v) / (twon(4) - 1.0);
                lte = S * twon(4);

                if (v < 0) break;

                lteList.Add(lte);
                hList.Add(h);
                xList.Add(x);

                if (Math.Abs(S) > eps)
                {
                    x -= h;
                    h /= 2;
                    C1++;
                    continue;
                }
                else if (Math.Abs(S) < (eps / twon(5)))
                {
                    vprev = v;
                    h *= 2;
                    C2++;
                }
                else vprev = v;

                u = ExactSolve(x, u0);
                gteList.Add(Math.Abs(u - v));

                f1_list.Add(x, v);
                f2_list.Add(x, u);

                List<double> tablerow = new List<double>(10) { x, v, v2, v - v2, lte, h, C1, C2, u, Math.Abs(u - v) };
                data.Add(tablerow);
                i++;
            }

            Draw(ref f1_list, xmax);
            Draw(ref f2_list, xmax);

            double maxGte = gteList.Max(), hmax = hList.Max(), hmin = hList.Min();
            double xhmax = xList[hList.IndexOf(hmax)], xhmin = xList[hList.IndexOf(hmin)];
            nRows = i;
            calcInfo.InitData(i, xmax - x, lteList.Max(), C1, C2, hmax, xhmax, hmin, xhmin, maxGte, data[gteList.IndexOf(maxGte)][0], x, v);
        }

        void Draw(ref ZedGraph.PointPairList f_list, double xmax = 1.0)  // построение графиков
        {
            if (countCurves == 15)
            {
                graph.GraphPane.CurveList.Clear();
                countCurves = 0;
            }

            string name;
            if (countCurves % 2 == 0) name = "exact" + (countCurves / 2).ToString();
            else name = "num" + (countCurves / 2).ToString();
            
            ZedGraph.GraphPane panel = graph.GraphPane;
            ZedGraph.LineItem Curve = panel.AddCurve(name, f_list, colors[countCurves], ZedGraph.SymbolType.None);
            if (countCurves == 0)
            {
                panel.XAxis.Min = -0.1;
                panel.XAxis.Max = xmax + 0.1;
                panel.YAxis.Min = -1;
            }
            countCurves++;
            graph.AxisChange();
            graph.Invalidate();
        }
    }
}
