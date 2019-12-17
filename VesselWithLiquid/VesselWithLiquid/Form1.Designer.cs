namespace VesselWithLiquid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using ZedGraph;
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ssigma = new System.Windows.Forms.TextBox();
            this.su0 = new System.Windows.Forms.TextBox();
            this.salpha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sN = new System.Windows.Forms.TextBox();
            this.table_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.seps = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sxmax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.sb = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.graph = new ZedGraph.ZedGraphControl();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Вычислить ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "Справка";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(40, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "u0 =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(49, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "α =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(49, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "σ = ";
            // 
            // ssigma
            // 
            this.ssigma.Location = new System.Drawing.Point(82, 249);
            this.ssigma.Name = "ssigma";
            this.ssigma.Size = new System.Drawing.Size(100, 20);
            this.ssigma.TabIndex = 6;
            this.ssigma.Text = "0.5";
            // 
            // su0
            // 
            this.su0.Location = new System.Drawing.Point(82, 155);
            this.su0.Name = "su0";
            this.su0.Size = new System.Drawing.Size(100, 20);
            this.su0.TabIndex = 7;
            this.su0.Text = "1";
            // 
            // salpha
            // 
            this.salpha.Location = new System.Drawing.Point(82, 221);
            this.salpha.Name = "salpha";
            this.salpha.Size = new System.Drawing.Size(100, 20);
            this.salpha.TabIndex = 8;
            this.salpha.Text = "2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(49, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "h = ";
            // 
            // sh
            // 
            this.sh.Location = new System.Drawing.Point(82, 315);
            this.sh.Name = "sh";
            this.sh.Size = new System.Drawing.Size(100, 20);
            this.sh.TabIndex = 10;
            this.sh.Text = "0.01";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(46, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "N = ";
            // 
            // sN
            // 
            this.sN.Location = new System.Drawing.Point(82, 341);
            this.sN.Name = "sN";
            this.sN.Size = new System.Drawing.Size(100, 20);
            this.sN.TabIndex = 12;
            this.sN.Text = "1000";
            // 
            // table_button
            // 
            this.table_button.Location = new System.Drawing.Point(12, 12);
            this.table_button.Name = "table_button";
            this.table_button.Size = new System.Drawing.Size(130, 50);
            this.table_button.TabIndex = 13;
            this.table_button.Text = "Таблица";
            this.table_button.UseVisualStyleBackColor = true;
            this.table_button.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(49, 367);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "ε = ";
            // 
            // seps
            // 
            this.seps.Location = new System.Drawing.Point(82, 367);
            this.seps.Name = "seps";
            this.seps.Size = new System.Drawing.Size(100, 20);
            this.seps.TabIndex = 15;
            this.seps.Text = "0.0001";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(21, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "xmax = ";
            // 
            // sxmax
            // 
            this.sxmax.Location = new System.Drawing.Point(82, 393);
            this.sxmax.Name = "sxmax";
            this.sxmax.Size = new System.Drawing.Size(100, 20);
            this.sxmax.TabIndex = 17;
            this.sxmax.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(48, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "b = ";
            // 
            // sb
            // 
            this.sb.Location = new System.Drawing.Point(82, 419);
            this.sb.Name = "sb";
            this.sb.Size = new System.Drawing.Size(100, 20);
            this.sb.TabIndex = 19;
            this.sb.Text = "0.000001";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(148, 71);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 51);
            this.button4.TabIndex = 20;
            this.button4.Text = "Информация о проведенных вычислениях";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(462, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(163, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Постановка задачи:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(816, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(202, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Аналитическое решение:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::VesselWithLiquid.Properties.Resources.ТочноеРешениеФизЗад11;
            this.pictureBox2.Location = new System.Drawing.Point(820, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(330, 87);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VesselWithLiquid.Properties.Resources.ФизЗадача11;
            this.pictureBox1.Location = new System.Drawing.Point(466, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // graph
            // 
            this.graph.AutoScroll = true;
            this.graph.IsShowPointValues = false;
            this.graph.Location = new System.Drawing.Point(466, 292);
            this.graph.Name = "graph";
            this.graph.PointValueFormat = "G";
            this.graph.Size = new System.Drawing.Size(724, 364);
            this.graph.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(12, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Параметры системы:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(19, 292);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Параметры метода:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label13.Location = new System.Drawing.Point(12, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(163, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Начальное условие:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label14.Location = new System.Drawing.Point(463, 132);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(687, 140);
            this.label14.TabIndex = 27;
            this.label14.Text = resources.GetString("label14.Text");
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 51);
            this.button3.TabIndex = 28;
            this.button3.Text = "Анализ решения ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(284, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 53);
            this.button5.TabIndex = 29;
            this.button5.Text = "Очистить график";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 653);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.sb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sxmax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.seps);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.table_button);
            this.Controls.Add(this.sN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.sh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.salpha);
            this.Controls.Add(this.su0);
            this.Controls.Add(this.ssigma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.graph);
            this.Name = "Form1";
            this.Text = "Измение уровня жидкости в сосуде";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ssigma;
        private System.Windows.Forms.TextBox su0;
        private System.Windows.Forms.TextBox salpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sN;
        private System.Windows.Forms.Button table_button;
        private ZedGraph.ZedGraphControl graph;
        private Label label6;
        private TextBox seps;
        private Label label7;
        private TextBox sxmax;
        private Label label8;
        private TextBox sb;
        private Button button4;
        private Label label9;
        private Label label10;
        private PictureBox pictureBox2;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Button button3;
        private Button button5;
    }
}

