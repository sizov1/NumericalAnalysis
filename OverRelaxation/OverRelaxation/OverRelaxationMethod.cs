using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverRelaxation
{
    abstract class IterationMethod
    {
        public double[,] v = null;
        public double a, b, c, d;
        protected double h, t;
        protected int n, m, nmax;
        public int countSteps;
        public double eps, maxError, epsMax;
        byte initAprx; // 1 - интер по X; 2 - по Y; 3 - нулевое

        public IterationMethod(double _a, double _b, double _c, double _d,
                                    int _n, int _m, double _eps, int _nmax, byte _initAprx)
        {
            a = _a; b = _b; c = _c; d = _d;
            n = _n; m = _m; nmax = _nmax;
            eps = _eps; initAprx = _initAprx;
            h = (b - a) / n;
            t = (d - c) / m;
            countSteps = 0; maxError = 0.0;
            epsMax = 0.0;
            v = new double[n + 1, m + 1];
        }

        public abstract double f(double x, double y);
        public abstract double M1(double y);
        public abstract double M2(double y);
        public abstract double M3(double x);
        public abstract double M4(double x);

        protected void InitBorderValue()
        {
            for (int j = 0; j < m + 1; j++)
            {
                v[0, j] = M1(c + j * t);
                v[n, j] = M2(c + j * t);
            }

            for (int i = 0; i < n + 1; i++)
            {
                v[i, 0] = M3(a + i * h);
                v[i, m] = M4(a + i * h);
            }
        }

        void ZeroInitialApproximate()
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    v[i, j] = 0.0;
                }
            }
        }

        void InterpolationXInitialApproximate()
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    v[i, j] = ((a + i * h) - a) / (b - a) * M2(c + j * t) +
                              ((a + i * h) - b) / (a - b) * M1(c + j * t);
                }
            }
        }

        void InterpolationYInitialApproximate()
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    v[i, j] = ((c + j * t) - c) / (d - c) * M4(a + i * h) +
                              ((c + j * t) - d) / (c - d) * M3(a + i * h);
                }
            }
        }

        protected void InitialApproximate()
        {
            if (initAprx == 1)
            {
                InterpolationXInitialApproximate();
            }
            else if (initAprx == 2)
            {
                InterpolationYInitialApproximate();
            }
            else if (initAprx == 3)
            {
                ZeroInitialApproximate();
            }
        }

    }

    abstract class OverRelaxationMethod : IterationMethod
    {
        public double w;
        
        public OverRelaxationMethod(double _a, double _b, double _c, double _d,
                                    int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w) :
            base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx)
        {
            if (_w > 2.0 || _w < 0.0)
            {
                w = CalculateOptimalValue(h, t);
            } else
            {
                w = _w;
            }
        }

        public abstract void MaxError();

        protected double CalculateOptimalValue(double h, double t)
        {
            double arg1 = Math.PI * h / (2 * (b - a));
            double arg2 = Math.PI * t / (2 * (d - c));
            double a2 = h * h + t * t;
            double lambdaMin = 2 * t * t / (a2) * Math.Sin(arg1) * Math.Sin(arg1)
                + 2 * h * h / (a2) * Math.Sin(arg2) * Math.Sin(arg2);
            w = 2 / (1 + Math.Sqrt(lambdaMin * (2 - lambdaMin)));
            return w;
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
                        double newValue = -w * (h2 * (v[i + 1,j] + v[i - 1,j]) +
                                                  t2 * (v[i,j + 1] + v[i,j - 1]));
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
        public MainTask(double _a, double _b, double _c, double _d,
                        int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w)
                        : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx, _w)
        {
        }

        public override void Solve()
        {
            base.Solve();
        }

        public override void MaxError()
        {
            maxError = 0.0; 
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

    abstract class MinimumResidualsMethod : IterationMethod
    {
        public double[,] r = null;
        public MinimumResidualsMethod(double _a, double _b, double _c, double _d,
                                    int _n, int _m, double _eps, int _nmax, byte _initAprx) :
            base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx)
        {
            r = new double[n + 1, m + 1];
        }

        public abstract void MaxError();

        protected double CalculateParameter(double h, double t)
        {
            double h2 = -((double)n / (b - a)) * ((double)n / (b - a));
            double t2 = -((double)m / (d - c)) * ((double)m / (d - c));
            double a2 = -2 * (h2 + t2);
            double divider = 0.0;
            double ts = 0.0;
            double temp;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    temp = (r[i, j] * a2 + h2 * (r[i + 1, j] + r[i - 1, j]) + t2 * (r[i, j + 1] + r[i, j - 1]));
                    ts += temp * r[i, j];
                    divider += temp * temp;
                }
            }
            ts = ts / divider;
            return ts;
        }

        public virtual void Solve()
        {
            InitBorderValue();
            InitialApproximate();

            epsMax = 0.0;
            double epsCurr = 0.0;
            double h2 = -((double)n / (b - a)) * ((double)n / (b - a));
            double t2 = -((double)m / (d - c)) * ((double)m / (d - c));
            double a2 = -2 * (h2 + t2);
            countSteps = 0;
            bool stop = false;
            double ts;
            while (!stop)
            {
                epsMax = 0.0;

                //невязка на текущей итерации
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < m; j++)
                    {
                        r[i, j] = v[i, j] * a2 + h2 * (v[i - 1, j] + v[i + 1, j]) + t2 * (v[i, j - 1] + v[i, j + 1])
                            - f(a + i * h, c + j * t); 
                    }
                }

                ts = CalculateParameter(h, t);

                //обновление компонент
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < m; j++)
                    {
                        double oldValue = v[i, j];

                        double newValue =  v[i, j] - ts * r[i, j]; 
                                               
                        epsCurr = Math.Abs(oldValue - newValue);
                        if (epsCurr > epsMax) epsMax = epsCurr;
                        v[i, j] = newValue;
                    }
                }
                countSteps++;
                if (epsMax < eps || countSteps >= nmax) stop = true;
            }
            MaxError();
        }

    }

    class TestTaskMRM : MinimumResidualsMethod
    {
        public TestTaskMRM(double _a, double _b, double _c, double _d,
                        int _n, int _m, double _eps, int _nmax, byte _initAprx)
                        : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx)
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

    class MainTaskMRM : MinimumResidualsMethod
    {
        public MainTaskMRM(double _a, double _b, double _c, double _d,
                        int _n, int _m, double _eps, int _nmax, byte _initAprx)
                        : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx)
        {
        }

        public override void Solve()
        {
            base.Solve();
        }

        public override void MaxError()
        {
            maxError = 0.0;
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
            return -x * (x + 1);
        }

        public override double M4(double x)
        {
            return -x * (x + 1);
        }
    }
}
