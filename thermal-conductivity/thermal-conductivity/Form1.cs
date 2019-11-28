using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace thermal_conductivity
{
    public partial class Form1 : Form
    {
        public int n = 0;
        public const double C11 = -0.33931760352278384;
        public const double C21 = 0.33931760352278384;
        public const double C12 = 1.0560782612867763;
        public const double C22 = -0.49204180123195052;
        public static double ksi = Math.PI / 4.0, nu1 = 1.0, nu2 = 0.0, f1 = 1.0, f2 = Math.Sqrt(2) / 2.0;
        public static double k1 = 1.0, k2 = 0.5, q1 = 1.0, q2 = (Math.PI / 4.0) * (Math.PI / 4.0);

        public class IncorrectValue : Exception
        {
            public IncorrectValue(string message) : base(message)
            {
            }
        }

        public Form1()
        {
            InitializeComponent();           
            zedGraphControl2.GraphPane.Title = "Графики решений на сетке";
            zedGraphControl2.GraphPane.XAxis.Title = "x";
            zedGraphControl1.GraphPane.Title = "График погрешности на сетке";
            zedGraphControl1.GraphPane.XAxis.Title = "x";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 task = new Form2();
            task.ShowDialog();
        }

        static double TestUx(double x)
        {
            if (x < 0)
                throw (new IncorrectValue("Test: U(x) func: x < 0"));
            else if (x < ksi)
                return C11 * Math.Exp(x) + C21 * Math.Exp(-x) + 1;
            else if ((ksi < x) && (x < 1))
                return C12 * Math.Exp(-Math.PI * Math.Sqrt(2) * x / 4.0) +
                       C22 * Math.Exp(Math.PI * Math.Sqrt(2) * x / 4.0) + 
                       8 * Math.Sqrt(2) / (Math.PI * Math.PI);
            throw (new IncorrectValue("Test: U(x) func: x > 1"));
        }

        
        // Вспомогательные функции

        public static List<double> GetGrid(double h)  // создает сетку от 0 до 1 с шагом h
        {
            List<double> grid = new List<double>();
            grid.Add(0.0);
            for(int i = 0; grid[i] < 1.0; i++)
            {
                double q = (double)(i + 1);
                grid.Add(q * h);
            }
            return grid;
        }

        public static List<double> GetAuxGrid(double h)  // создает вспомогательную сетку от 0 до 1 с шагом h
        {
            List<double> grid = new List<double>();
            grid.Add(h / 2.0);
            for (int i = 0; (grid[i] + h) < 1; i++)
            {
                grid.Add((i + 1.5) * h);
            }
            return grid;
        }

        //Функции для Тестовой задачи
        public static List<double> TestGetAi(double h, int n, List<double> grid)
        {
            List<double> ai = new List<double>();
            for(int i = 0; i < n; i++)
            {
                if (grid[i + 1] < ksi)
                {
                    ai.Add(k1);
                }
                else if (grid[i + 1] > ksi && grid[i] > ksi)
                {
                    ai.Add(k2);
                }
                else if (grid[i + 1] > ksi && grid[i] < ksi)
                {
                    ai.Add(h * k1 * k2 / (ksi * (k2 - k1) + grid[i + 1] * k1 - grid[i] * k2));
                }
            }
            return ai;
        }

        public static List<double> TestGetDi(double h, List<double> grid)
        {
            List<double> di = new List<double>();
            int n = grid.Count();
            for (int i = 0; i < n - 1; i++)
            {
                if (grid[i + 1] < ksi)
                {
                    di.Add(q1);
                }
                else if (grid[i + 1] > ksi && grid[i] > ksi)
                {
                    di.Add(q2);
                }
                else if (grid[i + 1] > ksi && grid[i] < ksi)
                {
                    di.Add((ksi * (q1 - q2) + q2 * grid[i+1] - q1 * grid[i]) / h);
                }
            }
            return di;
        }

        public static List<double> TestGetPhii(double h, List<double> grid)
        {
            List<double> phii = new List<double>();
            int n = grid.Count();
            for (int i = 0; i < n - 1; i++)
            {
                if (grid[i + 1] < ksi)
                {
                    phii.Add(f1);
                }
                else if (grid[i + 1] > ksi && grid[i] > ksi)
                {
                    phii.Add(f2);
                }
                else if (grid[i + 1] > ksi && grid[i] < ksi)
                {
                    phii.Add((ksi * (f1 - f2) + f2 * grid[i + 1] - f1 * grid[i]) / h);
                }
            }
            return phii;
        }

        public static List<double> ExactSolve(List<double> xi) // функций вычисляет точное значение функции в узлах сетки
        {
            List<double> ui = new List<double>();
            int n = xi.Count();
            ui.Add(1.0);
            for (int i = 1; i < n - 1; i++)
            {
                ui.Add(TestUx(xi[i]));
            }
            ui.Add(0.0);
            return ui;
        }

        //Функции для Основной задачи
        List<double> MainGetAi(double h, int n, List<double> grid)
        {
            List<double> ai = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double xi = grid[i], xi1 = grid[i + 1];
                if (xi1 < ksi)
                {
                    double integ = Math.Log(Math.Sin((xi1 + 1.1) / 2.0)) - Math.Log(Math.Cos((xi1 + 1.1) / 2.0))
                                   - Math.Log(Math.Sin((xi + 1.1) / 2.0)) + Math.Log(Math.Cos((xi + 1.1) / 2.0));  // значение интеграла
                    ai.Add(h * Math.Sqrt(2) / integ);
                }
                else if (xi1 > ksi && xi > ksi)
                {
                    double integ = Math.Tan(xi1) - Math.Tan(xi);
                    ai.Add(h / integ);
                }
                else if (xi1 > ksi && xi < ksi)
                {
                    double integ1 = (Math.Log(Math.Sin((ksi + 1.1) / 2.0)) - Math.Log(Math.Cos((ksi + 1.1) / 2.0))
                                   - Math.Log(Math.Sin((xi + 1.1) / 2.0)) + Math.Log(Math.Cos((xi + 1.1) / 2.0))) / Math.Sqrt(2);
                    double integ2 = Math.Tan(xi1) - Math.Tan(ksi);
                    ai.Add(h / (integ1 + integ2));
                }
            }
            return ai;
        }

        List<double> MainGetDi(double h, List<double> grid)
        {
            List<double> di = new List<double>();
            int n = grid.Count();
            for (int i = 0; i < n - 1; i++)
            {
                double xi = grid[i], xi1 = grid[i + 1];
                if (xi1 < ksi)
                {
                    di.Add(1.0);
                }
                else if (xi1 > ksi && xi > ksi)
                {
                    di.Add((xi1*xi1*xi1 - xi*xi*xi) / (3.0 * h));
                }
                else if (xi1 > ksi && xi < ksi)
                {
                    di.Add((ksi - xi + ((xi1 * xi1 * xi1 - ksi * ksi * ksi) / 3.0)) / h);
                }
            }
            return di;
        }

        List<double> MainGetPhii(double h, List<double> grid)
        {
            List<double> phii = new List<double>();
            int n = grid.Count();
            for (int i = 0; i < n - 1; i++)
            {
                double xi = grid[i], xi1 = grid[i + 1];
                if (xi1 < ksi)
                {
                    phii.Add(-(Math.Cos(2 * xi1) - Math.Cos(2 * xi)) / (2.0 * h));
                }
                else if (xi1 > ksi && xi > ksi)
                {
                    phii.Add((Math.Sin(xi1) - Math.Sin(xi)) / h);
                }
                else if (xi1 > ksi && xi < ksi)
                {
                    phii.Add(((-Math.Cos(2 * ksi) + Math.Cos(2 * xi)) / 2.0 + Math.Sin(xi1) - Math.Sin(ksi)) / h);
                }
            }
            return phii;
        }

        // Функции реализации метода баланса

        public static List<List<double>> GetTridiagonalMatrix(int n, double h, List<double> ai, List<double> di, List<double> phii)  // функция возращает 3ех диагональную матрицу (в самый правый столбец записан вектор b)
        {
            List<List<double>> m = new List<List<double>>();
            m.Add(new List<double>(4) { 1.0, 0.0, 0.0, 1.0});
            for (int i = 1; i < n; i++)
            {
                List<double> rowi = new List<double>(4) { ai[i - 1] / (h * h), - (((ai[i - 1] + ai[i]) / (h * h)) + di[i - 1]), ai[i] / (h * h), -phii[i - 1]};
                m.Add(rowi);
            }
            return m;
        }

        public static List<double> SolveDifScheme(int n, List<List<double>> mt)  // функция решает СЛАУ методом прогонки, все именна переменных как в лекциях
        {
            
            //прамой ход прогонки
            List<double> alphai = new List<double>();
            List<double> betai = new List<double>();
            alphai.Add(mt[0][1]); betai.Add(mt[0][3]);
            for (int i = 1; i < n; i++)
            {
                double Ai = mt[i][0], Ci = mt[i][1], Bi = mt[i][2], Phii = mt[i][3];
                alphai.Add(-Bi / (Ci + alphai[i - 1] * Ai));
                betai.Add((Phii - Ai * betai[i - 1]) / (Ci + alphai[i - 1] * Ai));
            }

            double[] vi = new double[n + 1];
            //обратный ход прогонки
            vi[n] = 0.0;  // т.к в силу нач. условий vn = 0
            for (int i = n - 1; i > 0; i--)
            {
                vi[i] = alphai[i] * vi[i + 1] + betai[i];
            }
            vi[0] = 1.0;

            List<double> Vi = vi.OfType<double>().ToList();
            return Vi;
        }

        public static List<double> GetAbsDif(List<double> a, List<double> b, string task)  // функция считает максимальную по модулю разницу между двумя "веткорами"
        {
            List<double> eps = new List<double>();
            int n = a.Count();
            int m = task == "test" ? 1 : 2;  // в случае основной задачи нужно перепрыгивать значения от половинного шага
            for (int i = 0; i < n; i++)
            {
                eps.Add(Math.Abs(b[i * m] - a[i]));
            }
            return eps;
        } 

        //Функции для работы с графиками 

        void DrawSolve(List<double> xi, List<double> ui, List<double> vi, string task)
        {
            ZedGraph.PointPairList v_list = new ZedGraph.PointPairList();
            ZedGraph.PointPairList u_list = new ZedGraph.PointPairList();

            int m = task == "test" ? 1 : 2;  // в случае основной задачи нужно перепрыгивать значения от половинного шага

            int n = xi.Count();
            for(int i = 0; i < n; i++)
            {
                v_list.Add(xi[i], vi[i]);
                u_list.Add(xi[i], ui[i * m]);
            }

          
            zedGraphControl2.GraphPane.XAxis.Min = -0.1;
            zedGraphControl2.GraphPane.XAxis.Max = 1.0;

            zedGraphControl2.GraphPane.CurveList.Clear();
            if (task == "test")
            {
                ZedGraph.LineItem CurveV = zedGraphControl2.GraphPane.AddCurve("num solve", v_list, Color.FromName("Blue"), ZedGraph.SymbolType.None);
                ZedGraph.LineItem CurveU = zedGraphControl2.GraphPane.AddCurve("exact solve", u_list, Color.FromName("Red"), ZedGraph.SymbolType.None);
                zedGraphControl2.GraphPane.YAxis.Title = "u(x), v(x)";
            }
            else if (task == "main")
            {
                zedGraphControl2.GraphPane.YAxis.Title = "v(x), v2(x)";
                ZedGraph.LineItem CurveV = zedGraphControl2.GraphPane.AddCurve("v(x)", v_list, Color.FromName("Blue"), ZedGraph.SymbolType.None);
                ZedGraph.LineItem CurveU = zedGraphControl2.GraphPane.AddCurve("v2(x)", u_list, Color.FromName("Red"), ZedGraph.SymbolType.None);
            }

            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }

        void DrawError(List<double> xi, List<double> dif, string task)
        {
            ZedGraph.PointPairList err_list = new ZedGraph.PointPairList();
            
            int n = xi.Count();

            for (int i = 1; i < n; i++)
            {
                err_list.Add(xi[i], dif[i]);
            }

            zedGraphControl1.GraphPane.XAxis.Min = -0.1;
            zedGraphControl1.GraphPane.XAxis.Max = 1.0;

            zedGraphControl1.GraphPane.CurveList.Clear();
            ZedGraph.LineItem CurveV = zedGraphControl1.GraphPane.AddCurve("error in scheme`s values", err_list, Color.FromName("Green"), ZedGraph.SymbolType.None);

            if (task == "test")
                zedGraphControl1.GraphPane.YAxis.Title = "|u(x) - v(x)|";
            else if (task == "main")
                zedGraphControl1.GraphPane.YAxis.Title = "|v(x) - v2(x)|";

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        //Функции для работы с таблицей

        void InitTable(int n, List<double> xi, List<double> vi, List<double> ui, List<double> dif, string task)
        {
            int m = 1;
            if (task == "test")
            {
                Column3.HeaderText = "v(xi)";
                Column4.HeaderText = "u(xi)";
                Column5.HeaderText = "|u(xi) - v(xi)|";
            }
            else if (task == "main")
            {
                Column3.HeaderText = "v(xi)";
                Column4.HeaderText = "v2(x2i)";
                Column5.HeaderText = "|v(xi) - v2(x2i)|";
                m = 2;
            }
            int aj = n / 1000 + 1;
            for (int j = 0, i = 0; j < n; j += aj, i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = j;
                dataGridView1.Rows[i].Cells[1].Value = xi[j];
                dataGridView1.Rows[i].Cells[2].Value = vi[j];
                dataGridView1.Rows[i].Cells[3].Value = ui[j * m];
                dataGridView1.Rows[i].Cells[4].Value = dif[j];
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {  
            n = System.Convert.ToInt32(numericUpDown1.Value.ToString());
            double h = 1.0 / n;
            List<double> xi = GetGrid(h);
            List<double> xi2 = GetAuxGrid(h);
            List<double> ai = TestGetAi(h, n, xi);
            List<double> di = TestGetDi(h, xi2);
            List<double> phii = TestGetPhii(h, xi2);
            List<List<double>> matrix = GetTridiagonalMatrix(n, h, ai, di, phii);
            List<double> vi = SolveDifScheme(n, matrix);
            List<double> ui = ExactSolve(xi);
            List<double> dif = GetAbsDif(vi, ui, "test");
            double eps1 = dif.Max();

            dataGridView1.Rows.Clear();
            InitTable(n, xi, vi, ui, dif, "test");
            DrawSolve(xi, ui, vi, "test");
            DrawError(xi, dif, "test");

            label_ntest.Text = n.ToString();
            label_epstest.Text = eps1.ToString();
            label_xepstest.Text = xi[dif.IndexOf(eps1)].ToString(); 
        }

        
        private void Button2_Click(object sender, EventArgs e)
        {
            n = System.Convert.ToInt32(numericUpDown1.Value.ToString());
            double h = 1.0 / n;
            List<double> xi = GetGrid(h);
            List<double> xi2 = GetAuxGrid(h);
            List<double> ai = MainGetAi(h, n, xi);
            List<double> di = MainGetDi(h, xi2);
            List<double> phii =  MainGetPhii(h, xi2);
            List<List<double>> matrix = GetTridiagonalMatrix(n, h, ai, di, phii);
            List<double> vi = SolveDifScheme(n, matrix);

            int n2 = n * 2;
            double h2 = 1.0 / n2;
            List<double> x2i = GetGrid(h2);
            List<double> x2i2 = GetAuxGrid(h2);
            List<double> ai2 = MainGetAi(h2, n2, x2i);
            List<double> di2 = MainGetDi(h2, x2i2);
            List<double> phii2 = MainGetPhii(h2, x2i2);
            List<List<double>> matrix2 = GetTridiagonalMatrix(n2, h2, ai2, di2, phii2);
            List<double> v2i = SolveDifScheme(n2, matrix2);

            List<double> dif = GetAbsDif(vi, v2i, "main");
            double eps1 = dif.Max();

            dataGridView1.Rows.Clear();
            InitTable(n, xi, vi, v2i, dif, "main");
            DrawSolve(xi, v2i, vi, "main");
            DrawError(xi, dif, "main");

            label_nmain.Text = n.ToString();
            label_epsmain.Text = eps1.ToString();
            label_xepsmain.Text = xi[dif.IndexOf(eps1)].ToString();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SerialEperiment se = new SerialEperiment();
            se.Show();
        }
    }
}
