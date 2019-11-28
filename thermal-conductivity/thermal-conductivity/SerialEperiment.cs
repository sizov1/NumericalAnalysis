using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thermal_conductivity
{
    public partial class SerialEperiment : Form
    {
        public SerialEperiment()
        {
            InitializeComponent();
            zedGraphControl1.GraphPane.Title = "Зависимость погрешности от числа разбиений";
            zedGraphControl1.GraphPane.XAxis.Title = "число разбиений";
            zedGraphControl1.GraphPane.YAxis.Title = "|u(x) - v(x)|";
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            ZedGraph.PointPairList point_list = new ZedGraph.PointPairList();

            Form1 tmp = new Form1();
            int nmin = System.Convert.ToInt32(numericUpDown1.Value.ToString());
            int nmax = System.Convert.ToInt32(numericUpDown2.Value.ToString());
            int step = System.Convert.ToInt32(numericUpDown3.Value.ToString());
            for(int i = nmin; i < nmax; i += step)
            {
                double h = 1.0 / i;
                List<double> xi = Form1.GetGrid(h);
                List<double> xi2 = Form1.GetAuxGrid(h);
                List<double> ai = Form1.TestGetAi(h, i, xi);
                List<double> di = Form1.TestGetDi(h, xi2);
                List<double> phii = Form1.TestGetPhii(h, xi2);
                List<List<double>> matrix = Form1.GetTridiagonalMatrix(i, h, ai, di, phii);
                List<double> vi = Form1.SolveDifScheme(i, matrix);
                List<double> ui = Form1.ExactSolve(xi);
                List<double> dif = Form1.GetAbsDif(vi, ui, "test");
                point_list.Add(i, dif.Max());
            }

            zedGraphControl1.GraphPane.CurveList.Clear();
            ZedGraph.LineItem Curve1 = zedGraphControl1.GraphPane.AddCurve("", point_list, Color.FromName("Red"), ZedGraph.SymbolType.None);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
