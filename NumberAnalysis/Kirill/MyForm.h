#pragma once
#include <math.h>
#include <vector>

namespace Graph {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace ZedGraph;
	using namespace std;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: ZedGraph::ZedGraphControl^ zedGraphControl1;
	private: System::Windows::Forms::Button^ button1;
	private: System::Windows::Forms::DataGridView^ dataGridView1;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ X;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ F_1;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ F_2;
	private: System::Windows::Forms::TextBox^ textBox1;
	private: System::Windows::Forms::Button^ button2;
	private: System::Windows::Forms::TextBox^ textBox5;
	private: System::Windows::Forms::TabControl^ tabControl1;
	private: System::Windows::Forms::TabPage^ tabPage1;
	private: System::Windows::Forms::TabPage^ tabPage2;
	private: ZedGraph::ZedGraphControl^ zedGraphControl2;
	private: System::Windows::Forms::DataGridView^ dataGridView2;
	private: System::Windows::Forms::TextBox^ textBox2;
	private: System::Windows::Forms::Button^ button4;
	private: System::Windows::Forms::Button^ button3;
	private: System::Windows::Forms::PictureBox^ pictureBox1;
	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ dataGridViewTextBoxColumn1;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ dataGridViewTextBoxColumn2;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ dataGridViewTextBoxColumn3;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column1;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column2;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column3;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column5;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column6;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column7;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ Column8;
	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::TextBox^ textBox3;
	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::TextBox^ textBox4;

	private: System::Windows::Forms::Label^ label5;
	private: System::Windows::Forms::TextBox^ textBox6;
	private: System::Windows::Forms::RadioButton^ radioButton1;
	private: System::Windows::Forms::RadioButton^ radioButton2;
	private: System::Windows::Forms::TextBox^ textBox7;
	private: System::Windows::Forms::Label^ label4;



















