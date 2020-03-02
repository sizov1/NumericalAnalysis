using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap image;
        static public float[,] se = null;
        public Form1()
        {
            InitializeComponent();
            se = new float[3, 3];
            se[0, 0] = 0.0f; se[0, 1] = 1.0f; se[0, 2] = 0.0f;
            se[1, 0] = 1.0f; se[1, 1] = 1.0f; se[1, 2] = 1.0f;
            se[2, 0] = 0.0f; se[2, 1] = 1.0f; se[2, 2] = 0.0f;
        }

        private void ФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void ИнверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void HРToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ФильтрГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ВОттенкиСерогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ФильтрСобеляToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ЛинеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new AutoLevels();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void РасширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Dilation(se);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ЗадатьСтруктурныйЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BInputForm bif = new BInputForm();
            bif.Show();
        }

        private void СужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Erosion(se);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ОткрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Opening(se);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ЗакрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Closing(se);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void TopHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TopHat(se);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void СепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ПоворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TurnFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ПереносToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TransferFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ВолныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new WavesFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void СерыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorldFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ИдеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PerfectReflectorFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void МедианныйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter(3);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void РезкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void MotionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
