using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace ImageProcessing
{
    abstract class Filters
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

    };

    class InvertFilter : Filters 
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                                               255 - sourceColor.G,
                                               255 - sourceColor.B);
            return resultColor;
        }
    };

    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int intensity = Convert.ToInt32(sourceColor.R * 0.299 + sourceColor.G * 0.587 + sourceColor.B * 0.114);
            intensity = Clamp(intensity, 0, 255);
            Color resultColor = Color.FromArgb(intensity,
                                               intensity,
                                               intensity);
            return resultColor;
        }
    }

    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            Color sourceColor = sourseImage.GetPixel(x, y);

            double k = 60.0;
            double intensity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;

            Color resultColor = Color.FromArgb(Clamp((int)(intensity + 2.0 * k), 0, 255),
                                                  Clamp((int)(intensity + k * 0.5), 0, 255),
                                                    Clamp((int)(intensity - 1.0 * k), 0, 255));
            return resultColor;
        }
    }

    class TransferFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            if (x + 50 > sourseImage.Width - 1)
                return Color.Transparent;
            else
            {
                Color resultColor = sourseImage.GetPixel(x + 50, y);
                return resultColor;
            }
        }
    }

    class TurnFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            int x0 = (int)(sourseImage.Width / 2), y0 = (int)(sourseImage.Height / 2);
            double w = Math.PI / 4.0;
            int xx = (int)((x - x0) * Math.Cos(w) - (y - y0) * Math.Sin(w) + x0);
            int yy = (int)((x - x0) * Math.Sin(w) + (y - y0) * Math.Cos(w) + y0);

            if ((xx < sourseImage.Width - 1) && (yy < sourseImage.Height - 1) && (xx > 0) && (yy > 0))
            {
                Color resultColor = sourseImage.GetPixel(xx, yy);
                return resultColor;
            }
            return Color.Transparent;
        }
    }

    class WavesFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            int xx = (int)(x + 20 * Math.Sin(2.0 * Math.PI * y / 60.0));
            int yy = y;

            if ((xx < sourseImage.Width - 1) && (yy < sourseImage.Height - 1) && (xx > 0) && (yy > 0))
            {
                Color resultColor = sourseImage.GetPixel(xx, yy);
                return resultColor;
            }
            return Color.Transparent;
        }
    }

    class GrayWorldFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            Color sourceColor = sourseImage.GetPixel(x, y);

            Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourseImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourseImage.Width, sourseImage.Height);

            double R = 0.0, G = 0.0, B = 0.0;
            double Avg = 0.0;

            Color temp;
            for (int i = 0; i < sourseImage.Width; i++)
                for (int j = 0; j < sourseImage.Height; j++)
                {
                    temp = sourseImage.GetPixel(i, j);
                    R += temp.R; G += temp.G; B += temp.B;
                }
            R = (double)R / (sourseImage.Width * sourseImage.Height);
            G = (double)G / (sourseImage.Width * sourseImage.Height);
            B = (double)B / (sourseImage.Width * sourseImage.Height);
            Avg = (R + G + B) / 3.0d;

            Color sourceColor, resultColor;

            for (int i = 0; i < sourseImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourseImage.Height; j++)
                {
                    sourceColor = sourseImage.GetPixel(i, j);
                    resultColor = Color.FromArgb(Clamp((int)(sourceColor.R * Avg / R), 0, 255),
                                                Clamp((int)(sourceColor.G * Avg / G), 0, 255),
                                                  Clamp((int)(sourceColor.B * Avg / B), 0, 255));

                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            return resultImage;
        }
    }

    class PerfectReflectorFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            Color sourceColor = sourseImage.GetPixel(x, y);

            Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }

        public override Bitmap processImage(Bitmap sourseImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourseImage.Width, sourseImage.Height);

            double Rm = 0.0, Gm = 0.0, Bm = 0.0;

            Color temp;
            for (int i = 0; i < sourseImage.Width; i++)
                for (int j = 0; j < sourseImage.Height; j++)
                {
                    temp = sourseImage.GetPixel(i, j);
                    if (temp.R > Rm)
                        Rm = temp.R;
                    if (temp.G > Gm)
                        Gm = temp.G;
                    if (temp.B > Bm)
                        Bm = temp.B;
                }

            Color sourceColor, resultColor;

            for (int i = 0; i < sourseImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourseImage.Height; j++)
                {
                    sourceColor = sourseImage.GetPixel(i, j);
                    resultColor = Color.FromArgb(Clamp((int)(sourceColor.R * 255 / Rm), 0, 255),
                                                    Clamp((int)(sourceColor.G * 255 / Gm), 0, 255),
                                                        Clamp((int)(sourceColor.B * 255 / Bm), 0, 255));

                    resultImage.SetPixel(i, j, resultColor);
                }
            }
            return resultImage;
        }
    }

    class MedianFilter : Filters
    {
        private
            int size;
        public MedianFilter(int size)
        {
            this.size = size;
        }
        public override Bitmap processImage(Bitmap sourseImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourseImage.Width, sourseImage.Height);
            int N = 3;
            int radius = (int)(N / 2);

            for (int i = radius; i < sourseImage.Width - radius; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = radius; j < sourseImage.Height - radius; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourseImage, i, j));
                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            Color sourceColor = sourseImage.GetPixel(x, y);
            int radius = (size / 2);
            int ind_median = size * size / 2;

            int[] local_R = new int[9];
            int[] local_G = new int[9];
            int[] local_B = new int[9];

            int k = 0;
            for (int i = x - radius; i <= x + radius; i++)
                for (int j = y - radius; j <= y + radius; j++)
                {
                    local_R[k] = sourseImage.GetPixel(i, j).R;
                    local_G[k] = sourseImage.GetPixel(i, j).G;
                    local_B[k] = sourseImage.GetPixel(i, j).B;
                    k++;
                }
            Array.Sort(local_R);
            Array.Sort(local_G);
            Array.Sort(local_B);


            Color resultColor = Color.FromArgb(local_R[ind_median], local_G[ind_median], local_B[ind_median]);
            return resultColor;
        }
    }

    class AutoLevels : Filters
    {
        private byte maxR = 0;
        private byte maxG = 0;
        private byte maxB = 0;

        private byte minR = 255;
        private byte minG = 255;
        private byte minB = 255;

        protected bool initflag;
        public AutoLevels()
        {
            initflag = false;
        }
        protected void InitMinMax(Bitmap sourceImage)
        {
            for (int i = 0; i < sourceImage.Width; i++)
            {
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    maxR = Math.Max(maxR, sourceColor.R);
                    maxG = Math.Max(maxG, sourceColor.G);
                    maxB = Math.Max(maxB, sourceColor.B);

                    minR = Math.Min(minR, sourceColor.R);
                    minG = Math.Min(minG, sourceColor.G);
                    minB = Math.Min(minB, sourceColor.B);
                }
            }
            initflag = true;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if (!initflag)
                InitMinMax(sourceImage);
            Color sourceColor = sourceImage.GetPixel(x, y);
            byte resR = (byte)((sourceColor.R - minR) * (255) / (maxR - minR));
            byte resG = (byte)((sourceColor.G - minG) * (255) / (maxG - minG));
            byte resB = (byte)((sourceColor.B - minB) * (255) / (maxB - minB));
            Color resultColor = Color.FromArgb(resR, resG, resB);
            return resultColor;
        }
    }

    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0.0f;
            float resultG = 0.0f;
            float resultB = 0.0f;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(Clamp((int)resultR, 0, 255),
                                  Clamp((int)resultG, 0, 255),
                                  Clamp((int)resultB, 0, 255));
        }
    }

    class Dilation : MatrixFilter
    {
        public Dilation(float[,] kernel)
        {
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            int max = 0;
            Color result = Color.FromArgb(0,0,0);
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    int intensity = Convert.ToInt32(neighborColor.R * 0.299 +
                                                    neighborColor.G * 0.587 +
                                                    neighborColor.B * 0.114);
                    intensity = Clamp(intensity, 0, 255);
                    if (kernel[k + radiusX, l + radiusY] != 0.0f && intensity > max)
                    {
                        max = intensity;
                        result = neighborColor;
                    }
                }
            }
            return result;
        }
    }

    class Erosion : MatrixFilter
    {
        public Erosion(float[,] kernel)
        {
            this.kernel = kernel;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            int min = 300;
            Color result = Color.FromArgb(0, 0, 0);
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    int intensity = Convert.ToInt32(neighborColor.R * 0.299 +
                                                    neighborColor.G * 0.587 +
                                                    neighborColor.B * 0.114);
                    intensity = Clamp(intensity, 0, 255);
                    if (kernel[k + radiusX, l + radiusY] != 0.0f && intensity < min)
                    {
                        min = intensity;
                        result = neighborColor;
                    }
                }
            }
            return result;
        }
    }

    class Opening : MatrixFilter
    {
        public Opening(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Dilation dil = new Dilation(kernel);
            Erosion eros = new Erosion(kernel);
            return dil.processImage(eros.processImage(sourceImage, worker), worker);
        }
    }

    class Closing : MatrixFilter
    {
        public Closing(float[,] kernel)
        {
            this.kernel = kernel;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Dilation dil = new Dilation(kernel);
            Erosion eros = new Erosion(kernel);
            return eros.processImage(dil.processImage(sourceImage, worker), worker);
        }
    }

    class TopHat : MatrixFilter
    {
        public TopHat(float[,] kernel)
        {
            this.kernel = kernel;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Opening clos = new Opening(kernel);
            Substraction subs = new Substraction(sourceImage);
            return subs.processImage(clos.processImage(sourceImage, worker), worker);
        }
    }

    class Substraction : Filters
    {
        Bitmap operandImage;
        public Substraction(Bitmap operand)
        {
            operandImage = operand;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color operandColor = operandImage.GetPixel(x, y);
            int resR = Clamp(operandColor.R - sourceColor.R, 0, 255);
            int resG = Clamp(operandColor.G - sourceColor.G, 0, 255);
            int resB = Clamp(operandColor.B - sourceColor.B, 0, 255);
            return Color.FromArgb(resR, resG, resB);
        }
    }

    class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }
            }
        }
    }

    class GaussianFilter : MatrixFilter
    {
        public GaussianFilter()
        {
            createGaussianKernel(3, 2);
        }

        public void createGaussianKernel(int radius, float sigma)
        {
            int size = 2 * radius + 1;
            kernel = new float[size, size];
            float norm = 0;
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp(-(i * i + j * j) / (2 * sigma * sigma)));
                    norm += kernel[i + radius, j + radius];
                }
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }
    }

    class SharpnessFilter : MatrixFilter
    {
        public SharpnessFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    if ((i == 1) && (j == 1))
                    {
                        kernel[i, j] = 9.0f;
                    }
                    else
                        kernel[i, j] = -1.0f;
                }
        }
    }

    class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            int sizeX = 9;
            int sizeY = 9;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    if (i == j)
                        kernel[i, j] = 1.0f / (float)(sizeY);
                    else
                        kernel[i, j] = 0.0f;
                }
        }
    }

    class SobelFilter : MatrixFilter
    {
        protected float[,] xkernel = null;
        protected float[,] ykernel = null;

        public SobelFilter()
        {
            int size = 3;
            xkernel = new float[size, size];
            xkernel[0, 0] = -1.0f; xkernel[0, 1] = 0.0f; xkernel[0, 2] = 1.0f;
            xkernel[1, 0] = -2.0f; xkernel[1, 1] = 0.0f; xkernel[1, 1] = 2.0f;
            xkernel[2, 0] = -1.0f; xkernel[2, 1] = 0.0f; xkernel[2, 2] = 1.0f;
            ykernel = new float[size, size];
            ykernel[0, 0] = -1.0f; ykernel[0, 1] = -2.0f; ykernel[0, 2] = -1.0f;
            ykernel[1, 0] = 0.0f; ykernel[1, 1] = 0.0f; ykernel[1, 1] = 0.0f;
            ykernel[2, 0] = 1.0f; ykernel[2, 1] = 2.0f; ykernel[2, 2] = 1.0f;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int xradiusX = xkernel.GetLength(0) / 2;
            int xradiusY = xkernel.GetLength(1) / 2;
            float xresultR = 0.0f;
            float xresultG = 0.0f;
            float xresultB = 0.0f;
            for (int l = -xradiusY; l <= xradiusY; l++)
            {
                for (int k = -xradiusX; k <= xradiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    xresultR += neighborColor.R * xkernel[k + xradiusX, l + xradiusY];
                    xresultG += neighborColor.G * xkernel[k + xradiusX, l + xradiusY];
                    xresultB += neighborColor.B * xkernel[k + xradiusX, l + xradiusY];
                }
            }

            int yradiusX = ykernel.GetLength(0) / 2;
            int yradiusY = ykernel.GetLength(1) / 2;
            float yresultR = 0.0f;
            float yresultG = 0.0f;
            float yresultB = 0.0f;
            for (int l = -yradiusY; l <= yradiusY; l++)
            {
                for (int k = -yradiusX; k <= yradiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    yresultR += neighborColor.R * ykernel[k + yradiusX, l + yradiusY];
                    yresultG += neighborColor.G * ykernel[k + yradiusX, l + yradiusY];
                    yresultB += neighborColor.B * ykernel[k + yradiusX, l + yradiusY];
                }
            }

            float result = xresultR * xresultR + xresultG * xresultG + xresultB * xresultB;
            result += yresultR * yresultR + yresultG * yresultG + yresultB * yresultB;
            result = (float)Math.Sqrt(result);

            return Color.FromArgb(Clamp((int)result, 0, 255),
                                  Clamp((int)result, 0, 255),
                                  Clamp((int)result, 0, 255));
        }
    }

}

