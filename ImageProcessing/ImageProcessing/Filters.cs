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
        public Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
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

