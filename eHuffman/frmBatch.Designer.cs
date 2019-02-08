namespace eHuffman
{
    partial class frmBatch
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDosyaEkle = new System.Windows.Forms.Button();
            this.lbDosyaListesi = new System.Windows.Forms.ListBox();
            this.btnSikistirAc = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgSo = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgSure = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb3 = new System.Windows.Forms.CheckBox();
            this.cb2 = new System.Windows.Forms.CheckBox();
            this.cb1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbArtim = new System.Windows.Forms.TextBox();
            this.ofdDosyaAc = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSo)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSure)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDosyaEkle);
            this.groupBox1.Controls.Add(this.lbDosyaListesi);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 456);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dosya Listesi";
            // 
            // btnDosyaEkle
            // 
            this.btnDosyaEkle.Location = new System.Drawing.Point(6, 427);
            this.btnDosyaEkle.Name = "btnDosyaEkle";
            this.btnDosyaEkle.Size = new System.Drawing.Size(182, 23);
            this.btnDosyaEkle.TabIndex = 2;
            this.btnDosyaEkle.Text = "Dosya Ekle";
            this.btnDosyaEkle.UseVisualStyleBackColor = true;
            this.btnDosyaEkle.Click += new System.EventHandler(this.btnDosyaEkle_Click);
            // 
            // lbDosyaListesi
            // 
            this.lbDosyaListesi.FormattingEnabled = true;
            this.lbDosyaListesi.Location = new System.Drawing.Point(6, 19);
            this.lbDosyaListesi.Name = "lbDosyaListesi";
            this.lbDosyaListesi.Size = new System.Drawing.Size(182, 394);
            this.lbDosyaListesi.TabIndex = 1;
            // 
            // btnSikistirAc
            // 
            this.btnSikistirAc.Location = new System.Drawing.Point(314, 17);
            this.btnSikistirAc.Name = "btnSikistirAc";
            this.btnSikistirAc.Size = new System.Drawing.Size(154, 23);
            this.btnSikistirAc.TabIndex = 2;
            this.btnSikistirAc.Text = "Sıkıştır/Aç";
            this.btnSikistirAc.UseVisualStyleBackColor = true;
            this.btnSikistirAc.Click += new System.EventHandler(this.btnSikistirAc_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(212, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 402);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgSo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 376);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sıkıştırma Oranları";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgSo
            // 
            this.dgSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSo.Location = new System.Drawing.Point(6, 6);
            this.dgSo.Name = "dgSo";
            this.dgSo.Size = new System.Drawing.Size(604, 364);
            this.dgSo.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgSure);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 376);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Süreler";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgSure
            // 
            this.dgSure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSure.Location = new System.Drawing.Point(6, 6);
            this.dgSure.Name = "dgSure";
            this.dgSure.Size = new System.Drawing.Size(604, 364);
            this.dgSure.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSikistirAc);
            this.groupBox2.Controls.Add(this.cb3);
            this.groupBox2.Controls.Add(this.cb2);
            this.groupBox2.Controls.Add(this.cb1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbArtim);
            this.groupBox2.Location = new System.Drawing.Point(212, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 48);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametreler";
            // 
            // cb3
            // 
            this.cb3.AutoSize = true;
            this.cb3.Location = new System.Drawing.Point(250, 21);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(58, 17);
            this.cb3.TabIndex = 4;
            this.cb3.Text = "3-gram";
            this.cb3.UseVisualStyleBackColor = true;
            // 
            // cb2
            // 
            this.cb2.AutoSize = true;
            this.cb2.Location = new System.Drawing.Point(186, 21);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(58, 17);
            this.cb2.TabIndex = 4;
            this.cb2.Text = "2-gram";
            this.cb2.UseVisualStyleBackColor = true;
            // 
            // cb1
            // 
            this.cb1.AutoSize = true;
            this.cb1.Location = new System.Drawing.Point(122, 21);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(58, 17);
            this.cb1.TabIndex = 4;
            this.cb1.Text = "1-gram";
            this.cb1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Artım(%):";
            // 
            // tbArtim
            // 
            this.tbArtim.Location = new System.Drawing.Point(60, 19);
            this.tbArtim.Name = "tbArtim";
            this.tbArtim.Size = new System.Drawing.Size(56, 20);
            this.tbArtim.TabIndex = 2;
            this.tbArtim.Text = "10";
            this.tbArtim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ofdDosyaAc
            // 
            this.ofdDosyaAc.Multiselect = true;
            this.ofdDosyaAc.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDosyaAc_FileOk);
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 480);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "frmBatch";
            this.Text = "Toplu İşlem";
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSo)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSure)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbDosyaListesi;
        private System.Windows.Forms.Button btnSikistirAc;
        private System.Windows.Forms.Button btnDosyaEkle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgSo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgSure;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cb3;
        private System.Windows.Forms.CheckBox cb2;
        private System.Windows.Forms.CheckBox cb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbArtim;
        private System.Windows.Forms.OpenFileDialog ofdDosyaAc;
    }
}