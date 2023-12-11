namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_filmadı = new System.Windows.Forms.TextBox();
            this.textBox_yili = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_tur = new System.Windows.Forms.TextBox();
            this.textBox_puan = new System.Windows.Forms.TextBox();
            this.textBox_yonetmen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(602, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1033, 735);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox_filmadı
            // 
            this.textBox_filmadı.Location = new System.Drawing.Point(112, 12);
            this.textBox_filmadı.Name = "textBox_filmadı";
            this.textBox_filmadı.Size = new System.Drawing.Size(261, 22);
            this.textBox_filmadı.TabIndex = 1;
            // 
            // textBox_yili
            // 
            this.textBox_yili.Location = new System.Drawing.Point(112, 47);
            this.textBox_yili.Name = "textBox_yili";
            this.textBox_yili.Size = new System.Drawing.Size(261, 22);
            this.textBox_yili.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Getir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Yıl";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tür";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Puan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Yönetmen";
            // 
            // textBox_tur
            // 
            this.textBox_tur.Location = new System.Drawing.Point(112, 79);
            this.textBox_tur.Name = "textBox_tur";
            this.textBox_tur.Size = new System.Drawing.Size(261, 22);
            this.textBox_tur.TabIndex = 9;
            // 
            // textBox_puan
            // 
            this.textBox_puan.Location = new System.Drawing.Point(112, 116);
            this.textBox_puan.Name = "textBox_puan";
            this.textBox_puan.Size = new System.Drawing.Size(261, 22);
            this.textBox_puan.TabIndex = 10;
            // 
            // textBox_yonetmen
            // 
            this.textBox_yonetmen.Location = new System.Drawing.Point(112, 154);
            this.textBox_yonetmen.Name = "textBox_yonetmen";
            this.textBox_yonetmen.Size = new System.Drawing.Size(261, 22);
            this.textBox_yonetmen.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1635, 735);
            this.Controls.Add(this.textBox_yonetmen);
            this.Controls.Add(this.textBox_puan);
            this.Controls.Add(this.textBox_tur);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_yili);
            this.Controls.Add(this.textBox_filmadı);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_filmadı;
        private System.Windows.Forms.TextBox textBox_yili;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_tur;
        private System.Windows.Forms.TextBox textBox_puan;
        private System.Windows.Forms.TextBox textBox_yonetmen;
    }
}

