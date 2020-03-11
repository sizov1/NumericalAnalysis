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

        void ConstructTable(int nColumns, int nRows)
        {
            AddColumn("j", " ");
            AddColumn("i", "i");

            dataGridView1.Columns["j"].Frozen = true;
            dataGridView1.Columns["i"].Frozen = true;

            for (int i = 0; i < nColumns; i++)
            {
                AddColumn(i.ToString(), i.ToString());
            }

            dataGridView1.Rows.Add(nRows);
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

            for (int j = 1; j < nRows; j++) 
            {
                dataGridView1.Rows[j].Cells[0].Value = (j - 1).ToString();
            }
        }

        void WriteXYValueToTable(double a, double b, double c, double d, int n, int m)
        {
            double h = (b - a) / n;
            for(int ind = 0; ind < n + 1; ind++)
            {
                int i = Convert.ToInt32(dataGridView1.Columns[ind + 2].Name);
                dataGridView1.Rows[0].Cells[ind + 2].Value = a + i * h;
            }

            double t = (d - c) / m;
            for (int ind = 0; ind < m + 1; ind++)
            {
                int j = Convert.ToInt32(dataGridView1.Rows[ind + 1].Cells[0].Value);
                dataGridView1.Rows[ind + 1].Cells[1].Value = c + j * t;
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

            ConstructTable(n + 1, m + 2);
            WriteXYValueToTable(-1.0, 0.0, 0.0, 1.0, n, m);

            if(is_u.Checked)
            {
                for(int i = 1; i < n; i++)
                {
                    for(int j = 1; j < m; j++)
                    {
                        double x = Convert.ToDouble(dataGridView1.Rows[0].Cells[j + 2].Value);
                        double y = Convert.ToDouble(dataGridView1.Rows[i + 1].Cells[1].Value);
                        dataGridView1.Rows[i + 1].Cells[j + 2].Value = task.u(x, y);
                    }
                }
            } else if(is_v.Checked)
            {
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < m; j++)
                    {
                        int ii = Convert.ToInt32(dataGridView1.Columns[j + 2].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[0].Value);
                        dataGridView1.Rows[i + 1].Cells[j + 2].Value = task.v[ii,jj];
                    }
                }
            } else if(is_diff.Checked)
            {
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < m; j++)
                    {
                        double x = Convert.ToDouble(dataGridView1.Rows[0].Cells[j + 2].Value);
                        double y = Convert.ToDouble(dataGridView1.Rows[i + 1].Cells[1].Value);
                        int ii = Convert.ToInt32(dataGridView1.Columns[j + 2].Name);
                        int jj = Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[0].Value);
                        dataGridView1.Rows[i + 1].Cells[j + 2].Value = Math.Abs(task.u(x, y) - task.v[ii, jj]);
                    }
                }
            }

        }
    }
}
