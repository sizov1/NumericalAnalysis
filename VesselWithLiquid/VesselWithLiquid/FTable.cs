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
    public partial class FTable : Form
    {
        public FTable()
        {
            InitializeComponent();
        }

        public void InitTable(ref List<List<double>> data, int number_rows, int number_columns)
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
