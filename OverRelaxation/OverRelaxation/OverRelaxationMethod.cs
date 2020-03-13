using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverRelaxation
{
    abstract class OverRelaxationMethod
    {
        public double[,] v = null;
        public double a, b, c, d;
        protected double h, t;
        protected int n, m, nmax;
        public int countSteps;
        public double eps, w, maxError, epsMax;
        byte initAprx; // 1 - интер по X; 2 - по Y; 3 - нулевое
        public OverRelaxationMethod(double _a, double _b, double _c, double _d,
                                    int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w)
        {
            a = _a; b = _b; c = _c; d = _d;
            n = _n; m = _m; nmax = _nmax;
            eps = _eps; initAprx = _initAprx;
            h = (b - a) / n;
            t = (d - c) / m;
            countSteps = 0; maxError = 0.0;
            epsMax = 0.0;
            v = new double[n + 1, m + 1];

            if (_w > 2.0 || _w < 0.0)
            {
                w = CalculateOptimalValue(h, t);
            } else
            {
                w = _w;
            }
        }


        public abstract double f(double x, double y);
        public abstract double M1(double y);
        public abstract double M2(double y);
        public abstract double M3(double x);
        public abstract double M4(double x);

        public abstract void MaxError();

        protected double CalculateOptimalValue(double h, double t)
        {
            w = 2.0 / (1 + Math.Sin(Math.PI * h));
            return w;
        }

        protected void InitBorderValue()
        {
            for(int j = 0; j < m + 1; j++)
            {
                v[0,j] = M1(c + j * t);
                v[n,j] = M2(c + j * t);
            }

            for (int i = 0; i < n + 1; i++)
            {
                v[i,0] = M3(a + i * h);
                v[i,m] = M4(a + i * h);
            }
        }

        void ZeroInitialApproximate()
        {
            for(int i = 1; i < n; i++)
            {
                for(int j = 1; j < m; j++)
                {
                    v[i,j] = 0.0;
                }
            }
        }

        void InterpolationXInitialApproximate()
        {
            for(int i = 1; i < n; i++)
            {
                for(int j = 1; j < m; j++)
                {
                    v[i,j] = ((a + i * h) - a) / (b - a) * M2(c + j * t) +
                              ((a + i * h) - b) / (a - b) * M1(c + j * t);
                }
            }
        }

        void InterpolationYInitialApproximate()
        {
            for(int i = 1; i < n; i++)
            {
                for(int j = 1; j < m; j++)
                {
                    v[i,j] = ((c + j * t) - c) / (d - c) * M4(a + i * h) +
                              ((c + j * t) - d) / (c - d) * M3(a + i * h);
                }
            }
        }

        protected void InitialApproximate()
        {
            if (initAprx == 1)
            {
                InterpolationXInitialApproximate();
            } else if (initAprx == 2)
            {
                InterpolationYInitialApproximate();
            } else if (initAprx == 3)
            {
                ZeroInitialApproximate();
            }
        }

        public virtual void Solve()
        {

            InitBorderValue();
            InitialApproximate();

            epsMax = 0.0;
            double epsCurr = 0.0;
            double h2 = - ((double)n / (b - a)) * ((double)n / (b - a));
            double t2 = - ((double)m / (d - c)) * ((double)m / (d - c));
            double a2 = -2 * (h2 + t2);
            countSteps = 0;
            bool stop = false;
            while(!stop)
            {
                epsMax = 0.0;
                for(int i = 1; i < n; i++)
                {
                    for(int j = 1; j < m; j++)
                    {
                        double oldValue = v[i,j];
                        double newValue = -w * (t2 * (v[i + 1,j] + v[i - 1,j]) +
                                                  h2 * (v[i,j + 1] + v[i,j - 1]));
                        newValue += (1 - w) * a2 * v[i,j] + w * f(a + i*h, c + j*t);
                        newValue /= a2;
                        epsCurr = Math.Abs(oldValue - newValue);
                        if (epsCurr > epsMax) epsMax = epsCurr;
                        v[i,j] = newValue;
                    }
                }
                countSteps++;
                if (epsMax < eps || countSteps >= nmax) stop = true;
            }
            MaxError();
        }

    }

    class TestTask : OverRelaxationMethod
    {
        public TestTask(double _a, double _b, double _c, double _d, 
                        int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w) 
                        : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx, _w)
        { }

        public override void MaxError()
        {
            List<double> errors = new List<double>();
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    errors.Add(Math.Abs(v[i, j] - u(a + i * h, c + j * t)));
                }
            }
            maxError = errors.Max();
        }

        public override double f(double x, double y)
        {
            return -(x * x + y * y) * Math.Exp(x * y);
        }

        public override double M1(double y)
        {
            return Math.Exp(a * y);
        }

        public override double M2(double y)
        {
            return Math.Exp(b * y);
        }

        public override double M3(double x)
        {
            return Math.Exp(x * c);
        }

        public override double M4(double x)
        {
            return Math.Exp(x * d);
        }

        public double u(double x, double y)
        {
            return Math.Exp(x * y);
        }
    }

    class MainTask : OverRelaxationMethod
    {
        int countSteps2;
        public int n2, m2;
        public double h2, t2;
        public double[,] v2 = null;
        public double w2, epsMax2;
        public MainTask(double _a, double _b, double _c, double _d,
                        int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w)
                        : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx, _w)
        {
            countSteps2 = 0;
            n2 = 2 * _n;
            m2 = 2 * _m;
            h2 = (_b - _a) / n2;
            t2 = (_d - _c) / m2;
            w2 = CalculateOptimalValue(h2, t2);
            v2 = new double[n2 + 1, m2 + 1];
        }

        public override void Solve()
        {
            base.Solve();

            InitBorderValue();
            InitialApproximate();

            epsMax = 0.0;
            double epsCurr = 0.0;
            double h22 = -((double)n2 / (b - a)) * ((double)n2 / (b - a));
            double t22 = -((double)m2 / (d - c)) * ((double)m2 / (d - c));
            double a2 = -2 * (h22 + t22);
            countSteps2 = 0;
            bool stop = false;
            while (!stop)
            {
                epsMax = 0.0;
                for (int i = 1; i < n2; i++)
                {
                    for (int j = 1; j < m2; j++)
                    {
                        double oldValue = v2[i, j];
                        double newValue = -w * (t22 * (v2[i + 1, j] + v2[i - 1, j]) +
                                                  h22 * (v2[i, j + 1] + v2[i, j - 1]));
                        newValue += (1 - w2) * a2 * v2[i, j] + w2 * f(a + i * h2, c + j * t2);
                        newValue /= a2;
                        epsCurr = Math.Abs(oldValue - newValue);
                        if (epsCurr > epsMax) epsMax = epsCurr;
                        v2[i, j] = newValue;
                    }
                }
                countSteps2++;
                if (epsMax < eps || countSteps2 >= nmax) stop = true;
            }
            MaxError();
    }

        public override void MaxError()
        {
            List<double> errors = new List<double>();
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    errors.Add(Math.Abs(v[i, j] - v2[2 * i, 2 * j]));
                }
            }
            maxError = errors.Max();
        }

        public override double f(double x, double y)
        {
            return Math.Cosh(x * x * y);
        }

        public override double M1(double y)
        {
            return Math.Sin(Math.PI * y);
        }

        public override double M2(double y)
        {
            return Math.Abs(Math.Sin(2 * Math.PI * y));
        }

        public override double M3(double x)
        {
            return - x * (x + 1);
        }

        public override double M4(double x)
        {
            return -x * (x + 1);
        }
    }
}
