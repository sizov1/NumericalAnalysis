namespace OverRelaxation
{
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.str_n = new System.Windows.Forms.TextBox();
            this.str_m = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.str_eps = new System.Windows.Forms.TextBox();
            this.str_nmax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.is_null_approx = new System.Windows.Forms.RadioButton();
            this.is_inter_y = new System.Windows.Forms.RadioButton();
            this.is_inter_x = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.is_diff = new System.Windows.Forms.RadioButton();
            this.is_u = new System.Windows.Forms.RadioButton();
            this.is_v = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.str_w = new System.Windows.Forms.TextBox();
            this.userValue = new System.Windows.Forms.RadioButton();
            this.optimalValue = new System.Windows.Forms.RadioButton();
            this.label_error = new System.Windows.Forms.Label();
            this.label_eps = new System.Windows.Forms.Label();
            this.label_niter = new System.Windows.Forms.Label();
            this.label_w = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OverRelaxation.Properties.Resources.ЛР1_ЗАДАЧА;
            this.pictureBox1.Location = new System.Drawing.Point(18, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Число разбиений по X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Число разбиений по Y";
            // 
            // str_n
            // 
            this.str_n.Location = new System.Drawing.Point(155, 180);
            this.str_n.Name = "str_n";
            this.str_n.Size = new System.Drawing.Size(100, 20);
            this.str_n.TabIndex = 3;
            this.str_n.Text = "100";
            // 
            // str_m
            // 
            this.str_m.Location = new System.Drawing.Point(155, 210);
            this.str_m.Name = "str_m";
            this.str_m.Size = new System.Drawing.Size(100, 20);
            this.str_m.TabIndex = 4;
            this.str_m.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Точность метода";
            // 
            // str_eps
            // 
            this.str_eps.Location = new System.Drawing.Point(155, 240);
            this.str_eps.Name = "str_eps";
            this.str_eps.Size = new System.Drawing.Size(100, 20);
            this.str_eps.TabIndex = 6;
            this.str_eps.Text = "0.0000001";
            // 
            // str_nmax
            // 
            this.str_nmax.Location = new System.Drawing.Point(155, 270);
            this.str_nmax.Name = "str_nmax";
            this.str_nmax.Size = new System.Drawing.Size(100, 20);
            this.str_nmax.TabIndex = 7;
            this.str_nmax.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ограничение шагов";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.is_null_approx);
            this.groupBox1.Controls.Add(this.is_inter_y);
            this.groupBox1.Controls.Add(this.is_inter_x);
            this.groupBox1.Location = new System.Drawing.Point(20, 411);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 92);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начальное приближение";
            // 
            // is_null_approx
            // 
            this.is_null_approx.AutoSize = true;
            this.is_null_approx.Location = new System.Drawing.Point(6, 65);
            this.is_null_approx.Name = "is_null_approx";
            this.is_null_approx.Size = new System.Drawing.Size(68, 17);
            this.is_null_approx.TabIndex = 12;
            this.is_null_approx.TabStop = true;
            this.is_null_approx.Text = "Нулевое";
            this.is_null_approx.UseVisualStyleBackColor = true;
            // 
            // is_inter_y
            // 
            this.is_inter_y.AutoSize = true;
            this.is_inter_y.Location = new System.Drawing.Point(6, 42);
            this.is_inter_y.Name = "is_inter_y";
            this.is_inter_y.Size = new System.Drawing.Size(123, 17);
            this.is_inter_y.TabIndex = 11;
            this.is_inter_y.TabStop = true;
            this.is_inter_y.Text = "Интерполяция по Y";
            this.is_inter_y.UseVisualStyleBackColor = true;
            // 
            // is_inter_x
            // 
            this.is_inter_x.AutoSize = true;
            this.is_inter_x.Location = new System.Drawing.Point(6, 19);
            this.is_inter_x.Name = "is_inter_x";
            this.is_inter_x.Size = new System.Drawing.Size(123, 17);
            this.is_inter_x.TabIndex = 10;
            this.is_inter_x.TabStop = true;
            this.is_inter_x.Text = "Интерполяция по X";
            this.is_inter_x.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 617);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "Решить тестовую задачу";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(18, 658);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "Решить основную задачу";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.is_diff);
            this.groupBox2.Controls.Add(this.is_u);
            this.groupBox2.Controls.Add(this.is_v);
            this.groupBox2.Location = new System.Drawing.Point(18, 509);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 102);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вывод в таблицу";
            // 
            // is_diff
            // 
            this.is_diff.AutoSize = true;
            this.is_diff.Location = new System.Drawing.Point(6, 65);
            this.is_diff.Name = "is_diff";
            this.is_diff.Size = new System.Drawing.Size(222, 30);
            this.is_diff.TabIndex = 16;
            this.is_diff.TabStop = true;
            this.is_diff.Text = "| u(x,y)  - v(x, y) | \r\n( | v2(x, y) - v(x,y) | для основной задачи)";
            this.is_diff.UseVisualStyleBackColor = true;
            // 
            // is_u
            // 
            this.is_u.AutoSize = true;
            this.is_u.Location = new System.Drawing.Point(6, 42);
            this.is_u.Name = "is_u";
            this.is_u.Size = new System.Drawing.Size(203, 17);
            this.is_u.TabIndex = 15;
            this.is_u.TabStop = true;
            this.is_u.Text = "u(x,y) (v2(x, y) для основной задачи)";
            this.is_u.UseVisualStyleBackColor = true;
            // 
            // is_v
            // 
            this.is_v.AutoSize = true;
            this.is_v.Location = new System.Drawing.Point(6, 19);
            this.is_v.Name = "is_v";
            this.is_v.Size = new System.Drawing.Size(50, 17);
            this.is_v.TabIndex = 14;
            this.is_v.TabStop = true;
            this.is_v.Text = "v(x,y)";
            this.is_v.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(281, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(695, 598);
            this.dataGridView1.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.str_w);
            this.groupBox3.Controls.Add(this.userValue);
            this.groupBox3.Controls.Add(this.optimalValue);
            this.groupBox3.Location = new System.Drawing.Point(18, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 105);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметр метода верхней релаксации";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "w = ";
            // 
            // str_w
            // 
            this.str_w.Location = new System.Drawing.Point(125, 77);
            this.str_w.Name = "str_w";
            this.str_w.Size = new System.Drawing.Size(100, 20);
            this.str_w.TabIndex = 2;
            // 
            // userValue
            // 
            this.userValue.AutoSize = true;
            this.userValue.Location = new System.Drawing.Point(7, 54);
            this.userValue.Name = "userValue";
            this.userValue.Size = new System.Drawing.Size(204, 17);
            this.userValue.TabIndex = 1;
            this.userValue.TabStop = true;
            this.userValue.Text = "Использовать указанное значение";
            this.userValue.UseVisualStyleBackColor = true;
            // 
            // optimalValue
            // 
            this.optimalValue.AutoSize = true;
            this.optimalValue.Location = new System.Drawing.Point(7, 30);
            this.optimalValue.Name = "optimalValue";
            this.optimalValue.Size = new System.Drawing.Size(218, 17);
            this.optimalValue.TabIndex = 0;
            this.optimalValue.TabStop = true;
            this.optimalValue.Text = "Использовать оптимальное значение";
            this.optimalValue.UseVisualStyleBackColor = true;
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(281, 618);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(0, 13);
            this.label_error.TabIndex = 16;
            // 
            // label_eps
            // 
            this.label_eps.AutoSize = true;
            this.label_eps.Location = new System.Drawing.Point(281, 658);
            this.label_eps.Name = "label_eps";
            this.label_eps.Size = new System.Drawing.Size(0, 13);
            this.label_eps.TabIndex = 17;
            // 
            // label_niter
            // 
            this.label_niter.AutoSize = true;
            this.label_niter.Location = new System.Drawing.Point(669, 658);
            this.label_niter.Name = "label_niter";
            this.label_niter.Size = new System.Drawing.Size(0, 13);
            this.label_niter.TabIndex = 18;
            // 
            // label_w
            // 
            this.label_w.AutoSize = true;
            this.label_w.Location = new System.Drawing.Point(820, 628);
            this.label_w.Name = "label_w";
            this.label_w.Size = new System.Drawing.Size(0, 13);
            this.label_w.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(988, 698);
            this.Controls.Add(this.label_w);
            this.Controls.Add(this.label_niter);
            this.Controls.Add(this.label_eps);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.str_nmax);
            this.Controls.Add(this.str_eps);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.str_m);
            this.Controls.Add(this.str_n);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Решение задачи Дирихле для уравнения Пуассона";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox str_n;
        private System.Windows.Forms.TextBox str_m;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox str_eps;
        private System.Windows.Forms.TextBox str_nmax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton is_null_approx;
        private System.Windows.Forms.RadioButton is_inter_y;
        private System.Windows.Forms.RadioButton is_inter_x;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton is_diff;
        private System.Windows.Forms.RadioButton is_u;
        private System.Windows.Forms.RadioButton is_v;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton userValue;
        private System.Windows.Forms.RadioButton optimalValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox str_w;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label_eps;
        private System.Windows.Forms.Label label_niter;
        private System.Windows.Forms.Label label_w;
    }
}

