using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Spline
{
    abstract class Spline
    {
        public double[] a, b, c, d;
        public double x0, xn, h;
        protected int n;
        public Spline(int _n)
        { 
            n = _n;
        }

        public abstract double F(double x);
        public abstract double dF(double x);
        public abstract double d2F(double x);

        public double S(double x)
        {
            int k = 0;
            double xcurr = x0;
            while (x > xcurr)
            {
                k++;
                xcurr += h;
            }
            double xk = x0 + h * k;
            return a[k - 1] + b[k - 1] * (x - xk) + c[k - 1] * (x - xk) * (x - xk) +
                d[k - 1] * Math.Pow((x - xk), 3);
        }

        double B(int k) // return B[k], where B: Ax = B
        {
            return 3 * (F(x0 + h * k) + F(x0 + h * (k - 2))) / h;
        }

        void InitC()
        {
            List<double> alphai = new List<double>();
            List<double> betai = new List<double>();
            alphai.Add(-0.5); betai.Add(B(2) / (2 * h));
            for (int i = 1; i < n - 2; i++)
            {
                double Ai = h, Ci = -2 * h, Bi = h, Phii = -B(i + 3);
                alphai.Add(-Bi / (Ci + alphai[i - 1] * Ai));
                betai.Add((Phii - Ai * betai[i - 1]) / (Ci + alphai[i - 1] * Ai));
            }

            c = new double[n + 1];
            c[n] = 0.0;
            c[n - 1] = (B(n) - 0.5 * betai[n - 3]) / (1 + 0.5 * alphai[n - 3]);
            for (int i = n - 2; i > 0; i--)
            {
                c[i] = alphai[i - 1] * c[i + 1] + betai[i - 1];
            }
        }

        void InitD()
        {
            d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = (c[i + 1] - c[i]) / (3 * h);
            }
        }

        void InitB()
        {
            b = new double[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = (F(x0 + h * i) - F(x0 + h * (i - 1))) / h;
                b[i] += 2 * h * c[i + 1] / 3;
                b[i] += h * c[i] / 3;
            }
        }

        void InitA()
        {
            a = new double[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = F(x0 + h * i);
            }
        }

        public void ConsructSpline()
        {
            InitC();
            InitD();
            InitB();
            InitA();
        }
    }

    class Test : Spline
    { 
        public Test(int _n) : base(_n)
        {
            x0 = -1.0; xn = 1.0;
            h = Math.Abs(xn - x0) / (double)n;
        }

        public override double F(double x)
        {
            if (x < 0.0)
            {
                return x * x * x + 3 * x * x;
            } else
            {
                return -x * x * x + 3 * x * x;
            }
        }
        public override double dF(double x)
        {
            if (x < 0.0)
            {
                return 3 * x * x + 6 * x;
            }
            else
            {
                return -3 * x * x + 6 * x;
            }
        }
        public override double d2F(double x)
        {
            if (x < 0.0)
            {
                return 6 * x + 6;
            }
            else
            {
                return -6 * x + 6;
            }
        }
    }

}
 