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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.is_diff = new System.Windows.Forms.RadioButton();
            this.is_u = new System.Windows.Forms.RadioButton();
            this.is_v = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_w = new System.Windows.Forms.Label();
            this.str_w = new System.Windows.Forms.TextBox();
            this.userValue = new System.Windows.Forms.RadioButton();
            this.optimalValue = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelXYTotalEps = new System.Windows.Forms.Label();
            this.labelEps = new System.Windows.Forms.Label();
            this.labelNIter = new System.Windows.Forms.Label();
            this.labelIJTotalEps = new System.Windows.Forms.Label();
            this.labelTotalEps = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.тестоваяЗадачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методВерхнейРелаксацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методМинимальныхНевязокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методСопряженногоГрадиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.основнаяЗадачаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.метоВерхнейРелаксацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методМинимальныхНевязокToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.убратьСправкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьV2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::OverRelaxation.Properties.Resources.ЛР1_ЗАДАЧА;
            this.pictureBox1.Location = new System.Drawing.Point(16, 46);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 252);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Число разбиений по X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 289);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Число разбиений по Y";
            // 
            // str_n
            // 
            this.str_n.Location = new System.Drawing.Point(199, 252);
            this.str_n.Margin = new System.Windows.Forms.Padding(4);
            this.str_n.Name = "str_n";
            this.str_n.Size = new System.Drawing.Size(105, 22);
            this.str_n.TabIndex = 3;
            this.str_n.Text = "10";
            // 
            // str_m
            // 
            this.str_m.Location = new System.Drawing.Point(199, 289);
            this.str_m.Margin = new System.Windows.Forms.Padding(4);
            this.str_m.Name = "str_m";
            this.str_m.Size = new System.Drawing.Size(105, 22);
            this.str_m.TabIndex = 4;
            this.str_m.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 326);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Точность метода";
            // 
            // str_eps
            // 
            this.str_eps.Location = new System.Drawing.Point(199, 326);
            this.str_eps.Margin = new System.Windows.Forms.Padding(4);
            this.str_eps.Name = "str_eps";
            this.str_eps.Size = new System.Drawing.Size(105, 22);
            this.str_eps.TabIndex = 6;
            this.str_eps.Text = "1e-008";
            // 
            // str_nmax
            // 
            this.str_nmax.Location = new System.Drawing.Point(199, 363);
            this.str_nmax.Margin = new System.Windows.Forms.Padding(4);
            this.str_nmax.Name = "str_nmax";
            this.str_nmax.Size = new System.Drawing.Size(105, 22);
            this.str_nmax.TabIndex = 7;
            this.str_nmax.Text = "100000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 363);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ограничение шагов";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.is_null_approx);
            this.groupBox1.Controls.Add(this.is_inter_y);
            this.groupBox1.Controls.Add(this.is_inter_x);
            this.groupBox1.Location = new System.Drawing.Point(19, 537);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(285, 113);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начальное приближение";
            // 
            // is_null_approx
            // 
            this.is_null_approx.AutoSize = true;
            this.is_null_approx.Location = new System.Drawing.Point(8, 80);
            this.is_null_approx.Margin = new System.Windows.Forms.Padding(4);
            this.is_null_approx.Name = "is_null_approx";
            this.is_null_approx.Size = new System.Drawing.Size(85, 21);
            this.is_null_approx.TabIndex = 12;
            this.is_null_approx.TabStop = true;
            this.is_null_approx.Text = "Нулевое";
            this.is_null_approx.UseVisualStyleBackColor = true;
            // 
            // is_inter_y
            // 
            this.is_inter_y.AutoSize = true;
            this.is_inter_y.Location = new System.Drawing.Point(8, 52);
            this.is_inter_y.Margin = new System.Windows.Forms.Padding(4);
            this.is_inter_y.Name = "is_inter_y";
            this.is_inter_y.Size = new System.Drawing.Size(159, 21);
            this.is_inter_y.TabIndex = 11;
            this.is_inter_y.TabStop = true;
            this.is_inter_y.Text = "Интерполяция по Y";
            this.is_inter_y.UseVisualStyleBackColor = true;
            // 
            // is_inter_x
            // 
            this.is_inter_x.AutoSize = true;
            this.is_inter_x.Location = new System.Drawing.Point(8, 23);
            this.is_inter_x.Margin = new System.Windows.Forms.Padding(4);
            this.is_inter_x.Name = "is_inter_x";
            this.is_inter_x.Size = new System.Drawing.Size(159, 21);
            this.is_inter_x.TabIndex = 10;
            this.is_inter_x.TabStop = true;
            this.is_inter_x.Text = "Интерполяция по X";
            this.is_inter_x.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.is_diff);
            this.groupBox2.Controls.Add(this.is_u);
            this.groupBox2.Controls.Add(this.is_v);
            this.groupBox2.Location = new System.Drawing.Point(16, 657);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(288, 126);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вывод в таблицу";
            // 
            // is_diff
            // 
            this.is_diff.AutoSize = true;
            this.is_diff.Location = new System.Drawing.Point(8, 80);
            this.is_diff.Margin = new System.Windows.Forms.Padding(4);
            this.is_diff.Name = "is_diff";
            this.is_diff.Size = new System.Drawing.Size(295, 38);
            this.is_diff.TabIndex = 16;
            this.is_diff.TabStop = true;
            this.is_diff.Text = "| u(x,y)  - v(x, y) | \r\n( | v2(x, y) - v(x,y) | для основной задачи)";
            this.is_diff.UseVisualStyleBackColor = true;
            // 
            // is_u
            // 
            this.is_u.AutoSize = true;
            this.is_u.Location = new System.Drawing.Point(8, 52);
            this.is_u.Margin = new System.Windows.Forms.Padding(4);
            this.is_u.Name = "is_u";
            this.is_u.Size = new System.Drawing.Size(269, 21);
            this.is_u.TabIndex = 15;
            this.is_u.TabStop = true;
            this.is_u.Text = "u(x,y) (v2(x, y) для основной задачи)";
            this.is_u.UseVisualStyleBackColor = true;
            // 
            // is_v
            // 
            this.is_v.AutoSize = true;
            this.is_v.Location = new System.Drawing.Point(8, 23);
            this.is_v.Margin = new System.Windows.Forms.Padding(4);
            this.is_v.Name = "is_v";
            this.is_v.Size = new System.Drawing.Size(63, 21);
            this.is_v.TabIndex = 14;
            this.is_v.TabStop = true;
            this.is_v.Text = "v(x,y)";
            this.is_v.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(312, 47);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1734, 868);
            this.dataGridView1.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_w);
            this.groupBox3.Controls.Add(this.str_w);
            this.groupBox3.Controls.Add(this.userValue);
            this.groupBox3.Controls.Add(this.optimalValue);
            this.groupBox3.Location = new System.Drawing.Point(16, 400);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(288, 129);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметр метода верхней релаксации";
            // 
            // label_w
            // 
            this.label_w.AutoSize = true;
            this.label_w.Location = new System.Drawing.Point(123, 98);
            this.label_w.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_w.Name = "label_w";
            this.label_w.Size = new System.Drawing.Size(33, 17);
            this.label_w.TabIndex = 16;
            this.label_w.Text = "w = ";
            // 
            // str_w
            // 
            this.str_w.Location = new System.Drawing.Point(167, 95);
            this.str_w.Margin = new System.Windows.Forms.Padding(4);
            this.str_w.Name = "str_w";
            this.str_w.Size = new System.Drawing.Size(132, 22);
            this.str_w.TabIndex = 2;
            // 
            // userValue
            // 
            this.userValue.AutoSize = true;
            this.userValue.Location = new System.Drawing.Point(9, 66);
            this.userValue.Margin = new System.Windows.Forms.Padding(4);
            this.userValue.Name = "userValue";
            this.userValue.Size = new System.Drawing.Size(261, 21);
            this.userValue.TabIndex = 1;
            this.userValue.TabStop = true;
            this.userValue.Text = "Использовать указанное значение";
            this.userValue.UseVisualStyleBackColor = true;
            // 
            // optimalValue
            // 
            this.optimalValue.AutoSize = true;
            this.optimalValue.Location = new System.Drawing.Point(9, 37);
            this.optimalValue.Margin = new System.Windows.Forms.Padding(4);
            this.optimalValue.Name = "optimalValue";
            this.optimalValue.Size = new System.Drawing.Size(279, 21);
            this.optimalValue.TabIndex = 0;
            this.optimalValue.TabStop = true;
            this.optimalValue.Text = "Использовать оптимальное значение";
            this.optimalValue.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelXYTotalEps);
            this.groupBox4.Controls.Add(this.labelEps);
            this.groupBox4.Controls.Add(this.labelNIter);
            this.groupBox4.Controls.Add(this.labelIJTotalEps);
            this.groupBox4.Controls.Add(this.labelTotalEps);
            this.groupBox4.Location = new System.Drawing.Point(327, 680);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(600, 208);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Результаты работы метода";
            // 
            // labelXYTotalEps
            // 
            this.labelXYTotalEps.AutoSize = true;
            this.labelXYTotalEps.Location = new System.Drawing.Point(312, 62);
            this.labelXYTotalEps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelXYTotalEps.Name = "labelXYTotalEps";
            this.labelXYTotalEps.Size = new System.Drawing.Size(114, 17);
            this.labelXYTotalEps.TabIndex = 4;
            this.labelXYTotalEps.Text = "с координатами";
            // 
            // labelEps
            // 
            this.labelEps.AutoSize = true;
            this.labelEps.Location = new System.Drawing.Point(8, 154);
            this.labelEps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEps.Name = "labelEps";
            this.labelEps.Size = new System.Drawing.Size(255, 17);
            this.labelEps.TabIndex = 3;
            this.labelEps.Text = "Достигнутая точность метода  eps = ";
            // 
            // labelNIter
            // 
            this.labelNIter.AutoSize = true;
            this.labelNIter.Location = new System.Drawing.Point(8, 130);
            this.labelNIter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNIter.Name = "labelNIter";
            this.labelNIter.Size = new System.Drawing.Size(198, 17);
            this.labelNIter.TabIndex = 2;
            this.labelNIter.Text = "Число итераций метода N = ";
            // 
            // labelIJTotalEps
            // 
            this.labelIJTotalEps.AutoSize = true;
            this.labelIJTotalEps.Location = new System.Drawing.Point(8, 62);
            this.labelIJTotalEps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIJTotalEps.Name = "labelIJTotalEps";
            this.labelIJTotalEps.Size = new System.Drawing.Size(196, 17);
            this.labelIJTotalEps.TabIndex = 1;
            this.labelIJTotalEps.Text = "которая достигается в узле ";
            // 
            // labelTotalEps
            // 
            this.labelTotalEps.AutoSize = true;
            this.labelTotalEps.Location = new System.Drawing.Point(8, 31);
            this.labelTotalEps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTotalEps.Name = "labelTotalEps";
            this.labelTotalEps.Size = new System.Drawing.Size(201, 17);
            this.labelTotalEps.TabIndex = 0;
            this.labelTotalEps.Text = "Задача решена с точностью ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестоваяЗадачаToolStripMenuItem,
            this.основнаяЗадачаToolStripMenuItem,
            this.тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem,
            this.убратьСправкуToolStripMenuItem,
            this.показатьVToolStripMenuItem,
            this.показатьV2ToolStripMenuItem,
            this.показатьEToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // тестоваяЗадачаToolStripMenuItem
            // 
            this.тестоваяЗадачаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.методВерхнейРелаксацииToolStripMenuItem,
            this.методМинимальныхНевязокToolStripMenuItem,
            this.методСопряженногоГрадиентаToolStripMenuItem});
            this.тестоваяЗадачаToolStripMenuItem.Name = "тестоваяЗадачаToolStripMenuItem";
            this.тестоваяЗадачаToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.тестоваяЗадачаToolStripMenuItem.Text = "Тестовая задача";
            // 
            // методВерхнейРелаксацииToolStripMenuItem
            // 
            this.методВерхнейРелаксацииToolStripMenuItem.Name = "методВерхнейРелаксацииToolStripMenuItem";
            this.методВерхнейРелаксацииToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.методВерхнейРелаксацииToolStripMenuItem.Text = "Метод верхней релаксации";
            this.методВерхнейРелаксацииToolStripMenuItem.Click += new System.EventHandler(this.МетодВерхнейРелаксацииToolStripMenuItem_Click);
            // 
            // методМинимальныхНевязокToolStripMenuItem
            // 
            this.методМинимальныхНевязокToolStripMenuItem.Name = "методМинимальныхНевязокToolStripMenuItem";
            this.методМинимальныхНевязокToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.методМинимальныхНевязокToolStripMenuItem.Text = "Метод минимальных невязок";
            this.методМинимальныхНевязокToolStripMenuItem.Click += new System.EventHandler(this.МетодМинимальныхНевязокToolStripMenuItem_Click);
            // 
            // методСопряженногоГрадиентаToolStripMenuItem
            // 
            this.методСопряженногоГрадиентаToolStripMenuItem.Name = "методСопряженногоГрадиентаToolStripMenuItem";
            this.методСопряженногоГрадиентаToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.методСопряженногоГрадиентаToolStripMenuItem.Text = "Метод сопряженного градиента";
            this.методСопряженногоГрадиентаToolStripMenuItem.Click += new System.EventHandler(this.МетодСопряженногоГрадиентаToolStripMenuItem_Click);
            // 
            // основнаяЗадачаToolStripMenuItem
            // 
            this.основнаяЗадачаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.метоВерхнейРелаксацииToolStripMenuItem,
            this.методМинимальныхНевязокToolStripMenuItem1});
            this.основнаяЗадачаToolStripMenuItem.Name = "основнаяЗадачаToolStripMenuItem";
            this.основнаяЗадачаToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.основнаяЗадачаToolStripMenuItem.Text = "Основная задача";
            // 
            // метоВерхнейРелаксацииToolStripMenuItem
            // 
            this.метоВерхнейРелаксацииToolStripMenuItem.Name = "метоВерхнейРелаксацииToolStripMenuItem";
            this.метоВерхнейРелаксацииToolStripMenuItem.Size = new System.Drawing.Size(300, 26);
            this.метоВерхнейРелаксацииToolStripMenuItem.Text = "Мето верхней релаксации";
            this.метоВерхнейРелаксацииToolStripMenuItem.Click += new System.EventHandler(this.МетоВерхнейРелаксацииToolStripMenuItem_Click);
            // 
            // методМинимальныхНевязокToolStripMenuItem1
            // 
            this.методМинимальныхНевязокToolStripMenuItem1.Name = "методМинимальныхНевязокToolStripMenuItem1";
            this.методМинимальныхНевязокToolStripMenuItem1.Size = new System.Drawing.Size(300, 26);
            this.методМинимальныхНевязокToolStripMenuItem1.Text = "Метод минимальных невязок";
            this.методМинимальныхНевязокToolStripMenuItem1.Click += new System.EventHandler(this.МетодМинимальныхНевязокToolStripMenuItem1_Click);
            // 
            // тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem
            // 
            this.тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem.Name = "тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem";
            this.тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem.Size = new System.Drawing.Size(349, 24);
            this.тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem.Text = "Тестовая задача на непрямоугольной области";
            this.тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem.Click += new System.EventHandler(this.ТестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem_Click);
            // 
            // убратьСправкуToolStripMenuItem
            // 
            this.убратьСправкуToolStripMenuItem.Name = "убратьСправкуToolStripMenuItem";
            this.убратьСправкуToolStripMenuItem.Size = new System.Drawing.Size(131, 24);
            this.убратьСправкуToolStripMenuItem.Text = "Убрать справку";
            this.убратьСправкуToolStripMenuItem.Click += new System.EventHandler(this.убратьСправкуToolStripMenuItem_Click);
            // 
            // показатьVToolStripMenuItem
            // 
            this.показатьVToolStripMenuItem.Name = "показатьVToolStripMenuItem";
            this.показатьVToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.показатьVToolStripMenuItem.Text = "Показать v";
            this.показатьVToolStripMenuItem.Click += new System.EventHandler(this.показатьVToolStripMenuItem_Click);
            // 
            // показатьV2ToolStripMenuItem
            // 
            this.показатьV2ToolStripMenuItem.Name = "показатьV2ToolStripMenuItem";
            this.показатьV2ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.показатьV2ToolStripMenuItem.Text = "Показать v2";
            this.показатьV2ToolStripMenuItem.Click += new System.EventHandler(this.показатьV2ToolStripMenuItem_Click);
            // 
            // показатьEToolStripMenuItem
            // 
            this.показатьEToolStripMenuItem.Name = "показатьEToolStripMenuItem";
            this.показатьEToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.показатьEToolStripMenuItem.Text = "Показать e";
            this.показатьEToolStripMenuItem.Click += new System.EventHandler(this.показатьEToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1924, 928);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton is_diff;
        private System.Windows.Forms.RadioButton is_u;
        private System.Windows.Forms.RadioButton is_v;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton userValue;
        private System.Windows.Forms.RadioButton optimalValue;
        private System.Windows.Forms.TextBox str_w;
        private System.Windows.Forms.Label label_w;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelIJTotalEps;
        private System.Windows.Forms.Label labelTotalEps;
        private System.Windows.Forms.Label labelEps;
        private System.Windows.Forms.Label labelNIter;
        private System.Windows.Forms.Label labelXYTotalEps;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem тестоваяЗадачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методВерхнейРелаксацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методМинимальныхНевязокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методСопряженногоГрадиентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem основнаяЗадачаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem метоВерхнейРелаксацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методМинимальныхНевязокToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem тестоваяЗадачаНаНепрямоугольнойОбластиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem убратьСправкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьV2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьEToolStripMenuItem;
    }
}