	protected:
	private: System::ComponentModel::IContainer^ components;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->components = (gcnew System::ComponentModel::Container());
			System::ComponentModel::ComponentResourceManager^ resources = (gcnew System::ComponentModel::ComponentResourceManager(MyForm::typeid));
			this->zedGraphControl1 = (gcnew ZedGraph::ZedGraphControl());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->dataGridView1 = (gcnew System::Windows::Forms::DataGridView());
			this->X = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->F_1 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->F_2 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->textBox5 = (gcnew System::Windows::Forms::TextBox());
			this->tabControl1 = (gcnew System::Windows::Forms::TabControl());
			this->tabPage1 = (gcnew System::Windows::Forms::TabPage());
			this->tabPage2 = (gcnew System::Windows::Forms::TabPage());
			this->radioButton2 = (gcnew System::Windows::Forms::RadioButton());
			this->radioButton1 = (gcnew System::Windows::Forms::RadioButton());
			this->label5 = (gcnew System::Windows::Forms::Label());
			this->textBox6 = (gcnew System::Windows::Forms::TextBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->textBox4 = (gcnew System::Windows::Forms::TextBox());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->textBox3 = (gcnew System::Windows::Forms::TextBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->dataGridView2 = (gcnew System::Windows::Forms::DataGridView());
			this->dataGridViewTextBoxColumn1 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->dataGridViewTextBoxColumn2 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->dataGridViewTextBoxColumn3 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column1 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column2 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column3 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column5 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column6 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column7 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->Column8 = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->zedGraphControl2 = (gcnew ZedGraph::ZedGraphControl());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->textBox7 = (gcnew System::Windows::Forms::TextBox());
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->BeginInit();
			this->tabControl1->SuspendLayout();
			this->tabPage1->SuspendLayout();
			this->tabPage2->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView2))->BeginInit();
			this->SuspendLayout();
			// 
			// zedGraphControl1
			// 
			this->zedGraphControl1->Location = System::Drawing::Point(591, 277);
			this->zedGraphControl1->Name = L"zedGraphControl1";
			this->zedGraphControl1->ScrollGrace = 0;
			this->zedGraphControl1->ScrollMaxX = 0;
			this->zedGraphControl1->ScrollMaxY = 0;
			this->zedGraphControl1->ScrollMaxY2 = 0;
			this->zedGraphControl1->ScrollMinX = 0;
			this->zedGraphControl1->ScrollMinY = 0;
			this->zedGraphControl1->ScrollMinY2 = 0;
			this->zedGraphControl1->Size = System::Drawing::Size(798, 345);
			this->zedGraphControl1->TabIndex = 0;
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(181, 6);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(158, 29);
			this->button1->TabIndex = 1;
			this->button1->Text = L"Draw";
			this->button1->UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this->dataGridView1->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView1->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(3) {
				this->X, this->F_1,
					this->F_2
			});
			this->dataGridView1->Location = System::Drawing::Point(6, 277);
			this->dataGridView1->Name = L"dataGridView1";
			this->dataGridView1->RowHeadersVisible = false;
			this->dataGridView1->Size = System::Drawing::Size(363, 345);
			this->dataGridView1->TabIndex = 2;
			// 
			// X
			// 
			this->X->HeaderText = L"X";
			this->X->Name = L"X";
			this->X->ReadOnly = true;
			this->X->Width = 50;
			// 
			// F_1
			// 
			this->F_1->HeaderText = L"F_1";
			this->F_1->Name = L"F_1";
			this->F_1->ReadOnly = true;
			// 
			// F_2
			// 
			this->F_2->HeaderText = L"F_2";
			this->F_2->Name = L"F_2";
			this->F_2->ReadOnly = true;
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(431, 335);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(48, 20);
			this->textBox1->TabIndex = 4;
			this->textBox1->Text = L"0";
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(6, 6);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(156, 29);
			this->button2->TabIndex = 9;
			this->button2->Text = L"Zoom";
			this->button2->UseVisualStyleBackColor = true;
			// 
			// textBox5
			// 
			this->textBox5->Location = System::Drawing::Point(291, 392);
			this->textBox5->Name = L"textBox5";
			this->textBox5->Size = System::Drawing::Size(48, 20);
			this->textBox5->TabIndex = 11;
			this->textBox5->Text = L"0";
			// 
			// tabControl1
			// 
			this->tabControl1->Controls->Add(this->tabPage1);
			this->tabControl1->Controls->Add(this->tabPage2);
			this->tabControl1->Location = System::Drawing::Point(2, 1);
			this->tabControl1->Name = L"tabControl1";
			this->tabControl1->SelectedIndex = 0;
			this->tabControl1->Size = System::Drawing::Size(1477, 650);
			this->tabControl1->TabIndex = 15;
			// 
			// tabPage1
			// 
			this->tabPage1->Controls->Add(this->zedGraphControl1);
			this->tabPage1->Controls->Add(this->button2);
			this->tabPage1->Controls->Add(this->dataGridView1);
			this->tabPage1->Controls->Add(this->button1);
			this->tabPage1->Controls->Add(this->textBox1);
			this->tabPage1->Controls->Add(this->textBox5);
			this->tabPage1->Location = System::Drawing::Point(4, 22);
			this->tabPage1->Name = L"tabPage1";
			this->tabPage1->Padding = System::Windows::Forms::Padding(3);
			this->tabPage1->Size = System::Drawing::Size(1469, 624);
			this->tabPage1->TabIndex = 0;
			this->tabPage1->Text = L"Основная задача";
			this->tabPage1->UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this->tabPage2->BackColor = System::Drawing::Color::LightGray;
			this->tabPage2->Controls->Add(this->textBox7);
			this->tabPage2->Controls->Add(this->label4);
			this->tabPage2->Controls->Add(this->radioButton2);
			this->tabPage2->Controls->Add(this->radioButton1);
			this->tabPage2->Controls->Add(this->label5);
			this->tabPage2->Controls->Add(this->textBox6);
			this->tabPage2->Controls->Add(this->label2);
			this->tabPage2->Controls->Add(this->textBox4);
			this->tabPage2->Controls->Add(this->label3);
			this->tabPage2->Controls->Add(this->textBox3);
			this->tabPage2->Controls->Add(this->label1);
			this->tabPage2->Controls->Add(this->pictureBox1);
			this->tabPage2->Controls->Add(this->button4);
			this->tabPage2->Controls->Add(this->textBox2);
			this->tabPage2->Controls->Add(this->button3);
			this->tabPage2->Controls->Add(this->dataGridView2);
			this->tabPage2->Controls->Add(this->zedGraphControl2);
			this->tabPage2->Location = System::Drawing::Point(4, 22);
			this->tabPage2->Name = L"tabPage2";
			this->tabPage2->Padding = System::Windows::Forms::Padding(3);
			this->tabPage2->Size = System::Drawing::Size(1469, 624);
			this->tabPage2->TabIndex = 1;
			this->tabPage2->Text = L"Тестовая задача";
			// 
			// radioButton2
			// 
			this->radioButton2->AutoSize = true;
			this->radioButton2->Checked = true;
			this->radioButton2->Location = System::Drawing::Point(342, 55);
			this->radioButton2->Name = L"radioButton2";
			this->radioButton2->RightToLeft = System::Windows::Forms::RightToLeft::Yes;
			this->radioButton2->Size = System::Drawing::Size(166, 17);
			this->radioButton2->TabIndex = 26;
			this->radioButton2->TabStop = true;
			this->radioButton2->Text = L" Без контроля погрешности";
			this->radioButton2->UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this->radioButton1->AutoSize = true;
			this->radioButton1->Location = System::Drawing::Point(342, 76);
			this->radioButton1->Name = L"radioButton1";
			this->radioButton1->RightToLeft = System::Windows::Forms::RightToLeft::Yes;
			this->radioButton1->Size = System::Drawing::Size(159, 17);
			this->radioButton1->TabIndex = 25;
			this->radioButton1->Text = L"C контролем погрешности";
			this->radioButton1->UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this->label5->AutoSize = true;
			this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12));
			this->label5->Location = System::Drawing::Point(651, 131);
			this->label5->Name = L"label5";
			this->label5->Size = System::Drawing::Size(191, 20);
			this->label5->TabIndex = 24;
			this->label5->Text = L" Макс. число шагов: N = ";
			// 
			// textBox6
			// 
			this->textBox6->Location = System::Drawing::Point(848, 131);
			this->textBox6->Name = L"textBox6";
			this->textBox6->Size = System::Drawing::Size(67, 20);
			this->textBox6->TabIndex = 22;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12));
			this->label2->Location = System::Drawing::Point(543, 93);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(299, 20);
			this->label2->TabIndex = 20;
			this->label2->Text = L" Начальный шаг интегрирования: h  = ";
			// 
			// textBox4
			// 
			this->textBox4->Location = System::Drawing::Point(848, 93);
			this->textBox4->Name = L"textBox4";
			this->textBox4->Size = System::Drawing::Size(67, 20);
			this->textBox4->TabIndex = 19;
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12));
			this->label3->Location = System::Drawing::Point(646, 53);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(196, 20);
			this->label3->TabIndex = 18;
			this->label3->Text = L"Правая граница: xmax  = ";
			// 
			// textBox3
			// 
			this->textBox3->Location = System::Drawing::Point(848, 55);
			this->textBox3->Name = L"textBox3";
			this->textBox3->Size = System::Drawing::Size(67, 20);
			this->textBox3->TabIndex = 16;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12));
			this->label1->Location = System::Drawing::Point(636, 15);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(206, 20);
			this->label1->TabIndex = 15;
			this->label1->Text = L"Начальное условие: u0  = ";
			// 
			// pictureBox1
			// 
			this->pictureBox1->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox1.Image")));
			this->pictureBox1->Location = System::Drawing::Point(6, 55);
			this->pictureBox1->Name = L"pictureBox1";
			this->pictureBox1->Size = System::Drawing::Size(308, 97);
			this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
			this->pictureBox1->TabIndex = 14;
			this->pictureBox1->TabStop = false;
			// 
			// button4
			// 
			this->button4->Location = System::Drawing::Point(168, 6);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(146, 29);
			this->button4->TabIndex = 12;
			this->button4->Text = L"Draw";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &MyForm::Button4_Click);
			// 
			// textBox2
			// 
			this->textBox2->Location = System::Drawing::Point(848, 17);
			this->textBox2->Name = L"textBox2";
			this->textBox2->Size = System::Drawing::Size(67, 20);
			this->textBox2->TabIndex = 13;
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(6, 6);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(146, 29);
			this->button3->TabIndex = 12;
			this->button3->Text = L"Zoom";
			this->button3->UseVisualStyleBackColor = true;
			// 
			// dataGridView2
			// 
			this->dataGridView2->BackgroundColor = System::Drawing::SystemColors::Window;
			this->dataGridView2->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->dataGridView2->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(10) {
				this->dataGridViewTextBoxColumn1,
					this->dataGridViewTextBoxColumn2, this->dataGridViewTextBoxColumn3, this->Column1, this->Column2, this->Column3, this->Column5,
					this->Column6, this->Column7, this->Column8
			});
			this->dataGridView2->Location = System::Drawing::Point(6, 178);
			this->dataGridView2->Name = L"dataGridView2";
			this->dataGridView2->RowHeadersVisible = false;
			this->dataGridView2->Size = System::Drawing::Size(451, 440);
			this->dataGridView2->TabIndex = 12;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this->dataGridViewTextBoxColumn1->HeaderText = L"xi";
			this->dataGridViewTextBoxColumn1->Name = L"dataGridViewTextBoxColumn1";
			this->dataGridViewTextBoxColumn1->ReadOnly = true;
			this->dataGridViewTextBoxColumn1->Width = 50;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this->dataGridViewTextBoxColumn2->HeaderText = L"vi";
			this->dataGridViewTextBoxColumn2->Name = L"dataGridViewTextBoxColumn2";
			this->dataGridViewTextBoxColumn2->ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this->dataGridViewTextBoxColumn3->HeaderText = L"v2i";
			this->dataGridViewTextBoxColumn3->Name = L"dataGridViewTextBoxColumn3";
			this->dataGridViewTextBoxColumn3->ReadOnly = true;
			// 
			// Column1
			// 
			this->Column1->HeaderText = L"vi - v2i";
			this->Column1->Name = L"Column1";
			// 
			// Column2
			// 
			this->Column2->HeaderText = L"ОЛП";
			this->Column2->Name = L"Column2";
			// 
			// Column3
			// 
			this->Column3->HeaderText = L"hi";
			this->Column3->Name = L"Column3";
			// 
			// Column5
			// 
			this->Column5->HeaderText = L"C1";
			this->Column5->Name = L"Column5";
			// 
			// Column6
			// 
			this->Column6->HeaderText = L"C2";
			this->Column6->Name = L"Column6";
			// 
			// Column7
			// 
			this->Column7->HeaderText = L"ui";
			this->Column7->Name = L"Column7";
			// 
			// Column8
			// 
			this->Column8->HeaderText = L"|ui - vi|";
			this->Column8->Name = L"Column8";
			// 
			// zedGraphControl2
			// 
			this->zedGraphControl2->Location = System::Drawing::Point(513, 178);
			this->zedGraphControl2->Name = L"zedGraphControl2";
			this->zedGraphControl2->ScrollGrace = 0;
			this->zedGraphControl2->ScrollMaxX = 0;
			this->zedGraphControl2->ScrollMaxY = 0;
			this->zedGraphControl2->ScrollMaxY2 = 0;
			this->zedGraphControl2->ScrollMinX = 0;
			this->zedGraphControl2->ScrollMinY = 0;
			this->zedGraphControl2->ScrollMinY2 = 0;
			this->zedGraphControl2->Size = System::Drawing::Size(885, 440);
			this->zedGraphControl2->TabIndex = 12;
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12));
			this->label4->Location = System::Drawing::Point(971, 17);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(317, 20);
			this->label4->TabIndex = 27;
			this->label4->Text = L"Параметр контроля погрешности: eps = ";
			// 
			// textBox7
			// 
			this->textBox7->Location = System::Drawing::Point(1294, 17);
			this->textBox7->Name = L"textBox7";
			this->textBox7->Size = System::Drawing::Size(67, 20);
			this->textBox7->TabIndex = 28;
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(1480, 656);
			this->Controls->Add(this->tabControl1);
			this->Name = L"MyForm";
			this->Text = L"Решения ОДУ методом Рунгу-Кутта 4ого порядка";
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView1))->EndInit();
			this->tabControl1->ResumeLayout(false);
			this->tabPage1->ResumeLayout(false);
			this->tabPage1->PerformLayout();
			this->tabPage2->ResumeLayout(false);
			this->tabPage2->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->dataGridView2))->EndInit();
			this->ResumeLayout(false);

		}
