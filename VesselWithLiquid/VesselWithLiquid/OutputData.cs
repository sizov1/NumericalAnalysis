using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesselWithLiquid
{
    public class OutputData
    {
        public int n;
        public double righterr;
        public double maxlte;
        public int C1;
        public int C2;
        public double maxh;
        public double xmaxh;
        public double minh;
        public double xminh;
        public double maxgte;
        public double xmaxgte;
        public double xlast;
        public double ylast;

        public OutputData() { }

        public void InitData(int _n, double _rightErr, double _maxLte, int _C1, int _C2,
            double _maxH, double _xmaxH, double _minH, double _xminH, double _maxGte, double _xmaxGte, double _xlast, double _ylast)
        {
            n = _n; righterr = _rightErr; maxlte = _maxLte; C1 = _C1; C2 = _C2; xlast = _xlast; ylast = _ylast;
            maxh = _maxH; xmaxh = _xmaxH;
            minh = _minH; xminh = _xminH;
            maxgte = _maxGte; xmaxgte = _xmaxGte;
        }
    }
}
