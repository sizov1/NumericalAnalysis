using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spline
{
    public class Info
    {
        public int n, N;
        public double e, de, d2e;
        public double xe, xde, xd2e;

        public Info() { }
        public void InitInfo(int _n, int _N, double _e, double _de, double _d2e, 
            double _xe, double _xde, double _xd2e)
        {
            n = _n; N = _N;
            e = _e; de = _de; d2e = _d2e;
            xe = _xe; xde = _xde; xd2e = _xd2e;
        }
    }
}
