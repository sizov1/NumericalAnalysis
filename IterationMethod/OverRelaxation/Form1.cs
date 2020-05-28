using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverRelaxation
{
    public partial class Form1 : Form
    {
        bool istest = true, isrectangle = true;
        double eps, w, h, t;
        int nmax, n, m;
        byte initApprx;
        double a = -1.0, b = 0.0, c = 0.0, d = 1.0;
        DirichletTask task, task2;
        public Form1() {
            InitializeComponent();
        }

        void InitMethodParameters() {
            eps = Convert.ToDouble(str_eps.Text);
            nmax = Convert.ToInt32(str_nmax.Text);
            n = Convert.ToInt32(str_n.Text);
            m = Convert.ToInt32(str_m.Text);
            w = -1.0;
            if (userValue.Checked) {
                w = Convert.ToDouble(str_w.Text);
            }

            initApprx = 3;
            if (is_inter_x.Checked) {
                initApprx = 1;
            } else if (is_inter_y.Checked) {
                initApprx = 2;
            }

            h = (b - a) / n;
            t = (d - c) / m;
        }

        void AddColumn(String name, String headerText) {
            DataGridViewTextBoxColumn column;
            column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.HeaderText = headerText;
            column.Width = 50;
            dataGridView1.Columns.Add(column);
        }

        void ConstructTable(ref int nColumns, ref int nRows) {
            dataGridView1.Rows.Clear();  // удаление всех строк
            int count = dataGridView1.Columns.Count;
            for (int i = 0; i < count; i++)     // цикл удаления всех столбцов
            {
                dataGridView1.Columns.RemoveAt(0);
            }
            AddColumn("j", " ");
            AddColumn("i", "i");

            dataGridView1.Columns["j"].Frozen = true;
            dataGridView1.Columns["i"].Frozen = true;

            int stepX = ((nRows - 2) / 30) + 1;
            int stepY = ((nColumns - 3) / 30) + 1;
            for (int i = 0; i < nColumns - 2; i += stepX) {
                AddColumn(i.ToString(), i.ToString());
            }

            dataGridView1.Rows.Add();
            for (int j = 0, i = 0; j < nRows - 1; j += stepY, i++) {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i + 1].Cells[0].Value = j.ToString();
            }

            dataGridView1.Rows[0].Cells[0].Value = 'j';
            dataGridView1.Rows[0].Cells[1].Value = "Y / X";
            dataGridView1.Rows[0].Frozen = true;
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightPink;
            dataGridView1.Rows[0].Cells[0].Style.BackColor = Color.LightGray;
            dataGridView1.Rows[0].Cells[1].Style.BackColor = Color.LightGray;
            dataGridView1.Columns["j"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.Columns["i"].DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightPink;
            dataGridView1.Columns[0].HeaderCell.Style.BackColor = Color.DarkGray;
            dataGridView1.Columns[1].HeaderCell.Style.BackColor = Color.DarkGray;
            dataGridView1.EnableHeadersVisualStyles = false;

            for (int i = 2; i < dataGridView1.ColumnCount; i++) {
                dataGridView1.Rows[1].Cells[i].Style.BackColor = Color.LightGreen;
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[i].Style.BackColor = Color.LightGreen;
            }

            for (int i = 1; i < dataGridView1.Rows.Count - 1; i++) {
                dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.LightGreen;
                dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Style.BackColor = Color.LightGreen;
            }


            nRows = dataGridView1.RowCount;
            nColumns = dataGridView1.ColumnCount;
        }
        void DrawTableForRectangleWithHole() {
            int nr = dataGridView1.RowCount - 1;
            int nc = dataGridView1.ColumnCount;
            for (int i = nr / 4 + 1; i < 3 * nr / 4 + 1; i++) {
                dataGridView1.Rows[i].Cells[nc / 4 + 2].Style.BackColor = Color.LightGreen;
                dataGridView1.Rows[i].Cells[3 * nc / 4].Style.BackColor = Color.LightGreen;
            }

            for (int i = nc / 4 + 2; i < 3 * nc / 4 + 1; i++) {
                dataGridView1.Rows[nr / 4 + 1].Cells[i].Style.BackColor = Color.LightGreen;
                dataGridView1.Rows[3 * nr / 4].Cells[i].Style.BackColor = Color.LightGreen;
            }
        }

        void WriteXYValueToTable(double a, double b, double c, double d, int n, int m) {
            double h = (b - a) / n;
            int nColumns = dataGridView1.ColumnCount;
            for (int ind = 2; ind < nColumns; ind++) {
                int i = Convert.ToInt32(dataGridView1.Columns[ind].Name);
                dataGridView1.Rows[0].Cells[ind].Value = a + i * h;
            }

            double t = (d - c) / m;
            int nRows = dataGridView1.RowCount;
            for (int ind = 1; ind < nRows; ind++) {
                int j = Convert.ToInt32(dataGridView1.Rows[ind].Cells[0].Value);
                dataGridView1.Rows[ind].Cells[1].Value = c + j * t;
            }
        }

        void InitUTable(int nrows, int ncolumns, ref DirichletTask task) {
            for (int i = 1; i < nrows - 1; i++) {
                for (int j = 2; j < ncolumns; j++) {
                    int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                    int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    dataGridView1.Rows[i].Cells[j].Value = task.u(ii, jj);
                }
            }
        }

        void InitVTable(int nrows, int ncolumns, ref DirichletTask task) {
            for (int i = 1; i < nrows - 1; i++) {
                for (int j = 2; j < ncolumns; j++) {
                    int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                    int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    dataGridView1.Rows[i].Cells[j].Value = task.GetValue(ii, jj);
                }
            }
        }
        void InitTestDifferenceTable(int nrows, int ncolumns, ref DirichletTask task) {
            for (int i = 1; i < nrows - 1; i++) {
                for (int j = 2; j < ncolumns; j++) {
                    int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                    int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    dataGridView1.Rows[i].Cells[j].Value = Math.Abs(task.u(ii, jj) - task.GetValue(ii, jj));
                }
            }
        }
        void InitMainDifferenceTable(int nrows, int ncolumns, ref DirichletTask task, ref DirichletTask task2) {
            for (int i = 1; i < nrows - 1; i++) {
                for (int j = 2; j < ncolumns; j++) {
                    int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                    int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    dataGridView1.Rows[i].Cells[j].Value = Math.Abs(task2.GetValue(2 * ii, 2 * jj) - task.GetValue(ii, jj));
                }
            }
        }

        double CalculateTestError(ref DirichletTask task, ref int iTotalEps, ref int jTotalEps) {
            double maxError = -1e100;
            for (int i = 1, j = 1; i < n && j < m; task.GetNextInnerXYIndex(ref i, ref j)) {
                double currError = Math.Abs(task.u(i, j) - task.v[i, j]);
                if (currError > maxError) {
                    maxError = currError;
                    iTotalEps = i; jTotalEps = j;
                }
            }
            return maxError;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nrows = m + 2;
            int ncolumns = n + 3;
            ConstructTable(ref ncolumns, ref nrows);
            if (!isrectangle) DrawTableForRectangleWithHole();
            WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);
            InitVTable(nrows, ncolumns, ref task);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!istest) return;
            int nrows = m + 2;
            int ncolumns = n + 3;
            ConstructTable(ref ncolumns, ref nrows);
            if (!isrectangle) DrawTableForRectangleWithHole();
            WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);
            InitUTable(nrows, ncolumns, ref task);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (istest) return;
            int nrows = 2 * m + 2;
            int ncolumns = 2 * n + 3;
            ConstructTable(ref ncolumns, ref nrows);
            if (!isrectangle) DrawTableForRectangleWithHole();
            WriteXYValueToTable(a, b, c, d, n, m);
            InitVTable(nrows, ncolumns, ref task2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!istest) return;
            int nrows = m + 2;
            int ncolumns = n + 3;
            ConstructTable(ref ncolumns, ref nrows);
            if (!isrectangle) DrawTableForRectangleWithHole();
            WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);
            InitTestDifferenceTable(nrows, ncolumns, ref task);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (istest) return;
            int nrows = m + 2;
            int ncolumns = n + 3;
            ConstructTable(ref ncolumns, ref nrows);
            if (!isrectangle) DrawTableForRectangleWithHole();
            WriteXYValueToTable(a, b, c, d, n, m);
            InitMainDifferenceTable(nrows, ncolumns, ref task, ref task2);
        }

        double CalculateMainError(ref DirichletTask task, ref DirichletTask task2, ref int iTotalEps, ref int jTotalEps) {
            double maxError = -1e100;
            for (int i = 1, j = 1; i < n && j < m; task.GetNextInnerXYIndex(ref i, ref j)) {
                double currError = Math.Abs(task2.GetValue(2 * i, 2 * j) - task.GetValue(i, j));
                if (currError > maxError) {
                    maxError = currError;
                    iTotalEps = i; jTotalEps = j;
                }
            }
            return maxError;
        }

        void WriteResults(bool isTest, double maxError, int iTotalEps, int jTotalEps,
    double xTotalEps, double yTotalEps, double epsMax, int nIters, double rmax, double rmax2 = 0.0) {
            labelIJTotalEps.Text = "которая достигается в узле (i, j) = " + "("
                + iTotalEps.ToString() + ", " + jTotalEps.ToString() + ")";

            labelXYTotalEps.Text = "с координатами (x, y) = " + "(" +
                Math.Round(xTotalEps, 2).ToString() + ", " 
                + Math.Round(yTotalEps, 2).ToString() + ")";

            if (isTest) {
                labelTotalEps.Text = "Задача решена с точностью: max|u[i][j] - v[i][j]| = ";
            } else {
                labelTotalEps.Text = "Задача решена с точностью: max|v2[i][j] - v[i][j]| = ";
            }

            labelTotalEps.Text += maxError.ToString();

            labelEps.Text = "Достигнутая точность метода  eps = " + epsMax.ToString();

            labelNIter.Text = "Число итераций метода N = " + nIters.ToString();

            labelrmax.Text = "Норма невязки для v = " + rmax.ToString();
            if (!istest) {
                labelrmax2.Text = "Норма невязки для v2 = " + rmax2.ToString();
            } else {
                labelrmax2.Text = " ";
            }
        }

        private void МетодВерхнейРелаксацииToolStripMenuItem_Click(object sender, EventArgs e) {
            InitMethodParameters();

            istest = true;
            isrectangle = true;
            task = new TestTaskRectangle(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx, w);
            task.OverRelaxationMethod();

            int iTotalEps = -1, jTotalEps = -1;
            double maxError = CalculateTestError(ref task, ref iTotalEps, ref jTotalEps);

            double xTotalEps = a + iTotalEps * (b - a) / n;
            double yTotalEps = c + jTotalEps * (d - c) / m;
            double rmax = task.RMax();

            WriteResults(istest, maxError, iTotalEps, jTotalEps, xTotalEps, yTotalEps, task.epsMax, task.countSteps, rmax);
            str_w.Text = task.w.ToString();
        }

        private void МетодМинимальныхНевязокToolStripMenuItem_Click(object sender, EventArgs e) {
            InitMethodParameters();

            istest = true;
            isrectangle = true;
            task = new TestTaskRectangle(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx);
            task.MinimumResidualsMethod();

            int iTotalEps = -1, jTotalEps = -1;
            double maxError = CalculateTestError(ref task, ref iTotalEps, ref jTotalEps);

            double xTotalEps = a + iTotalEps * (b - a) / n;
            double yTotalEps = c + jTotalEps * (d - c) / m;
            double rmax = task.RMax();

            WriteResults(istest, maxError, iTotalEps, jTotalEps, xTotalEps, yTotalEps, task.epsMax, task.countSteps, rmax);
        }
 
        private void МетоВерхнейРелаксацииToolStripMenuItem_Click(object sender, EventArgs e) {
            InitMethodParameters();

            istest = false;
            isrectangle = true;
            task = new MainTaskRectangle(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx, w);
            task2 = new MainTaskRectangle(-1.0, 0.0, 0.0, 1.0, 2 * n, 2 * m, eps, nmax, initApprx, w);
            task.OverRelaxationMethod();
            task2.OverRelaxationMethod();

            int iTotalEps = -1, jTotalEps = -1;
            double maxError = CalculateMainError(ref task, ref task2, ref iTotalEps, ref jTotalEps);

            double xTotalEps = a + iTotalEps * (b - a) / n;
            double yTotalEps = c + jTotalEps * (d - c) / m;
            double rmax = task.RMax();
            double rmax2 = task2.RMax();

            WriteResults(istest, maxError, iTotalEps, jTotalEps, xTotalEps, yTotalEps, task.epsMax, task.countSteps, rmax, rmax2);
            str_w.Text = task.w.ToString();
        }

        private void МетодМинимальныхНевязокToolStripMenuItem1_Click(object sender, EventArgs e) {
            InitMethodParameters();

            istest = false;
            isrectangle = true;
            task = new MainTaskRectangle(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx);
            task2 = new MainTaskRectangle(-1.0, 0.0, 0.0, 1.0, 2 * n, 2 * m, eps, nmax, initApprx);
            task.MinimumResidualsMethod();
            task2.MinimumResidualsMethod();

            int iTotalEps = -1, jTotalEps = -1;
            double maxError = CalculateMainError(ref task, ref task2, ref iTotalEps, ref jTotalEps);

            double xTotalEps = a + iTotalEps * (b - a) / n;
            double yTotalEps = c + jTotalEps * (d - c) / m;
            double rmax = task.RMax();
            double rmax2 = task2.RMax();

            WriteResults(istest, maxError, iTotalEps, jTotalEps, xTotalEps, yTotalEps, task.epsMax, task.countSteps, rmax, rmax2);
            str_w.Text = task.w.ToString();
        }

        private void методСопряженныхГрадиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitMethodParameters();

            istest = false;
            isrectangle = true;
            task = new MainTaskRectangle(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx, w);
            task2 = new MainTaskRectangle(-1.0, 0.0, 0.0, 1.0, 2 * n, 2 * m, eps, nmax, initApprx, w);
            task.ConjugateGradientMethod();
            task2.ConjugateGradientMethod();

            int iTotalEps = -1, jTotalEps = -1;
            double maxError = CalculateMainError(ref task, ref task2, ref iTotalEps, ref jTotalEps);

            double xTotalEps = a + iTotalEps * (b - a) / n;
            double yTotalEps = c + jTotalEps * (d - c) / m;
            double rmax = task.RMax();
            double rmax2 = task2.RMax();

            WriteResults(istest, maxError, iTotalEps, jTotalEps, xTotalEps, yTotalEps, task.epsMax, task.countSteps, rmax, rmax2);
            str_w.Text = task.w.ToString();
        }

        private void МетодСопряженногоГрадиентаToolStripMenuItem_Click(object sender, EventArgs e) {
            InitMethodParameters();
            istest = true;
            isrectangle = true;
            task = new TestTaskRectangle(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx);
            task.ConjugateGradientMethod();

            int iTotalEps = -1, jTotalEps = -1;
            double maxError = CalculateTestError(ref task, ref iTotalEps, ref jTotalEps);

            double xTotalEps = a + iTotalEps * (b - a) / n;
            double yTotalEps = c + jTotalEps * (d - c) / m;
            double rmax = task.RMax();

            WriteResults(istest, maxError, iTotalEps, jTotalEps, xTotalEps, yTotalEps, task.epsMax, task.countSteps, rmax);
        }

        private void ТестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem_Click(object sender, EventArgs e) {
            InitMethodParameters();
            istest = true;
            isrectangle = false;
            task = new TestTaskRectangleWithHole(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx);

            task.ConjugateGradientMethod();

            int nrows = m + 2;
            int ncolumns = n + 3;

            int iTotalEps = -1, jTotalEps = -1;
            double maxError = CalculateTestError(ref task, ref iTotalEps, ref jTotalEps);

            double xTotalEps = a + iTotalEps * (b - a) / n;
            double yTotalEps = c + jTotalEps * (d - c) / m;
            double rmax = task.RMax();

            WriteResults(istest, maxError, iTotalEps, jTotalEps, xTotalEps, yTotalEps, task.epsMax, task.countSteps, rmax);
        }
    }
}

