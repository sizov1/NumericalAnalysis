using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Spline
{
    public partial class Form1 : Form
    {
        Info inf = new Info();
        int n, N;
        Spline spline;
        double x0, xn, h, hN; 

        public Form1()
        {
            InitializeComponent();
            zedGraphFS.GraphPane.Title = "Графики функции и сплайна";
            zedGraphdFdS.GraphPane.Title = "Графики проиводных";
            zedGraphError.GraphPane.Title = "График погрешности сплайна";
            zedGraphdError.GraphPane.Title = "График погрешности производных";
            zedGraphFS.GraphPane.XAxis.Title = "x";
            zedGraphdFdS.GraphPane.XAxis.Title = "x";
            zedGraphError.GraphPane.XAxis.Title = "x";
            zedGraphdError.GraphPane.XAxis.Title = "x";
            zedGraphFS.GraphPane.YAxis.Title = "F(x), S(x)";
            zedGraphdFdS.GraphPane.YAxis.Title = "F'(x), S'(x)";
            zedGraphError.GraphPane.YAxis.Title = "F(x) - S(x)";
            zedGraphdError.GraphPane.YAxis.Title = "F'(x) - S'(x)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormInfo fi = new FormInfo();
            fi.DisplayInfo(inf);
            fi.Show();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            n = System.Convert.ToInt32(entern.Text.ToString());
            N = 3 * n;
            inf.InitInfo(n, N);
            if (comboBox1.SelectedIndex == 0)
            {
                spline = new Test(n);
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                spline = new Main(n);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                spline = new Osscilate(n);
            }
            spline.ConsructSpline();
            x0 = spline.x0; xn = spline.xn;
            h = spline.h; hN = h / 3;
            SplineCoefficientTable();
            SplineValuesTable();
            CalcErrorsSpline();
            DrawGraphics();
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

        void CalcErrorsSpline()
        {
            for (int i = 0; i < N; i++)
            {
                double xk = x0 + i * hN;
                double e = Math.Abs(spline.F(xk) - spline.S(xk));
                double de = Math.Abs(spline.dF(xk) - spline.dS(xk)); ;
                double d2e = Math.Abs(spline.d2F(xk) - spline.d2S(xk));
         
                if (inf.e < e) {
                    inf.e = e;
                    inf.xe = xk;
                }
                if (inf.de < de) {
                    inf.de = de;
                    inf.xde = xk;
                }
                if (inf.d2e < d2e) {
                    inf.d2e = d2e;
                    inf.xd2e = xk;
                }
            }
        }

        void DrawGraphics()
        {
            ZedGraph.PointPairList FkList = new ZedGraph.PointPairList();
            ZedGraph.PointPairList SkList = new ZedGraph.PointPairList();
            ZedGraph.PointPairList dFkList = new ZedGraph.PointPairList();
            ZedGraph.PointPairList dSkList = new ZedGraph.PointPairList();
            ZedGraph.PointPairList eList = new ZedGraph.PointPairList();
            ZedGraph.PointPairList deList = new ZedGraph.PointPairList();

            for (int i = 0; i < N; i++)
            {
                if (i % 3 == 0)
                    continue;
                double xk = x0 + i * hN;
                double Fk = spline.F(xk);
                double Sk = spline.S(xk);
                double dFk = spline.dF(xk);
                double dSk = spline.dS(xk);
                double e = Fk - Sk;
                double de = dFk - dSk;
                FkList.Add(xk, Fk);
                SkList.Add(xk, Sk);
                dFkList.Add(xk, dFk);
                dSkList.Add(xk, dSk);
                eList.Add(xk, e);
                deList.Add(xk, de);
            }

            zedGraphFS.GraphPane.XAxis.Min = x0;
            zedGraphFS.GraphPane.XAxis.Max = xn;
            zedGraphdFdS.GraphPane.XAxis.Min = x0;
            zedGraphdFdS.GraphPane.XAxis.Max = xn;
            zedGraphError.GraphPane.XAxis.Min = x0;
            zedGraphError.GraphPane.XAxis.Max = xn;
            zedGraphdError.GraphPane.XAxis.Min = x0;
            zedGraphdError.GraphPane.XAxis.Max = xn;

            zedGraphFS.GraphPane.CurveList.Clear();
            zedGraphdFdS.GraphPane.CurveList.Clear();
            zedGraphError.GraphPane.CurveList.Clear();
            zedGraphdError.GraphPane.CurveList.Clear();

            zedGraphFS.GraphPane.AddCurve("F(x)", FkList, Color.FromName("Blue"), ZedGraph.SymbolType.None);
            zedGraphFS.GraphPane.AddCurve("S(x)", SkList, Color.FromName("Red"), ZedGraph.SymbolType.None);
            zedGraphdFdS.GraphPane.AddCurve("F'(x)", dFkList, Color.FromName("Blue"), ZedGraph.SymbolType.None);
            zedGraphdFdS.GraphPane.AddCurve("S'(x)", dSkList, Color.FromName("Red"), ZedGraph.SymbolType.None);
            ZedGraph.LineItem eCurve = zedGraphError.GraphPane.AddCurve("F(x) - S(x)", eList, Color.FromName("Blue"), ZedGraph.SymbolType.None);
            ZedGraph.LineItem deCurve = zedGraphdError.GraphPane.AddCurve("F'(x) - S'(x)", deList, Color.FromName("Blue"), ZedGraph.SymbolType.None);

//            eCurve.Line.IsVisible = false;
//            deCurve.Line.IsVisible = false;

            zedGraphFS.AxisChange();
            zedGraphdFdS.AxisChange();
            zedGraphError.AxisChange();
            zedGraphdError.AxisChange();

            zedGraphFS.Invalidate();
            zedGraphdFdS.Invalidate();
            zedGraphError.Invalidate();
            zedGraphdError.Invalidate();
        }
        void SplineValuesTable()
        {
            for (int i = 0; i < N; i++)
            {
                double xk = x0 + i * hN;
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
    }
}
