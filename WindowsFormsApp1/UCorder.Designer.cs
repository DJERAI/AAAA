
namespace WindowsFormsApp1
{
    partial class UCorder
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCorder));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(51, 410);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(231, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(48, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите клиента";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(52, 456);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(151, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(48, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите тариф";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(115, 505);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(151, 21);
            this.comboBox3.TabIndex = 4;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(111, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Выберите автомобиль";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(387, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Создать заказ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(51, 577);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(231, 21);
            this.comboBox4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(48, 555);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Выберите водителя";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(496, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Выберите начальный адрес";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(496, 507);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Выберите конечный адрес";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(15)))), ((int)(((byte)(55)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(947, 343);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.MediumOrchid;
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(15)))), ((int)(((byte)(55)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripTextBox1,
            this.toolStripSeparator2,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(950, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(736, 471);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 20);
            this.textBox1.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(732, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(219, 19);
            this.label7.TabIndex = 18;
            this.label7.Text = "Введите количество километров ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(499, 472);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(215, 20);
            this.textBox2.TabIndex = 19;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(500, 526);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(215, 20);
            this.textBox3.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.Color.Azure;
            this.dateTimePicker1.Location = new System.Drawing.Point(736, 527);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 20);
            this.dateTimePicker1.TabIndex = 21;
            this.dateTimePicker1.Value = new System.DateTime(2022, 2, 23, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(732, 507);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 22;
            this.label8.Text = "Выберите дату";
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(115, 532);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(151, 21);
            this.comboBox5.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(62, 507);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "Марка";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(52, 532);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 19);
            this.label10.TabIndex = 25;
            this.label10.Text = "Модель";
            // 
            // comboBox6
            // 
            this.comboBox6.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(245, 456);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(156, 21);
            this.comboBox6.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic);
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(256, 434);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 19);
            this.label11.TabIndex = 27;
            this.label11.Text = "Выберите диспетчера";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::WindowsFormsApp1.Properties.Resources.icons8_google_поиск_64;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Поиск по ID";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Удаление ";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // UCorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(15)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "UCorder";
            this.Size = new System.Drawing.Size(950, 610);
            this.Load += new System.EventHandler(this.UCorder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label11;
    }
}
