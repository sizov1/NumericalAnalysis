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
        int n, m, nmax;
        double eps, w;
        byte initAprx; // 1 - интер по X; 2 - по Y; 3 - нулевое
        public OverRelaxationMethod(double _a, double _b, double _c, double _d,
                                    int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w)
        {
            a = _a; b = _b; c = _c; d = _d;
            n = _n; m = _m; nmax = _nmax;
            eps = _eps; initAprx = _initAprx;
            h = (b - a) / n;
            t = (d - c) / m;
            v = new double[n + 1, m + 1];

            if (_w > 2.0 || _w < 0.0)
            {
                w = CalculateOptimalValue();
            } else
            {
                w = _w;
            }
        }


        public abstract double f(double x, double y);
        public abstract double m1(double y);
        public abstract double m2(double y);
        public abstract double m3(double x);
        public abstract double m4(double x);

        double CalculateOptimalValue()
        {
            return 1.5;
        }

        void InitBorderValue()
        {
            for(int j = 0; j < m + 1; j++)
            {
                v[0,j] = m1(c + j * t);
                v[n,j] = m2(c + j * t);
            }

            for (int i = 0; i < n + 1; i++)
            {
                v[i,0] = m3(a + i * h);
                v[i,m] = m4(a + i * h);
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
                    v[i,j] = ((a + i * h) - a) / (b - a) * m2(c + j * t) +
                              ((a + i * h) - b) / (a - b) * m1(c + j * t);
                }
            }
        }

        void InterpolationYInitialApproximate()
        {
            for(int i = 1; i < n; i++)
            {
                for(int j = 1; j < m; j++)
                {
                    v[i,j] = ((c + j * t) - c) / (d - c) * m4(a + i * h) +
                              ((c + j * t) - d) / (c - d) * m3(a + i * h);
                }
            }
        }

        void InitialApproximate()
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

        public void Solve()
        {

            InitBorderValue();
            InitialApproximate();

            double epsMax = 0.0, epsCurr = 0.0;
            double h2 = - ((double)n / (b - a)) * ((double)n / (b - a));
            double t2 = - ((double)m / (d - c)) * ((double)m / (d - c));
            double a2 = -2 * (h2 + t2);
            int countSteps = 0;
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
        }
    }

    class TestTask : OverRelaxationMethod
    {
        public TestTask(double _a, double _b, double _c, double _d, 
                        int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w) 
                        : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx, _w)
        { }

        public override double f(double x, double y)
        {
            return (x * x + y * y) * Math.Exp(x * y);
        }

        public override double m1(double y)
        {
            return Math.Exp(a * y);
        }

        public override double m2(double y)
        {
            return Math.Exp(b * y);
        }

        public override double m3(double x)
        {
            return Math.Exp(x * c);
        }

        public override double m4(double x)
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
        public MainTask(double _a, double _b, double _c, double _d,
                        int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w)
                        : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx, _w)
        { }

        public override double f(double x, double y)
        {
            return Math.Cosh(x * x * y);
        }

        public override double m1(double y)
        {
            return Math.Sin(Math.PI * y);
        }

        public override double m2(double y)
        {
            return Math.Abs(Math.Sin(2 * Math.PI * y));
        }

        public override double m3(double x)
        {
            return - x * (x + 1);
        }

        public override double m4(double x)
        {
            return -x * (x + 1);
        }
    }
}
