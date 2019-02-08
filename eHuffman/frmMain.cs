using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eHuffman
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDosyaAc_Click(object sender, EventArgs e)
        {
            ofdDosya.ShowDialog();
        }

        private void ofdDosya_FileOk(object sender, CancelEventArgs e)
        {
            tbDosya.Text = ofdDosya.FileName;
        }

        private void btnSikistir_Click(object sender, EventArgs e)
        {
            //Dosya yolu, ngram değeri ve seçilen ngramların % kaçının kullanılacağı verisinin verilmesiyle sıkıştırma işleminin gerçekleştirilmesi
            sikistirAc sa = new sikistirAc();
            int yuzde = 0;
            if (tbDosya.Text != "")
                if (cmbNgram.SelectedIndex != -1)
                    if (tbYuzde.Text != "")
                        if (Int32.TryParse(tbYuzde.Text, out yuzde))
                            if (yuzde > 0 && yuzde <= 100)
                                sa.sikistir(tbDosya.Text, Int32.Parse(cmbNgram.SelectedItem.ToString()), Int32.Parse(tbYuzde.Text));
                            else
                                MessageBox.Show("Yüzde 0-100 arasında olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Yüzde kısmına sayı girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Saklanacak N-Gram yüzdesi girilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("N-gram Büyüklüğü seçilmelidir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Dosya Seçilmelidir", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            //Ehf dosyasının verilip açılmış dosyanın oluşturulması
            sikistirAc sa = new sikistirAc();
            if (tbDosya.Text != "")
                if (tbDosya.Text.Substring(tbDosya.Text.Length - 3, 3) == "ehf")
                    sa.ac(tbDosya.Text);
                else
                    MessageBox.Show("ehf Dosyası Açılabilir", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Dosya Seçilmelidir", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTopluIslem_Click(object sender, EventArgs e)
        {
            frmBatch fb = new frmBatch();
            fb.Show();
        }

        private void cmbNgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNgram.SelectedIndex == 0)
                tbYuzde.Enabled = false;
            else
                tbYuzde.Enabled = true;
        }
    }
}
