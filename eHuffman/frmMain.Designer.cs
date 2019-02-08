namespace eHuffman
{
    partial class frmMain
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
            this.ofdDosya = new System.Windows.Forms.OpenFileDialog();
            this.btnDosyaAc = new System.Windows.Forms.Button();
            this.tbYuzde = new System.Windows.Forms.TextBox();
            this.cmbNgram = new System.Windows.Forms.ComboBox();
            this.tbDosya = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDosyaAdi = new System.Windows.Forms.GroupBox();
            this.grpSecenekler = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpIslemler = new System.Windows.Forms.GroupBox();
            this.btnAc = new System.Windows.Forms.Button();
            this.btnSikistir = new System.Windows.Forms.Button();
            this.btnTopluIslem = new System.Windows.Forms.Button();
            this.grpDosyaAdi.SuspendLayout();
            this.grpSecenekler.SuspendLayout();
            this.grpIslemler.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdDosya
            // 
            this.ofdDosya.Filter = "Tüm Dosyalar|*.*|ehf Dosyası|*.ehf";
            this.ofdDosya.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdDosya_FileOk);
            // 
            // btnDosyaAc
            // 
            this.btnDosyaAc.Location = new System.Drawing.Point(310, 17);
            this.btnDosyaAc.Name = "btnDosyaAc";
            this.btnDosyaAc.Size = new System.Drawing.Size(75, 23);
            this.btnDosyaAc.TabIndex = 0;
            this.btnDosyaAc.Text = "Gözat...";
            this.btnDosyaAc.UseVisualStyleBackColor = true;
            this.btnDosyaAc.Click += new System.EventHandler(this.btnDosyaAc_Click);
            // 
            // tbYuzde
            // 
            this.tbYuzde.Location = new System.Drawing.Point(106, 32);
            this.tbYuzde.Name = "tbYuzde";
            this.tbYuzde.Size = new System.Drawing.Size(83, 20);
            this.tbYuzde.TabIndex = 1;
            this.tbYuzde.Text = "50";
            this.tbYuzde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbNgram
            // 
            this.cmbNgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNgram.FormattingEnabled = true;
            this.cmbNgram.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbNgram.Location = new System.Drawing.Point(9, 32);
            this.cmbNgram.Name = "cmbNgram";
            this.cmbNgram.Size = new System.Drawing.Size(91, 21);
            this.cmbNgram.TabIndex = 2;
            this.cmbNgram.SelectedIndexChanged += new System.EventHandler(this.cmbNgram_SelectedIndexChanged);
            // 
            // tbDosya
            // 
            this.tbDosya.Location = new System.Drawing.Point(6, 19);
            this.tbDosya.Name = "tbDosya";
            this.tbDosya.Size = new System.Drawing.Size(298, 20);
            this.tbDosya.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "N-gram Büyüklüğü";
            // 
            // grpDosyaAdi
            // 
            this.grpDosyaAdi.Controls.Add(this.tbDosya);
            this.grpDosyaAdi.Controls.Add(this.btnDosyaAc);
            this.grpDosyaAdi.Location = new System.Drawing.Point(12, 12);
            this.grpDosyaAdi.Name = "grpDosyaAdi";
            this.grpDosyaAdi.Size = new System.Drawing.Size(391, 46);
            this.grpDosyaAdi.TabIndex = 5;
            this.grpDosyaAdi.TabStop = false;
            this.grpDosyaAdi.Text = "Dosya Adı";
            // 
            // grpSecenekler
            // 
            this.grpSecenekler.Controls.Add(this.label2);
            this.grpSecenekler.Controls.Add(this.label1);
            this.grpSecenekler.Controls.Add(this.tbYuzde);
            this.grpSecenekler.Controls.Add(this.cmbNgram);
            this.grpSecenekler.Location = new System.Drawing.Point(12, 64);
            this.grpSecenekler.Name = "grpSecenekler";
            this.grpSecenekler.Size = new System.Drawing.Size(206, 66);
            this.grpSecenekler.TabIndex = 6;
            this.grpSecenekler.TabStop = false;
            this.grpSecenekler.Text = "Seçenekler";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "N-Gram Yüzdesi";
            // 
            // grpIslemler
            // 
            this.grpIslemler.Controls.Add(this.btnAc);
            this.grpIslemler.Controls.Add(this.btnSikistir);
            this.grpIslemler.Location = new System.Drawing.Point(224, 64);
            this.grpIslemler.Name = "grpIslemler";
            this.grpIslemler.Size = new System.Drawing.Size(179, 66);
            this.grpIslemler.TabIndex = 7;
            this.grpIslemler.TabStop = false;
            this.grpIslemler.Text = "İşlemler";
            // 
            // btnAc
            // 
            this.btnAc.Location = new System.Drawing.Point(96, 19);
            this.btnAc.Name = "btnAc";
            this.btnAc.Size = new System.Drawing.Size(77, 33);
            this.btnAc.TabIndex = 0;
            this.btnAc.Text = "Aç";
            this.btnAc.UseVisualStyleBackColor = true;
            this.btnAc.Click += new System.EventHandler(this.btnAc_Click);
            // 
            // btnSikistir
            // 
            this.btnSikistir.Location = new System.Drawing.Point(6, 19);
            this.btnSikistir.Name = "btnSikistir";
            this.btnSikistir.Size = new System.Drawing.Size(84, 33);
            this.btnSikistir.TabIndex = 0;
            this.btnSikistir.Text = "Sıkıştır";
            this.btnSikistir.UseVisualStyleBackColor = true;
            this.btnSikistir.Click += new System.EventHandler(this.btnSikistir_Click);
            // 
            // btnTopluIslem
            // 
            this.btnTopluIslem.Location = new System.Drawing.Point(12, 136);
            this.btnTopluIslem.Name = "btnTopluIslem";
            this.btnTopluIslem.Size = new System.Drawing.Size(391, 23);
            this.btnTopluIslem.TabIndex = 8;
            this.btnTopluIslem.Text = "Toplu İşlem";
            this.btnTopluIslem.UseVisualStyleBackColor = true;
            this.btnTopluIslem.Click += new System.EventHandler(this.btnTopluIslem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 165);
            this.Controls.Add(this.btnTopluIslem);
            this.Controls.Add(this.grpIslemler);
            this.Controls.Add(this.grpSecenekler);
            this.Controls.Add(this.grpDosyaAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eHuffman";
            this.grpDosyaAdi.ResumeLayout(false);
            this.grpDosyaAdi.PerformLayout();
            this.grpSecenekler.ResumeLayout(false);
            this.grpSecenekler.PerformLayout();
            this.grpIslemler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdDosya;
        private System.Windows.Forms.Button btnDosyaAc;
        private System.Windows.Forms.TextBox tbYuzde;
        private System.Windows.Forms.ComboBox cmbNgram;
        private System.Windows.Forms.TextBox tbDosya;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDosyaAdi;
        private System.Windows.Forms.GroupBox grpSecenekler;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpIslemler;
        private System.Windows.Forms.Button btnAc;
        private System.Windows.Forms.Button btnSikistir;
        private System.Windows.Forms.Button btnTopluIslem;
    }
}