#pragma endregion
	private:

		double f(double x, double u) {
			return (-5 * u) / 2;
		}

		double get_next_v(const double x_prev, const double v_prev, const double h) {
			const double k1 = f(x_prev, v_prev);
			const double k2 = f(x_prev + h / 2, v_prev + (h / 2) * k1);
			const double k3 = f(x_prev + h / 2, v_prev + (h / 2) * k2);
			const double k4 = f(x_prev + h, v_prev + h * k3);
			double v_next = v_prev + (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
			return v_next;
		}

		const double m = (-5.0) / 2.0;

		// функция расчета траектории с постоянным шагом 
		void CalcWithoutControlLTE(const double& E, const double& u0, const double& xmax, const double& h, const int& N) {
			GraphPane^ panel = zedGraphControl2->GraphPane;
			panel->CurveList->Clear();
			PointPairList^ f1_list = gcnew ZedGraph::PointPairList();
			PointPairList^ f2_list = gcnew ZedGraph::PointPairList();

			dataGridView2->Rows->Clear();
			// добавляем начальную точку на график
			f1_list->Add(0, u0);

			int i = 0;
			double v = u0;
			vector<vector<double>> table;

			for (double x = 0.0; (fabs(x - xmax) > E) && (i < N); x += h) {

				// вычисляем следующие значение численной траектории
				v = get_next_v(x, v, h); 

				// вычисляем значение численной траектории с помощью двойного счета с половинным шагом
				double v2 = get_next_v(x, v, h / 2);
				v2 = get_next_v(x + h / 2, v2, h / 2);

				// считаем ОЛП
				const double sp = static_cast<double>(2 << 3);
				double lte = ((v2 - v) / (sp - 1.0)) * sp;  

				 // вычисляем значение точного решения
				double u = u0 * exp( m * (x + h) ); 

				// добавляем точки точного и численного решения на график 
				f1_list->Add(x + h, v);
				f2_list->Add(x + h, u);

				vector<double> tablerow(10);
				tablerow[0] = x + h;
				tablerow[1] = v;
				tablerow[2] = v2;
				tablerow[3] = v - v2;
				tablerow[4] = lte;
				tablerow[5] = h;
				tablerow[6] = 0;
				tablerow[7] = 0;
				tablerow[8] = u;
				tablerow[9] = fabs(u - v);
				table.push_back(tablerow);

				i++;
			}

			// рисуем график численного решения
			LineItem Curve1 = panel->AddCurve("num", f1_list, Color::Red, SymbolType::None);
			// рисуем график точного решения 
			LineItem Curve2 = panel->AddCurve("exact", f2_list, Color::Blue, SymbolType::None);

			panel->XAxis->Scale->Min = 0;
			panel->XAxis->Scale->Max = xmax + 0.1;
			panel->YAxis->Scale->Min = -1;

			zedGraphControl2->AxisChange();
			zedGraphControl2->Invalidate();
		}

		// функция расчета траектории с половинным шагом 
		void CalcWithControlLTE(const double& E, const double& u0, const double& xmax, double h, const int& N) {
			PointPairList^ f1_list = gcnew ZedGraph::PointPairList();
			PointPairList^ f2_list = gcnew ZedGraph::PointPairList();

			vector<vector<double>> table;
			vector<double> tablerow(10);

			// добавляем начальную точку на график
			f1_list->Add(0.0f, u0);

			const double eps = Convert::ToDouble(textBox7->Text); // параметр контроля ЛП
			int C1 = 0, C2 = 0, i = 0;
			double v = u0, vprev = v;  // переменную vprev я создал для возможности повторить расчеты, в случае, когда S > eps

			for (double x = 0.0; (fabs(x - xmax) > E) && (i < N);) {

				// вычисляем значение численной траектории
				v = get_next_v(x, vprev, h);
				// вычисляем значение численной траектории с помощью двойного счета с половинным шагом
				double v2 = get_next_v(x, v, h / 2);
				v2 = get_next_v(x + h / 2, v2, h / 2);

				// считаем ОЛП
				const double SP = static_cast<double>(2 << 3);
				const double S = ((v2 - v) / (SP) - 1.0);
				const double aS = fabs(S);
				const double lte = S * SP;

				// принимаем решение об изменении шага и выборе точки
				if ((aS - eps) > E) {
					// ЛП большая относильно нашего eps => точка (x + h, v) не подходит
					// уменьшаем шаг интегрирования вдвое
					h = h / 2.0;
					C1++;
					// выполняем расчеты заново из точки (x, vprev)
					continue;
				}
				else if ((aS - eps) < E && (aS - ((eps) / (2 << 4))) > E) {
					// точка (x + h, v) подходит
					x += h;
					vprev = v;
				}
				else if ((aS - ((eps) / (2 << 4))) < E) {
					// точка (x + h, v) подходит, но шаг интегрирования можно увеличить вдвое
					x += h;
					vprev = v;
					h = h * 2.0;
					C2++;
				}

				// вычисляем значение точного решения 
				double u = u0 * exp(m * x);

				// добавляем точки численного и точного решения на график 
				f1_list->Add(x, v);
				f2_list->Add(x, u);

				tablerow[0] = x + h;  tablerow[1] = v;   tablerow[2] = v2;
				tablerow[3] = v - v2; tablerow[4] = lte; tablerow[5] = h;
				tablerow[6] = C1;	  tablerow[7] = C2;
				tablerow[8] = u;      tablerow[9] = fabs(u - v);

				table.push_back(tablerow);
				i++;
			}
		}

		void Draw(PointPairList^& f1_list, PointPairList^& f2_list, double xmax) {
			GraphPane^ panel = zedGraphControl2->GraphPane;
			panel->CurveList->Clear();
			// рисуем график численного решения
			LineItem Curve1 = panel->AddCurve("num", f1_list, Color::Red, SymbolType::None);
			// рисуем график точного решения 
			LineItem Curve2 = panel->AddCurve("exact", f2_list, Color::Blue, SymbolType::None);

			panel->XAxis->Scale->Min = 0;
			panel->XAxis->Scale->Max = xmax + 0.1;
			panel->YAxis->Scale->Min = -1;

			zedGraphControl2->AxisChange();
			zedGraphControl2->Invalidate();
		}

	private: System::Void Button4_Click(System::Object^ sender, System::EventArgs^ e) {

		const double E = 1e-20;
		double u0 = Convert::ToDouble(textBox2->Text);
		double xmax = Convert::ToDouble(textBox3->Text);
		double h = Convert::ToDouble(textBox4->Text);
		int N = Convert::ToInt32(textBox6->Text);

		// ЧТО БУДЕТ ЕСЛИ UMAX < U0 при H > 0???!

		if (radioButton1->Checked) {
			CalcWithControlLTE(E, u0, xmax, h, N);
		}
		else {
			CalcWithoutControlLTE(E, u0, xmax, h, N);
		}
	}

	};
	}