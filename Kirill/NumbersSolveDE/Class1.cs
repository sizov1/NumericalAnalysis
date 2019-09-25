using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersSolveDE
{
    public class OutputData
    {
        public int n;
        public double rightErr;
        public double maxLte;
        public int C1;
        public int C2;
        public KeyValuePair<double, double> maxH;
        public KeyValuePair<double, double> minH;
        public KeyValuePair<double, double> maxGte;

        public OutputData() { }

        public void InitData(int _n, double _rightErr, double _maxLte, int _C1, int _C2,
            double _maxH, double _xmaxH, double _minH, double _xminH, double _maxGte, double _xmaxGte)
        {
            n = _n; rightErr = _rightErr; maxLte = _maxLte; C1 = _C1; C2 = _C2;
            maxH = new KeyValuePair<double, double>(_maxH, _xmaxH);
            minH = new KeyValuePair<double, double>(_minH, _xminH);
            maxGte = new KeyValuePair<double, double>(_maxGte, _xmaxGte);
        }
    }
}
