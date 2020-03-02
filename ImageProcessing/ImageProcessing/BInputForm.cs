using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class BInputForm : Form
    {
        public ManualResetEvent clickEventNext = new ManualResetEvent(false);
        public ManualResetEvent clickEventInit = new ManualResetEvent(false);
        public int n;
        public bool init = false;
        public BInputForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int size = Convert.ToInt32(textBox1.Text);
            n = size;
            for (int i = 0; i < n; i++)
            {
                string ColumnName = Convert.ToString(i + 1);
                string varColumnName = "Column" + ColumnName;
                dataGridView1.Columns.Add(varColumnName, ColumnName);
                dataGridView1.Rows.Add();
            }
            clickEventInit.Set();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1.se = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Form1.se[i,j] = (float)Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
                }
            }
            this.Close();
        }

    }
}
