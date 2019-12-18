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
    public partial class FInfoSolve : Form
    {
        public FInfoSolve()
        {
            InitializeComponent();
        }

        public void InitInfo(OutputData data)
        {
            sOutN.Text = data.n.ToString();
            srightErr.Text = data.righterr.ToString();
            sOutLte.Text = data.maxlte.ToString();
            sOutHMax.Text = data.maxh.ToString();
            sOutXHMax.Text = data.xmaxh.ToString();
            sOutHMin.Text = data.minh.ToString();
            sOutXHMin.Text = data.xminh.ToString();
            sOutC1.Text = data.C1.ToString();
            sOutC2.Text = data.C2.ToString();
            sOutGte.Text = data.maxgte.ToString();
            sOutXGte.Text = data.xmaxgte.ToString();
            sxlast.Text = data.xlast.ToString();
            sylast.Text = data.ylast.ToString();
        }

    }
}
