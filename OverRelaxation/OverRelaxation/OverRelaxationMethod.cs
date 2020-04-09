using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverRelaxation
{
    abstract class DirichletTask
    {
        public double[,] v = null;
        public double[,] r = null;
        public double a, b, c, d;
        public double a2, h2, t2;
        protected double h, t;
        protected int n, m, nmax;
        public int countSteps;
        public double eps, epsMax;
        public double w;
        byte initAprx; // 1 - интер по X; 2 - по Y; 3 - нулевое

        public DirichletTask(double _a, double _b, double _c, double _d,
                                        int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w = -1.0)
        {
            a = _a; b = _b; c = _c; d = _d;
            n = _n; m = _m; nmax = _nmax;
            eps = _eps; initAprx = _initAprx;
            h = (b - a) / n;
            t = (d - c) / m;
            countSteps = 0;
            epsMax = 0.0;
            v = new double[n + 1, m + 1];
            h2 = -((double)n / (b - a)) * ((double)n / (b - a));
            t2 = -((double)m / (d - c)) * ((double)m / (d - c));
            a2 = -2 * (h2 + t2);
            if (_w < 0.0)
            {
                w = CalculateOptimalValue(h, t);
            }
            else
            {
                w = _w;
            }
        }



        public double u(double x, double y)
        {
            // тестовая функция
            return Math.Exp(x * y);
        }
        public abstract double f(double x, double y);
        public abstract double M1(double y);
        public abstract double M2(double y);
        public abstract double M3(double x);
        public abstract double M4(double x);

        protected void InitBorderValueRectangle()
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

        protected void InitBorderValueRectangleWithHole()
        {
            for (int j = m / 4; j < 3 * m / 4; j++)
            {
                v[n / 4, j] = u(a + (n / 4) * h, c + j * t);
                v[3 * n / 4, j] = u(a + (3 * n / 4) * h, c + j * t);
            }

            for (int i = n / 4; i < 3 * n / 4; i++)
            {
                v[i, m / 4] = u(a + i * h, c + (m / 4) * t);
                v[i, 3 * m / 4] = u(a + i * h, c + (3 * m / 4) * t);
            }

            for (int j = 0; j < m; j++)
            {
                v[0, j] = u(a, c + j * t);
                v[n, j] = u(b, c + j * t);
            }

            for (int i = 0; i < n; i++)
            {
                v[i, 0] = u(a + i * h, c);
                v[i, m] = u(a + i * h, d);
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

        protected void InitialApproximateRectangle()
        {
            if (initAprx == 1)
                InterpolationXInitialApproximate();
            else if (initAprx == 2)
                InterpolationYInitialApproximate();
            else if (initAprx == 3)
                ZeroInitialApproximate();
        }

        protected void InitialApproximateRectangleWithHole()
        {
            if (initAprx != 3)
            {
                if (initAprx == 1)
                    InterpolationXInitialApproximate();
                else if (initAprx == 2)
                    InterpolationYInitialApproximate();
                for (int i = n / 4; i < 3 * n / 4; i++)
                    for (int j = m / 4; j < 3 * m / 4; j++)
                        v[i, j] = 0.0;
            } else if (initAprx == 3)
            {
                ZeroInitialApproximate();
            }

          
        }

        private double CalculateOptimalValue(double h, double t)
        {
            //calculate optimal value for w in over relaxation method
            double arg1 = Math.PI * h / (2 * (b - a));
            double arg2 = Math.PI * t / (2 * (d - c));
            double a2 = h * h + t * t;
            double lambdaMin = 2 * t * t / (a2) * Math.Sin(arg1) * Math.Sin(arg1)
                + 2 * h * h / (a2) * Math.Sin(arg2) * Math.Sin(arg2);
            w = 2 / (1 + Math.Sqrt(lambdaMin * (2 - lambdaMin)));
            return w;
        }

        public void OverRelaxationMethod()
        {
            InitBorderValueRectangle();
            InitialApproximateRectangle();

            epsMax = 0.0;
            double epsCurr = 0.0;
            double h2 = -((double)n / (b - a)) * ((double)n / (b - a));
            double t2 = -((double)m / (d - c)) * ((double)m / (d - c));
            double a2 = -2 * (h2 + t2);
            countSteps = 0;
            bool stop = false;
            while (!stop)
            {
                epsMax = 0.0;
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < m; j++)
                    {
                        double oldValue = v[i, j];
                        double newValue = -w * (h2 * (v[i + 1, j] + v[i - 1, j]) +
                                                  t2 * (v[i, j + 1] + v[i, j - 1]));
                        newValue += (1 - w) * a2 * v[i, j] + w * f(a + i * h, c + j * t);
                        newValue /= a2;
                        epsCurr = Math.Abs(oldValue - newValue);
                        if (epsCurr > epsMax) epsMax = epsCurr;
                        v[i, j] = newValue;
                    }
                }
                countSteps++;
                if (epsMax < eps || countSteps >= nmax) stop = true;
            }
        }

        protected double CalculateParameter(double h, double t)
        {
            // function calculate parameters in minimum residual method
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

        public void MinimumResidualsMethod()
        {
            InitBorderValueRectangle();
            InitialApproximateRectangle();

            r = new double[n + 1, m + 1];
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

                        double newValue = v[i, j] - ts * r[i, j];

                        epsCurr = Math.Abs(oldValue - newValue);
                        if (epsCurr > epsMax) epsMax = epsCurr;
                        v[i, j] = newValue;
                    }
                }
                countSteps++;
                if (epsMax < eps || countSteps >= nmax) stop = true;
            }
        }

        private double CalculateAplhaS(ref double alphaSNum, ref double alphaSDen, ref double[,] hs)
        {
            // функция вычисляет значение параметра alphaS
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    alphaSNum += r[i, j] * hs[i, j];
                    alphaSDen += hs[i, j] * (hs[i, j] * a2 + h2 * (hs[i - 1, j] + hs[i + 1, j])
                        + t2 * (hs[i, j - 1] + hs[i, j + 1]));
                }
            }
            return -alphaSNum / alphaSDen;
        }

        private double CalculateBetaS(ref double[,] hs, ref double betaSNum, ref double betaSDen)
        {
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    betaSNum += (hs[i, j] * a2 + h2 * (hs[i - 1, j] + hs[i + 1, j])
                        + t2 * (hs[i, j - 1] + hs[i, j + 1])) * r[i, j];
                }
            }
            return betaSNum / betaSDen;
        }

        private bool CalculateV(ref double[,] hs, ref double alphaS)
        {
            double epsCurr = 0.0;
            // функция вычисляет значение вектора V на новом шаге
            for (int i = 1; i < n / 4; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    double oldVal = v[i, j];
                    v[i, j] += alphaS * hs[i, j];   // v(s)
                    epsCurr = Math.Abs(v[i, j] - oldVal);
                    if (epsCurr > epsMax)
                        epsMax = epsCurr;
                }
            }

            for (int i = n / 4; i < 3 * n / 4; i++)
            {
                for (int j = 1; j < m / 4; j++)
                {
                    double oldVal = v[i, j];
                    v[i, j] += alphaS * hs[i, j];   // v(s)
                    epsCurr = Math.Abs(v[i, j] - oldVal);
                    if (epsCurr > epsMax)
                        epsMax = epsCurr;
                }

                for (int j = 3 * m / 4; j < m; j++)
                {
                    double oldVal = v[i, j];
                    v[i, j] += alphaS * hs[i, j];   // v(s)
                    epsCurr = Math.Abs(v[i, j] - oldVal);
                    if (epsCurr > epsMax)
                        epsMax = epsCurr;
                }
            }

            for (int i = 3 * n / 4; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    double oldVal = v[i, j];
                    v[i, j] += alphaS * hs[i, j];   // v(s)
                    epsCurr = Math.Abs(v[i, j] - oldVal);
                    if (epsCurr > epsMax)
                        epsMax = epsCurr;
                }
            }
            if (epsMax < eps)
                return true;
            return false;
        }

        private void CalculateR()
        {
            // функция вычисляет вектор невязки на текущем шаге
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    r[i, j] = (v[i, j] * a2 + h2 * (v[i - 1, j] + v[i + 1, j]) +
                        t2 * (v[i, j - 1] + v[i, j + 1]) - f(a + i * h, c + j * t));
                }
            }
        }

        private void CalculateH(ref double[,] hs, ref double betaS)
        {
            // функция вычисляет значение вектора h на текущем шаге
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    hs[i, j] = -r[i, j] + hs[i, j] * betaS;
                }
            }
        }

        public void ConjugateGradientMethod()
        {
            InitBorderValueRectangle();
            InitialApproximateRectangle();

            r = new double[n + 1, m + 1];
            double[,] hs = new double[n + 1, m + 1];
            double betaSNum = 0.0, betaSDen = 0.0, betaS = 0.0;
            double alphaS = 0.0, alphaSNum = 0.0, alphaSDen = 0.0;

            CalculateR();
            CalculateH(ref hs, ref betaS);
            alphaS = CalculateAplhaS(ref alphaSNum, ref alphaSDen, ref hs);
            CalculateV(ref hs, ref alphaS);

            countSteps = 0;
            while (countSteps != nmax)
            {
                CalculateR();
                betaSNum = 0.0; betaSDen = alphaSDen;
                betaS = CalculateBetaS(ref hs, ref betaSNum, ref betaSDen);
                CalculateH(ref hs, ref betaS);
                alphaSNum = 0.0; alphaSDen = 0.0;
                alphaS = CalculateAplhaS(ref alphaSNum, ref alphaSDen, ref hs);
                if (CalculateV(ref hs, ref alphaS))
                    break;
                countSteps++;
            }
        }

        public void ConjugateGradientMethodRectangleWithHole()
        {
            InitBorderValueRectangleWithHole();
            InitialApproximateRectangleWithHole();

            r = new double[n + 1, m + 1];
            double[,] hs = new double[n + 1, m + 1];
            double betaSNum = 0.0, betaSDen = 0.0, betaS = 0.0;
            double alphaS = 0.0, alphaSNum = 0.0, alphaSDen = 0.0;

            CalculateR();
            CalculateH(ref hs, ref betaS);
            alphaS = CalculateAplhaS(ref alphaSNum, ref alphaSDen, ref hs);
            CalculateV(ref hs, ref alphaS);

            countSteps = 0;
            while (countSteps != nmax)
            {
                CalculateR();
                betaSNum = 0.0; betaSDen = alphaSDen;
                betaS = CalculateBetaS(ref hs, ref betaSNum, ref betaSDen);
                CalculateH(ref hs, ref betaS);
                alphaSNum = 0.0; alphaSDen = 0.0;
                alphaS = CalculateAplhaS(ref alphaSNum, ref alphaSDen, ref hs);
                if (CalculateV(ref hs, ref alphaS))
                    break;
                countSteps++;
            }
        }
    }

    class TestTask : DirichletTask
    {
        public TestTask(double _a, double _b, double _c, double _d,
                    int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w = -1.0)
                    : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx, _w)
        { }

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

    }

    class MainTask : DirichletTask
    {
        public MainTask(double _a, double _b, double _c, double _d,
                    int _n, int _m, double _eps, int _nmax, byte _initAprx, double _w = -1.0)
                    : base(_a, _b, _c, _d, _n, _m, _eps, _nmax, _initAprx, _w)
        {
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
