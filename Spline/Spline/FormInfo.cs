using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spline
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
        }

        public void DisplayInfo(Info inf)
        {
            sn.Text = inf.n.ToString();
            strN.Text = inf.N.ToString();
            stre.Text = Math.Round(inf.e, 5).ToString("E");
            strde.Text = Math.Round(inf.de, 5).ToString("E");
            strd2e.Text = Math.Round(inf.d2e, 5).ToString("E");
            strxe.Text = Math.Round(inf.xe, 5).ToString("E");
            strxde.Text = Math.Round(inf.xde, 5).ToString("E");
            strxd2e.Text = Math.Round(inf.xd2e, 5).ToString("E");
        }

    }
}
