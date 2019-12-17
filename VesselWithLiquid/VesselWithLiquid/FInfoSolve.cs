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
            srightErr.Text = data.rightErr.ToString();
            sOutLte.Text = data.maxLte.ToString();
            sOutHMax.Text = data.maxH.Key.ToString();
            sOutXHMax.Text = data.maxH.Value.ToString();
            sOutHMin.Text = data.minH.Key.ToString();
            sOutXHMin.Text = data.minH.Value.ToString();
            sOutC1.Text = data.C1.ToString();
            sOutC2.Text = data.C2.ToString();
            sOutGte.Text = data.maxGte.Key.ToString();
            sOutXGte.Text = data.maxGte.Value.ToString();
            sxlast.Text = data.xlast.ToString();
            sylast.Text = data.ylast.ToString();
        }

    }
}
