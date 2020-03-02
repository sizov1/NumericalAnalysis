using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
   
    public partial class StructInputForm : Form
    {
        public int[,] se = null;
        public int size;
        public StructInputForm(int n)
        {
            InitializeComponent();
            size = n;
            for (int i = 0; i < n; i++)
            {
                string ColumnName = Convert.ToString(i + 1);
                string varColumnName = "Column" + ColumnName;
                dataGridView1.Columns.Add(varColumnName, ColumnName);
                dataGridView1.Rows.Add();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            se = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    se[i,j] = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                }
            }
        }
    }
}
