using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumbersSolveDE
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void InitInfo(OutputData data)
        {
            n_out.Text = data.n.ToString();
            rightErr_out.Text = data.rightErr.ToString();
            maxlte_out.Text = data.maxLte.ToString();
            maxh_out.Text = data.maxH.Key.ToString();
            xmaxh_out.Text = data.maxH.Value.ToString();
            minh_out.Text = data.minH.Key.ToString();
            xminh_out.Text = data.minH.Value.ToString();
            c1_out.Text = data.C1.ToString();
            c2_out.Text = data.C2.ToString();
            maxgte_out.Text = data.maxGte.Key.ToString();
            xmaxgte_out.Text = data.maxGte.Value.ToString();
        }

    }
}
