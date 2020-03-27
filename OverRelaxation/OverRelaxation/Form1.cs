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
        public Form1()
        {
            InitializeComponent();
        }

        void AddColumn(String name, String headerText)
        {
            DataGridViewTextBoxColumn column;
            column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.HeaderText = headerText;
            column.Width = 50;
            dataGridView1.Columns.Add(column);
        }

        void ConstructTable(ref int nColumns, ref int nRows)
        {
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

            int stepX = ((nRows - 2) / 100) + 1;
            int stepY = ((nColumns - 3) / 100) + 1;
            for (int i = 0; i < nColumns - 2; i+=stepX)
            {
                AddColumn(i.ToString(), i.ToString());
            }

            dataGridView1.Rows.Add();
            for (int j = 0, i = 0; j < nRows - 1; j += stepY, i++)
            {
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

            nRows = dataGridView1.RowCount;
            nColumns = dataGridView1.ColumnCount;
        }

        void WriteXYValueToTable(double a, double b, double c, double d, int n, int m)
        {
            double h = (b - a) / n;
            int nColumns = dataGridView1.ColumnCount;
            for(int ind = 2; ind < nColumns; ind++)
            {
                int i = Convert.ToInt32(dataGridView1.Columns[ind].Name);
                dataGridView1.Rows[0].Cells[ind].Value = a + i * h;
            }

            double t = (d - c) / m;
            int nRows = dataGridView1.RowCount;
            for (int ind = 1; ind < nRows; ind++)
            {
                int j = Convert.ToInt32(dataGridView1.Rows[ind].Cells[0].Value);
                dataGridView1.Rows[ind].Cells[1].Value = c + j * t;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double eps = Convert.ToDouble(str_eps.Text);
            int nmax = Convert.ToInt32(str_nmax.Text);
            int n = Convert.ToInt32(str_n.Text);
            int m = Convert.ToInt32(str_m.Text);
            double w = -1.0;
            if (userValue.Checked) w = Convert.ToDouble(str_w.Text);
            byte initApprx = 3;
            if (is_inter_x.Checked) initApprx = 1;
            else if (is_inter_y.Checked) initApprx = 2;

            TestTask task = new TestTask(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx, w);
            task.Solve();

            int nrows = m + 2;
            int ncolumns = n + 3;
            ConstructTable(ref ncolumns, ref nrows);
            WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

            if(is_u.Checked)
            {
                for(int i = 1; i < nrows - 1; i++)
                {
                    for(int j = 2; j < ncolumns; j++)
                    {
                        double x = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                        double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task.u(x, y);
                    }
                }
            } else if(is_v.Checked)
            {
                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task.v[ii,jj];
                    }
                }
            } else if(is_diff.Checked)
            {
                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        double x = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                        double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = Math.Abs(task.u(x, y) - task.v[ii, jj]);
                    }
                }
            }

            label_error.Text = "Тестовая задача быда решена с точностью: " +
                "max|u[i][j] - v[i][j]| = " + task.maxError.ToString();

            label_eps.Text = "Достигнутая точность итерационного метода: " + task.epsMax;

            label_niter.Text = "На решение затрачено" + task.countSteps + " итераций";

            label_w.Text = "w = " + task.w.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double eps = Convert.ToDouble(str_eps.Text);
            int nmax = Convert.ToInt32(str_nmax.Text);
            int n = Convert.ToInt32(str_n.Text);
            int m = Convert.ToInt32(str_m.Text);
            double w = -1.0;
            if (userValue.Checked) w = Convert.ToDouble(str_w.Text);
            byte initApprx = 3;
            if (is_inter_x.Checked) initApprx = 1;
            else if (is_inter_y.Checked) initApprx = 2;

            MainTask task = new MainTask(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx, w);
            MainTask task2 = new MainTask(-1.0, 0.0, 0.0, 1.0, 2 * n, 2 * m, eps, nmax, initApprx, w);
            task.Solve();
            task2.Solve();

            if (is_u.Checked)
            {
                int nrows = 2 * m + 2;
                int ncolumns = 2 * n + 3;
                ConstructTable(ref ncolumns, ref nrows);
                WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task2.v[ii, jj];
                    }
                }
            }
            else if (is_v.Checked)
            {
                int nrows = m + 2;
                int ncolumns = n + 3;
                ConstructTable(ref ncolumns, ref nrows);
                WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task.v[ii, jj];
                    }
                }
            }
            else if (is_diff.Checked)
            {
                int nrows = m + 2;
                int ncolumns = n + 3;
                ConstructTable(ref ncolumns, ref nrows);
                WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = Math.Abs(task2.v[ii*2, jj*2] - task.v[ii, jj]);
                    }
                }
            }

            List<double> errors = new List<double>();
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    errors.Add(Math.Abs(task2.v[i * 2, j * 2] - task.v[i, j]));
                }
            }
            double maxError = errors.Max();

            label_error.Text = "Основная задача быда решена с точностью: " +
                "max|v2[i][j] - v[i][j]| = " + maxError.ToString();

            label_eps.Text = "Достигнутая точность итерационного метода: " + task.epsMax;

            label_niter.Text = "На решение затрачено" + task.countSteps + " итераций";

            label_w.Text = "w = " + task.w.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double eps = Convert.ToDouble(str_eps.Text);
            int nmax = Convert.ToInt32(str_nmax.Text);
            int n = Convert.ToInt32(str_n.Text);
            int m = Convert.ToInt32(str_m.Text);

            byte initApprx = 3;
            if (is_inter_x.Checked) initApprx = 1;
            else if (is_inter_y.Checked) initApprx = 2;

            TestTaskMRM task = new TestTaskMRM(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx);
            task.Solve();

            int nrows = m + 2;
            int ncolumns = n + 3;
            ConstructTable(ref ncolumns, ref nrows);
            WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

            if (is_u.Checked)
            {
                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        double x = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                        double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task.u(x, y);
                    }
                }
            }
            else if (is_v.Checked)
            {
                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task.v[ii, jj];
                    }
                }
            }
            else if (is_diff.Checked)
            {
                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        double x = Convert.ToDouble(dataGridView1.Rows[0].Cells[j].Value);
                        double y = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = Math.Abs(task.u(x, y) - task.v[ii, jj]);
                    }
                }
            }

            label_error.Text = "Тестовая задача быда решена с точностью: " +
                "max|u[i][j] - v[i][j]| = " + task.maxError.ToString();

            label_eps.Text = "Достигнутая точность итерационного метода: " + task.epsMax;

            label_niter.Text = "На решение затрачено" + task.countSteps + " итераций";

            label_w.Text = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double eps = Convert.ToDouble(str_eps.Text);
            int nmax = Convert.ToInt32(str_nmax.Text);
            int n = Convert.ToInt32(str_n.Text);
            int m = Convert.ToInt32(str_m.Text);

            byte initApprx = 3;
            if (is_inter_x.Checked) initApprx = 1;
            else if (is_inter_y.Checked) initApprx = 2;

            MainTaskMRM task = new MainTaskMRM(-1.0, 0.0, 0.0, 1.0, n, m, eps, nmax, initApprx);
            MainTaskMRM task2 = new MainTaskMRM(-1.0, 0.0, 0.0, 1.0, 2 * n, 2 * m, eps, nmax, initApprx);
            task.Solve();
            task2.Solve();

            if (is_u.Checked)
            {
                int nrows = 2 * m + 2;
                int ncolumns = 2 * n + 3;
                ConstructTable(ref ncolumns, ref nrows);
                WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task2.v[ii, jj];
                    }
                }
            }
            else if (is_v.Checked)
            {
                int nrows = m + 2;
                int ncolumns = n + 3;
                ConstructTable(ref ncolumns, ref nrows);
                WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = task.v[ii, jj];
                    }
                }
            }
            else if (is_diff.Checked)
            {
                int nrows = m + 2;
                int ncolumns = n + 3;
                ConstructTable(ref ncolumns, ref nrows);
                WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

                for (int i = 1; i < nrows - 1; i++)
                {
                    for (int j = 2; j < ncolumns; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                        dataGridView1.Rows[i].Cells[j].Value = Math.Abs(task2.v[ii * 2, jj * 2] - task.v[ii, jj]);
                    }
                }
            }

            List<double> errors = new List<double>();
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    errors.Add(Math.Abs(task2.v[i * 2, j * 2] - task.v[i, j]));
                }
            }
            double maxError = errors.Max();

            label_error.Text = "Основная задача быда решена с точностью: " +
                "max|v2[i][j] - v[i][j]| = " + maxError.ToString();

            label_eps.Text = "Достигнутая точность итерационного метода: " + task.epsMax;

            label_niter.Text = "На решение затрачено" + task.countSteps + " итераций";

            label_w.Text = " ";
        }
    }
}
