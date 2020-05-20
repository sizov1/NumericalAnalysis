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
            stre.Text = inf.e.ToString("E");
            strde.Text = inf.de.ToString("E");
            strd2e.Text = inf.d2e.ToString("E");
            strxe.Text = inf.xe.ToString("E");
            strxde.Text = inf.xde.ToString("E");
            strxd2e.Text = inf.xd2e.ToString("E");
        }

    }
}
